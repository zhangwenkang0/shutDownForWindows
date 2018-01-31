namespace ShuntDoneWindows
{  
    partial class ShuntDone
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ShuntDone));
            this.label1 = new System.Windows.Forms.Label();
            this.textDateTime = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.dtpCurrentDate = new System.Windows.Forms.DateTimePicker();
            this.dtpCurrentTime = new System.Windows.Forms.DateTimePicker();
            this.btnHide = new System.Windows.Forms.Button();
            this.tmrMainClock = new System.Windows.Forms.Timer(this.components);
            this.notifyIcon1 = new System.Windows.Forms.NotifyIcon(this.components);
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.menuItemShowMainForm = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemExit = new System.Windows.Forms.ToolStripMenuItem();
            this.btnOut = new System.Windows.Forms.Button();
            this.btnStart = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.lblState1 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.lblState2 = new System.Windows.Forms.Label();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(55, 32);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(59, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "当前时间 ";
            // 
            // textDateTime
            // 
            this.textDateTime.Location = new System.Drawing.Point(146, 32);
            this.textDateTime.Name = "textDateTime";
            this.textDateTime.ReadOnly = true;
            this.textDateTime.Size = new System.Drawing.Size(203, 21);
            this.textDateTime.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(55, 82);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(77, 12);
            this.label2.TabIndex = 2;
            this.label2.Text = "设计关机时间";
            // 
            // dtpCurrentDate
            // 
            this.dtpCurrentDate.Location = new System.Drawing.Point(146, 82);
            this.dtpCurrentDate.Name = "dtpCurrentDate";
            this.dtpCurrentDate.Size = new System.Drawing.Size(109, 21);
            this.dtpCurrentDate.TabIndex = 3;
            // 
            // dtpCurrentTime
            // 
            this.dtpCurrentTime.CustomFormat = "";
            this.dtpCurrentTime.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.dtpCurrentTime.Location = new System.Drawing.Point(261, 82);
            this.dtpCurrentTime.Name = "dtpCurrentTime";
            this.dtpCurrentTime.ShowUpDown = true;
            this.dtpCurrentTime.Size = new System.Drawing.Size(88, 21);
            this.dtpCurrentTime.TabIndex = 4;
            // 
            // btnHide
            // 
            this.btnHide.Location = new System.Drawing.Point(201, 140);
            this.btnHide.Name = "btnHide";
            this.btnHide.Size = new System.Drawing.Size(66, 23);
            this.btnHide.TabIndex = 6;
            this.btnHide.Text = "隐藏";
            this.btnHide.UseVisualStyleBackColor = true;
            this.btnHide.Click += new System.EventHandler(this.btnHide_Click);
            // 
            // tmrMainClock
            // 
            this.tmrMainClock.Interval = 1000;
            this.tmrMainClock.Tick += new System.EventHandler(this.tmrMainClock_Tick);
            // 
            // notifyIcon1
            // 
            this.notifyIcon1.ContextMenuStrip = this.contextMenuStrip1;
            this.notifyIcon1.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon1.Icon")));
            this.notifyIcon1.Text = "定时关机";
            this.notifyIcon1.Visible = true;
            this.notifyIcon1.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.notifyIcon1_MouseDoubleClick);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuItemShowMainForm,
            this.menuItemExit});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(135, 48);
            // 
            // menuItemShowMainForm
            // 
            this.menuItemShowMainForm.Name = "menuItemShowMainForm";
            this.menuItemShowMainForm.Size = new System.Drawing.Size(134, 22);
            this.menuItemShowMainForm.Text = "显示主界面";
            this.menuItemShowMainForm.Click += new System.EventHandler(this.menuItemShowMainForm_Click);
            // 
            // menuItemExit
            // 
            this.menuItemExit.Name = "menuItemExit";
            this.menuItemExit.Size = new System.Drawing.Size(134, 22);
            this.menuItemExit.Text = "退出";
            this.menuItemExit.Click += new System.EventHandler(this.menuItemExit_Click);
            // 
            // btnOut
            // 
            this.btnOut.Location = new System.Drawing.Point(274, 140);
            this.btnOut.Name = "btnOut";
            this.btnOut.Size = new System.Drawing.Size(75, 23);
            this.btnOut.TabIndex = 7;
            this.btnOut.Text = "退出";
            this.btnOut.UseVisualStyleBackColor = true;
            this.btnOut.Click += new System.EventHandler(this.btnOut_Click);
            // 
            // btnStart
            // 
            this.btnStart.Location = new System.Drawing.Point(39, 140);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(75, 23);
            this.btnStart.TabIndex = 8;
            this.btnStart.Text = "启动";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(120, 140);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 9;
            this.btnCancel.Text = "取消";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // lblState1
            // 
            this.lblState1.AutoSize = true;
            this.lblState1.Location = new System.Drawing.Point(39, 122);
            this.lblState1.Name = "lblState1";
            this.lblState1.Size = new System.Drawing.Size(35, 12);
            this.lblState1.TabIndex = 10;
            this.lblState1.Text = "状态:";
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(0, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(100, 23);
            this.label4.TabIndex = 13;
            // 
            // lblState2
            // 
            this.lblState2.AutoSize = true;
            this.lblState2.Location = new System.Drawing.Point(73, 122);
            this.lblState2.Name = "lblState2";
            this.lblState2.Size = new System.Drawing.Size(0, 12);
            this.lblState2.TabIndex = 12;
            // 
            // ShuntDone
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(382, 185);
            this.Controls.Add(this.lblState2);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.lblState1);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnStart);
            this.Controls.Add(this.btnOut);
            this.Controls.Add(this.btnHide);
            this.Controls.Add(this.dtpCurrentTime);
            this.Controls.Add(this.dtpCurrentDate);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.textDateTime);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "ShuntDone";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "定时关机";
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textDateTime;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker dtpCurrentDate;
        private System.Windows.Forms.DateTimePicker dtpCurrentTime;
        private System.Windows.Forms.Button btnHide;
        private System.Windows.Forms.Timer tmrMainClock;
        private System.Windows.Forms.NotifyIcon notifyIcon1;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem menuItemShowMainForm;
        private System.Windows.Forms.ToolStripMenuItem menuItemExit;
        private System.Windows.Forms.Button btnOut;
        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Label lblState1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lblState2;
    }
}