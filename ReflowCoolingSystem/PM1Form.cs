using Ajin_IO_driver;
using System;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using System.Windows.Forms;

namespace ReflowCoolingSystem
{
    public partial class PM1Form : UserControl
    {
        AnalogDlg AnaDlg;        

        [DllImport("kernel32")]
        private static extern long WritePrivateProfileString(string section, string key, string val, string filePath);

        [DllImport("kernel32")]
        private static extern int GetPrivateProfileString(string section, string key, string def, StringBuilder retVal, int size, string filePath);
        

        private MaintnanceForm m_Parent;               

        int module;
        string ModuleName;
        private Label[] m_valueBox;
        private Label[] m_CH1_1psiLevel;
        private Label[] m_CH1_2psiLevel;
        private Label[] m_CH2_1psiLevel;
        private Label[] m_CH2_2psiLevel;
        private Label[] m_CH3_1psiLevel;
        private Label[] m_CH3_2psiLevel;        

        int nCallCnt = 0;
        bool bIdleFlag = true;

        // e-SIM server data Parsing시, 사용 할 변수.
        string strServerAllData = "";
        string strParsingData = "";

        bool bRecipeReadFlag = false;

        public PM1Form(MaintnanceForm parent)
        {
            InitializeComponent();

            m_Parent = parent;            

            module = (int)MODULE._PM1;
            ModuleName = "PM1";

            m_valueBox = new Label[Define.OUT_CH_MAX - 1] { Label_ActualZone1Psi, Label_ActualZone2Psi, Label_ActualZone3Psi };

            m_CH1_1psiLevel = new Label[7] { label_CH1_1_10, label_CH1_1_20, label_CH1_1_30, label_CH1_1_40, label_CH1_1_50, label_CH1_1_60, label_CH1_1_70 };
            m_CH1_2psiLevel = new Label[7] { label_CH1_2_10, label_CH1_2_20, label_CH1_2_30, label_CH1_2_40, label_CH1_2_50, label_CH1_2_60, label_CH1_2_70 };
            m_CH2_1psiLevel = new Label[7] { label_CH2_1_10, label_CH2_1_20, label_CH2_1_30, label_CH2_1_40, label_CH2_1_50, label_CH2_1_60, label_CH2_1_70 };
            m_CH2_2psiLevel = new Label[7] { label_CH2_2_10, label_CH2_2_20, label_CH2_2_30, label_CH2_2_40, label_CH2_2_50, label_CH2_2_60, label_CH2_2_70 };
            m_CH3_1psiLevel = new Label[7] { label_CH3_1_10, label_CH3_1_20, label_CH3_1_30, label_CH3_1_40, label_CH3_1_50, label_CH3_1_60, label_CH3_1_70 };
            m_CH3_2psiLevel = new Label[7] { label_CH3_2_10, label_CH3_2_20, label_CH3_2_30, label_CH3_2_40, label_CH3_2_50, label_CH3_2_60, label_CH3_2_70 };
        }

        private void PM1Form_Load(object sender, EventArgs e)
        {
            Width = 1172;
            Height = 824;
            Top = 0;
            Left = 0;

            // 프로그램 시작 시, Device를 불러와 Air blowing
            F_SERVER_DATA_PARSING();            
        }

        private void SetDoubleBuffered(Control control, bool doubleBuffered = true)
        {
            PropertyInfo propertyInfo = typeof(Control).GetProperty
            (
                "DoubleBuffered",
                BindingFlags.Instance | BindingFlags.NonPublic
            );
            propertyInfo.SetValue(control, doubleBuffered, null);
        }        

        public void Display()
        {
            try
            {
                label_SBAAsset.Text = Define.SBA_ASSET;
                label_SBAMnbr.Text = Define.SBA_MNBR;                
                if (Define.ReflowState == Define.REFLOW_IDLE)
                {
                    label_REFLOW_State.Text = "Idle";

                    // Air blow zero set, Device name init, Tower lamp set
                    if (bIdleFlag)
                    {
                        AIOClass.WriteVoltage(0, 0);
                        AIOClass.WriteVoltage(1, 0);
                        AIOClass.WriteVoltage(2, 0);

                        Define.dCH1PsiSetValue = 0.0;
                        Define.dCH2PsiSetValue = 0.0;
                        Define.dCH3PsiSetValue = 0.0;

                        Define.strBackupDeviceName = "Empty";
                        Define.strDeviceName = "--";

                        /*
                        if ((Define.bAlarm1 == false) && (Define.bAlarm2 == false) && (Define.bAlarm3 == false))
                            Global.Towerlamp_Set((byte)Switch.Off, (byte)Switch.Off, (byte)Switch.Off, (byte)Switch.Off, (byte)Switch.Off, (byte)Switch.Off);
                        */                        

                        bIdleFlag = false;
                    }                    
                }
                else if (Define.ReflowState == Define.REFLOW_RUN)
                {
                    label_REFLOW_State.Text = "Auto run";
                    if (!bIdleFlag)
                        bIdleFlag = true;

                    if (Define.strBackupDeviceName != Define.strDeviceName)
                    {
                        Define.strBackupDeviceName = Define.strDeviceName;

                        Define.seqMode[module] = Define.MODE_PROCESS;
                        Define.seqCtrl[module] = Define.CTRL_RUN;
                        Define.seqSts[module] = Define.STS_IDLE;

                        bRecipeReadFlag = true;

                        /*
                        if ((Define.bAlarm1 == false) && (Define.bAlarm2 == false) && (Define.bAlarm3 == false))
                            Global.Towerlamp_Set((byte)Switch.Off, (byte)Switch.Off, (byte)Switch.On, (byte)Switch.Off, (byte)Switch.Off, (byte)Switch.Off);
                        */                        
                    }
                }
               
                // Web service 호출 (1min) - Device name
                if (nCallCnt >= 120)
                {
                    nCallCnt = 0;

                    F_SERVER_DATA_PARSING();
                }
                else
                {
                    nCallCnt++;
                }

                Label_Device.Text = Define.strDeviceName;
                Label_Recipe.Text = Define.sRunRecipeName;
                if ((Define.sRunRecipeName != null) && (Define.sRunRecipeName != string.Empty))
                {
                    if (bRecipeReadFlag)
                    {
                        Process_Recipe_Load();

                        bRecipeReadFlag = false;
                    }                                            
                }

                /*
                for (int i = 0; i < Define.OUT_CH_MAX - 1; i++)
                {
                    double dReadVoltage = AIOClass.ReadVoltage(i + 1) * 7.0;
                    m_valueBox[i].Text = string.Format("{0:0.0}", dReadVoltage);

                    Define.dPsiActValue[i] = dReadVoltage;
                } 
                */

                textBox_SetZone1Psi.Text = (Define.dCH1PsiSetValue).ToString("0.0");
                textBox_SetZone2Psi.Text = (Define.dCH2PsiSetValue).ToString("0.0");
                textBox_SetZone3Psi.Text = (Define.dCH3PsiSetValue).ToString("0.0");

                _ui_psiLevel_show();                


                if (Define.bPM1Event)
                {
                    Eventlog_File_Read();
                }
            }
            catch (Exception) 
            {
                
            }            
        }

        private void _ui_psiLevel_show()
        {
            int iPsiLevel = 7;

            // CH1
            if (Define.dCH1PsiSetValue <= 0)
            {
                for (int i = 0; i < iPsiLevel; i++)
                {
                    if (m_CH1_1psiLevel[i].BackColor != Color.Silver)
                        m_CH1_1psiLevel[i].BackColor = Color.Silver;

                    if (m_CH1_2psiLevel[i].BackColor != Color.Silver)
                        m_CH1_2psiLevel[i].BackColor = Color.Silver;
                }
            }
            else if ((Define.dCH1PsiSetValue > 0) && (Define.dCH1PsiSetValue <= 10))
            {
                for (int i = 0; i < iPsiLevel; i++)
                {
                    if (i == 0)
                    {
                        if (m_CH1_1psiLevel[i].BackColor != Color.Lime)
                            m_CH1_1psiLevel[i].BackColor = Color.Lime;

                        if (m_CH1_2psiLevel[i].BackColor != Color.Lime)
                            m_CH1_2psiLevel[i].BackColor = Color.Lime;
                    }
                    else
                    {
                        if (m_CH1_1psiLevel[i].BackColor != Color.Silver)
                            m_CH1_1psiLevel[i].BackColor = Color.Silver;

                        if (m_CH1_2psiLevel[i].BackColor != Color.Silver)
                            m_CH1_2psiLevel[i].BackColor = Color.Silver;
                    }
                }
            }
            else if ((Define.dCH1PsiSetValue > 10) && (Define.dCH1PsiSetValue <= 20))
            {
                for (int i = 0; i < iPsiLevel; i++)
                {
                    if (i == 0 || i == 1)
                    {
                        if (m_CH1_1psiLevel[i].BackColor != Color.Lime)
                            m_CH1_1psiLevel[i].BackColor = Color.Lime;

                        if (m_CH1_2psiLevel[i].BackColor != Color.Lime)
                            m_CH1_2psiLevel[i].BackColor = Color.Lime;
                    }
                    else
                    {
                        if (m_CH1_1psiLevel[i].BackColor != Color.Silver)
                            m_CH1_1psiLevel[i].BackColor = Color.Silver;

                        if (m_CH1_2psiLevel[i].BackColor != Color.Silver)
                            m_CH1_2psiLevel[i].BackColor = Color.Silver;
                    }
                }
            }
            else if ((Define.dCH1PsiSetValue > 20) && (Define.dCH1PsiSetValue <= 30))
            {
                for (int i = 0; i < iPsiLevel; i++)
                {
                    if (i == 0 || i == 1 || i == 2)
                    {
                        if (m_CH1_1psiLevel[i].BackColor != Color.Lime)
                            m_CH1_1psiLevel[i].BackColor = Color.Lime;

                        if (m_CH1_2psiLevel[i].BackColor != Color.Lime)
                            m_CH1_2psiLevel[i].BackColor = Color.Lime;
                    }
                    else
                    {
                        if (m_CH1_1psiLevel[i].BackColor != Color.Silver)
                            m_CH1_1psiLevel[i].BackColor = Color.Silver;

                        if (m_CH1_2psiLevel[i].BackColor != Color.Silver)
                            m_CH1_2psiLevel[i].BackColor = Color.Silver;
                    }
                }
            }
            else if ((Define.dCH1PsiSetValue > 30) && (Define.dCH1PsiSetValue <= 40))
            {
                for (int i = 0; i < iPsiLevel; i++)
                {
                    if (i == 0 || i == 1 || i == 2 || i == 3)
                    {
                        if (m_CH1_1psiLevel[i].BackColor != Color.Lime)
                            m_CH1_1psiLevel[i].BackColor = Color.Lime;

                        if (m_CH1_2psiLevel[i].BackColor != Color.Lime)
                            m_CH1_2psiLevel[i].BackColor = Color.Lime;
                    }
                    else
                    {
                        if (m_CH1_1psiLevel[i].BackColor != Color.Silver)
                            m_CH1_1psiLevel[i].BackColor = Color.Silver;

                        if (m_CH1_2psiLevel[i].BackColor != Color.Silver)
                            m_CH1_2psiLevel[i].BackColor = Color.Silver;
                    }
                }
            }
            else if ((Define.dCH1PsiSetValue > 40) && (Define.dCH1PsiSetValue <= 50))
            {
                for (int i = 0; i < iPsiLevel; i++)
                {
                    if (i == 0 || i == 1 || i == 2 || i == 3 || i == 4)
                    {
                        if (m_CH1_1psiLevel[i].BackColor != Color.Lime)
                            m_CH1_1psiLevel[i].BackColor = Color.Lime;

                        if (m_CH1_2psiLevel[i].BackColor != Color.Lime)
                            m_CH1_2psiLevel[i].BackColor = Color.Lime;
                    }
                    else
                    {
                        if (m_CH1_1psiLevel[i].BackColor != Color.Silver)
                            m_CH1_1psiLevel[i].BackColor = Color.Silver;

                        if (m_CH1_2psiLevel[i].BackColor != Color.Silver)
                            m_CH1_2psiLevel[i].BackColor = Color.Silver;
                    }
                }
            }
            else if ((Define.dCH1PsiSetValue > 50) && (Define.dCH1PsiSetValue <= 60))
            {
                for (int i = 0; i < iPsiLevel; i++)
                {
                    if (i == 0 || i == 1 || i == 2 || i == 3 || i == 4 || i == 5)
                    {
                        if (m_CH1_1psiLevel[i].BackColor != Color.Lime)
                            m_CH1_1psiLevel[i].BackColor = Color.Lime;

                        if (m_CH1_2psiLevel[i].BackColor != Color.Lime)
                            m_CH1_2psiLevel[i].BackColor = Color.Lime;
                    }
                    else
                    {
                        if (m_CH1_1psiLevel[i].BackColor != Color.Silver)
                            m_CH1_1psiLevel[i].BackColor = Color.Silver;

                        if (m_CH1_2psiLevel[i].BackColor != Color.Silver)
                            m_CH1_2psiLevel[i].BackColor = Color.Silver;
                    }
                }
            }
            else if ((Define.dCH1PsiSetValue > 60) && (Define.dCH1PsiSetValue <= 70))
            {
                for (int i = 0; i < iPsiLevel; i++)
                {
                    if (m_CH1_1psiLevel[i].BackColor != Color.Lime)
                        m_CH1_1psiLevel[i].BackColor = Color.Lime;

                    if (m_CH1_2psiLevel[i].BackColor != Color.Lime)
                        m_CH1_2psiLevel[i].BackColor = Color.Lime;
                }
            }
            else
            {
                for (int i = 0; i < iPsiLevel; i++)
                {
                    if (m_CH1_1psiLevel[i].BackColor != Color.Silver)
                        m_CH1_1psiLevel[i].BackColor = Color.Silver;

                    if (m_CH1_2psiLevel[i].BackColor != Color.Silver)
                        m_CH1_2psiLevel[i].BackColor = Color.Silver;
                }
            }

            // CH2
            if (Define.dCH2PsiSetValue <= 0)
            {
                for (int i = 0; i < iPsiLevel; i++)
                {
                    if (m_CH2_1psiLevel[i].BackColor != Color.Silver)
                        m_CH2_1psiLevel[i].BackColor = Color.Silver;

                    if (m_CH2_2psiLevel[i].BackColor != Color.Silver)
                        m_CH2_2psiLevel[i].BackColor = Color.Silver;
                }
            }
            else if ((Define.dCH2PsiSetValue > 0) && (Define.dCH2PsiSetValue <= 10))
            {
                for (int i = 0; i < iPsiLevel; i++)
                {
                    if (i == 0)
                    {
                        if (m_CH2_1psiLevel[i].BackColor != Color.Lime)
                            m_CH2_1psiLevel[i].BackColor = Color.Lime;

                        if (m_CH2_2psiLevel[i].BackColor != Color.Lime)
                            m_CH2_2psiLevel[i].BackColor = Color.Lime;
                    }
                    else
                    {
                        if (m_CH2_1psiLevel[i].BackColor != Color.Silver)
                            m_CH2_1psiLevel[i].BackColor = Color.Silver;

                        if (m_CH2_2psiLevel[i].BackColor != Color.Silver)
                            m_CH2_2psiLevel[i].BackColor = Color.Silver;
                    }
                }
            }
            else if ((Define.dCH2PsiSetValue > 10) && (Define.dCH2PsiSetValue <= 20))
            {
                for (int i = 0; i < iPsiLevel; i++)
                {
                    if (i == 0 || i == 1)
                    {
                        if (m_CH2_1psiLevel[i].BackColor != Color.Lime)
                            m_CH2_1psiLevel[i].BackColor = Color.Lime;

                        if (m_CH2_2psiLevel[i].BackColor != Color.Lime)
                            m_CH2_2psiLevel[i].BackColor = Color.Lime;
                    }
                    else
                    {
                        if (m_CH2_1psiLevel[i].BackColor != Color.Silver)
                            m_CH2_1psiLevel[i].BackColor = Color.Silver;

                        if (m_CH2_2psiLevel[i].BackColor != Color.Silver)
                            m_CH2_2psiLevel[i].BackColor = Color.Silver;
                    }
                }
            }
            else if ((Define.dCH2PsiSetValue > 20) && (Define.dCH2PsiSetValue <= 30))
            {
                for (int i = 0; i < iPsiLevel; i++)
                {
                    if (i == 0 || i == 1 || i == 2)
                    {
                        if (m_CH2_1psiLevel[i].BackColor != Color.Lime)
                            m_CH2_1psiLevel[i].BackColor = Color.Lime;

                        if (m_CH2_2psiLevel[i].BackColor != Color.Lime)
                            m_CH2_2psiLevel[i].BackColor = Color.Lime;
                    }
                    else
                    {
                        if (m_CH2_1psiLevel[i].BackColor != Color.Silver)
                            m_CH2_1psiLevel[i].BackColor = Color.Silver;

                        if (m_CH2_2psiLevel[i].BackColor != Color.Silver)
                            m_CH2_2psiLevel[i].BackColor = Color.Silver;
                    }
                }
            }
            else if ((Define.dCH2PsiSetValue > 30) && (Define.dCH2PsiSetValue <= 40))
            {
                for (int i = 0; i < iPsiLevel; i++)
                {
                    if (i == 0 || i == 1 || i == 2 || i == 3)
                    {
                        if (m_CH2_1psiLevel[i].BackColor != Color.Lime)
                            m_CH2_1psiLevel[i].BackColor = Color.Lime;

                        if (m_CH2_2psiLevel[i].BackColor != Color.Lime)
                            m_CH2_2psiLevel[i].BackColor = Color.Lime;
                    }
                    else
                    {
                        if (m_CH2_1psiLevel[i].BackColor != Color.Silver)
                            m_CH2_1psiLevel[i].BackColor = Color.Silver;

                        if (m_CH2_2psiLevel[i].BackColor != Color.Silver)
                            m_CH2_2psiLevel[i].BackColor = Color.Silver;
                    }
                }
            }
            else if ((Define.dCH2PsiSetValue > 40) && (Define.dCH2PsiSetValue <= 50))
            {
                for (int i = 0; i < iPsiLevel; i++)
                {
                    if (i == 0 || i == 1 || i == 2 || i == 3 || i == 4)
                    {
                        if (m_CH2_1psiLevel[i].BackColor != Color.Lime)
                            m_CH2_1psiLevel[i].BackColor = Color.Lime;

                        if (m_CH2_2psiLevel[i].BackColor != Color.Lime)
                            m_CH2_2psiLevel[i].BackColor = Color.Lime;
                    }
                    else
                    {
                        if (m_CH2_1psiLevel[i].BackColor != Color.Silver)
                            m_CH2_1psiLevel[i].BackColor = Color.Silver;

                        if (m_CH2_2psiLevel[i].BackColor != Color.Silver)
                            m_CH2_2psiLevel[i].BackColor = Color.Silver;
                    }
                }
            }
            else if ((Define.dCH2PsiSetValue > 50) && (Define.dCH2PsiSetValue <= 60))
            {
                for (int i = 0; i < iPsiLevel; i++)
                {
                    if (i == 0 || i == 1 || i == 2 || i == 3 || i == 4 || i == 5)
                    {
                        if (m_CH2_1psiLevel[i].BackColor != Color.Lime)
                            m_CH2_1psiLevel[i].BackColor = Color.Lime;

                        if (m_CH2_2psiLevel[i].BackColor != Color.Lime)
                            m_CH2_2psiLevel[i].BackColor = Color.Lime;
                    }
                    else
                    {
                        if (m_CH2_1psiLevel[i].BackColor != Color.Silver)
                            m_CH2_1psiLevel[i].BackColor = Color.Silver;

                        if (m_CH2_2psiLevel[i].BackColor != Color.Silver)
                            m_CH2_2psiLevel[i].BackColor = Color.Silver;
                    }
                }
            }
            else if ((Define.dCH2PsiSetValue > 60) && (Define.dCH2PsiSetValue <= 70))
            {
                for (int i = 0; i < iPsiLevel; i++)
                {
                    if (m_CH2_1psiLevel[i].BackColor != Color.Lime)
                        m_CH2_1psiLevel[i].BackColor = Color.Lime;

                    if (m_CH2_2psiLevel[i].BackColor != Color.Lime)
                        m_CH2_2psiLevel[i].BackColor = Color.Lime;
                }
            }
            else
            {
                for (int i = 0; i < iPsiLevel; i++)
                {
                    if (m_CH2_1psiLevel[i].BackColor != Color.Silver)
                        m_CH2_1psiLevel[i].BackColor = Color.Silver;

                    if (m_CH2_2psiLevel[i].BackColor != Color.Silver)
                        m_CH2_2psiLevel[i].BackColor = Color.Silver;
                }
            }

            // CH3
            if (Define.dCH3PsiSetValue <= 0)
            {
                for (int i = 0; i < iPsiLevel; i++)
                {
                    if (m_CH3_1psiLevel[i].BackColor != Color.Silver)
                        m_CH3_1psiLevel[i].BackColor = Color.Silver;

                    if (m_CH3_2psiLevel[i].BackColor != Color.Silver)
                        m_CH3_2psiLevel[i].BackColor = Color.Silver;
                }
            }
            else if ((Define.dCH3PsiSetValue > 0) && (Define.dCH3PsiSetValue <= 10))
            {
                for (int i = 0; i < iPsiLevel; i++)
                {
                    if (i == 0)
                    {
                        if (m_CH3_1psiLevel[i].BackColor != Color.Lime)
                            m_CH3_1psiLevel[i].BackColor = Color.Lime;

                        if (m_CH3_2psiLevel[i].BackColor != Color.Lime)
                            m_CH3_2psiLevel[i].BackColor = Color.Lime;
                    }
                    else
                    {
                        if (m_CH3_1psiLevel[i].BackColor != Color.Silver)
                            m_CH3_1psiLevel[i].BackColor = Color.Silver;

                        if (m_CH3_2psiLevel[i].BackColor != Color.Silver)
                            m_CH3_2psiLevel[i].BackColor = Color.Silver;
                    }
                }
            }
            else if ((Define.dCH3PsiSetValue > 10) && (Define.dCH3PsiSetValue <= 20))
            {
                for (int i = 0; i < iPsiLevel; i++)
                {
                    if (i == 0 || i == 1)
                    {
                        if (m_CH3_1psiLevel[i].BackColor != Color.Lime)
                            m_CH3_1psiLevel[i].BackColor = Color.Lime;

                        if (m_CH3_2psiLevel[i].BackColor != Color.Lime)
                            m_CH3_2psiLevel[i].BackColor = Color.Lime;
                    }
                    else
                    {
                        if (m_CH3_1psiLevel[i].BackColor != Color.Silver)
                            m_CH3_1psiLevel[i].BackColor = Color.Silver;

                        if (m_CH3_2psiLevel[i].BackColor != Color.Silver)
                            m_CH3_2psiLevel[i].BackColor = Color.Silver;
                    }
                }
            }
            else if ((Define.dCH3PsiSetValue > 20) && (Define.dCH3PsiSetValue <= 30))
            {
                for (int i = 0; i < iPsiLevel; i++)
                {
                    if (i == 0 || i == 1 || i == 2)
                    {
                        if (m_CH3_1psiLevel[i].BackColor != Color.Lime)
                            m_CH3_1psiLevel[i].BackColor = Color.Lime;

                        if (m_CH3_2psiLevel[i].BackColor != Color.Lime)
                            m_CH3_2psiLevel[i].BackColor = Color.Lime;
                    }
                    else
                    {
                        if (m_CH3_1psiLevel[i].BackColor != Color.Silver)
                            m_CH3_1psiLevel[i].BackColor = Color.Silver;

                        if (m_CH3_2psiLevel[i].BackColor != Color.Silver)
                            m_CH3_2psiLevel[i].BackColor = Color.Silver;
                    }
                }
            }
            else if ((Define.dCH3PsiSetValue > 30) && (Define.dCH3PsiSetValue <= 40))
            {
                for (int i = 0; i < iPsiLevel; i++)
                {
                    if (i == 0 || i == 1 || i == 2 || i == 3)
                    {
                        if (m_CH3_1psiLevel[i].BackColor != Color.Lime)
                            m_CH3_1psiLevel[i].BackColor = Color.Lime;

                        if (m_CH3_2psiLevel[i].BackColor != Color.Lime)
                            m_CH3_2psiLevel[i].BackColor = Color.Lime;
                    }
                    else
                    {
                        if (m_CH3_1psiLevel[i].BackColor != Color.Silver)
                            m_CH3_1psiLevel[i].BackColor = Color.Silver;

                        if (m_CH3_2psiLevel[i].BackColor != Color.Silver)
                            m_CH3_2psiLevel[i].BackColor = Color.Silver;
                    }
                }
            }
            else if ((Define.dCH3PsiSetValue > 40) && (Define.dCH3PsiSetValue <= 50))
            {
                for (int i = 0; i < iPsiLevel; i++)
                {
                    if (i == 0 || i == 1 || i == 2 || i == 3 || i == 4)
                    {
                        if (m_CH3_1psiLevel[i].BackColor != Color.Lime)
                            m_CH3_1psiLevel[i].BackColor = Color.Lime;

                        if (m_CH3_2psiLevel[i].BackColor != Color.Lime)
                            m_CH3_2psiLevel[i].BackColor = Color.Lime;
                    }
                    else
                    {
                        if (m_CH3_1psiLevel[i].BackColor != Color.Silver)
                            m_CH3_1psiLevel[i].BackColor = Color.Silver;

                        if (m_CH3_2psiLevel[i].BackColor != Color.Silver)
                            m_CH3_2psiLevel[i].BackColor = Color.Silver;
                    }
                }
            }
            else if ((Define.dCH3PsiSetValue > 50) && (Define.dCH3PsiSetValue <= 60))
            {
                for (int i = 0; i < iPsiLevel; i++)
                {
                    if (i == 0 || i == 1 || i == 2 || i == 3 || i == 4 || i == 5)
                    {
                        if (m_CH3_1psiLevel[i].BackColor != Color.Lime)
                            m_CH3_1psiLevel[i].BackColor = Color.Lime;

                        if (m_CH3_2psiLevel[i].BackColor != Color.Lime)
                            m_CH3_2psiLevel[i].BackColor = Color.Lime;
                    }
                    else
                    {
                        if (m_CH3_1psiLevel[i].BackColor != Color.Silver)
                            m_CH3_1psiLevel[i].BackColor = Color.Silver;

                        if (m_CH3_2psiLevel[i].BackColor != Color.Silver)
                            m_CH3_2psiLevel[i].BackColor = Color.Silver;
                    }
                }
            }
            else if ((Define.dCH3PsiSetValue > 60) && (Define.dCH3PsiSetValue <= 70))
            {
                for (int i = 0; i < iPsiLevel; i++)
                {
                    if (m_CH3_1psiLevel[i].BackColor != Color.Lime)
                        m_CH3_1psiLevel[i].BackColor = Color.Lime;

                    if (m_CH3_2psiLevel[i].BackColor != Color.Lime)
                        m_CH3_2psiLevel[i].BackColor = Color.Lime;
                }
            }
            else
            {
                for (int i = 0; i < iPsiLevel; i++)
                {
                    if (m_CH3_1psiLevel[i].BackColor != Color.Silver)
                        m_CH3_1psiLevel[i].BackColor = Color.Silver;

                    if (m_CH3_2psiLevel[i].BackColor != Color.Silver)
                        m_CH3_2psiLevel[i].BackColor = Color.Silver;
                }
            }
        }

        private void F_SERVER_DATA_PARSING()
        {
            // Create a request for the URL.                        
            // Only device parameter
            //WebRequest request = WebRequest.Create("http://k5cimservice.amkor.co.kr:8080/ysj/ecim/get_cim_params?equip_asset=" + Define.SBA_ASSET + "&params=Device");
            WebRequest request = WebRequest.Create("http://k5cimservice.amkor.co.kr:8080/ysj/ecim/get_cim_params?equip_asset=" + Define.SBA_ASSET + "&params=PDL");

            // If required by the server, set the credentials.
            request.Credentials = CredentialCache.DefaultCredentials;

            // Get the response.
            WebResponse response = request.GetResponse();            

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
                strParsingData = word;
                string[] words2 = strParsingData.Split('\b');   // bs로 구분.

                //if (words2[0].Equals("Device", StringComparison.OrdinalIgnoreCase))
                if (words2[0].Equals("PDL", StringComparison.OrdinalIgnoreCase))
                {
                    Define.strDeviceName = words2[1];
                    break;
                }
            }            
        }

        private void Process_Recipe_Load()
        {
            try
            {
                string rowValue;
                string[] cellValue;
                recipeGrid.Rows.Clear();
                recipeGrid.Columns.Clear();

                if (File.Exists(string.Format("{0}\\{1}", Global.RecipeFilePath, Define.sRunRecipeName)))
                {
                    StreamReader streamReader = new StreamReader(string.Format("{0}\\{1}", Global.RecipeFilePath, Define.sRunRecipeName));
                    rowValue = streamReader.ReadLine();
                    cellValue = rowValue.Split(',');

                    for (int i = 0; i <= cellValue.Count() - 1; i++)
                    {
                        DataGridViewTextBoxColumn column = new DataGridViewTextBoxColumn();
                        column.Name = cellValue[i];
                        column.HeaderText = cellValue[i];
                        recipeGrid.Columns.Add(column);
                    }

                    while (streamReader.Peek() != -1)
                    {
                        rowValue = streamReader.ReadLine();
                        cellValue = rowValue.Split(',');
                        recipeGrid.Rows.Add(cellValue);
                    }
                    streamReader.Close();

                    foreach (DataGridViewColumn item in recipeGrid.Columns)
                    {
                        item.SortMode = DataGridViewColumnSortMode.NotSortable;
                    }
                }                
            }
            catch (Exception)
            {
                
            }
        }

        private void Eventlog_File_Read()
        {
            Define.bPM1Event = false;

            try
            {
                string sTmpData;

                string sYear = string.Format("{0:yyyy}", DateTime.Now).Trim();
                string sMonth = string.Format("{0:MM}", DateTime.Now).Trim();
                string sDay = string.Format("{0:dd}", DateTime.Now).Trim();
                string FileName = string.Format("{0}.txt", sDay);

                if (File.Exists(string.Format("{0}{1}\\{2}\\{3}\\{4}", Global.logfilePath, ModuleName, sYear, sMonth, FileName)))
                {
                    byte[] bytes;
                    using (var fs = File.Open(string.Format("{0}{1}\\{2}\\{3}\\{4}", Global.logfilePath, ModuleName, sYear, sMonth, FileName), FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
                    {
                        try
                        {
                            bytes = new byte[fs.Length];
                            fs.Read(bytes, 0, (int)fs.Length);
                            sTmpData = Encoding.Default.GetString(bytes);                                                        

                            string[] data = sTmpData.Split('\n');
                            int iLength = data.Length;
                            if (iLength >= 2)
                            {
                                string sVal = data[iLength - 2].ToString();

                                Invoke((Action)(() =>
                                {
                                    listBoxEventLog.Update();

                                    if (listBoxEventLog.Items.Count >= 10)
                                        listBoxEventLog.Items.Clear();

                                    listBoxEventLog.Items.Add(sVal);
                                    listBoxEventLog.SelectedIndex = listBoxEventLog.Items.Count - 1;                                    
                                }));
                            }
                        }
                        catch (ArgumentException)
                        {

                        }
                    }
                }
            }
            catch (IOException)
            {

            }
        }

        private void textBox_SetZone1Psi_Click(object sender, EventArgs e)
        {
            TextBox tBox = (TextBox)sender;
            AnaDlg = new AnalogDlg();

            try
            {                
                string strText = tBox.Tag.ToString();
                switch (strText)
                {
                    case "0":
                        {
                            if (AnaDlg.ShowDialog() == DialogResult.OK)
                            {
                                tBox.Text = AnaDlg.m_strResult;

                                bool bChk = double.TryParse(tBox.Text.ToString(), out double dVal);

                                if ((dVal < 0.0) || (dVal > 70.0))
                                {
                                    MessageBox.Show("Min:0.0 / Max:70.0 입니다", "Notification", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                    tBox.Text = "0.0";
                                    Define.dCH1PsiSetValue = 0.0;
                                    return;
                                }

                                if (bChk)
                                {
                                    AIOClass.WriteVoltage(int.Parse(strText), dVal / 7.0);
                                    Define.dCH1PsiSetValue = dVal;
                                }
                                else
                                {
                                    MessageBox.Show("잘못된 값이 입력되었습니다", "Notification", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                    tBox.Text = "0.0";
                                    Define.dCH1PsiSetValue = 0.0;
                                    return;
                                }
                            }
                        }
                        break;

                    case "1":
                        {
                            if (AnaDlg.ShowDialog() == DialogResult.OK)
                            {
                                tBox.Text = AnaDlg.m_strResult;

                                bool bChk = double.TryParse(tBox.Text.ToString(), out double dVal);

                                if ((dVal < 0.0) || (dVal > 70.0))
                                {
                                    MessageBox.Show("Min:0.0 / Max:70.0 입니다", "Notification", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                    tBox.Text = "0.0";
                                    Define.dCH2PsiSetValue = 0.0;
                                    return;
                                }

                                if (bChk)
                                {
                                    AIOClass.WriteVoltage(int.Parse(strText), dVal / 7.0);
                                    Define.dCH2PsiSetValue = dVal;
                                }
                                else
                                {
                                    MessageBox.Show("잘못된 값이 입력되었습니다", "Notification", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                    tBox.Text = "0.0";
                                    Define.dCH2PsiSetValue = 0.0;
                                    return;
                                }
                            }
                        }
                        break;

                    case "2":
                        {
                            if (AnaDlg.ShowDialog() == DialogResult.OK)
                            {
                                tBox.Text = AnaDlg.m_strResult;

                                bool bChk = double.TryParse(tBox.Text.ToString(), out double dVal);

                                if ((dVal < 0.0) || (dVal > 70.0))
                                {
                                    MessageBox.Show("Min:0.0 / Max:70.0 입니다", "Notification", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                    tBox.Text = "0.0";
                                    Define.dCH3PsiSetValue = 0.0;
                                    return;
                                }

                                if (bChk)
                                {
                                    AIOClass.WriteVoltage(int.Parse(strText), dVal / 7.0);
                                    Define.dCH3PsiSetValue = dVal;
                                }
                                else
                                {
                                    MessageBox.Show("잘못된 값이 입력되었습니다", "Notification", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                    tBox.Text = "0.0";
                                    Define.dCH3PsiSetValue = 0.0;
                                    return;
                                }
                            }
                        }
                        break;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Notification");
            }                                  
        }

        private void btn_SetZone1PsiDown_Click(object sender, EventArgs e)
        {            
            Button btn = (Button)sender;
            
            try
            {
                string strTmp = btn.Tag.ToString();
                switch (strTmp)
                {
                    case "0":
                        {
                            bool bChk = double.TryParse(textBox_SetZone1Psi.Text.ToString(), out double dVal);

                            if ((dVal < 0.0) || (dVal > 70.0))
                            {
                                MessageBox.Show("Min:0.0 / Max:70.0 입니다", "Notification", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                Define.dCH1PsiSetValue = 0.0;
                                return;
                            }

                            if (bChk)
                            {
                                dVal = dVal - 0.1;
                                AIOClass.WriteVoltage(int.Parse(strTmp), dVal / 7.0);
                                Define.dCH1PsiSetValue = dVal;
                            }
                            else
                            {
                                MessageBox.Show("잘못된 값이 입력되었습니다", "Notification", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                Define.dCH1PsiSetValue = 0.0;
                                return;
                            }                            
                        }
                        break;

                    case "1":
                        {
                            bool bChk = double.TryParse(textBox_SetZone2Psi.Text.ToString(), out double dVal);

                            if ((dVal < 0.0) || (dVal > 70.0))
                            {
                                MessageBox.Show("Min:0.0 / Max:70.0 입니다", "Notification", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                Define.dCH2PsiSetValue = 0.0;
                                return;
                            }

                            if (bChk)
                            {
                                dVal = dVal - 0.1;
                                AIOClass.WriteVoltage(int.Parse(strTmp), dVal / 7.0);
                                Define.dCH2PsiSetValue = dVal;
                            }
                            else
                            {
                                MessageBox.Show("잘못된 값이 입력되었습니다", "Notification", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                Define.dCH2PsiSetValue = 0.0;
                                return;
                            }                            
                        }
                        break;

                    case "2":
                        {
                            bool bChk = double.TryParse(textBox_SetZone3Psi.Text.ToString(), out double dVal);

                            if ((dVal < 0.0) || (dVal > 70.0))
                            {
                                MessageBox.Show("Min:0.0 / Max:70.0 입니다", "Notification", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                Define.dCH3PsiSetValue = 0.0;
                                return;
                            }

                            if (bChk)
                            {
                                dVal = dVal - 0.1;
                                AIOClass.WriteVoltage(int.Parse(strTmp), dVal / 7.0);
                                Define.dCH3PsiSetValue = dVal;
                            }
                            else
                            {
                                MessageBox.Show("잘못된 값이 입력되었습니다", "Notification", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                Define.dCH3PsiSetValue = 0.0;
                                return;
                            }                            
                        }
                        break;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Notification");
            }            
        }

        private void btn_SetZone1PsiUp_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;

            try
            {
                string strTmp = btn.Tag.ToString();
                switch (strTmp)
                {
                    case "0":
                        {
                            bool bChk = double.TryParse(textBox_SetZone1Psi.Text.ToString(), out double dVal);

                            if ((dVal < 0.0) || (dVal > 70.0))
                            {
                                MessageBox.Show("Min:0.0 / Max:70.0 입니다", "Notification", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                Define.dCH1PsiSetValue = 0.0;
                                return;
                            }

                            if (bChk)
                            {
                                dVal = dVal + 0.1;
                                AIOClass.WriteVoltage(int.Parse(strTmp), dVal / 7.0);
                                Define.dCH1PsiSetValue = dVal;
                            }
                            else
                            {
                                MessageBox.Show("잘못된 값이 입력되었습니다", "Notification", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                Define.dCH1PsiSetValue = 0.0;
                                return;
                            }                           
                        }
                        break;

                    case "1":
                        {
                            bool bChk = double.TryParse(textBox_SetZone2Psi.Text.ToString(), out double dVal);

                            if ((dVal < 0.0) || (dVal > 70.0))
                            {
                                MessageBox.Show("Min:0.0 / Max:70.0 입니다", "Notification", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                Define.dCH2PsiSetValue = 0.0;
                                return;
                            }

                            if (bChk)
                            {
                                dVal = dVal + 0.1;
                                AIOClass.WriteVoltage(int.Parse(strTmp), dVal / 7.0);
                                Define.dCH2PsiSetValue = dVal;
                            }
                            else
                            {
                                MessageBox.Show("잘못된 값이 입력되었습니다", "Notification", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                Define.dCH2PsiSetValue = 0.0;
                                return;
                            }                           
                        }
                        break;

                    case "2":
                        {
                            bool bChk = double.TryParse(textBox_SetZone3Psi.Text.ToString(), out double dVal);

                            if ((dVal < 0.0) || (dVal > 70.0))
                            {
                                MessageBox.Show("Min:0.0 / Max:70.0 입니다", "Notification", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                Define.dCH3PsiSetValue = 0.0;
                                return;
                            }

                            if (bChk)
                            {
                                dVal = dVal + 0.1;
                                AIOClass.WriteVoltage(int.Parse(strTmp), dVal / 7.0);
                                Define.dCH3PsiSetValue = dVal;
                            }
                            else
                            {
                                MessageBox.Show("잘못된 값이 입력되었습니다", "Notification", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                Define.dCH3PsiSetValue = 0.0;
                                return;
                            }                           
                        }
                        break;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Notification");
            }            
        }

        private void AirBlowOff_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;

            try
            {
                string strTmp = btn.Tag.ToString();
                switch (strTmp)
                {
                    case "0":
                        {
                            AIOClass.WriteVoltage(0, 0);                            
                            Define.dCH1PsiSetValue = 0.0;                                                        
                        }
                        break;

                    case "1":
                        {
                            AIOClass.WriteVoltage(1, 0);
                            Define.dCH2PsiSetValue = 0.0;
                        }
                        break;

                    case "2":
                        {
                            AIOClass.WriteVoltage(2, 0);
                            Define.dCH3PsiSetValue = 0.0;
                        }
                        break;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Notification");
            }
        }

        private void btnProcess_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            string strTmp = btn.Text.ToString();
            switch (strTmp)
            {
                case "Air blow start":
                    {
                        Define.seqMode[module] = Define.MODE_PROCESS;
                        Define.seqCtrl[module] = Define.CTRL_RUN;
                        Define.seqSts[module] = Define.STS_IDLE;
                    }
                    break;                
            }
        }                
    }
}
