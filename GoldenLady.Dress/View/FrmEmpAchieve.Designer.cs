namespace GoldenLady.Dress
{
    partial class FrmEmpAchieve
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
            this.btnDressSearch = new System.Windows.Forms.Button();
            this.cmbDressEmp = new System.Windows.Forms.ComboBox();
            this.dtpDressEnd = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.chkChooseDress = new System.Windows.Forms.CheckBox();
            this.cmbVenue = new System.Windows.Forms.ComboBox();
            this.dtpDressBegin = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.dgvCnt = new System.Windows.Forms.DataGridView();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCnt)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Controls.Add(this.btnDressSearch);
            this.panel1.Controls.Add(this.cmbDressEmp);
            this.panel1.Controls.Add(this.dtpDressEnd);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.chkChooseDress);
            this.panel1.Controls.Add(this.cmbVenue);
            this.panel1.Controls.Add(this.dtpDressBegin);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(219, 710);
            this.panel1.TabIndex = 0;
            // 
            // btnDressSearch
            // 
            this.btnDressSearch.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.btnDressSearch.Location = new System.Drawing.Point(12, 293);
            this.btnDressSearch.Name = "btnDressSearch";
            this.btnDressSearch.Size = new System.Drawing.Size(196, 35);
            this.btnDressSearch.TabIndex = 21;
            this.btnDressSearch.Text = "查         询";
            this.btnDressSearch.UseVisualStyleBackColor = false;
            this.btnDressSearch.Click += new System.EventHandler(this.btnDressSearch_Click);
            // 
            // cmbDressEmp
            // 
            this.cmbDressEmp.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbDressEmp.FormattingEnabled = true;
            this.cmbDressEmp.Location = new System.Drawing.Point(79, 223);
            this.cmbDressEmp.Name = "cmbDressEmp";
            this.cmbDressEmp.Size = new System.Drawing.Size(129, 28);
            this.cmbDressEmp.TabIndex = 18;
            // 
            // dtpDressEnd
            // 
            this.dtpDressEnd.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpDressEnd.Location = new System.Drawing.Point(79, 102);
            this.dtpDressEnd.Name = "dtpDressEnd";
            this.dtpDressEnd.Size = new System.Drawing.Size(129, 26);
            this.dtpDressEnd.TabIndex = 10;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(8, 227);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(59, 20);
            this.label1.TabIndex = 17;
            this.label1.Text = "礼 服 师";
            // 
            // chkChooseDress
            // 
            this.chkChooseDress.AutoSize = true;
            this.chkChooseDress.Checked = true;
            this.chkChooseDress.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkChooseDress.Location = new System.Drawing.Point(12, 31);
            this.chkChooseDress.Name = "chkChooseDress";
            this.chkChooseDress.Size = new System.Drawing.Size(84, 24);
            this.chkChooseDress.TabIndex = 9;
            this.chkChooseDress.Text = "选衣时间";
            this.chkChooseDress.UseVisualStyleBackColor = true;
            // 
            // cmbVenue
            // 
            this.cmbVenue.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbVenue.FormattingEnabled = true;
            this.cmbVenue.Location = new System.Drawing.Point(79, 159);
            this.cmbVenue.Name = "cmbVenue";
            this.cmbVenue.Size = new System.Drawing.Size(129, 28);
            this.cmbVenue.TabIndex = 16;
            this.cmbVenue.SelectedValueChanged += new System.EventHandler(this.cmbVenue_SelectedValueChanged);
            // 
            // dtpDressBegin
            // 
            this.dtpDressBegin.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpDressBegin.Location = new System.Drawing.Point(79, 61);
            this.dtpDressBegin.Name = "dtpDressBegin";
            this.dtpDressBegin.Size = new System.Drawing.Size(129, 26);
            this.dtpDressBegin.TabIndex = 8;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(8, 163);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 20);
            this.label2.TabIndex = 15;
            this.label2.Text = "所属场馆";
            // 
            // dgvCnt
            // 
            this.dgvCnt.AllowUserToAddRows = false;
            this.dgvCnt.AllowUserToDeleteRows = false;
            this.dgvCnt.BackgroundColor = System.Drawing.Color.White;
            this.dgvCnt.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCnt.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvCnt.Location = new System.Drawing.Point(219, 0);
            this.dgvCnt.Name = "dgvCnt";
            this.dgvCnt.ReadOnly = true;
            this.dgvCnt.RowTemplate.Height = 23;
            this.dgvCnt.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvCnt.Size = new System.Drawing.Size(769, 710);
            this.dgvCnt.TabIndex = 1;
            // 
            // FrmEmpAchieve
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.dgvCnt);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "FrmEmpAchieve";
            this.Size = new System.Drawing.Size(988, 710);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCnt)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DateTimePicker dtpDressEnd;
        private System.Windows.Forms.CheckBox chkChooseDress;
        private System.Windows.Forms.DateTimePicker dtpDressBegin;
        private System.Windows.Forms.ComboBox cmbDressEmp;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmbVenue;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnDressSearch;
        private System.Windows.Forms.DataGridView dgvCnt;
    }
}
