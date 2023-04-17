
namespace ReflowCoolingSystem
{
    partial class PM1Form
    {
        /// <summary> 
        /// 필수 디자이너 변수입니다.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// 사용 중인 모든 리소스를 정리합니다.
        /// </summary>
        /// <param name="disposing">관리되는 리소스를 삭제해야 하면 true이고, 그렇지 않으면 false입니다.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region 구성 요소 디자이너에서 생성한 코드

        /// <summary> 
        /// 디자이너 지원에 필요한 메서드입니다. 
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마세요.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.Label_Volt2 = new System.Windows.Forms.Label();
            this.Label_Volt1 = new System.Windows.Forms.Label();
            this.Label_Volt4 = new System.Windows.Forms.Label();
            this.Label_Volt3 = new System.Windows.Forms.Label();
            this.listBoxEventLog = new System.Windows.Forms.ListBox();
            this.Eventlog_Display = new System.Windows.Forms.Timer(this.components);
            this.label16 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.Label_Device = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // Label_Volt2
            // 
            this.Label_Volt2.BackColor = System.Drawing.Color.Black;
            this.Label_Volt2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.Label_Volt2.Font = new System.Drawing.Font("Nirmala UI", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label_Volt2.ForeColor = System.Drawing.Color.Yellow;
            this.Label_Volt2.Location = new System.Drawing.Point(615, 230);
            this.Label_Volt2.Name = "Label_Volt2";
            this.Label_Volt2.Size = new System.Drawing.Size(93, 38);
            this.Label_Volt2.TabIndex = 491;
            this.Label_Volt2.Text = "--";
            this.Label_Volt2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Label_Volt1
            // 
            this.Label_Volt1.BackColor = System.Drawing.Color.Black;
            this.Label_Volt1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.Label_Volt1.Font = new System.Drawing.Font("Nirmala UI", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label_Volt1.ForeColor = System.Drawing.Color.Yellow;
            this.Label_Volt1.Location = new System.Drawing.Point(615, 190);
            this.Label_Volt1.Name = "Label_Volt1";
            this.Label_Volt1.Size = new System.Drawing.Size(93, 38);
            this.Label_Volt1.TabIndex = 490;
            this.Label_Volt1.Text = "--";
            this.Label_Volt1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Label_Volt4
            // 
            this.Label_Volt4.BackColor = System.Drawing.Color.Black;
            this.Label_Volt4.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.Label_Volt4.Font = new System.Drawing.Font("Nirmala UI", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label_Volt4.ForeColor = System.Drawing.Color.Yellow;
            this.Label_Volt4.Location = new System.Drawing.Point(615, 330);
            this.Label_Volt4.Name = "Label_Volt4";
            this.Label_Volt4.Size = new System.Drawing.Size(93, 38);
            this.Label_Volt4.TabIndex = 495;
            this.Label_Volt4.Text = "--";
            this.Label_Volt4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Label_Volt3
            // 
            this.Label_Volt3.BackColor = System.Drawing.Color.Black;
            this.Label_Volt3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.Label_Volt3.Font = new System.Drawing.Font("Nirmala UI", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label_Volt3.ForeColor = System.Drawing.Color.Yellow;
            this.Label_Volt3.Location = new System.Drawing.Point(615, 290);
            this.Label_Volt3.Name = "Label_Volt3";
            this.Label_Volt3.Size = new System.Drawing.Size(93, 38);
            this.Label_Volt3.TabIndex = 494;
            this.Label_Volt3.Text = "--";
            this.Label_Volt3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // listBoxEventLog
            // 
            this.listBoxEventLog.Font = new System.Drawing.Font("Nirmala UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listBoxEventLog.ForeColor = System.Drawing.Color.Black;
            this.listBoxEventLog.FormattingEnabled = true;
            this.listBoxEventLog.ItemHeight = 17;
            this.listBoxEventLog.Location = new System.Drawing.Point(3, 737);
            this.listBoxEventLog.Name = "listBoxEventLog";
            this.listBoxEventLog.Size = new System.Drawing.Size(1760, 140);
            this.listBoxEventLog.TabIndex = 504;
            // 
            // Eventlog_Display
            // 
            this.Eventlog_Display.Interval = 500;
            this.Eventlog_Display.Tick += new System.EventHandler(this.Eventlog_Display_Tick);
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Font = new System.Drawing.Font("Nirmala UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label16.Location = new System.Drawing.Point(709, 210);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(17, 17);
            this.label16.TabIndex = 513;
            this.label16.Text = "V";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Nirmala UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15.Location = new System.Drawing.Point(709, 250);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(17, 17);
            this.label15.TabIndex = 514;
            this.label15.Text = "V";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Nirmala UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.Location = new System.Drawing.Point(710, 310);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(17, 17);
            this.label14.TabIndex = 515;
            this.label14.Text = "V";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Nirmala UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.Location = new System.Drawing.Point(710, 350);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(17, 17);
            this.label13.TabIndex = 516;
            this.label13.Text = "V";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.BackColor = System.Drawing.Color.Transparent;
            this.label9.Font = new System.Drawing.Font("Tahoma", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.Color.Black;
            this.label9.Location = new System.Drawing.Point(96, 74);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(97, 24);
            this.label9.TabIndex = 518;
            this.label9.Text = "Device : ";
            // 
            // Label_Device
            // 
            this.Label_Device.AutoSize = true;
            this.Label_Device.Font = new System.Drawing.Font("Tahoma", 25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label_Device.ForeColor = System.Drawing.Color.Black;
            this.Label_Device.Location = new System.Drawing.Point(203, 64);
            this.Label_Device.Name = "Label_Device";
            this.Label_Device.Size = new System.Drawing.Size(48, 41);
            this.Label_Device.TabIndex = 517;
            this.Label_Device.Text = "--";
            // 
            // PM1Form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.label9);
            this.Controls.Add(this.Label_Device);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.label16);
            this.Controls.Add(this.listBoxEventLog);
            this.Controls.Add(this.Label_Volt4);
            this.Controls.Add(this.Label_Volt3);
            this.Controls.Add(this.Label_Volt2);
            this.Controls.Add(this.Label_Volt1);
            this.Name = "PM1Form";
            this.Size = new System.Drawing.Size(1766, 880);
            this.Load += new System.EventHandler(this.PM1Form_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label Label_Volt2;
        private System.Windows.Forms.Label Label_Volt1;
        private System.Windows.Forms.Label Label_Volt4;
        private System.Windows.Forms.Label Label_Volt3;
        public System.Windows.Forms.ListBox listBoxEventLog;
        private System.Windows.Forms.Timer Eventlog_Display;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label Label_Device;
    }
}
