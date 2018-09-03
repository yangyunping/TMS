namespace GoldenLady.Dress.View
{
    partial class FrmDressInfo
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.cmbVenues = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.chkInOut = new System.Windows.Forms.CheckBox();
            this.picImage = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtDressbarcode = new System.Windows.Forms.TextBox();
            this.dtpEnd = new System.Windows.Forms.DateTimePicker();
            this.dtpBegin = new System.Windows.Forms.DateTimePicker();
            this.chkDate = new System.Windows.Forms.CheckBox();
            this.btnSearch = new System.Windows.Forms.Button();
            this.dgvMemary = new System.Windows.Forms.DataGridView();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picImage)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMemary)).BeginInit();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.cmbVenues);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.chkInOut);
            this.panel1.Controls.Add(this.picImage);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.txtDressbarcode);
            this.panel1.Controls.Add(this.dtpEnd);
            this.panel1.Controls.Add(this.dtpBegin);
            this.panel1.Controls.Add(this.chkDate);
            this.panel1.Controls.Add(this.btnSearch);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(223, 686);
            this.panel1.TabIndex = 0;
            // 
            // cmbVenues
            // 
            this.cmbVenues.BackColor = System.Drawing.Color.White;
            this.cmbVenues.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cmbVenues.FormattingEnabled = true;
            this.cmbVenues.Location = new System.Drawing.Point(63, 23);
            this.cmbVenues.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.cmbVenues.Name = "cmbVenues";
            this.cmbVenues.Size = new System.Drawing.Size(142, 28);
            this.cmbVenues.TabIndex = 144;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.Location = new System.Drawing.Point(12, 26);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 20);
            this.label2.TabIndex = 143;
            this.label2.Text = "馆 名";
            // 
            // chkInOut
            // 
            this.chkInOut.AutoSize = true;
            this.chkInOut.Location = new System.Drawing.Point(63, 277);
            this.chkInOut.Name = "chkInOut";
            this.chkInOut.Size = new System.Drawing.Size(140, 24);
            this.chkInOut.TabIndex = 22;
            this.chkInOut.Text = "取出送进单独查询";
            this.chkInOut.UseVisualStyleBackColor = true;
            // 
            // picImage
            // 
            this.picImage.BackColor = System.Drawing.Color.White;
            this.picImage.Location = new System.Drawing.Point(3, 380);
            this.picImage.Name = "picImage";
            this.picImage.Size = new System.Drawing.Size(214, 276);
            this.picImage.TabIndex = 21;
            this.picImage.TabStop = false;
            this.picImage.Click += new System.EventHandler(this.picImage_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 200);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 20);
            this.label1.TabIndex = 19;
            this.label1.Text = "礼服条码";
            // 
            // txtDressbarcode
            // 
            this.txtDressbarcode.BackColor = System.Drawing.Color.Snow;
            this.txtDressbarcode.Location = new System.Drawing.Point(63, 233);
            this.txtDressbarcode.Name = "txtDressbarcode";
            this.txtDressbarcode.Size = new System.Drawing.Size(142, 26);
            this.txtDressbarcode.TabIndex = 20;
            this.txtDressbarcode.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtDressbarcode_KeyDown);
            // 
            // dtpEnd
            // 
            this.dtpEnd.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpEnd.Location = new System.Drawing.Point(63, 153);
            this.dtpEnd.Name = "dtpEnd";
            this.dtpEnd.Size = new System.Drawing.Size(142, 26);
            this.dtpEnd.TabIndex = 18;
            // 
            // dtpBegin
            // 
            this.dtpBegin.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpBegin.Location = new System.Drawing.Point(63, 110);
            this.dtpBegin.Name = "dtpBegin";
            this.dtpBegin.Size = new System.Drawing.Size(142, 26);
            this.dtpBegin.TabIndex = 17;
            // 
            // chkDate
            // 
            this.chkDate.AutoSize = true;
            this.chkDate.Checked = true;
            this.chkDate.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkDate.Location = new System.Drawing.Point(16, 80);
            this.chkDate.Name = "chkDate";
            this.chkDate.Size = new System.Drawing.Size(56, 24);
            this.chkDate.TabIndex = 16;
            this.chkDate.Text = "日期";
            this.chkDate.UseVisualStyleBackColor = true;
            this.chkDate.CheckedChanged += new System.EventHandler(this.chkDate_CheckedChanged);
            // 
            // btnSearch
            // 
            this.btnSearch.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.btnSearch.Location = new System.Drawing.Point(24, 307);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(179, 40);
            this.btnSearch.TabIndex = 15;
            this.btnSearch.Text = "查    询";
            this.btnSearch.UseVisualStyleBackColor = false;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // dgvMemary
            // 
            this.dgvMemary.AllowUserToAddRows = false;
            this.dgvMemary.BackgroundColor = System.Drawing.Color.White;
            this.dgvMemary.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dgvMemary.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvMemary.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvMemary.Location = new System.Drawing.Point(0, 0);
            this.dgvMemary.MultiSelect = false;
            this.dgvMemary.Name = "dgvMemary";
            this.dgvMemary.RowHeadersWidth = 10;
            this.dgvMemary.RowTemplate.Height = 23;
            this.dgvMemary.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvMemary.Size = new System.Drawing.Size(796, 686);
            this.dgvMemary.TabIndex = 1;
            this.dgvMemary.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvMemary_CellClick);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.dgvMemary);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(223, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(796, 686);
            this.panel2.TabIndex = 2;
            // 
            // FrmDressInfo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "FrmDressInfo";
            this.Size = new System.Drawing.Size(1019, 686);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picImage)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMemary)).EndInit();
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DateTimePicker dtpEnd;
        private System.Windows.Forms.DateTimePicker dtpBegin;
        private System.Windows.Forms.CheckBox chkDate;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtDressbarcode;
        private System.Windows.Forms.DataGridView dgvMemary;
        private System.Windows.Forms.PictureBox picImage;
        private System.Windows.Forms.CheckBox chkInOut;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.ComboBox cmbVenues;
        private System.Windows.Forms.Label label2;
    }
}
