using System;
using System.IO;
using System.Windows.Forms;

namespace ReflowCoolingSystem
{
    public partial class RecipeSelectForm : Form
    {
        public RecipeSelectForm()
        {
            InitializeComponent();
        }

        private void RecipeSelectForm_Load(object sender, EventArgs e)
        {
            Top = 250;
            Left = 500;            

            Get_lstRecipeFile();
        }

        private void RecipeSelectForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            Dispose();
        }

        private void Get_lstRecipeFile()
        {
            try
            {
                listBox_RecipeName.Items.Clear();

                if (Directory.Exists(Global.RecipeFilePath))
                {
                    string[] FileList = Directory.GetFiles(Global.RecipeFilePath, "*.csv");
                    string[] strSplit = new string[1];
                    strSplit[0] = "\\";

                    for (int i = 0; i < FileList.Length; i++)
                    {
                        string[] FileSplit = FileList[i].Split(strSplit, StringSplitOptions.RemoveEmptyEntries);
                        listBox_RecipeName.Items.Add(FileSplit[FileSplit.Length - 1]);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Notification");
            }
        }

        private void btn_RecipeFile_Select_Click(object sender, EventArgs e)
        {
            if (listBox_RecipeName.SelectedItem != null)
            {
                Define.sSelectRecipeName = string.Empty;
                Define.sSelectRecipeName = listBox_RecipeName.SelectedItem.ToString();

                this.DialogResult = DialogResult.OK;
            }
        }

        private void btn_RecipeFile_SelectCancel_Click(object sender, EventArgs e)
        {
            Close();
        }        
    }
}
