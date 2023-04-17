using System;
using System.Drawing;
using System.IO;
using System.Net;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;
using Ajin_IO_driver;

namespace ReflowCoolingSystem
{
    public partial class PM1Form : UserControl
    {
        [DllImport("kernel32")]
        private static extern long WritePrivateProfileString(string section, string key, string val, string filePath);

        [DllImport("kernel32")]
        private static extern int GetPrivateProfileString(string section, string key, string def, StringBuilder retVal, int size, string filePath);

        private MaintnanceForm m_Parent;               

        int module;
        string ModuleName;
        private Label[] m_valueBox;

        // e-SIM server data Parsing시, 사용 할 변수.
        string strServerAllData = "";
        string strParsingData = "";
        string strDeviceName = "";

        public PM1Form(MaintnanceForm parent)
        {
            InitializeComponent();

            m_Parent = parent;            

            module = (int)MODULE._PM1;
            ModuleName = "PM1";

            m_valueBox = new Label[Define.OUT_CH_MAX] { Label_Volt1, Label_Volt2, Label_Volt3, Label_Volt4 };
        }

        private void PM1Form_Load(object sender, EventArgs e)
        {
            Width = 1766;
            Height = 880;
            Top = 0;
            Left = 0;            

            Eventlog_Display.Enabled = true;
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
            /*
            for (int i = 0; i < Define.OUT_CH_MAX; i++)
            {
                m_valueBox[i].Text = string.Format("{0:0.00}", AIOClass.ReadVoltage(i + 1));
            } 
            */
        }

        private void Eventlog_Display_Tick(object sender, EventArgs e)
        {
            // Web service 호출 - Device name
            F_SERVER_DATA_PARSING();


            if (Define.bPM1Event)
            {
                Eventlog_File_Read();
            }
        }

        private void F_SERVER_DATA_PARSING()
        {
            // Create a request for the URL.            
            WebRequest request = WebRequest.Create(
                "http://cim_service.amkor.co.kr:8080/ysj/conn/get_all_equip_parameter?MNBR=" + Define.EQ_MNBR_1 + "&Language=1");

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
                strParsingData = word;
                string[] words2 = strParsingData.Split('\b');   // bs로 구분.

                if (words2[0].Equals("Device", StringComparison.OrdinalIgnoreCase))
                {
                    strDeviceName = words2[1];
                    break;
                }                                                
            }

            // Device name
            this.Label_Device.Invoke((MethodInvoker)delegate
            {
                Label_Device.Text = strDeviceName;
            });                                 
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
    }
}
