using Ajin_IO_driver;
using System;
using System.Data.OleDb;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace ReflowCoolingSystem.Squence
{
    struct TPrcsRecipe
    {
        public int TotalStep;           // Process total step
        public int StepNum;             // Process step number

        public string[] StepName;       // Process step name                
        public double[] Zone1Psi;
        public double[] Zone2Psi;
        public double[] Zone3Psi;
    }

    class Cooling : TBaseThread
    {
        Thread thread;

        private new TStep step;
        TPrcsRecipe prcsRecipe; // Recipe struct

        public Cooling()
        {
            ModuleName = "PM1";
            module = (byte)MODULE._PM1;

            thread = new Thread(new ThreadStart(Execute));

            prcsRecipe = new TPrcsRecipe();            

            prcsRecipe.StepName = new string[Define.RECIPE_MAX_STEP];   // Max 50step            
            prcsRecipe.Zone1Psi = new double[Define.RECIPE_MAX_STEP];
            prcsRecipe.Zone2Psi = new double[Define.RECIPE_MAX_STEP];
            prcsRecipe.Zone3Psi = new double[Define.RECIPE_MAX_STEP];

            thread.Start();
        }

        public void Dispose()
        {
            thread.Abort();
        }

        private void Execute()
        {
            try
            {
                while (true)
                {                    
                    Process_Progress();                    

                    Thread.Sleep(100);
                }
            }
            catch (Exception)
            {

            }
        }

        private void AlarmAction(string sAction)
        {
            if (sAction == "Abort")
            {
                F_PROCESS_ALL_ZEROSET();

                //Global.Towerlamp_Set((byte)Switch.On, (byte)Switch.Off, (byte)Switch.Off, (byte)Switch.Off, (byte)Switch.Off, (byte)Switch.Off);

                Define.seqMode[module] = Define.MODE_IDLE;
                Define.seqCtrl[module] = Define.CTRL_IDLE;
                Define.seqSts[module] = Define.STS_ABORTOK;                               

                Global.EventLog("Process has stopped : " + sAction, ModuleName, "Event");
            }
        }        

        // PROCESS PROGRESS /////////////////////////////////////////////////////////////////
        #region PROCESS_PROGRESS
        private void Process_Progress()
        {
            if ((Define.seqMode[module] == Define.MODE_PROCESS) && (Define.seqCtrl[module] == Define.CTRL_RUN))
            {
                Thread.Sleep(500);
                step.Layer = 1;
                step.Times = 1;
                step.Flag = true;

                prcsRecipe.TotalStep = 0;
                prcsRecipe.StepNum = 0;

                for (int i = 0; i < Define.RECIPE_MAX_STEP; i++)
                {
                    prcsRecipe.StepName[i] = string.Empty;                    
                    prcsRecipe.Zone1Psi[i] = 0.0;
                    prcsRecipe.Zone2Psi[i] = 0.0;
                    prcsRecipe.Zone3Psi[i] = 0.0;
                }
                                
                Define.seqCtrl[module] = Define.CTRL_RUNNING;
                Define.seqSts[module] = Define.STS_PROCESS_ING;

                Global.EventLog("Start the air blow setup", ModuleName, "Event");                
            }
            else if ((Define.seqMode[module] == Define.MODE_PROCESS) && (Define.seqCtrl[module] == Define.CTRL_RUNNING))
            {                
                switch (step.Layer)
                {
                    case 1:
                        {
                            P_PROCESS_DeviceLoading();
                        }
                        break;

                    case 2:
                        {
                            P_PROCESS_RecipeLoading(string.Format("{0}\\{1}", Global.RecipeFilePath, Define.sRunRecipeName));
                        }
                        break;
                                                                                
                    case 3:
                        {
                            P_PROCESS_IO_Setting();
                        }
                        break;
                    
                    case 4:
                        {
                            P_PROCESS_End();
                        }
                        break;
                }
            }
        }
        #endregion
        /////////////////////////////////////////////////////////////////////////////////////
        ///
        // FUNCTION /////////////////////////////////////////////////////////////////////////
        #region PROCESS FUNCTION
        private void P_PROCESS_DeviceLoading()
        {
            if (step.Flag)
            {
                Global.EventLog("Loading registered device", ModuleName, "Event");

                RecipeOfDevice_Read();

                step.Flag = false;
                step.Times = 1;
            }
            else
            {
                if (step.Times >= 3)
                {
                    step.Flag = true;
                    step.Layer++;
                }
                else
                {
                    step.INC_TIMES();
                }
            }
        }

        private void RecipeOfDevice_Read()
        {
            string connStr = Global.DeviceDataPath;
            using (OleDbConnection conn = new OleDbConnection(connStr))
            {
                conn.Open();

                try
                {
                    string sql = "SELECT * FROM Regist WHERE DeviceName = '" + Define.strDeviceName.ToString() + "' ";
                    OleDbCommand cmd = new OleDbCommand(sql, conn);

                    OleDbDataReader reader;
                    reader = cmd.ExecuteReader();

                    if (reader.Read())
                    {
                        Define.sRunRecipeName = reader.GetString(1).ToString();                        
                    }

                    reader.Close();
                }
                catch (OleDbException ex)
                {
                    Global.EventLog(ex.Message, ModuleName, "Event");

                    AlarmAction("Abort");
                }
                finally
                {
                    conn.Close();
                }
            }
        }

        private void P_PROCESS_RecipeLoading(string FileName)
        {
            if (step.Flag)
            {
                Global.EventLog("Loading process recipe file", ModuleName, "Event");

                step.Flag = false;
                step.Times = 1;
            }
            else
            {
                if (File.Exists(FileName))
                {
                    ImportExcelData_Read(FileName);

                    prcsRecipe.StepNum = 1; // Recipe 현재 스탭 초기화

                    Global.EventLog(string.Format("Recipe file was successfully read : {0}", Define.sRunRecipeName), ModuleName, "Event");                                        

                    step.Flag = true;                    
                    step.Layer++;                    
                }
                else
                {                    
                    Global.EventLog("Failed to read recipe file", ModuleName, "Event");

                    AlarmAction("Abort");
                }
            }
        }

        private void ImportExcelData_Read(string fileName)
        {
            uint lineNum = 0;   // Recipe 파일의 item line 총 갯수

            try
            {
                StreamReader sr = new StreamReader(fileName);
                while (!sr.EndOfStream)
                {
                    if (lineNum == 0)
                    {
                        string line = sr.ReadLine();
                        string[] data = line.Split(',');

                        int iDataCnt = data.Length - 1;
                        prcsRecipe.TotalStep = iDataCnt;    // Process total step count

                        lineNum++;
                    }
                    else if (lineNum == 1)
                    {
                        string line = sr.ReadLine();
                        string[] data = line.Split(',');

                        for (int i = 0; i < prcsRecipe.TotalStep; i++)
                        {
                            prcsRecipe.StepName[i] = data[i + 1];   // Process step name
                        }

                        lineNum++;
                    }
                    else if (lineNum == 2)
                    {
                        string line = sr.ReadLine();
                        string[] data = line.Split(',');

                        for (int i = 0; i < prcsRecipe.TotalStep; i++)
                        {
                            prcsRecipe.Zone1Psi[i] = double.Parse(data[i + 1]); // Zone1
                        }

                        lineNum++;
                    }
                    else if (lineNum == 3)
                    {
                        string line = sr.ReadLine();
                        string[] data = line.Split(',');

                        for (int i = 0; i < prcsRecipe.TotalStep; i++)
                        {
                            prcsRecipe.Zone2Psi[i] = double.Parse(data[i + 1]); // Zone2
                        }

                        lineNum++;
                    }
                    else if (lineNum == 4)
                    {
                        string line = sr.ReadLine();
                        string[] data = line.Split(',');

                        for (int i = 0; i < prcsRecipe.TotalStep; i++)
                        {
                            prcsRecipe.Zone3Psi[i] = double.Parse(data[i + 1]); // Zone3
                        }

                        sr.Close();
                        break;
                    }                    
                }
            }
            catch (Exception ex)
            {
                Global.EventLog(ex.Message, ModuleName, "Event");

                AlarmAction("Abort");
            }
        }

        private void P_PROCESS_IO_Setting()
        {
            try
            {
                // Zone1
                if (prcsRecipe.Zone1Psi[prcsRecipe.StepNum - 1] != 0)
                {
                    AIOClass.WriteVoltage(0, prcsRecipe.Zone1Psi[prcsRecipe.StepNum - 1] / 7.0);
                    Define.dCH1PsiSetValue = prcsRecipe.Zone1Psi[prcsRecipe.StepNum - 1];
                }
                else
                {
                    AIOClass.WriteVoltage(0, 0);
                    Define.dCH1PsiSetValue = 0.0;
                }

                // Zone2
                if (prcsRecipe.Zone2Psi[prcsRecipe.StepNum - 1] != 0)
                {
                    AIOClass.WriteVoltage(1, prcsRecipe.Zone2Psi[prcsRecipe.StepNum - 1] / 7.0);
                    Define.dCH2PsiSetValue = prcsRecipe.Zone2Psi[prcsRecipe.StepNum - 1];
                }
                else
                {
                    AIOClass.WriteVoltage(1, 0);
                    Define.dCH2PsiSetValue = 0.0;
                }

                // Zone3
                if (prcsRecipe.Zone3Psi[prcsRecipe.StepNum - 1] != 0)
                {
                    AIOClass.WriteVoltage(2, prcsRecipe.Zone3Psi[prcsRecipe.StepNum - 1] / 7.0);
                    Define.dCH3PsiSetValue = prcsRecipe.Zone3Psi[prcsRecipe.StepNum - 1];
                }
                else
                {
                    AIOClass.WriteVoltage(2, 0);
                    Define.dCH3PsiSetValue = 0.0;
                }
            }
            catch (Exception ex)
            {
                Global.EventLog(ex.Message, ModuleName, "Event");

                AlarmAction("Abort");
            }            
        }

        private void P_PROCESS_End()
        {
            //Global.Towerlamp_Set((byte)Switch.Off, (byte)Switch.Off, (byte)Switch.On, (byte)Switch.Off, (byte)Switch.Off, (byte)Switch.Off);

            Define.seqMode[module] = Define.MODE_IDLE;
            Define.seqCtrl[module] = Define.CTRL_IDLE;
            Define.seqSts[module] = Define.STS_PROCESS_END;
            
            Global.EventLog("Complete air blow setup", ModuleName, "Event");            
        }

        private void F_PROCESS_ALL_ZEROSET()
        {
            AIOClass.WriteVoltage(0, 0);
            AIOClass.WriteVoltage(1, 0);
            AIOClass.WriteVoltage(2, 0);

            Define.dCH1PsiSetValue = 0.0;
            Define.dCH2PsiSetValue = 0.0;
            Define.dCH3PsiSetValue = 0.0;
        }
        #endregion
        /////////////////////////////////////////////////////////////////////////////////////
    }
}
