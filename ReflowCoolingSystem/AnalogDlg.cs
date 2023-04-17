using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ReflowCoolingSystem
{
    public partial class AnalogDlg : Form
    {
        public string m_strResult = "";

        public AnalogDlg()
        {
            InitializeComponent();
        }

        private void AnalogDlg_Load(object sender, EventArgs e)
        {
            Top = 300;
            Left = 500;

            txtResult.Text = string.Empty;

            this.ActiveControl = txtResult;
            txtResult.Focus();
        }

        private void ana_Key_1_Click(object sender, EventArgs e)
        {
            string strTagNum = (sender as Button).Tag.ToString();
            m_strResult += strTagNum;
            txtResult.Text = m_strResult;
        }

        private void m_Key_Del_Click(object sender, EventArgs e)
        {
            if (m_strResult.Length == 1)
            {
                m_strResult = "";
            }
            else
            {
                if (m_strResult.Length >= 1)
                    m_strResult = m_strResult.Remove(m_strResult.Length - 1, 1);
            }

            txtResult.Text = m_strResult;
        }

        private void m_Key_Clear_Click(object sender, EventArgs e)
        {
            m_strResult = "";
            txtResult.Text = m_strResult;
        }

        private void ana_Key_Cancel_Click(object sender, EventArgs e)
        {
            m_strResult = "";
            txtResult.Text = m_strResult;

            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void ana_Key_OK_Click(object sender, EventArgs e)
        {
            RESULT_VALUE();            
        }

        private void RESULT_VALUE()
        {
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        public static string FloatToString(float fval)
        {
            string strVal = "";
            strVal = fval.ToString();
            return strVal;
        }

        private void txtResult_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                RESULT_VALUE();
            }
        }
        private void s_txtResult_TextChanged(object sender, EventArgs e)
        {
            m_strResult = txtResult.Text;
            txtResult.Focus();
            txtResult.Select(txtResult.TextLength, 0);
        }        
    }
}
