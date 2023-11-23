
namespace ReflowCoolingSystem
{
    partial class RecipeForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle17 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle18 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle19 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle20 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle21 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle22 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle23 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle24 = new System.Windows.Forms.DataGridViewCellStyle();
            this.listBox_RecipeName = new System.Windows.Forms.ListBox();
            this.recipeGrid = new System.Windows.Forms.DataGridView();
            this.btn_RecipeStep_Add = new System.Windows.Forms.Button();
            this.btn_RecipeStep_Del = new System.Windows.Forms.Button();
            this.btn_RecipeFile_Del = new System.Windows.Forms.Button();
            this.btn_RecipeFile_New = new System.Windows.Forms.Button();
            this.btn_RecipeFile_Copy = new System.Windows.Forms.Button();
            this.btn_RecipeFile_Cancel = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txt_CurStep = new System.Windows.Forms.Label();
            this.txt_RecipeFileName = new System.Windows.Forms.Label();
            this.txt_Step = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btn_RecipeStep_Insert = new System.Windows.Forms.Button();
            this.btn_RecipeFile_Edit = new System.Windows.Forms.Button();
            this.btn_RecipeFile_Save = new System.Windows.Forms.Button();
            this.txt_Mode = new System.Windows.Forms.Label();
            this.textBox_Device = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.boxUserDel = new System.Windows.Forms.GroupBox();
            this.btnDeviceRegist_Del = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.textBoxDeleteRecipe = new System.Windows.Forms.TextBox();
            this.textBoxDeleteDevice = new System.Windows.Forms.TextBox();
            this.dataGridViewDeviceRegist = new System.Windows.Forms.DataGridView();
            this.deviceNameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.recipeNameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.registBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.deviceRegistDataSet = new ReflowCoolingSystem.DeviceRegistDataSet();
            this.registTableAdapter = new ReflowCoolingSystem.DeviceRegistDataSetTableAdapters.RegistTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.recipeGrid)).BeginInit();
            this.boxUserDel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewDeviceRegist)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.registBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.deviceRegistDataSet)).BeginInit();
            this.SuspendLayout();
            // 
            // listBox_RecipeName
            // 
            this.listBox_RecipeName.BackColor = System.Drawing.Color.White;
            this.listBox_RecipeName.Font = new System.Drawing.Font("Nirmala UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listBox_RecipeName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.listBox_RecipeName.FormattingEnabled = true;
            this.listBox_RecipeName.ItemHeight = 20;
            this.listBox_RecipeName.Location = new System.Drawing.Point(441, 51);
            this.listBox_RecipeName.Name = "listBox_RecipeName";
            this.listBox_RecipeName.Size = new System.Drawing.Size(286, 624);
            this.listBox_RecipeName.TabIndex = 0;
            this.listBox_RecipeName.SelectedIndexChanged += new System.EventHandler(this.listBox_RecipeName_SelectedIndexChanged);
            // 
            // recipeGrid
            // 
            dataGridViewCellStyle17.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.recipeGrid.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle17;
            dataGridViewCellStyle18.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle18.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle18.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle18.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle18.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle18.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle18.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.recipeGrid.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle18;
            this.recipeGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle19.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle19.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle19.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle19.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle19.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle19.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle19.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.recipeGrid.DefaultCellStyle = dataGridViewCellStyle19;
            this.recipeGrid.Location = new System.Drawing.Point(12, 51);
            this.recipeGrid.Name = "recipeGrid";
            dataGridViewCellStyle20.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle20.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle20.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle20.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle20.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle20.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle20.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.recipeGrid.RowHeadersDefaultCellStyle = dataGridViewCellStyle20;
            dataGridViewCellStyle21.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.recipeGrid.RowsDefaultCellStyle = dataGridViewCellStyle21;
            this.recipeGrid.RowTemplate.Height = 23;
            this.recipeGrid.Size = new System.Drawing.Size(423, 634);
            this.recipeGrid.TabIndex = 1;
            this.recipeGrid.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.recipeGrid_CellClick);
            this.recipeGrid.SelectionChanged += new System.EventHandler(this.recipeGrid_SelectionChanged);
            // 
            // btn_RecipeStep_Add
            // 
            this.btn_RecipeStep_Add.BackColor = System.Drawing.Color.Transparent;
            this.btn_RecipeStep_Add.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btn_RecipeStep_Add.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_RecipeStep_Add.FlatAppearance.BorderSize = 0;
            this.btn_RecipeStep_Add.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btn_RecipeStep_Add.Font = new System.Drawing.Font("Nirmala UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_RecipeStep_Add.ForeColor = System.Drawing.Color.Navy;
            this.btn_RecipeStep_Add.Location = new System.Drawing.Point(222, 699);
            this.btn_RecipeStep_Add.Name = "btn_RecipeStep_Add";
            this.btn_RecipeStep_Add.Size = new System.Drawing.Size(67, 37);
            this.btn_RecipeStep_Add.TabIndex = 42;
            this.btn_RecipeStep_Add.Text = "Add";
            this.btn_RecipeStep_Add.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.btn_RecipeStep_Add.UseVisualStyleBackColor = false;
            this.btn_RecipeStep_Add.Visible = false;
            this.btn_RecipeStep_Add.Click += new System.EventHandler(this.btn_RecipeStep_Add_Click);
            // 
            // btn_RecipeStep_Del
            // 
            this.btn_RecipeStep_Del.BackColor = System.Drawing.Color.Transparent;
            this.btn_RecipeStep_Del.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btn_RecipeStep_Del.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_RecipeStep_Del.FlatAppearance.BorderSize = 0;
            this.btn_RecipeStep_Del.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btn_RecipeStep_Del.Font = new System.Drawing.Font("Nirmala UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_RecipeStep_Del.ForeColor = System.Drawing.Color.Red;
            this.btn_RecipeStep_Del.Location = new System.Drawing.Point(368, 699);
            this.btn_RecipeStep_Del.Name = "btn_RecipeStep_Del";
            this.btn_RecipeStep_Del.Size = new System.Drawing.Size(67, 37);
            this.btn_RecipeStep_Del.TabIndex = 43;
            this.btn_RecipeStep_Del.Text = "Delete";
            this.btn_RecipeStep_Del.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.btn_RecipeStep_Del.UseVisualStyleBackColor = false;
            this.btn_RecipeStep_Del.Visible = false;
            this.btn_RecipeStep_Del.Click += new System.EventHandler(this.btn_RecipeStep_Del_Click);
            // 
            // btn_RecipeFile_Del
            // 
            this.btn_RecipeFile_Del.BackColor = System.Drawing.Color.Transparent;
            this.btn_RecipeFile_Del.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btn_RecipeFile_Del.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_RecipeFile_Del.FlatAppearance.BorderSize = 0;
            this.btn_RecipeFile_Del.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btn_RecipeFile_Del.Font = new System.Drawing.Font("Nirmala UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_RecipeFile_Del.ForeColor = System.Drawing.Color.Red;
            this.btn_RecipeFile_Del.Location = new System.Drawing.Point(441, 742);
            this.btn_RecipeFile_Del.Name = "btn_RecipeFile_Del";
            this.btn_RecipeFile_Del.Size = new System.Drawing.Size(67, 37);
            this.btn_RecipeFile_Del.TabIndex = 45;
            this.btn_RecipeFile_Del.Text = "Delete";
            this.btn_RecipeFile_Del.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.btn_RecipeFile_Del.UseVisualStyleBackColor = false;
            this.btn_RecipeFile_Del.Click += new System.EventHandler(this.btn_RecipeFile_Del_Click);
            // 
            // btn_RecipeFile_New
            // 
            this.btn_RecipeFile_New.BackColor = System.Drawing.Color.Transparent;
            this.btn_RecipeFile_New.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btn_RecipeFile_New.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_RecipeFile_New.FlatAppearance.BorderSize = 0;
            this.btn_RecipeFile_New.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btn_RecipeFile_New.Font = new System.Drawing.Font("Nirmala UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_RecipeFile_New.ForeColor = System.Drawing.Color.Navy;
            this.btn_RecipeFile_New.Location = new System.Drawing.Point(441, 699);
            this.btn_RecipeFile_New.Name = "btn_RecipeFile_New";
            this.btn_RecipeFile_New.Size = new System.Drawing.Size(67, 37);
            this.btn_RecipeFile_New.TabIndex = 44;
            this.btn_RecipeFile_New.Text = "New";
            this.btn_RecipeFile_New.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.btn_RecipeFile_New.UseVisualStyleBackColor = false;
            this.btn_RecipeFile_New.Click += new System.EventHandler(this.btn_RecipeFile_New_Click);
            // 
            // btn_RecipeFile_Copy
            // 
            this.btn_RecipeFile_Copy.BackColor = System.Drawing.Color.Transparent;
            this.btn_RecipeFile_Copy.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btn_RecipeFile_Copy.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_RecipeFile_Copy.FlatAppearance.BorderSize = 0;
            this.btn_RecipeFile_Copy.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btn_RecipeFile_Copy.Font = new System.Drawing.Font("Nirmala UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_RecipeFile_Copy.ForeColor = System.Drawing.Color.Navy;
            this.btn_RecipeFile_Copy.Location = new System.Drawing.Point(587, 699);
            this.btn_RecipeFile_Copy.Name = "btn_RecipeFile_Copy";
            this.btn_RecipeFile_Copy.Size = new System.Drawing.Size(67, 37);
            this.btn_RecipeFile_Copy.TabIndex = 46;
            this.btn_RecipeFile_Copy.Text = "Copy";
            this.btn_RecipeFile_Copy.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.btn_RecipeFile_Copy.UseVisualStyleBackColor = false;
            this.btn_RecipeFile_Copy.Click += new System.EventHandler(this.btn_RecipeFile_Copy_Click);
            // 
            // btn_RecipeFile_Cancel
            // 
            this.btn_RecipeFile_Cancel.BackColor = System.Drawing.Color.Transparent;
            this.btn_RecipeFile_Cancel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btn_RecipeFile_Cancel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_RecipeFile_Cancel.FlatAppearance.BorderSize = 0;
            this.btn_RecipeFile_Cancel.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btn_RecipeFile_Cancel.Font = new System.Drawing.Font("Nirmala UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_RecipeFile_Cancel.ForeColor = System.Drawing.Color.Navy;
            this.btn_RecipeFile_Cancel.Location = new System.Drawing.Point(514, 742);
            this.btn_RecipeFile_Cancel.Name = "btn_RecipeFile_Cancel";
            this.btn_RecipeFile_Cancel.Size = new System.Drawing.Size(67, 37);
            this.btn_RecipeFile_Cancel.TabIndex = 47;
            this.btn_RecipeFile_Cancel.Text = "Cancel";
            this.btn_RecipeFile_Cancel.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.btn_RecipeFile_Cancel.UseVisualStyleBackColor = false;
            this.btn_RecipeFile_Cancel.Click += new System.EventHandler(this.btn_RecipeFile_Cancel_Click);
            // 
            // label3
            // 
            this.label3.BackColor = System.Drawing.Color.Navy;
            this.label3.Location = new System.Drawing.Point(213, 699);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(3, 35);
            this.label3.TabIndex = 48;
            this.label3.Visible = false;
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Nirmala UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Navy;
            this.label2.Location = new System.Drawing.Point(12, 699);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(132, 35);
            this.label2.TabIndex = 49;
            this.label2.Text = "Current Step";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.label2.Visible = false;
            // 
            // txt_CurStep
            // 
            this.txt_CurStep.BackColor = System.Drawing.Color.White;
            this.txt_CurStep.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txt_CurStep.Font = new System.Drawing.Font("Nirmala UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_CurStep.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.txt_CurStep.Location = new System.Drawing.Point(150, 699);
            this.txt_CurStep.Name = "txt_CurStep";
            this.txt_CurStep.Size = new System.Drawing.Size(57, 35);
            this.txt_CurStep.TabIndex = 50;
            this.txt_CurStep.Text = "0";
            this.txt_CurStep.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.txt_CurStep.Visible = false;
            // 
            // txt_RecipeFileName
            // 
            this.txt_RecipeFileName.BackColor = System.Drawing.Color.White;
            this.txt_RecipeFileName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txt_RecipeFileName.Font = new System.Drawing.Font("Nirmala UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_RecipeFileName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.txt_RecipeFileName.Location = new System.Drawing.Point(108, 18);
            this.txt_RecipeFileName.Name = "txt_RecipeFileName";
            this.txt_RecipeFileName.Size = new System.Drawing.Size(231, 30);
            this.txt_RecipeFileName.TabIndex = 53;
            this.txt_RecipeFileName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txt_Step
            // 
            this.txt_Step.BackColor = System.Drawing.Color.White;
            this.txt_Step.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txt_Step.Font = new System.Drawing.Font("Nirmala UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_Step.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.txt_Step.Location = new System.Drawing.Point(345, 18);
            this.txt_Step.Name = "txt_Step";
            this.txt_Step.Size = new System.Drawing.Size(90, 30);
            this.txt_Step.TabIndex = 54;
            this.txt_Step.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Nirmala UI", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Navy;
            this.label1.Location = new System.Drawing.Point(441, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(286, 30);
            this.label1.TabIndex = 51;
            this.label1.Text = "Process Recipe List";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btn_RecipeStep_Insert
            // 
            this.btn_RecipeStep_Insert.BackColor = System.Drawing.Color.Transparent;
            this.btn_RecipeStep_Insert.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btn_RecipeStep_Insert.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_RecipeStep_Insert.FlatAppearance.BorderSize = 0;
            this.btn_RecipeStep_Insert.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btn_RecipeStep_Insert.Font = new System.Drawing.Font("Nirmala UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_RecipeStep_Insert.ForeColor = System.Drawing.Color.Navy;
            this.btn_RecipeStep_Insert.Location = new System.Drawing.Point(295, 699);
            this.btn_RecipeStep_Insert.Name = "btn_RecipeStep_Insert";
            this.btn_RecipeStep_Insert.Size = new System.Drawing.Size(67, 37);
            this.btn_RecipeStep_Insert.TabIndex = 55;
            this.btn_RecipeStep_Insert.Text = "Insert";
            this.btn_RecipeStep_Insert.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.btn_RecipeStep_Insert.UseVisualStyleBackColor = false;
            this.btn_RecipeStep_Insert.Visible = false;
            this.btn_RecipeStep_Insert.Click += new System.EventHandler(this.btn_RecipeStep_Insert_Click);
            // 
            // btn_RecipeFile_Edit
            // 
            this.btn_RecipeFile_Edit.BackColor = System.Drawing.Color.Transparent;
            this.btn_RecipeFile_Edit.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btn_RecipeFile_Edit.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_RecipeFile_Edit.FlatAppearance.BorderSize = 0;
            this.btn_RecipeFile_Edit.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btn_RecipeFile_Edit.Font = new System.Drawing.Font("Nirmala UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_RecipeFile_Edit.ForeColor = System.Drawing.Color.Navy;
            this.btn_RecipeFile_Edit.Location = new System.Drawing.Point(514, 699);
            this.btn_RecipeFile_Edit.Name = "btn_RecipeFile_Edit";
            this.btn_RecipeFile_Edit.Size = new System.Drawing.Size(67, 37);
            this.btn_RecipeFile_Edit.TabIndex = 56;
            this.btn_RecipeFile_Edit.Text = "Change";
            this.btn_RecipeFile_Edit.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.btn_RecipeFile_Edit.UseVisualStyleBackColor = false;
            this.btn_RecipeFile_Edit.Click += new System.EventHandler(this.btn_RecipeFile_Edit_Click);
            // 
            // btn_RecipeFile_Save
            // 
            this.btn_RecipeFile_Save.BackColor = System.Drawing.Color.Transparent;
            this.btn_RecipeFile_Save.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btn_RecipeFile_Save.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_RecipeFile_Save.FlatAppearance.BorderSize = 0;
            this.btn_RecipeFile_Save.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btn_RecipeFile_Save.Font = new System.Drawing.Font("Nirmala UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_RecipeFile_Save.ForeColor = System.Drawing.Color.Navy;
            this.btn_RecipeFile_Save.Location = new System.Drawing.Point(660, 699);
            this.btn_RecipeFile_Save.Name = "btn_RecipeFile_Save";
            this.btn_RecipeFile_Save.Size = new System.Drawing.Size(67, 37);
            this.btn_RecipeFile_Save.TabIndex = 57;
            this.btn_RecipeFile_Save.Text = "Save";
            this.btn_RecipeFile_Save.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.btn_RecipeFile_Save.UseVisualStyleBackColor = false;
            this.btn_RecipeFile_Save.Click += new System.EventHandler(this.btn_RecipeFile_Save_Click);
            // 
            // txt_Mode
            // 
            this.txt_Mode.BackColor = System.Drawing.Color.White;
            this.txt_Mode.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txt_Mode.Font = new System.Drawing.Font("Nirmala UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_Mode.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.txt_Mode.Location = new System.Drawing.Point(12, 18);
            this.txt_Mode.Name = "txt_Mode";
            this.txt_Mode.Size = new System.Drawing.Size(90, 30);
            this.txt_Mode.TabIndex = 58;
            this.txt_Mode.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // textBox_Device
            // 
            this.textBox_Device.BackColor = System.Drawing.Color.PaleGreen;
            this.textBox_Device.Cursor = System.Windows.Forms.Cursors.Hand;
            this.textBox_Device.Font = new System.Drawing.Font("Nirmala UI", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox_Device.Location = new System.Drawing.Point(733, 51);
            this.textBox_Device.Name = "textBox_Device";
            this.textBox_Device.ReadOnly = true;
            this.textBox_Device.Size = new System.Drawing.Size(427, 43);
            this.textBox_Device.TabIndex = 527;
            this.textBox_Device.Text = "--";
            this.textBox_Device.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.textBox_Device.Click += new System.EventHandler(this.textBox_Device_Click);
            // 
            // label4
            // 
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("Nirmala UI", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.Navy;
            this.label4.Location = new System.Drawing.Point(802, 18);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(286, 30);
            this.label4.TabIndex = 528;
            this.label4.Text = "Device regist";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // boxUserDel
            // 
            this.boxUserDel.BackColor = System.Drawing.Color.White;
            this.boxUserDel.Controls.Add(this.btnDeviceRegist_Del);
            this.boxUserDel.Controls.Add(this.label7);
            this.boxUserDel.Controls.Add(this.label8);
            this.boxUserDel.Controls.Add(this.textBoxDeleteRecipe);
            this.boxUserDel.Controls.Add(this.textBoxDeleteDevice);
            this.boxUserDel.Font = new System.Drawing.Font("Nirmala UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.boxUserDel.ForeColor = System.Drawing.Color.Navy;
            this.boxUserDel.Location = new System.Drawing.Point(733, 690);
            this.boxUserDel.Name = "boxUserDel";
            this.boxUserDel.Size = new System.Drawing.Size(427, 120);
            this.boxUserDel.TabIndex = 530;
            this.boxUserDel.TabStop = false;
            // 
            // btnDeviceRegist_Del
            // 
            this.btnDeviceRegist_Del.BackColor = System.Drawing.Color.White;
            this.btnDeviceRegist_Del.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnDeviceRegist_Del.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnDeviceRegist_Del.FlatAppearance.BorderSize = 0;
            this.btnDeviceRegist_Del.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnDeviceRegist_Del.Font = new System.Drawing.Font("Nirmala UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDeviceRegist_Del.ForeColor = System.Drawing.Color.Red;
            this.btnDeviceRegist_Del.Location = new System.Drawing.Point(321, 85);
            this.btnDeviceRegist_Del.Name = "btnDeviceRegist_Del";
            this.btnDeviceRegist_Del.Size = new System.Drawing.Size(100, 29);
            this.btnDeviceRegist_Del.TabIndex = 33;
            this.btnDeviceRegist_Del.Text = "Delete";
            this.btnDeviceRegist_Del.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.btnDeviceRegist_Del.UseVisualStyleBackColor = false;
            this.btnDeviceRegist_Del.Click += new System.EventHandler(this.btnDeviceRegist_Del_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Nirmala UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(7, 54);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(48, 17);
            this.label7.TabIndex = 17;
            this.label7.Text = "Recipe";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Nirmala UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(6, 21);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(49, 17);
            this.label8.TabIndex = 18;
            this.label8.Text = "Device";
            // 
            // textBoxDeleteRecipe
            // 
            this.textBoxDeleteRecipe.BackColor = System.Drawing.Color.Silver;
            this.textBoxDeleteRecipe.Enabled = false;
            this.textBoxDeleteRecipe.Font = new System.Drawing.Font("Nirmala UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxDeleteRecipe.Location = new System.Drawing.Point(61, 51);
            this.textBoxDeleteRecipe.Name = "textBoxDeleteRecipe";
            this.textBoxDeleteRecipe.Size = new System.Drawing.Size(360, 25);
            this.textBoxDeleteRecipe.TabIndex = 12;
            // 
            // textBoxDeleteDevice
            // 
            this.textBoxDeleteDevice.BackColor = System.Drawing.Color.Silver;
            this.textBoxDeleteDevice.Enabled = false;
            this.textBoxDeleteDevice.Font = new System.Drawing.Font("Nirmala UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxDeleteDevice.Location = new System.Drawing.Point(61, 18);
            this.textBoxDeleteDevice.Name = "textBoxDeleteDevice";
            this.textBoxDeleteDevice.Size = new System.Drawing.Size(360, 25);
            this.textBoxDeleteDevice.TabIndex = 11;
            // 
            // dataGridViewDeviceRegist
            // 
            this.dataGridViewDeviceRegist.AllowUserToAddRows = false;
            this.dataGridViewDeviceRegist.AllowUserToDeleteRows = false;
            this.dataGridViewDeviceRegist.AllowUserToResizeColumns = false;
            this.dataGridViewDeviceRegist.AllowUserToResizeRows = false;
            this.dataGridViewDeviceRegist.AutoGenerateColumns = false;
            this.dataGridViewDeviceRegist.BackgroundColor = System.Drawing.Color.White;
            this.dataGridViewDeviceRegist.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dataGridViewDeviceRegist.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Raised;
            dataGridViewCellStyle22.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle22.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle22.Font = new System.Drawing.Font("Nirmala UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle22.ForeColor = System.Drawing.Color.Navy;
            dataGridViewCellStyle22.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle22.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle22.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewDeviceRegist.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle22;
            this.dataGridViewDeviceRegist.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewDeviceRegist.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.deviceNameDataGridViewTextBoxColumn,
            this.recipeNameDataGridViewTextBoxColumn});
            this.dataGridViewDeviceRegist.DataSource = this.registBindingSource;
            dataGridViewCellStyle23.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle23.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle23.Font = new System.Drawing.Font("Nirmala UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle23.ForeColor = System.Drawing.Color.Navy;
            dataGridViewCellStyle23.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle23.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle23.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewDeviceRegist.DefaultCellStyle = dataGridViewCellStyle23;
            this.dataGridViewDeviceRegist.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dataGridViewDeviceRegist.GridColor = System.Drawing.Color.White;
            this.dataGridViewDeviceRegist.Location = new System.Drawing.Point(733, 100);
            this.dataGridViewDeviceRegist.Name = "dataGridViewDeviceRegist";
            this.dataGridViewDeviceRegist.ReadOnly = true;
            dataGridViewCellStyle24.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle24.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle24.Font = new System.Drawing.Font("Nirmala UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle24.ForeColor = System.Drawing.Color.Navy;
            dataGridViewCellStyle24.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle24.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle24.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewDeviceRegist.RowHeadersDefaultCellStyle = dataGridViewCellStyle24;
            this.dataGridViewDeviceRegist.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dataGridViewDeviceRegist.RowTemplate.Height = 23;
            this.dataGridViewDeviceRegist.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewDeviceRegist.Size = new System.Drawing.Size(427, 585);
            this.dataGridViewDeviceRegist.TabIndex = 531;
            this.dataGridViewDeviceRegist.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.dataGridViewDeviceRegist_DataBindingComplete);
            this.dataGridViewDeviceRegist.SelectionChanged += new System.EventHandler(this.dataGridViewDeviceRegist_SelectionChanged);
            // 
            // deviceNameDataGridViewTextBoxColumn
            // 
            this.deviceNameDataGridViewTextBoxColumn.DataPropertyName = "DeviceName";
            this.deviceNameDataGridViewTextBoxColumn.HeaderText = "DeviceName";
            this.deviceNameDataGridViewTextBoxColumn.Name = "deviceNameDataGridViewTextBoxColumn";
            this.deviceNameDataGridViewTextBoxColumn.ReadOnly = true;
            this.deviceNameDataGridViewTextBoxColumn.Width = 230;
            // 
            // recipeNameDataGridViewTextBoxColumn
            // 
            this.recipeNameDataGridViewTextBoxColumn.DataPropertyName = "RecipeName";
            this.recipeNameDataGridViewTextBoxColumn.HeaderText = "RecipeName";
            this.recipeNameDataGridViewTextBoxColumn.Name = "recipeNameDataGridViewTextBoxColumn";
            this.recipeNameDataGridViewTextBoxColumn.ReadOnly = true;
            this.recipeNameDataGridViewTextBoxColumn.Width = 153;
            // 
            // registBindingSource
            // 
            this.registBindingSource.DataMember = "Regist";
            this.registBindingSource.DataSource = this.deviceRegistDataSet;
            // 
            // deviceRegistDataSet
            // 
            this.deviceRegistDataSet.DataSetName = "DeviceRegistDataSet";
            this.deviceRegistDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // registTableAdapter
            // 
            this.registTableAdapter.ClearBeforeFill = true;
            // 
            // RecipeForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1172, 824);
            this.Controls.Add(this.dataGridViewDeviceRegist);
            this.Controls.Add(this.boxUserDel);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.textBox_Device);
            this.Controls.Add(this.txt_Mode);
            this.Controls.Add(this.btn_RecipeFile_Save);
            this.Controls.Add(this.btn_RecipeFile_Edit);
            this.Controls.Add(this.btn_RecipeStep_Insert);
            this.Controls.Add(this.txt_RecipeFileName);
            this.Controls.Add(this.txt_Step);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txt_CurStep);
            this.Controls.Add(this.btn_RecipeFile_Cancel);
            this.Controls.Add(this.btn_RecipeFile_Copy);
            this.Controls.Add(this.btn_RecipeFile_Del);
            this.Controls.Add(this.btn_RecipeFile_New);
            this.Controls.Add(this.btn_RecipeStep_Del);
            this.Controls.Add(this.btn_RecipeStep_Add);
            this.Controls.Add(this.recipeGrid);
            this.Controls.Add(this.listBox_RecipeName);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "RecipeForm";
            this.Text = "Recipe";
            this.Activated += new System.EventHandler(this.RecipeForm_Activated);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.RecipeForm_FormClosing);
            this.Load += new System.EventHandler(this.RecipeForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.recipeGrid)).EndInit();
            this.boxUserDel.ResumeLayout(false);
            this.boxUserDel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewDeviceRegist)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.registBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.deviceRegistDataSet)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox listBox_RecipeName;
        private System.Windows.Forms.DataGridView recipeGrid;
        private System.Windows.Forms.Button btn_RecipeStep_Add;
        private System.Windows.Forms.Button btn_RecipeStep_Del;
        private System.Windows.Forms.Button btn_RecipeFile_Del;
        private System.Windows.Forms.Button btn_RecipeFile_New;
        private System.Windows.Forms.Button btn_RecipeFile_Copy;
        private System.Windows.Forms.Button btn_RecipeFile_Cancel;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label txt_CurStep;
        private System.Windows.Forms.Label txt_RecipeFileName;
        private System.Windows.Forms.Label txt_Step;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btn_RecipeStep_Insert;
        private System.Windows.Forms.Button btn_RecipeFile_Edit;
        private System.Windows.Forms.Button btn_RecipeFile_Save;
        private System.Windows.Forms.Label txt_Mode;
        private System.Windows.Forms.TextBox textBox_Device;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.GroupBox boxUserDel;
        private System.Windows.Forms.Button btnDeviceRegist_Del;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox textBoxDeleteRecipe;
        private System.Windows.Forms.TextBox textBoxDeleteDevice;
        private System.Windows.Forms.DataGridView dataGridViewDeviceRegist;
        private DeviceRegistDataSet deviceRegistDataSet;
        private System.Windows.Forms.BindingSource registBindingSource;
        private DeviceRegistDataSetTableAdapters.RegistTableAdapter registTableAdapter;
        private System.Windows.Forms.DataGridViewTextBoxColumn deviceNameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn recipeNameDataGridViewTextBoxColumn;
    }
}