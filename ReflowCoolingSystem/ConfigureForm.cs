using System;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;

namespace ReflowCoolingSystem
{
    public partial class ConfigureForm : Form
    {
        AnalogDlg AnaDlg;

        [DllImport("kernel32")]
        private static extern long WritePrivateProfileString(string section, string key, string val, string filePath);

        [DllImport("kernel32")]
        private static extern int GetPrivateProfileString(string section, string key, string def, StringBuilder retVal, int size, string filePath);

        public ConfigureForm()
        {            
            InitializeComponent();
        }

        private void ConfigureForm_Load(object sender, EventArgs e)
        {
            Width = 1766;
            Height = 880;
            Top = 0;
            Left = 0;

            PARAMETER_LOAD();            
        }

        private void ConfigureForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            Dispose();
        }

        private void PARAMETER_LOAD()
        {
            try
            {
                // Ini file read
                StringBuilder sbStabilTime = new StringBuilder();

                GetPrivateProfileString("Parameter", "StabilizationTime", "", sbStabilTime, sbStabilTime.Capacity, string.Format("{0}{1}", Global.ConfigurePath, "Configure.ini"));

                Configure_List.Stabilization_Time = Convert.ToInt16(sbStabilTime.ToString().Trim());
                txtBoxStabilizationTime.Text = (Configure_List.Stabilization_Time).ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Notification", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }           
        }        

        private void txtBoxDoorOpenCloseTimeout_Click(object sender, EventArgs e)
        {
            TextBox textBox = (TextBox)sender;

            AnaDlg = new AnalogDlg();            
            if (AnaDlg.ShowDialog() == DialogResult.OK)
            {
                textBox.Text = AnaDlg.m_strResult;

                string[] sVal = new string[1];
                string sTemp = textBox.Text.ToString().Trim();
                sVal[0] = sTemp;
                if (!Global.Value_Check(sVal))
                {
                    MessageBox.Show("잘못 된 값이 입력되었습니다.", "알림", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    textBox.Text = "0";
                }
            }
        }

        private void btnParameterSave_Click(object sender, EventArgs e)
        {
            try
            {
                WritePrivateProfileString("Parameter", "StabilizationTime", txtBoxStabilizationTime.Text, string.Format("{0}{1}", Global.ConfigurePath, "Configure.ini"));

                PARAMETER_LOAD();

                MessageBox.Show("Configure 값이 저장 되었습니다.", "알림", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Notification", MessageBoxButtons.OK, MessageBoxIcon.Error);                
            }          
        }            
    }
}
