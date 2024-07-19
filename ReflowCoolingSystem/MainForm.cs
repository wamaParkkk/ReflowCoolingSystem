using System;
using System.IO;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace ReflowCoolingSystem
{
    public partial class MainForm : Form
    {
        LoginForm m_loginForm;        
        MaintnanceForm m_maintnanceForm;
        RecipeForm m_recipeForm;
        ConfigureForm m_configureForm;                
        EventLogForm m_eventLogForm;
        UserRegistForm m_userRegistForm;

        Squence.Cooling cooling;
        
        public MainForm()
        {
            InitializeComponent();

            SubFormCreate();

            Global.Init();

            CreateThread();
        }
        
        private void MainForm_Load(object sender, EventArgs e)
        {
            Width = 1280;
            Height = 1024;
            Top = 0;
            Left = 0;

            Define.bLogin = false;
            Define.bMainActivate = false;            

            MyNativeWindows myNativeWindows = new MyNativeWindows();

            for (int i = 0; i < this.Controls.Count; i++)
            {
                MdiClient mdiClient = this.Controls[i] as MdiClient;
                if (mdiClient != null)
                {
                    myNativeWindows.ReleaseHandle();
                    myNativeWindows.AssignHandle(mdiClient.Handle);
                }
            }            

            timerDisplay.Enabled = true;            

            SubFormShow((byte)Page.LogInPage);

            F_ButtonVisible(false, false, false, false, false);
        }

        public class MyNativeWindows : NativeWindow
        {
            public MyNativeWindows()
            {
            }

            private const int WM_NCCALCSIZE = 0x0083;
            private const int SB_BOTH = 3;

            [DllImport("user32.dll")]
            private static extern int ShowScrollBar(IntPtr hWnd, int wBar, int bShow);

            protected override void WndProc(ref Message m)
            {
                switch (m.Msg)
                {
                    case WM_NCCALCSIZE:
                        ShowScrollBar(m.HWnd, SB_BOTH, 0);
                        break;
                }
                base.WndProc(ref m);
            }
        }        

        private void SubFormCreate()
        {            
            m_loginForm = new LoginForm();
            m_loginForm.MdiParent = this;
            m_loginForm.Dock = DockStyle.Fill;
            m_loginForm.Show();

            m_userRegistForm = new UserRegistForm();
            m_userRegistForm.MdiParent = this;
            m_userRegistForm.Dock = DockStyle.Fill;
            m_userRegistForm.Show();

            m_maintnanceForm = new MaintnanceForm();
            m_maintnanceForm.MdiParent = this;
            m_maintnanceForm.Dock = DockStyle.Fill;
            m_maintnanceForm.Show();

            m_recipeForm = new RecipeForm();
            m_recipeForm.MdiParent = this;
            m_recipeForm.Dock = DockStyle.Fill;
            m_recipeForm.Show();

            m_configureForm = new ConfigureForm();
            m_configureForm.MdiParent = this;
            m_configureForm.Dock = DockStyle.Fill;
            m_configureForm.Show();                        

            m_eventLogForm = new EventLogForm();
            m_eventLogForm.MdiParent = this;
            m_eventLogForm.Dock = DockStyle.Fill;
            m_eventLogForm.Show();
        }

        private void CreateThread()
        {            
            cooling = new Squence.Cooling();
        }

        private void FreeThread()
        {
            cooling.Dispose();            
        }

        public void SubFormShow(byte PageNum)
        {
            try
            {
                Define.currentPage = PageNum;
                byte iPage = PageNum;

                switch (iPage)
                {
                    case (byte)Page.LogInPage:
                        {
                            m_loginForm.Activate();
                            m_loginForm.BringToFront();                            
                        }
                        break;                    

                    case (byte)Page.MaintnancePage:
                        {
                            m_maintnanceForm.Activate();
                            m_maintnanceForm.BringToFront();                            
                        }
                        break;

                    case (byte)Page.RecipePage:
                        {
                            m_recipeForm.Activate();
                            m_recipeForm.BringToFront();                            
                        }
                        break;

                    case (byte)Page.ConfigurePage:
                        {
                            m_configureForm.Activate();
                            m_configureForm.BringToFront();
                        }
                        break;                                        

                    case (byte)Page.EventLogPage:
                        {
                            m_eventLogForm.Activate();
                            m_eventLogForm.BringToFront();
                        }
                        break;

                    case (byte)Page.UserRegist:
                        {
                            m_userRegistForm.Activate();
                            m_userRegistForm.BringToFront();
                        }
                        break;
                }
            }
            catch
            {
                MessageBox.Show("폼 양식을 가져오는 도중 오류가 발생했습니다.", "Notification", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void F_ButtonVisible(bool bMaintBtn, bool bRecipeBtn, bool bConfigureBtn, bool bEventLogBtn, bool bUserRegistBtn)
        {            
            pictureBoxMain.Enabled = bMaintBtn;
            btnMaintnance.Enabled = bMaintBtn;

            pictureBoxRecipe.Enabled = bRecipeBtn;
            btnRecipe.Enabled = bRecipeBtn;

            pictureBoxConfigure.Enabled = bConfigureBtn;
            btnConfigure.Enabled = bConfigureBtn;

            pictureBoxEventLog.Enabled = bEventLogBtn;
            btnEventLog.Enabled = bEventLogBtn;

            pictureBoxUserRegist.Enabled = bUserRegistBtn;
            btnUserRegist.Enabled = bUserRegistBtn;
        }                        

        private void btnMain_Click(object sender, EventArgs e)
        {
            SubFormShow((byte)Page.MaintnancePage);
        }

        private void btnRecipe_Click(object sender, EventArgs e)
        {
            SubFormShow((byte)Page.RecipePage);
        }

        private void btnConfigure_Click(object sender, EventArgs e)
        {
            SubFormShow((byte)Page.ConfigurePage);
        }

        private void btnEventLog_Click(object sender, EventArgs e)
        {
            SubFormShow((byte)Page.EventLogPage);
        }

        private void btnUserRegist_Click(object sender, EventArgs e)
        {
            SubFormShow((byte)Page.UserRegist);
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("프로그램을 종료 하겠습니까?", "Notification", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                timerDisplay.Enabled = false;

                FreeThread();

                Global.Usb_Qu_Close();

                Dispose();
                //Application.Exit();
                Application.ExitThread();
                Environment.Exit(0);
            }
        }

        private void pictureBoxBuzzer_Click(object sender, EventArgs e)
        {
            Global.Towerlamp_Set((byte)Switch.Off, (byte)Switch.Off, (byte)Switch.Off, (byte)Switch.Off, (byte)Switch.Off, (byte)Switch.Off);
        }

        private void pictureBoxUserGuide_Click(object sender, EventArgs e)
        {
            String openPDFFile = Path.GetFullPath(Path.Combine(AppContext.BaseDirectory, @"..\..\..\Document\SW operation manual_Reflow air knife system.pdf"));
            File.WriteAllBytes(openPDFFile, Properties.Resources.SW_operation_manual_Reflow_air_knife_system);
            System.Diagnostics.Process.Start(openPDFFile);
        }

        private void timerDisplay_Tick(object sender, EventArgs e)
        {
            Display();
        }

        private void Display()
        {
            laDate.Text = System.DateTime.Today.ToShortDateString();
            laTime.Text = System.DateTime.Now.ToLongTimeString();
            laUserLevel.Text = "Level : " + Define.UserLevel;

            if (Define.currentPage == (byte)Page.MaintnancePage)
            {
                labelPageName.Text = "Process";
                if (Define.bMainActivate)
                {
                    m_maintnanceForm.Activate();
                    m_maintnanceForm.BringToFront();

                    Define.bMainActivate = false;
                }                           
            }
            else if (Define.currentPage == (byte)Page.RecipePage)
            {
                labelPageName.Text = "Recipe";
            }
            else if (Define.currentPage == (byte)Page.ConfigurePage)
            {
                labelPageName.Text = "Configure";
            }                        
            else if (Define.currentPage == (byte)Page.EventLogPage)
            {
                labelPageName.Text = "Event Log";
            }
            else if (Define.currentPage == (byte)Page.UserRegist)
            {
                labelPageName.Text = "User regist";
                m_userRegistForm.BringToFront();
            }
            else if (Define.currentPage == (byte)Page.LogInPage)
            {
                labelPageName.Text = "Log-In";
            }
            

            // User level에 따른 버튼 활성화
            if (Define.UserLevel == "Master")
            {
                // maint, recipe, configure, eventlog, userRegist
                F_ButtonVisible(true, true, true, true, true);
            }
            else if (Define.UserLevel == "Maintnance")
            {
                F_ButtonVisible(true, true, true, true, false);
            }
            else if (Define.UserLevel == "User")
            {
                F_ButtonVisible(true, false, false, true, false);
            }                             
        }        
    }
}
