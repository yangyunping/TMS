namespace GoldenLady.Dress
{
    partial class frmLogin
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmLogin));
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.cmbUserName = new System.Windows.Forms.ComboBox();
            this.chbUserName = new System.Windows.Forms.CheckBox();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.pbEmployeePhoto = new System.Windows.Forms.PictureBox();
            this.lbUpdateLog = new System.Windows.Forms.LinkLabel();
            this.lblLogin = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.cmbLine = new System.Windows.Forms.ComboBox();
            this.notify = new System.Windows.Forms.NotifyIcon(this.components);
            this.btnLogin = new System.Windows.Forms.Button();
            this.CloseForm = new System.Windows.Forms.Label();
            this.lbpwd = new System.Windows.Forms.LinkLabel();
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbEmployeePhoto)).BeginInit();
            this.SuspendLayout();
            // 
            // txtPassword
            // 
            this.txtPassword.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtPassword.Location = new System.Drawing.Point(172, 95);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.PasswordChar = '●';
            this.txtPassword.Size = new System.Drawing.Size(157, 23);
            this.txtPassword.TabIndex = 1;
            this.txtPassword.Enter += new System.EventHandler(this.txtPassword_Enter);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Location = new System.Drawing.Point(107, 60);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 4;
            this.label1.Text = "登 录 名";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Location = new System.Drawing.Point(107, 100);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 12);
            this.label2.TabIndex = 5;
            this.label2.Text = "密    码";
            // 
            // cmbUserName
            // 
            this.cmbUserName.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cmbUserName.FormattingEnabled = true;
            this.cmbUserName.Location = new System.Drawing.Point(172, 57);
            this.cmbUserName.Name = "cmbUserName";
            this.cmbUserName.Size = new System.Drawing.Size(157, 22);
            this.cmbUserName.TabIndex = 0;
            this.cmbUserName.SelectedIndexChanged += new System.EventHandler(this.cmbUserName_SelectedIndexChanged);
            this.cmbUserName.Leave += new System.EventHandler(this.cmbUserName_Leave);
            // 
            // chbUserName
            // 
            this.chbUserName.AutoSize = true;
            this.chbUserName.BackColor = System.Drawing.Color.Transparent;
            this.chbUserName.Checked = true;
            this.chbUserName.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chbUserName.Location = new System.Drawing.Point(172, 175);
            this.chbUserName.Name = "chbUserName";
            this.chbUserName.Size = new System.Drawing.Size(84, 16);
            this.chbUserName.TabIndex = 2;
            this.chbUserName.Text = "记住登录名";
            this.chbUserName.UseVisualStyleBackColor = false;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 6;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 126F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 101F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 74F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 69F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 63F));
            this.tableLayoutPanel1.Controls.Add(this.label3, 0, 0);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(200, 100);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(3, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(1, 12);
            this.label3.TabIndex = 0;
            this.label3.Text = "label3";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(116, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(41, 12);
            this.label4.TabIndex = 1;
            this.label4.Text = "label4";
            // 
            // pbEmployeePhoto
            // 
            this.pbEmployeePhoto.BackColor = System.Drawing.Color.Transparent;
            this.pbEmployeePhoto.Image = ((System.Drawing.Image)(resources.GetObject("pbEmployeePhoto.Image")));
            this.pbEmployeePhoto.Location = new System.Drawing.Point(3, 0);
            this.pbEmployeePhoto.Name = "pbEmployeePhoto";
            this.pbEmployeePhoto.Size = new System.Drawing.Size(71, 57);
            this.pbEmployeePhoto.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbEmployeePhoto.TabIndex = 20;
            this.pbEmployeePhoto.TabStop = false;
            // 
            // lbUpdateLog
            // 
            this.lbUpdateLog.ActiveLinkColor = System.Drawing.Color.MistyRose;
            this.lbUpdateLog.AutoSize = true;
            this.lbUpdateLog.BackColor = System.Drawing.Color.Transparent;
            this.lbUpdateLog.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbUpdateLog.LinkColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lbUpdateLog.Location = new System.Drawing.Point(0, 243);
            this.lbUpdateLog.Name = "lbUpdateLog";
            this.lbUpdateLog.Size = new System.Drawing.Size(63, 14);
            this.lbUpdateLog.TabIndex = 21;
            this.lbUpdateLog.TabStop = true;
            this.lbUpdateLog.Text = "更新记录";
            // 
            // lblLogin
            // 
            this.lblLogin.BackColor = System.Drawing.Color.Transparent;
            this.lblLogin.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblLogin.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblLogin.Location = new System.Drawing.Point(109, 5);
            this.lblLogin.Name = "lblLogin";
            this.lblLogin.Size = new System.Drawing.Size(246, 42);
            this.lblLogin.TabIndex = 22;
            this.lblLogin.Text = "用户登录(USER LOGIN)";
            this.lblLogin.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.PeachPuff;
            this.label6.ForeColor = System.Drawing.Color.Black;
            this.label6.Location = new System.Drawing.Point(107, 136);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(53, 12);
            this.label6.TabIndex = 23;
            this.label6.Text = "线路选择";
            // 
            // cmbLine
            // 
            this.cmbLine.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbLine.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cmbLine.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cmbLine.FormattingEnabled = true;
            this.cmbLine.Items.AddRange(new object[] {
            "内网线路",
            "电信线路",
            "铁通线路"});
            this.cmbLine.Location = new System.Drawing.Point(172, 133);
            this.cmbLine.Name = "cmbLine";
            this.cmbLine.Size = new System.Drawing.Size(157, 22);
            this.cmbLine.TabIndex = 24;
            // 
            // notify
            // 
            this.notify.Icon = ((System.Drawing.Icon)(resources.GetObject("notify.Icon")));
            this.notify.Text = "金牌流程管理系统";
            // 
            // btnLogin
            // 
            this.btnLogin.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.btnLogin.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnLogin.Location = new System.Drawing.Point(109, 208);
            this.btnLogin.Name = "btnLogin";
            this.btnLogin.Size = new System.Drawing.Size(220, 28);
            this.btnLogin.TabIndex = 26;
            this.btnLogin.Text = "登   录";
            this.btnLogin.UseVisualStyleBackColor = false;
            this.btnLogin.Click += new System.EventHandler(this.btnLogin_Click);
            // 
            // CloseForm
            // 
            this.CloseForm.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.CloseForm.BackColor = System.Drawing.Color.Transparent;
            this.CloseForm.Font = new System.Drawing.Font("微软雅黑", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.CloseForm.Location = new System.Drawing.Point(392, 0);
            this.CloseForm.Name = "CloseForm";
            this.CloseForm.Size = new System.Drawing.Size(32, 31);
            this.CloseForm.TabIndex = 28;
            this.CloseForm.Text = "×";
            this.CloseForm.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbpwd
            // 
            this.lbpwd.AutoSize = true;
            this.lbpwd.Location = new System.Drawing.Point(270, 176);
            this.lbpwd.Name = "lbpwd";
            this.lbpwd.Size = new System.Drawing.Size(59, 12);
            this.lbpwd.TabIndex = 29;
            this.lbpwd.TabStop = true;
            this.lbpwd.Text = "忘记密码?";
            this.lbpwd.Visible = false;
            this.lbpwd.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lbpwd_LinkClicked);
            // 
            // linkLabel1
            // 
            this.linkLabel1.ActiveLinkColor = System.Drawing.Color.MistyRose;
            this.linkLabel1.AutoSize = true;
            this.linkLabel1.BackColor = System.Drawing.Color.Transparent;
            this.linkLabel1.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.linkLabel1.LinkColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.linkLabel1.Location = new System.Drawing.Point(361, 243);
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.Size = new System.Drawing.Size(63, 14);
            this.linkLabel1.TabIndex = 30;
            this.linkLabel1.TabStop = true;
            this.linkLabel1.Text = "故障处理";
            // 
            // frmLogin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(423, 261);
            this.Controls.Add(this.linkLabel1);
            this.Controls.Add(this.lbpwd);
            this.Controls.Add(this.CloseForm);
            this.Controls.Add(this.btnLogin);
            this.Controls.Add(this.pbEmployeePhoto);
            this.Controls.Add(this.lbUpdateLog);
            this.Controls.Add(this.cmbLine);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.lblLogin);
            this.Controls.Add(this.chbUserName);
            this.Controls.Add(this.cmbUserName);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtPassword);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmLogin";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "登录验证";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmLogin_FormClosing);
            this.Load += new System.EventHandler(this.frmLogin_Load);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.frmLogin_Paint);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmLogin_KeyDown);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbEmployeePhoto)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmbUserName;
        private System.Windows.Forms.CheckBox chbUserName;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.PictureBox pbEmployeePhoto;
        private System.Windows.Forms.Label lblLogin;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox cmbLine;
        private System.Windows.Forms.LinkLabel lbUpdateLog;
        private System.Windows.Forms.NotifyIcon notify;
        private System.Windows.Forms.Button btnLogin;
        private System.Windows.Forms.Label CloseForm;
        private System.Windows.Forms.LinkLabel lbpwd;
        private System.Windows.Forms.LinkLabel linkLabel1;
    }
}

