namespace GoldenLady.SMSNew
{
    partial class frmSearch
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
            this.ckbAllTime = new System.Windows.Forms.CheckBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.ckbCancel = new System.Windows.Forms.CheckBox();
            this.ckbNotSent = new System.Windows.Forms.CheckBox();
            this.ckbSucceed = new System.Windows.Forms.CheckBox();
            this.ckbFailed = new System.Windows.Forms.CheckBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnSearch = new System.Windows.Forms.Button();
            this.txtKey = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.dtpEnd = new System.Windows.Forms.DateTimePicker();
            this.dtpStart = new System.Windows.Forms.DateTimePicker();
            this.grbResult = new System.Windows.Forms.GroupBox();
            this.dgvSearchResult = new System.Windows.Forms.DataGridView();
            this.id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column9 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cms = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.tsmiResend = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiDelete = new System.Windows.Forms.ToolStripMenuItem();
            this.groupBox1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.grbResult.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSearchResult)).BeginInit();
            this.cms.SuspendLayout();
            this.SuspendLayout();
            // 
            // ckbAllTime
            // 
            this.ckbAllTime.AutoSize = true;
            this.ckbAllTime.Location = new System.Drawing.Point(192, 23);
            this.ckbAllTime.Name = "ckbAllTime";
            this.ckbAllTime.Size = new System.Drawing.Size(84, 16);
            this.ckbAllTime.TabIndex = 3;
            this.ckbAllTime.Text = "全部时间段";
            this.ckbAllTime.UseVisualStyleBackColor = true;
            this.ckbAllTime.CheckedChanged += new System.EventHandler(this.ckbAllTime_CheckedChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.panel2);
            this.groupBox1.Controls.Add(this.panel1);
            this.groupBox1.Controls.Add(this.ckbAllTime);
            this.groupBox1.Controls.Add(this.dtpEnd);
            this.groupBox1.Controls.Add(this.dtpStart);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(557, 104);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "输入查询条件";
            // 
            // panel2
            // 
            this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel2.Controls.Add(this.ckbCancel);
            this.panel2.Controls.Add(this.ckbNotSent);
            this.panel2.Controls.Add(this.ckbSucceed);
            this.panel2.Controls.Add(this.ckbFailed);
            this.panel2.Location = new System.Drawing.Point(282, 12);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(269, 33);
            this.panel2.TabIndex = 5;
            // 
            // ckbCancel
            // 
            this.ckbCancel.AutoSize = true;
            this.ckbCancel.Location = new System.Drawing.Point(177, 9);
            this.ckbCancel.Name = "ckbCancel";
            this.ckbCancel.Size = new System.Drawing.Size(84, 16);
            this.ckbCancel.TabIndex = 17;
            this.ckbCancel.Text = "已取消发送";
            this.ckbCancel.UseVisualStyleBackColor = true;
            this.ckbCancel.CheckedChanged += new System.EventHandler(this.ckbCancel_CheckedChanged);
            // 
            // ckbNotSent
            // 
            this.ckbNotSent.AutoSize = true;
            this.ckbNotSent.Location = new System.Drawing.Point(111, 9);
            this.ckbNotSent.Name = "ckbNotSent";
            this.ckbNotSent.Size = new System.Drawing.Size(60, 16);
            this.ckbNotSent.TabIndex = 16;
            this.ckbNotSent.Text = "未发送";
            this.ckbNotSent.UseVisualStyleBackColor = true;
            this.ckbNotSent.CheckedChanged += new System.EventHandler(this.ckbNotSent_CheckedChanged);
            // 
            // ckbSucceed
            // 
            this.ckbSucceed.AutoSize = true;
            this.ckbSucceed.Location = new System.Drawing.Point(3, 9);
            this.ckbSucceed.Name = "ckbSucceed";
            this.ckbSucceed.Size = new System.Drawing.Size(48, 16);
            this.ckbSucceed.TabIndex = 14;
            this.ckbSucceed.Text = "成功";
            this.ckbSucceed.UseVisualStyleBackColor = true;
            this.ckbSucceed.CheckedChanged += new System.EventHandler(this.ckbSucceed_CheckedChanged);
            // 
            // ckbFailed
            // 
            this.ckbFailed.AutoSize = true;
            this.ckbFailed.Location = new System.Drawing.Point(57, 9);
            this.ckbFailed.Name = "ckbFailed";
            this.ckbFailed.Size = new System.Drawing.Size(48, 16);
            this.ckbFailed.TabIndex = 15;
            this.ckbFailed.Text = "失败";
            this.ckbFailed.UseVisualStyleBackColor = true;
            this.ckbFailed.CheckedChanged += new System.EventHandler(this.ckbFailed_CheckedChanged);
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.btnSearch);
            this.panel1.Controls.Add(this.txtKey);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(7, 55);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(544, 43);
            this.panel1.TabIndex = 4;
            // 
            // btnSearch
            // 
            this.btnSearch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSearch.Location = new System.Drawing.Point(463, 9);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(75, 23);
            this.btnSearch.TabIndex = 8;
            this.btnSearch.Text = "查询";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // txtKey
            // 
            this.txtKey.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txtKey.Location = new System.Drawing.Point(56, 9);
            this.txtKey.Name = "txtKey";
            this.txtKey.Size = new System.Drawing.Size(401, 21);
            this.txtKey.TabIndex = 7;
            this.txtKey.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtKey_KeyDown);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 14);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 12);
            this.label1.TabIndex = 6;
            this.label1.Text = "关键字";
            // 
            // dtpEnd
            // 
            this.dtpEnd.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpEnd.Location = new System.Drawing.Point(99, 20);
            this.dtpEnd.Name = "dtpEnd";
            this.dtpEnd.Size = new System.Drawing.Size(87, 21);
            this.dtpEnd.TabIndex = 2;
            this.dtpEnd.ValueChanged += new System.EventHandler(this.dtpEnd_ValueChanged);
            // 
            // dtpStart
            // 
            this.dtpStart.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpStart.Location = new System.Drawing.Point(6, 20);
            this.dtpStart.Name = "dtpStart";
            this.dtpStart.Size = new System.Drawing.Size(87, 21);
            this.dtpStart.TabIndex = 0;
            this.dtpStart.ValueChanged += new System.EventHandler(this.dtpStart_ValueChanged);
            // 
            // grbResult
            // 
            this.grbResult.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.grbResult.Controls.Add(this.dgvSearchResult);
            this.grbResult.Location = new System.Drawing.Point(12, 123);
            this.grbResult.Name = "grbResult";
            this.grbResult.Size = new System.Drawing.Size(557, 216);
            this.grbResult.TabIndex = 1;
            this.grbResult.TabStop = false;
            this.grbResult.Text = "查询结果 共0条";
            // 
            // dgvSearchResult
            // 
            this.dgvSearchResult.AllowUserToAddRows = false;
            this.dgvSearchResult.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvSearchResult.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvSearchResult.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.id,
            this.Column9,
            this.Column6,
            this.Column1,
            this.Column2,
            this.Column3,
            this.Column4,
            this.Column5,
            this.Column7,
            this.Column8});
            this.dgvSearchResult.ContextMenuStrip = this.cms;
            this.dgvSearchResult.Location = new System.Drawing.Point(7, 21);
            this.dgvSearchResult.Name = "dgvSearchResult";
            this.dgvSearchResult.ReadOnly = true;
            this.dgvSearchResult.RowTemplate.Height = 23;
            this.dgvSearchResult.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvSearchResult.Size = new System.Drawing.Size(539, 189);
            this.dgvSearchResult.TabIndex = 0;
            this.dgvSearchResult.SelectionChanged += new System.EventHandler(this.dgvSearchResult_SelectionChanged);
            // 
            // id
            // 
            this.id.DataPropertyName = "smsid";
            this.id.HeaderText = "短信编号";
            this.id.Name = "id";
            this.id.ReadOnly = true;
            this.id.Visible = false;
            // 
            // Column9
            // 
            this.Column9.DataPropertyName = "customername";
            this.Column9.HeaderText = "顾客姓名";
            this.Column9.Name = "Column9";
            this.Column9.ReadOnly = true;
            // 
            // Column6
            // 
            this.Column6.DataPropertyName = "customerno";
            this.Column6.HeaderText = "客户号";
            this.Column6.Name = "Column6";
            this.Column6.ReadOnly = true;
            // 
            // Column1
            // 
            this.Column1.DataPropertyName = "customersex";
            this.Column1.HeaderText = "性别";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            this.Column1.Width = 40;
            // 
            // Column2
            // 
            this.Column2.DataPropertyName = "smsphone";
            this.Column2.HeaderText = "手机号码";
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            this.Column2.Width = 85;
            // 
            // Column3
            // 
            this.Column3.DataPropertyName = "smscontent";
            this.Column3.HeaderText = "短信内容";
            this.Column3.Name = "Column3";
            this.Column3.ReadOnly = true;
            // 
            // Column4
            // 
            this.Column4.DataPropertyName = "smstime";
            this.Column4.HeaderText = "发送时间";
            this.Column4.Name = "Column4";
            this.Column4.ReadOnly = true;
            this.Column4.Width = 120;
            // 
            // Column5
            // 
            this.Column5.DataPropertyName = "smsstatus";
            this.Column5.HeaderText = "发送状态";
            this.Column5.Name = "Column5";
            this.Column5.ReadOnly = true;
            this.Column5.Width = 80;
            // 
            // Column7
            // 
            this.Column7.DataPropertyName = "name";
            this.Column7.HeaderText = "短信类别";
            this.Column7.Name = "Column7";
            this.Column7.ReadOnly = true;
            // 
            // Column8
            // 
            this.Column8.DataPropertyName = "employeeno";
            this.Column8.HeaderText = "操作人员";
            this.Column8.Name = "Column8";
            this.Column8.ReadOnly = true;
            // 
            // cms
            // 
            this.cms.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiResend,
            this.tsmiDelete});
            this.cms.Name = "cms";
            this.cms.Size = new System.Drawing.Size(119, 48);
            this.cms.Opened += new System.EventHandler(this.cms_Opened);
            // 
            // tsmiResend
            // 
            this.tsmiResend.Name = "tsmiResend";
            this.tsmiResend.Size = new System.Drawing.Size(118, 22);
            this.tsmiResend.Text = "重新发送";
            this.tsmiResend.Click += new System.EventHandler(this.tsmiResend_Click);
            // 
            // tsmiDelete
            // 
            this.tsmiDelete.Name = "tsmiDelete";
            this.tsmiDelete.Size = new System.Drawing.Size(118, 22);
            this.tsmiDelete.Text = "删除";
            this.tsmiDelete.Click += new System.EventHandler(this.tsmiDelete_Click);
            // 
            // frmSearch
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(581, 351);
            this.Controls.Add(this.grbResult);
            this.Controls.Add(this.groupBox1);
            this.MinimumSize = new System.Drawing.Size(589, 385);
            this.Name = "frmSearch";
            this.Opacity = 0.95;
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "短信查询";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.grbResult.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvSearchResult)).EndInit();
            this.cms.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DateTimePicker dtpStart;
        private System.Windows.Forms.DateTimePicker dtpEnd;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox txtKey;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.CheckBox ckbNotSent;
        private System.Windows.Forms.CheckBox ckbSucceed;
        private System.Windows.Forms.CheckBox ckbFailed;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.GroupBox grbResult;
        private System.Windows.Forms.DataGridView dgvSearchResult;
        private System.Windows.Forms.CheckBox ckbAllTime;
        private System.Windows.Forms.ContextMenuStrip cms;
        private System.Windows.Forms.ToolStripMenuItem tsmiDelete;
        private System.Windows.Forms.CheckBox ckbCancel;
        private System.Windows.Forms.DataGridViewTextBoxColumn id;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column9;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column6;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column5;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column7;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column8;
        private System.Windows.Forms.ToolStripMenuItem tsmiResend;
    }
}