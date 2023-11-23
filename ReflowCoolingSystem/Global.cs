using Ajin_IO_driver;
using System;
using System.Drawing;
using System.IO;
using System.Net;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Timers;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ProgressBar;
using Timer = System.Timers.Timer;

namespace ReflowCoolingSystem
{
    public struct TStep
    {
        public bool Flag;
        public byte Layer;
        public double Times;

        public void INC_TIMES()
        {
            Times++;
            Thread.Sleep(900);
        }        
    }

    public class TBaseThread
    {
        public byte module;
        public string ModuleName;

        public TStep step;
    }    

    class Global
    {
        public static string userdataPath = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + Path.GetFullPath(Path.Combine(AppContext.BaseDirectory, @"..\..\UserData.accdb"));
        public static string DeviceDataPath = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + Path.GetFullPath(Path.Combine(AppContext.BaseDirectory, @"..\..\DeviceRegist.accdb"));
        public static string logfilePath = Path.GetFullPath(Path.Combine(AppContext.BaseDirectory, @"..\..\EventLog\"));
        public static string RecipeFilePath = Path.GetFullPath(Path.Combine(AppContext.BaseDirectory, @"..\..\Recipes"));
        public static string ConfigurePath = Path.GetFullPath(Path.Combine(AppContext.BaseDirectory, @"..\..\Configure\"));
        public static string serialPortInfoPath = Path.GetFullPath(Path.Combine(AppContext.BaseDirectory, @"..\..\"));

        private static InterlockDisplayForm interlockDisplayForm;

        private static Timer interlock_timer = new Timer();
        static int nWebCallCnt = 1;
        static int nAirFlowCnt1 = 1;
        static int nAirFlowCnt2 = 1;
        static int nAirFlowCnt3 = 1;

        [DllImport("kernel32")]
        private static extern long WritePrivateProfileString(string section, string key, string val, string filePath);

        [DllImport("kernel32")]
        private static extern int GetPrivateProfileString(string section, string key, string def, StringBuilder retVal, int size, string filePath);

        [DllImport("QUvc_dll.dll")]
        public static extern unsafe bool Usb_Qu_write(byte Q_index, byte Q_type, byte[] pQ_data);
        [DllImport("QUvc_dll.dll")]
        public static extern void Usb_Qu_Open();
        [DllImport("QUvc_dll.dll")]
        public static extern void Usb_Qu_Close();
        [DllImport("QUvc_dll.dll")]
        public static extern int Usb_Qu_Getstate();


        #region 이벤트로그 파일 폴더 및 파일 생성       
        public static void EventLog(string Msg, string moduleName, string Mode)
        {
            string sYear = string.Format("{0:yyyy}", DateTime.Now).Trim();
            string sMonth = string.Format("{0:MM}", DateTime.Now).Trim();
            string sDay = string.Format("{0:dd}", DateTime.Now).Trim();            
            string sDate = string.Format("{0}-{1}-{2}", sYear, sMonth, sDay);
            string sTime = DateTime.Now.ToString("HH:mm:ss");
            string sDateTime;            
            sDateTime = string.Format("[{0}, {1}] ", sDate, sTime);
            
            WriteFile(string.Format("{0}{1}", sDateTime, Msg), moduleName, Mode);

            if (Mode == "Event")
            {
                if (moduleName == "PM1")
                {
                    Define.bPM1Event = true;
                }                               
            }
            else if (Mode == "Alarm")
            {
                if (moduleName == "PM1")
                {
                    //
                }                
            }            
        }

        private static void WriteFile(string Msg, string moduleName, string Mode)
        {            
            string sYear = string.Format("{0:yyyy}", DateTime.Now).Trim();
            string sMonth = string.Format("{0:MM}", DateTime.Now).Trim();
            string sDay = string.Format("{0:dd}", DateTime.Now).Trim();            
            string FileName = string.Format("{0}.txt", sDay);
            string sPath = string.Empty;
            if (Mode == "Event")
            {
                sPath = logfilePath;
            }                            

            try
            {                
                if (!Directory.Exists(string.Format("{0}{1}\\{2}", sPath, moduleName, sYear)))
                {
                    CreateYearFolder(string.Format("{0}{1}", sPath, moduleName));
                }
                
                if (!Directory.Exists(string.Format("{0}{1}\\{2}\\{3}", sPath, moduleName, sYear, sMonth)))
                {
                    CreateMonthFolder(string.Format("{0}{1}", sPath, moduleName));
                }
                
                if (File.Exists(string.Format("{0}{1}\\{2}\\{3}\\{4}", sPath, moduleName, sYear, sMonth, FileName)))
                {
                    StreamWriter writer;                    
                    writer = File.AppendText(string.Format("{0}{1}\\{2}\\{3}\\{4}", sPath, moduleName, sYear, sMonth, FileName));
                    writer.WriteLine(Msg);
                    writer.Close();
                }
                else
                {                    
                    CreateFile(string.Format("{0}{1}", sPath, moduleName), Msg);

                    StreamWriter writer;                    
                    writer = File.AppendText(string.Format("{0}{1}\\{2}\\{3}\\{4}", sPath, moduleName, sYear, sMonth, FileName));
                    writer.WriteLine(Msg);
                    writer.Close();
                }
            }
            catch (IOException)
            {
                
            }
        }

        private static void CreateYearFolder(string Path)
        {
            string sYear = string.Format("{0:yyyy}", DateTime.Now).Trim();
            string FolderName = sYear;
            
            Directory.CreateDirectory(string.Format("{0}\\{1}", Path, FolderName));
        }

        private static void CreateMonthFolder(string Path)
        {
            string sYear = string.Format("{0:yyyy}", DateTime.Now).Trim();
            string sMonth = string.Format("{0:MM}", DateTime.Now).Trim();
            string FolderName = sMonth;
            
            Directory.CreateDirectory(string.Format("{0}\\{1}\\{2}", Path, sYear, FolderName));
        }

        private static void CreateFile(string Path, string Msg)
        {            
            string sYear = string.Format("{0:yyyy}", DateTime.Now).Trim();
            string sMonth = string.Format("{0:MM}", DateTime.Now).Trim();
            string sDay = string.Format("{0:dd}", DateTime.Now).Trim();            
            string FileName = string.Format("{0}.txt", sDay);
            
            if (!File.Exists(string.Format("{0}\\{1}\\{2}\\{3}", Path, sYear, sMonth, FileName)))
            {
                using (File.Create(string.Format("{0}\\{1}\\{2}\\{3}", Path, sYear, sMonth, FileName))) ;
            }
        }
        #endregion        

        public static void Init()
        {
            interlock_timer.Interval = 1000;
            interlock_timer.Elapsed += new ElapsedEventHandler(VALUE_INTERLOCK_CHECK);
            interlock_timer.Start();
            
            try
            {
                // 장비 ASSET번호 불러오기
                EQ_INFO_LOAD();

                // IO보드 초기화
                AIOClass.OpenDevice();

                // USB Tower lamp init
                Usb_Qu_Open();

                F_ALL_EQUIP_PARAMETER_DATA_PARSING();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Notification");
            }            
        }

        private static void EQ_INFO_LOAD()
        {
            try
            {
                // File read
                StringBuilder sb_SBA_Asset = new StringBuilder();
                GetPrivateProfileString("SBA_ASSET", "No", "", sb_SBA_Asset, sb_SBA_Asset.Capacity, string.Format("{0}{1}", Global.ConfigurePath, "Configure.ini"));                
                Define.SBA_ASSET = sb_SBA_Asset.ToString().Trim();

                StringBuilder sb_SBA_Mnbr = new StringBuilder();
                GetPrivateProfileString("SBA_MNBR", "No", "", sb_SBA_Mnbr, sb_SBA_Mnbr.Capacity, string.Format("{0}{1}", Global.ConfigurePath, "Configure.ini"));
                Define.SBA_MNBR = sb_SBA_Mnbr.ToString().Trim();

                StringBuilder sb_REFLOW_Mnbr = new StringBuilder();
                GetPrivateProfileString("REFLOW_MNBR", "No", "", sb_REFLOW_Mnbr, sb_REFLOW_Mnbr.Capacity, string.Format("{0}{1}", Global.ConfigurePath, "Configure.ini"));
                Define.REFLOW_MNBR = sb_REFLOW_Mnbr.ToString().Trim();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Notification", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public static void Towerlamp_Set(byte Red, byte Yellow, byte Green, byte Blue, byte White, byte Sound)
        {
            try
            {
                byte[] bAcon = new byte[6];
                bAcon[0] = Red;
                bAcon[1] = Yellow;
                bAcon[2] = Green;
                bAcon[3] = Blue;
                bAcon[4] = White;
                bAcon[5] = Sound;

                Usb_Qu_write(0, 0, bAcon);
            }
            catch
            {

            }
        }

        #region 항시 체크 인터락
        private static void VALUE_INTERLOCK_CHECK(object sender, ElapsedEventArgs e)
        {
            // 장비(REFLOW) Process State 확인
            // Web service 호출 (3min)
            if (nWebCallCnt >= 180)
            {                
                F_ALL_EQUIP_PARAMETER_DATA_PARSING();

                nWebCallCnt = 1;
            }
            else
            {
                nWebCallCnt++;
            }       
            
            // Air blow tolerance check
            if (Define.dCH1PsiSetValue > 0)
            {
                double Tolerance = (Define.dCH1PsiSetValue / 100) * Configure_List.iAirBlowTolerance;
                //if (Math.Abs(Define.dCH1PsiSetValue - Define.dPsiActValue[0]) > Tolerance)
                if (Math.Abs(Define.dCH1PsiSetValue - Define.dCH1PsiSetValue) > Tolerance)
                {
                    if (nAirFlowCnt1 >= Configure_List.iAirFlowTimeOut)
                    {
                        if (Define.sInterlockMsg == string.Empty)
                        {
                            Define.sInterlockMsg = "Air flow is not constant!";
                            Define.sInterlockChecklist = "Check the pneumatic valve or sensor";
                            
                            DialogResult result = interlockDisplayForm.ShowDialog();
                            if (result == DialogResult.OK)
                            {
                                Define.sInterlockMsg = string.Empty;
                                Define.sInterlockChecklist = string.Empty;
                            }

                            if (!Define.bAlarm1)
                                Define.bAlarm1 = true;

                            Towerlamp_Set((byte)Switch.On, (byte)Switch.Off, (byte)Switch.Off, (byte)Switch.Off, (byte)Switch.Off, (byte)Switch.Buzzer);
                        }
                    }
                    else
                    {
                        nAirFlowCnt1++;
                    }
                }
                else
                {
                    if (nAirFlowCnt1 != 1)
                        nAirFlowCnt1 = 1;

                    if (Define.bAlarm1 != false)
                        Define.bAlarm1 = false;
                }                                          
            }

            if (Define.dCH2PsiSetValue > 0)
            {
                double Tolerance = (Define.dCH2PsiSetValue / 100) * Configure_List.iAirBlowTolerance;
                //if (Math.Abs(Define.dCH2PsiSetValue - Define.dPsiActValue[1]) > Tolerance)
                if (Math.Abs(Define.dCH2PsiSetValue - Define.dCH2PsiSetValue) > Tolerance)
                {
                    if (nAirFlowCnt2 >= Configure_List.iAirFlowTimeOut)
                    {
                        if (Define.sInterlockMsg == string.Empty)
                        {
                            Define.sInterlockMsg = "Air flow is not constant!";
                            Define.sInterlockChecklist = "Check the pneumatic valve or sensor";

                            DialogResult result = interlockDisplayForm.ShowDialog();
                            if (result == DialogResult.OK)
                            {
                                Define.sInterlockMsg = string.Empty;
                                Define.sInterlockChecklist = string.Empty;
                            }

                            if (!Define.bAlarm2)
                                Define.bAlarm2 = true;

                            Towerlamp_Set((byte)Switch.On, (byte)Switch.Off, (byte)Switch.Off, (byte)Switch.Off, (byte)Switch.Off, (byte)Switch.Buzzer);
                        }
                    }
                    else
                    {
                        nAirFlowCnt2++;
                    }
                }
                else
                {
                    if (nAirFlowCnt2 != 1)
                        nAirFlowCnt2 = 1;

                    if (Define.bAlarm2 != false)
                        Define.bAlarm2 = false;
                }
            }

            if (Define.dCH3PsiSetValue > 0)
            {
                double Tolerance = (Define.dCH3PsiSetValue / 100) * Configure_List.iAirBlowTolerance;
                //if (Math.Abs(Define.dCH3PsiSetValue - Define.dPsiActValue[2]) > Tolerance)
                if (Math.Abs(Define.dCH3PsiSetValue - Define.dCH3PsiSetValue) > Tolerance)
                {
                    if (nAirFlowCnt3 >= Configure_List.iAirFlowTimeOut)
                    {
                        if (Define.sInterlockMsg == string.Empty)
                        {
                            Define.sInterlockMsg = "Air flow is not constant!";
                            Define.sInterlockChecklist = "Check the pneumatic valve or sensor";

                            DialogResult result = interlockDisplayForm.ShowDialog();
                            if (result == DialogResult.OK)
                            {
                                Define.sInterlockMsg = string.Empty;
                                Define.sInterlockChecklist = string.Empty;
                            }

                            if (!Define.bAlarm3)
                                Define.bAlarm3 = true;

                            Towerlamp_Set((byte)Switch.On, (byte)Switch.Off, (byte)Switch.Off, (byte)Switch.Off, (byte)Switch.Off, (byte)Switch.Buzzer);
                        }
                    }
                    else
                    {
                        nAirFlowCnt3++;
                    }
                }
                else
                {
                    if (nAirFlowCnt3 != 1)
                        nAirFlowCnt3 = 1;

                    if (Define.bAlarm3 != false)
                        Define.bAlarm3 = false;
                }
            }
        }

        private static void F_ALL_EQUIP_PARAMETER_DATA_PARSING()
        {
            string strServerAllData = string.Empty;

            // Create a request for the URL.            
            WebRequest request = WebRequest.Create(
                "http://cim_service.amkor.co.kr:8080/ysj/conn/get_all_equip_parameter?MNBR=" + Define.REFLOW_MNBR + "&Language=1");

            // If required by the server, set the credentials.
            request.Credentials = CredentialCache.DefaultCredentials;

            // Get the response.
            WebResponse response = request.GetResponse();

            // Display the status.
            //Console.WriteLine(((HttpWebResponse)response).StatusDescription);

            // Get the stream containing content returned by the server.
            // The using block ensures the stream is automatically closed.
            using (Stream dataStream = response.GetResponseStream())
            {
                // Open the stream using a StreamReader for easy access.
                StreamReader reader = new StreamReader(dataStream);
                // Read the content.
                string responseFromServer = reader.ReadToEnd();
                // Display the content.
                strServerAllData = responseFromServer;
            }

            // Close the response.
            response.Close();

            string phrase = strServerAllData;
            string[] words = phrase.Split('\t');    // Tab으로 구분.

            foreach (var word in words)
            {
                string strParsingData = word;
                string[] words2 = strParsingData.Split('\b');    // bs로 구분.

                if (words2[0].Equals("Process State", StringComparison.OrdinalIgnoreCase))
                {
                    if (words2[1].Equals("Idle", StringComparison.OrdinalIgnoreCase))
                    {
                        Define.ReflowState = Define.REFLOW_IDLE;
                    }
                    else if (words2[1].Equals("Auto run", StringComparison.OrdinalIgnoreCase))
                    {
                        Define.ReflowState = Define.REFLOW_RUN;
                    }

                    break;
                }                
            }
        }
        #endregion
    }
}
