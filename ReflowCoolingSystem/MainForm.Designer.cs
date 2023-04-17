
namespace ReflowCoolingSystem
{
    partial class MainForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.timerDisplay = new System.Windows.Forms.Timer(this.components);
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.panel5 = new System.Windows.Forms.Panel();
            this.pictureBoxEventLog = new System.Windows.Forms.PictureBox();
            this.btnEventLog = new System.Windows.Forms.Button();
            this.pictureBoxUserRegist = new System.Windows.Forms.PictureBox();
            this.btnUserRegist = new System.Windows.Forms.Button();
            this.laUserLevel = new System.Windows.Forms.Label();
            this.labelPageName = new System.Windows.Forms.Label();
            this.laTime = new System.Windows.Forms.Label();
            this.laDate = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panelLogo = new System.Windows.Forms.Panel();
            this.panel9 = new System.Windows.Forms.Panel();
            this.panel10 = new System.Windows.Forms.Panel();
            this.pictureBoxExit = new System.Windows.Forms.PictureBox();
            this.pictureBoxConfigure = new System.Windows.Forms.PictureBox();
            this.pictureBoxMain = new System.Windows.Forms.PictureBox();
            this.btnMaintnance = new System.Windows.Forms.Button();
            this.btnConfigure = new System.Windows.Forms.Button();
            this.btnExit = new System.Windows.Forms.Button();
            this.panel7 = new System.Windows.Forms.Panel();
            this.panel8 = new System.Windows.Forms.Panel();
            this.panel6 = new System.Windows.Forms.Panel();
            this.panel1.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxEventLog)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxUserRegist)).BeginInit();
            this.panel2.SuspendLayout();
            this.panel9.SuspendLayout();
            this.panel10.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxExit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxConfigure)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxMain)).BeginInit();
            this.panel7.SuspendLayout();
            this.SuspendLayout();
            // 
            // timerDisplay
            // 
            this.timerDisplay.Interval = 500;
            this.timerDisplay.Tick += new System.EventHandler(this.timerDisplay_Tick);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.panel4);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1920, 100);
            this.panel1.TabIndex = 31;
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.panel5);
            this.panel4.Location = new System.Drawing.Point(275, 0);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(1647, 100);
            this.panel4.TabIndex = 1;
            // 
            // panel5
            // 
            this.panel5.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.panel5.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("panel5.BackgroundImage")));
            this.panel5.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panel5.Controls.Add(this.pictureBoxEventLog);
            this.panel5.Controls.Add(this.btnEventLog);
            this.panel5.Controls.Add(this.pictureBoxUserRegist);
            this.panel5.Controls.Add(this.btnUserRegist);
            this.panel5.Controls.Add(this.laUserLevel);
            this.panel5.Controls.Add(this.labelPageName);
            this.panel5.Controls.Add(this.laTime);
            this.panel5.Controls.Add(this.laDate);
            this.panel5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel5.Location = new System.Drawing.Point(0, 0);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(1647, 100);
            this.panel5.TabIndex = 20;
            // 
            // pictureBoxEventLog
            // 
            this.pictureBoxEventLog.BackColor = System.Drawing.Color.Transparent;
            this.pictureBoxEventLog.BackgroundImage = global::ReflowCoolingSystem.Properties.Resources.log;
            this.pictureBoxEventLog.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pictureBoxEventLog.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBoxEventLog.Location = new System.Drawing.Point(475, 29);
            this.pictureBoxEventLog.Name = "pictureBoxEventLog";
            this.pictureBoxEventLog.Size = new System.Drawing.Size(42, 42);
            this.pictureBoxEventLog.TabIndex = 156;
            this.pictureBoxEventLog.TabStop = false;
            this.pictureBoxEventLog.Click += new System.EventHandler(this.btnEventLog_Click);
            // 
            // btnEventLog
            // 
            this.btnEventLog.BackColor = System.Drawing.Color.Transparent;
            this.btnEventLog.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnEventLog.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnEventLog.FlatAppearance.BorderSize = 0;
            this.btnEventLog.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnEventLog.Font = new System.Drawing.Font("Nirmala UI", 12.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEventLog.ForeColor = System.Drawing.Color.White;
            this.btnEventLog.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnEventLog.Location = new System.Drawing.Point(516, 29);
            this.btnEventLog.Name = "btnEventLog";
            this.btnEventLog.Size = new System.Drawing.Size(111, 42);
            this.btnEventLog.TabIndex = 155;
            this.btnEventLog.Text = "Event Log";
            this.btnEventLog.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.btnEventLog.UseVisualStyleBackColor = false;
            this.btnEventLog.Click += new System.EventHandler(this.btnEventLog_Click);
            // 
            // pictureBoxUserRegist
            // 
            this.pictureBoxUserRegist.BackColor = System.Drawing.Color.Transparent;
            this.pictureBoxUserRegist.BackgroundImage = global::ReflowCoolingSystem.Properties.Resources.register;
            this.pictureBoxUserRegist.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pictureBoxUserRegist.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBoxUserRegist.Location = new System.Drawing.Point(633, 29);
            this.pictureBoxUserRegist.Name = "pictureBoxUserRegist";
            this.pictureBoxUserRegist.Size = new System.Drawing.Size(42, 42);
            this.pictureBoxUserRegist.TabIndex = 153;
            this.pictureBoxUserRegist.TabStop = false;
            this.pictureBoxUserRegist.Click += new System.EventHandler(this.btnUserRegist_Click);
            // 
            // btnUserRegist
            // 
            this.btnUserRegist.BackColor = System.Drawing.Color.Transparent;
            this.btnUserRegist.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnUserRegist.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnUserRegist.FlatAppearance.BorderSize = 0;
            this.btnUserRegist.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnUserRegist.Font = new System.Drawing.Font("Nirmala UI", 12.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUserRegist.ForeColor = System.Drawing.Color.White;
            this.btnUserRegist.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnUserRegist.Location = new System.Drawing.Point(674, 29);
            this.btnUserRegist.Name = "btnUserRegist";
            this.btnUserRegist.Size = new System.Drawing.Size(111, 42);
            this.btnUserRegist.TabIndex = 152;
            this.btnUserRegist.Text = "User regist";
            this.btnUserRegist.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.btnUserRegist.UseVisualStyleBackColor = false;
            this.btnUserRegist.Click += new System.EventHandler(this.btnUserRegist_Click);
            // 
            // laUserLevel
            // 
            this.laUserLevel.AutoSize = true;
            this.laUserLevel.BackColor = System.Drawing.Color.Transparent;
            this.laUserLevel.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.laUserLevel.ForeColor = System.Drawing.Color.Yellow;
            this.laUserLevel.Location = new System.Drawing.Point(1452, 17);
            this.laUserLevel.Name = "laUserLevel";
            this.laUserLevel.Size = new System.Drawing.Size(17, 14);
            this.laUserLevel.TabIndex = 151;
            this.laUserLevel.Text = "--";
            // 
            // labelPageName
            // 
            this.labelPageName.AutoSize = true;
            this.labelPageName.BackColor = System.Drawing.Color.Transparent;
            this.labelPageName.Font = new System.Drawing.Font("Nirmala UI", 30F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelPageName.ForeColor = System.Drawing.Color.White;
            this.labelPageName.Location = new System.Drawing.Point(50, 16);
            this.labelPageName.Name = "labelPageName";
            this.labelPageName.Size = new System.Drawing.Size(55, 54);
            this.labelPageName.TabIndex = 149;
            this.labelPageName.Text = "--";
            this.labelPageName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // laTime
            // 
            this.laTime.AutoSize = true;
            this.laTime.BackColor = System.Drawing.Color.Transparent;
            this.laTime.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.laTime.ForeColor = System.Drawing.SystemColors.Window;
            this.laTime.Location = new System.Drawing.Point(1452, 57);
            this.laTime.Name = "laTime";
            this.laTime.Size = new System.Drawing.Size(63, 14);
            this.laTime.TabIndex = 148;
            this.laTime.Text = "00:00:00";
            // 
            // laDate
            // 
            this.laDate.AutoSize = true;
            this.laDate.BackColor = System.Drawing.Color.Transparent;
            this.laDate.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.laDate.ForeColor = System.Drawing.SystemColors.Window;
            this.laDate.Location = new System.Drawing.Point(1452, 37);
            this.laDate.Name = "laDate";
            this.laDate.Size = new System.Drawing.Size(79, 14);
            this.laDate.TabIndex = 147;
            this.laDate.Text = "0000.00.00";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.panelLogo);
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(276, 100);
            this.panel2.TabIndex = 0;
            // 
            // panelLogo
            // 
            this.panelLogo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(69)))), ((int)(((byte)(146)))), ((int)(((byte)(190)))));
            this.panelLogo.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("panelLogo.BackgroundImage")));
            this.panelLogo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panelLogo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelLogo.Location = new System.Drawing.Point(0, 0);
            this.panelLogo.Name = "panelLogo";
            this.panelLogo.Size = new System.Drawing.Size(276, 100);
            this.panelLogo.TabIndex = 18;
            // 
            // panel9
            // 
            this.panel9.Controls.Add(this.panel10);
            this.panel9.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel9.Location = new System.Drawing.Point(0, 980);
            this.panel9.Name = "panel9";
            this.panel9.Size = new System.Drawing.Size(1920, 100);
            this.panel9.TabIndex = 38;
            // 
            // panel10
            // 
            this.panel10.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.panel10.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("panel10.BackgroundImage")));
            this.panel10.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panel10.Controls.Add(this.pictureBoxExit);
            this.panel10.Controls.Add(this.pictureBoxConfigure);
            this.panel10.Controls.Add(this.pictureBoxMain);
            this.panel10.Controls.Add(this.btnMaintnance);
            this.panel10.Controls.Add(this.btnConfigure);
            this.panel10.Controls.Add(this.btnExit);
            this.panel10.Location = new System.Drawing.Point(0, 0);
            this.panel10.Name = "panel10";
            this.panel10.Size = new System.Drawing.Size(1920, 106);
            this.panel10.TabIndex = 34;
            // 
            // pictureBoxExit
            // 
            this.pictureBoxExit.BackColor = System.Drawing.Color.Transparent;
            this.pictureBoxExit.BackgroundImage = global::ReflowCoolingSystem.Properties.Resources.ExitButton;
            this.pictureBoxExit.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pictureBoxExit.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBoxExit.Location = new System.Drawing.Point(1580, 46);
            this.pictureBoxExit.Name = "pictureBoxExit";
            this.pictureBoxExit.Size = new System.Drawing.Size(42, 42);
            this.pictureBoxExit.TabIndex = 39;
            this.pictureBoxExit.TabStop = false;
            this.pictureBoxExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // pictureBoxConfigure
            // 
            this.pictureBoxConfigure.BackColor = System.Drawing.Color.Transparent;
            this.pictureBoxConfigure.BackgroundImage = global::ReflowCoolingSystem.Properties.Resources.ConfigButton;
            this.pictureBoxConfigure.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pictureBoxConfigure.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBoxConfigure.Location = new System.Drawing.Point(908, 46);
            this.pictureBoxConfigure.Name = "pictureBoxConfigure";
            this.pictureBoxConfigure.Size = new System.Drawing.Size(42, 42);
            this.pictureBoxConfigure.TabIndex = 37;
            this.pictureBoxConfigure.TabStop = false;
            this.pictureBoxConfigure.Click += new System.EventHandler(this.btnConfigure_Click);
            // 
            // pictureBoxMain
            // 
            this.pictureBoxMain.BackColor = System.Drawing.Color.Transparent;
            this.pictureBoxMain.BackgroundImage = global::ReflowCoolingSystem.Properties.Resources.Maint;
            this.pictureBoxMain.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pictureBoxMain.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBoxMain.Location = new System.Drawing.Point(750, 46);
            this.pictureBoxMain.Name = "pictureBoxMain";
            this.pictureBoxMain.Size = new System.Drawing.Size(42, 42);
            this.pictureBoxMain.TabIndex = 35;
            this.pictureBoxMain.TabStop = false;
            this.pictureBoxMain.Click += new System.EventHandler(this.btnMain_Click);
            // 
            // btnMaintnance
            // 
            this.btnMaintnance.BackColor = System.Drawing.Color.Transparent;
            this.btnMaintnance.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnMaintnance.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnMaintnance.FlatAppearance.BorderSize = 0;
            this.btnMaintnance.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnMaintnance.Font = new System.Drawing.Font("Nirmala UI", 12.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMaintnance.ForeColor = System.Drawing.Color.White;
            this.btnMaintnance.Location = new System.Drawing.Point(791, 46);
            this.btnMaintnance.Name = "btnMaintnance";
            this.btnMaintnance.Size = new System.Drawing.Size(111, 42);
            this.btnMaintnance.TabIndex = 33;
            this.btnMaintnance.Text = "Process";
            this.btnMaintnance.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.btnMaintnance.UseVisualStyleBackColor = false;
            this.btnMaintnance.Click += new System.EventHandler(this.btnMain_Click);
            // 
            // btnConfigure
            // 
            this.btnConfigure.BackColor = System.Drawing.Color.Transparent;
            this.btnConfigure.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnConfigure.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnConfigure.FlatAppearance.BorderSize = 0;
            this.btnConfigure.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnConfigure.Font = new System.Drawing.Font("Nirmala UI", 12.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnConfigure.ForeColor = System.Drawing.Color.White;
            this.btnConfigure.Location = new System.Drawing.Point(949, 46);
            this.btnConfigure.Name = "btnConfigure";
            this.btnConfigure.Size = new System.Drawing.Size(111, 42);
            this.btnConfigure.TabIndex = 34;
            this.btnConfigure.Text = "Configure";
            this.btnConfigure.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.btnConfigure.UseVisualStyleBackColor = false;
            this.btnConfigure.Click += new System.EventHandler(this.btnConfigure_Click);
            // 
            // btnExit
            // 
            this.btnExit.BackColor = System.Drawing.Color.Transparent;
            this.btnExit.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnExit.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnExit.FlatAppearance.BorderSize = 0;
            this.btnExit.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnExit.Font = new System.Drawing.Font("Nirmala UI", 12.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExit.ForeColor = System.Drawing.Color.White;
            this.btnExit.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnExit.Location = new System.Drawing.Point(1621, 46);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(111, 42);
            this.btnExit.TabIndex = 31;
            this.btnExit.Text = "Exit";
            this.btnExit.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.btnExit.UseVisualStyleBackColor = false;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // panel7
            // 
            this.panel7.Controls.Add(this.panel8);
            this.panel7.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel7.Location = new System.Drawing.Point(1788, 100);
            this.panel7.Name = "panel7";
            this.panel7.Size = new System.Drawing.Size(132, 880);
            this.panel7.TabIndex = 40;
            // 
            // panel8
            // 
            this.panel8.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.panel8.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("panel8.BackgroundImage")));
            this.panel8.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel8.Location = new System.Drawing.Point(0, 0);
            this.panel8.Name = "panel8";
            this.panel8.Size = new System.Drawing.Size(132, 880);
            this.panel8.TabIndex = 41;
            // 
            // panel6
            // 
            this.panel6.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("panel6.BackgroundImage")));
            this.panel6.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panel6.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel6.Location = new System.Drawing.Point(0, 100);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(22, 880);
            this.panel6.TabIndex = 39;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(51)))), ((int)(((byte)(73)))));
            this.ClientSize = new System.Drawing.Size(1920, 1080);
            this.Controls.Add(this.panel7);
            this.Controls.Add(this.panel6);
            this.Controls.Add(this.panel9);
            this.Controls.Add(this.panel1);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.IsMdiContainer = true;
            this.Name = "MainForm";
            this.ShowIcon = false;
            this.Text = "Resistance Measurement System";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.panel1.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.panel5.ResumeLayout(false);
            this.panel5.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxEventLog)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxUserRegist)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel9.ResumeLayout(false);
            this.panel10.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxExit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxConfigure)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxMain)).EndInit();
            this.panel7.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Timer timerDisplay;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Panel panel5;
        public System.Windows.Forms.Label labelPageName;
        private System.Windows.Forms.Label laTime;
        private System.Windows.Forms.Label laDate;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panelLogo;
        private System.Windows.Forms.Panel panel9;
        private System.Windows.Forms.Panel panel10;
        private System.Windows.Forms.PictureBox pictureBoxExit;
        private System.Windows.Forms.PictureBox pictureBoxConfigure;
        private System.Windows.Forms.PictureBox pictureBoxMain;
        private System.Windows.Forms.Button btnMaintnance;
        private System.Windows.Forms.Button btnConfigure;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.Panel panel7;
        private System.Windows.Forms.Panel panel8;
        private System.Windows.Forms.Label laUserLevel;
        private System.Windows.Forms.PictureBox pictureBoxUserRegist;
        private System.Windows.Forms.Button btnUserRegist;
        private System.Windows.Forms.PictureBox pictureBoxEventLog;
        private System.Windows.Forms.Button btnEventLog;
    }
}