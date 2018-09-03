namespace GoldenLady.Dress.View
{
    partial class FrmDressInOut
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

        #region 组件设计器生成的代码

        /// <summary> 
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panel1 = new System.Windows.Forms.Panel();
            this.picImage = new System.Windows.Forms.PictureBox();
            this.dtpEnd = new System.Windows.Forms.DateTimePicker();
            this.dtpBegin = new System.Windows.Forms.DateTimePicker();
            this.chkDate = new System.Windows.Forms.CheckBox();
            this.btnDressChooseFinish = new System.Windows.Forms.Button();
            this.lblStyle = new System.Windows.Forms.Label();
            this.btnManageSearch = new System.Windows.Forms.Button();
            this.grbInformation = new System.Windows.Forms.GroupBox();
            this.chkSmall = new System.Windows.Forms.CheckBox();
            this.cmbMoblePhone = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.lblCusName = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtDressbarcode = new System.Windows.Forms.TextBox();
            this.lblName = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtEmpNO = new System.Windows.Forms.TextBox();
            this.btnout = new System.Windows.Forms.Button();
            this.btnIn = new System.Windows.Forms.Button();
            this.dgvShow = new System.Windows.Forms.DataGridView();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picImage)).BeginInit();
            this.grbInformation.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvShow)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.picImage);
            this.panel1.Controls.Add(this.dtpEnd);
            this.panel1.Controls.Add(this.dtpBegin);
            this.panel1.Controls.Add(this.chkDate);
            this.panel1.Controls.Add(this.btnDressChooseFinish);
            this.panel1.Controls.Add(this.lblStyle);
            this.panel1.Controls.Add(this.btnManageSearch);
            this.panel1.Controls.Add(this.grbInformation);
            this.panel1.Controls.Add(this.btnout);
            this.panel1.Controls.Add(this.btnIn);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel1.Location = new System.Drawing.Point(632, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(295, 814);
            this.panel1.TabIndex = 0;
            // 
            // picImage
            // 
            this.picImage.Location = new System.Drawing.Point(37, 544);
            this.picImage.Name = "picImage";
            this.picImage.Size = new System.Drawing.Size(224, 267);
            this.picImage.TabIndex = 15;
            this.picImage.TabStop = false;
            this.picImage.Click += new System.EventHandler(this.picImage_Click);
            // 
            // dtpEnd
            // 
            this.dtpEnd.Enabled = false;
            this.dtpEnd.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpEnd.Location = new System.Drawing.Point(110, 447);
            this.dtpEnd.Name = "dtpEnd";
            this.dtpEnd.Size = new System.Drawing.Size(151, 26);
            this.dtpEnd.TabIndex = 14;
            // 
            // dtpBegin
            // 
            this.dtpBegin.Enabled = false;
            this.dtpBegin.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpBegin.Location = new System.Drawing.Point(110, 404);
            this.dtpBegin.Name = "dtpBegin";
            this.dtpBegin.Size = new System.Drawing.Size(151, 26);
            this.dtpBegin.TabIndex = 13;
            // 
            // chkDate
            // 
            this.chkDate.AutoSize = true;
            this.chkDate.Location = new System.Drawing.Point(37, 405);
            this.chkDate.Name = "chkDate";
            this.chkDate.Size = new System.Drawing.Size(56, 24);
            this.chkDate.TabIndex = 12;
            this.chkDate.Text = "日期";
            this.chkDate.UseVisualStyleBackColor = true;
            this.chkDate.CheckedChanged += new System.EventHandler(this.chkDate_CheckedChanged);
            // 
            // btnDressChooseFinish
            // 
            this.btnDressChooseFinish.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.btnDressChooseFinish.Location = new System.Drawing.Point(171, 488);
            this.btnDressChooseFinish.Name = "btnDressChooseFinish";
            this.btnDressChooseFinish.Size = new System.Drawing.Size(90, 40);
            this.btnDressChooseFinish.TabIndex = 11;
            this.btnDressChooseFinish.Text = "选衣完成";
            this.btnDressChooseFinish.UseVisualStyleBackColor = false;
            this.btnDressChooseFinish.Click += new System.EventHandler(this.btnDressChooseFinish_Click);
            // 
            // lblStyle
            // 
            this.lblStyle.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblStyle.AutoSize = true;
            this.lblStyle.BackColor = System.Drawing.Color.Linen;
            this.lblStyle.Font = new System.Drawing.Font("微软雅黑", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblStyle.Location = new System.Drawing.Point(119, 13);
            this.lblStyle.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblStyle.Name = "lblStyle";
            this.lblStyle.Size = new System.Drawing.Size(88, 25);
            this.lblStyle.TabIndex = 10;
            this.lblStyle.Text = "礼服进出";
            // 
            // btnManageSearch
            // 
            this.btnManageSearch.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.btnManageSearch.Location = new System.Drawing.Point(37, 488);
            this.btnManageSearch.Name = "btnManageSearch";
            this.btnManageSearch.Size = new System.Drawing.Size(93, 40);
            this.btnManageSearch.TabIndex = 8;
            this.btnManageSearch.Text = "管理查询";
            this.btnManageSearch.UseVisualStyleBackColor = false;
            this.btnManageSearch.Click += new System.EventHandler(this.btnManageSearch_Click);
            // 
            // grbInformation
            // 
            this.grbInformation.BackColor = System.Drawing.Color.White;
            this.grbInformation.Controls.Add(this.chkSmall);
            this.grbInformation.Controls.Add(this.cmbMoblePhone);
            this.grbInformation.Controls.Add(this.label6);
            this.grbInformation.Controls.Add(this.lblCusName);
            this.grbInformation.Controls.Add(this.label5);
            this.grbInformation.Controls.Add(this.label1);
            this.grbInformation.Controls.Add(this.txtDressbarcode);
            this.grbInformation.Controls.Add(this.lblName);
            this.grbInformation.Controls.Add(this.label2);
            this.grbInformation.Controls.Add(this.label3);
            this.grbInformation.Controls.Add(this.txtEmpNO);
            this.grbInformation.Location = new System.Drawing.Point(3, 107);
            this.grbInformation.Name = "grbInformation";
            this.grbInformation.Size = new System.Drawing.Size(289, 279);
            this.grbInformation.TabIndex = 9;
            this.grbInformation.TabStop = false;
            // 
            // chkSmall
            // 
            this.chkSmall.AutoSize = true;
            this.chkSmall.Location = new System.Drawing.Point(107, 248);
            this.chkSmall.Name = "chkSmall";
            this.chkSmall.Size = new System.Drawing.Size(56, 24);
            this.chkSmall.TabIndex = 13;
            this.chkSmall.Text = "小件";
            this.chkSmall.UseVisualStyleBackColor = true;
            // 
            // cmbMoblePhone
            // 
            this.cmbMoblePhone.FormattingEnabled = true;
            this.cmbMoblePhone.Location = new System.Drawing.Point(107, 122);
            this.cmbMoblePhone.Name = "cmbMoblePhone";
            this.cmbMoblePhone.Size = new System.Drawing.Size(151, 28);
            this.cmbMoblePhone.TabIndex = 12;
            this.cmbMoblePhone.SelectedValueChanged += new System.EventHandler(this.cmbMoblePhone_SelectedValueChanged);
            this.cmbMoblePhone.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cmbMoblePhone_KeyDown);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(30, 126);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(65, 20);
            this.label6.TabIndex = 10;
            this.label6.Text = "顾客电话";
            // 
            // lblCusName
            // 
            this.lblCusName.AutoSize = true;
            this.lblCusName.Location = new System.Drawing.Point(106, 175);
            this.lblCusName.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblCusName.Name = "lblCusName";
            this.lblCusName.Size = new System.Drawing.Size(0, 20);
            this.lblCusName.TabIndex = 9;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(30, 175);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(65, 20);
            this.label5.TabIndex = 8;
            this.label5.Text = "顾客姓名";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(30, 219);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "礼服条码";
            // 
            // txtDressbarcode
            // 
            this.txtDressbarcode.BackColor = System.Drawing.Color.Snow;
            this.txtDressbarcode.Location = new System.Drawing.Point(107, 216);
            this.txtDressbarcode.Name = "txtDressbarcode";
            this.txtDressbarcode.Size = new System.Drawing.Size(151, 26);
            this.txtDressbarcode.TabIndex = 1;
            this.txtDressbarcode.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtDressbarcode_KeyDown);
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Location = new System.Drawing.Point(106, 83);
            this.lblName.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(0, 20);
            this.lblName.TabIndex = 7;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(29, 37);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 20);
            this.label2.TabIndex = 2;
            this.label2.Text = "员工工号";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(30, 83);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 20);
            this.label3.TabIndex = 6;
            this.label3.Text = "员工姓名";
            // 
            // txtEmpNO
            // 
            this.txtEmpNO.BackColor = System.Drawing.Color.Snow;
            this.txtEmpNO.Location = new System.Drawing.Point(107, 34);
            this.txtEmpNO.Name = "txtEmpNO";
            this.txtEmpNO.Size = new System.Drawing.Size(151, 26);
            this.txtEmpNO.TabIndex = 3;
            this.txtEmpNO.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtEmpNO_KeyDown);
            // 
            // btnout
            // 
            this.btnout.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.btnout.Location = new System.Drawing.Point(37, 52);
            this.btnout.Name = "btnout";
            this.btnout.Size = new System.Drawing.Size(93, 40);
            this.btnout.TabIndex = 4;
            this.btnout.Text = "取出";
            this.btnout.UseVisualStyleBackColor = false;
            this.btnout.Click += new System.EventHandler(this.btnout_Click);
            // 
            // btnIn
            // 
            this.btnIn.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.btnIn.Location = new System.Drawing.Point(186, 52);
            this.btnIn.Name = "btnIn";
            this.btnIn.Size = new System.Drawing.Size(90, 40);
            this.btnIn.TabIndex = 5;
            this.btnIn.Text = "送进";
            this.btnIn.UseVisualStyleBackColor = false;
            this.btnIn.Click += new System.EventHandler(this.btnIn_Click);
            // 
            // dgvShow
            // 
            this.dgvShow.AllowUserToAddRows = false;
            this.dgvShow.BackgroundColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            this.dgvShow.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvShow.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvShow.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgvShow.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvShow.Location = new System.Drawing.Point(0, 0);
            this.dgvShow.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.dgvShow.MultiSelect = false;
            this.dgvShow.Name = "dgvShow";
            this.dgvShow.ReadOnly = true;
            this.dgvShow.RowHeadersWidth = 15;
            this.dgvShow.RowTemplate.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.dgvShow.RowTemplate.Height = 23;
            this.dgvShow.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvShow.Size = new System.Drawing.Size(632, 814);
            this.dgvShow.TabIndex = 1;
            this.dgvShow.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvShow_CellClick);
            // 
            // FrmDressInOut
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.dgvShow);
            this.Controls.Add(this.panel1);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "FrmDressInOut";
            this.Size = new System.Drawing.Size(927, 814);
            this.Load += new System.EventHandler(this.FrmDressInOut_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picImage)).EndInit();
            this.grbInformation.ResumeLayout(false);
            this.grbInformation.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvShow)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox txtEmpNO;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtDressbarcode;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dgvShow;
        private System.Windows.Forms.Button btnIn;
        private System.Windows.Forms.Button btnout;
        private System.Windows.Forms.Button btnManageSearch;
        private System.Windows.Forms.GroupBox grbInformation;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblStyle;
        private System.Windows.Forms.Button btnDressChooseFinish;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label lblCusName;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.DateTimePicker dtpEnd;
        private System.Windows.Forms.DateTimePicker dtpBegin;
        private System.Windows.Forms.CheckBox chkDate;
        private System.Windows.Forms.PictureBox picImage;
        private System.Windows.Forms.ComboBox cmbMoblePhone;
        private System.Windows.Forms.CheckBox chkSmall;
    }
}
