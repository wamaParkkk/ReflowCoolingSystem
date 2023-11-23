using System;
using System.Reflection;
using System.Windows.Forms;

namespace ReflowCoolingSystem
{
    public partial class MaintnanceForm : Form
    {       
        public PM1Form m_PM1Form;        

        public MaintnanceForm()
        {
            InitializeComponent();

            m_PM1Form = new PM1Form(this);
            m_PM1Form.Visible = false;
            Controls.Add(m_PM1Form);
        }

        private void MaintnanceForm_Load(object sender, EventArgs e)
        {            
            displayTimer.Enabled = true;

            if (!m_PM1Form.Visible)
                m_PM1Form.Visible = true;
        }

        private void MaintnanceForm_Activated(object sender, EventArgs e)
        {
            Width = 1172;
            Height = 824;
            Top = 0;
            Left = 0;

            SetDoubleBuffered(m_PM1Form);
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

        private void MaintnanceForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            displayTimer.Enabled = false;

            m_PM1Form.Dispose();            
            Dispose();
        }        

        private void dispalyTimer_Tick(object sender, EventArgs e)
        {
            m_PM1Form.Display();
        }
    }
}
