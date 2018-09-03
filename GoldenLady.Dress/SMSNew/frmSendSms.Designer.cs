namespace GoldenLady.SMSNew
{
    partial class frmSendSms
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtPhone = new System.Windows.Forms.TextBox();
            this.cmsTxtPhone = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.tsmiExcelIn = new System.Windows.Forms.ToolStripMenuItem();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.lblLength = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.cmbAi = new System.Windows.Forms.ComboBox();
            this.txtSendContent = new System.Windows.Forms.TextBox();
            this.sts = new System.Windows.Forms.StatusStrip();
            this.tslSmsCount = new System.Windows.Forms.ToolStripStatusLabel();
            this.lkbBalance = new System.Windows.Forms.LinkLabel();
            this.ofdPhoneFile = new System.Windows.Forms.OpenFileDialog();
            this.dtpHMS = new System.Windows.Forms.DateTimePicker();
            this.dtpYMD = new System.Windows.Forms.DateTimePicker();
            this.ckbTiming = new System.Windows.Forms.CheckBox();
            this.btnSend = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.cmsTxtPhone.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.sts.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtPhone);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.groupBox1.Size = new System.Drawing.Size(456, 114);
            this.groupBox1.TabIndex = 9;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "请在下面输入手机号";
            // 
            // txtPhone
            // 
            this.txtPhone.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtPhone.ContextMenuStrip = this.cmsTxtPhone;
            this.txtPhone.Location = new System.Drawing.Point(8, 33);
            this.txtPhone.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtPhone.Multiline = true;
            this.txtPhone.Name = "txtPhone";
            this.txtPhone.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtPhone.Size = new System.Drawing.Size(438, 71);
            this.txtPhone.TabIndex = 1;
            this.txtPhone.TextChanged += new System.EventHandler(this.txtPhone_TextChanged);
            this.txtPhone.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtPhone_KeyPress);
            // 
            // cmsTxtPhone
            // 
            this.cmsTxtPhone.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiExcelIn});
            this.cmsTxtPhone.Name = "cmsTxtPhone";
            this.cmsTxtPhone.Size = new System.Drawing.Size(130, 26);
            // 
            // tsmiExcelIn
            // 
            this.tsmiExcelIn.Name = "tsmiExcelIn";
            this.tsmiExcelIn.Size = new System.Drawing.Size(129, 22);
            this.tsmiExcelIn.Text = "Excel导入";
            this.tsmiExcelIn.Click += new System.EventHandler(this.tsmiExcelIn_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.lblLength);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.cmbAi);
            this.groupBox2.Controls.Add(this.txtSendContent);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox2.Location = new System.Drawing.Point(0, 114);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.groupBox2.Size = new System.Drawing.Size(456, 191);
            this.groupBox2.TabIndex = 10;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "请在下面输入短信内容";
            // 
            // lblLength
            // 
            this.lblLength.AutoSize = true;
            this.lblLength.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblLength.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblLength.Location = new System.Drawing.Point(367, 38);
            this.lblLength.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblLength.Name = "lblLength";
            this.lblLength.Size = new System.Drawing.Size(75, 22);
            this.lblLength.TabIndex = 10;
            this.lblLength.Text = "已输入0字";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.label1.Location = new System.Drawing.Point(256, 39);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(93, 20);
            this.label1.TabIndex = 9;
            this.label1.Text = "选择常用短语";
            // 
            // cmbAi
            // 
            this.cmbAi.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbAi.FormattingEnabled = true;
            this.cmbAi.Location = new System.Drawing.Point(8, 35);
            this.cmbAi.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cmbAi.Name = "cmbAi";
            this.cmbAi.Size = new System.Drawing.Size(239, 28);
            this.cmbAi.TabIndex = 7;
            this.cmbAi.SelectedIndexChanged += new System.EventHandler(this.cmbAi_SelectedIndexChanged);
            // 
            // txtSendContent
            // 
            this.txtSendContent.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtSendContent.Location = new System.Drawing.Point(7, 77);
            this.txtSendContent.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtSendContent.Multiline = true;
            this.txtSendContent.Name = "txtSendContent";
            this.txtSendContent.Size = new System.Drawing.Size(440, 102);
            this.txtSendContent.TabIndex = 6;
            this.txtSendContent.TextChanged += new System.EventHandler(this.txtSendContent_TextChanged);
            // 
            // sts
            // 
            this.sts.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tslSmsCount});
            this.sts.Location = new System.Drawing.Point(0, 371);
            this.sts.Name = "sts";
            this.sts.Padding = new System.Windows.Forms.Padding(1, 0, 19, 0);
            this.sts.Size = new System.Drawing.Size(456, 22);
            this.sts.TabIndex = 11;
            this.sts.Text = "statusStrip1";
            // 
            // tslSmsCount
            // 
            this.tslSmsCount.Name = "tslSmsCount";
            this.tslSmsCount.Size = new System.Drawing.Size(75, 17);
            this.tslSmsCount.Text = "即将发送0条";
            // 
            // lkbBalance
            // 
            this.lkbBalance.AutoSize = true;
            this.lkbBalance.Location = new System.Drawing.Point(121, 328);
            this.lkbBalance.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lkbBalance.Name = "lkbBalance";
            this.lkbBalance.Size = new System.Drawing.Size(37, 20);
            this.lkbBalance.TabIndex = 12;
            this.lkbBalance.TabStop = true;
            this.lkbBalance.Text = "余额";
            this.lkbBalance.Click += new System.EventHandler(this.lkbBalance_Click);
            // 
            // ofdPhoneFile
            // 
            this.ofdPhoneFile.FileOk += new System.ComponentModel.CancelEventHandler(this.ofdPhoneFile_FileOk);
            // 
            // dtpHMS
            // 
            this.dtpHMS.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.dtpHMS.Enabled = false;
            this.dtpHMS.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.dtpHMS.Location = new System.Drawing.Point(360, 325);
            this.dtpHMS.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.dtpHMS.Name = "dtpHMS";
            this.dtpHMS.Size = new System.Drawing.Size(93, 26);
            this.dtpHMS.TabIndex = 16;
            // 
            // dtpYMD
            // 
            this.dtpYMD.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.dtpYMD.Enabled = false;
            this.dtpYMD.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpYMD.Location = new System.Drawing.Point(254, 325);
            this.dtpYMD.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.dtpYMD.Name = "dtpYMD";
            this.dtpYMD.Size = new System.Drawing.Size(98, 26);
            this.dtpYMD.TabIndex = 15;
            // 
            // ckbTiming
            // 
            this.ckbTiming.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.ckbTiming.AutoSize = true;
            this.ckbTiming.Enabled = false;
            this.ckbTiming.Location = new System.Drawing.Point(191, 326);
            this.ckbTiming.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.ckbTiming.Name = "ckbTiming";
            this.ckbTiming.Size = new System.Drawing.Size(56, 24);
            this.ckbTiming.TabIndex = 14;
            this.ckbTiming.Text = "定时";
            this.ckbTiming.UseVisualStyleBackColor = true;
            // 
            // btnSend
            // 
            this.btnSend.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnSend.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.btnSend.Location = new System.Drawing.Point(13, 319);
            this.btnSend.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnSend.Name = "btnSend";
            this.btnSend.Size = new System.Drawing.Size(100, 38);
            this.btnSend.TabIndex = 13;
            this.btnSend.Text = "发送";
            this.btnSend.UseVisualStyleBackColor = false;
            this.btnSend.Click += new System.EventHandler(this.btnSend_Click);
            // 
            // frmSendSms
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(456, 393);
            this.Controls.Add(this.dtpHMS);
            this.Controls.Add(this.dtpYMD);
            this.Controls.Add(this.ckbTiming);
            this.Controls.Add(this.btnSend);
            this.Controls.Add(this.lkbBalance);
            this.Controls.Add(this.sts);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.MaximizeBox = false;
            this.Name = "frmSendSms";
            this.Opacity = 0.95D;
            this.ShowIcon = false;
            this.Text = "发送短信";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmSendSms_FormClosing);
            this.Load += new System.EventHandler(this.frmSendSms_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.cmsTxtPhone.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.sts.ResumeLayout(false);
            this.sts.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txtPhone;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.ComboBox cmbAi;
        private System.Windows.Forms.TextBox txtSendContent;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblLength;
        private System.Windows.Forms.StatusStrip sts;
        private System.Windows.Forms.ToolStripStatusLabel tslSmsCount;
        private System.Windows.Forms.LinkLabel lkbBalance;
        private System.Windows.Forms.ContextMenuStrip cmsTxtPhone;
        private System.Windows.Forms.ToolStripMenuItem tsmiExcelIn;
        private System.Windows.Forms.OpenFileDialog ofdPhoneFile;
        private System.Windows.Forms.DateTimePicker dtpHMS;
        private System.Windows.Forms.DateTimePicker dtpYMD;
        private System.Windows.Forms.CheckBox ckbTiming;
        private System.Windows.Forms.Button btnSend;
    }
}