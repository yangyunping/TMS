namespace GoldenLady.Dress.View
{
    partial class FrmDressCleanStatistics
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
            this.components = new System.ComponentModel.Container();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnPrint = new System.Windows.Forms.Button();
            this.txtDressBarCode = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.rbName2 = new System.Windows.Forms.RadioButton();
            this.rbName1 = new System.Windows.Forms.RadioButton();
            this.chkDate = new System.Windows.Forms.CheckBox();
            this.btnSearchWash = new System.Windows.Forms.Button();
            this.cmbVenues = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cmbParentStyle = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.dtpBegin = new System.Windows.Forms.DateTimePicker();
            this.cmbStyle = new System.Windows.Forms.ComboBox();
            this.dtpEnd = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.picImage = new System.Windows.Forms.PictureBox();
            this.lblSum = new System.Windows.Forms.Label();
            this.printDocument1 = new System.Drawing.Printing.PrintDocument();
            this.dgvStatistic = new System.Windows.Forms.DataGridView();
            this.TypeName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Count = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvShow = new System.Windows.Forms.DataGridView();
            this.DressBarCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DressStatus = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DressNumbers = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.RuleName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.OperatePeople = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.OperateTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.guanmin = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.删除ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picImage)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvStatistic)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvShow)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnPrint);
            this.panel1.Controls.Add(this.txtDressBarCode);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.rbName2);
            this.panel1.Controls.Add(this.rbName1);
            this.panel1.Controls.Add(this.chkDate);
            this.panel1.Controls.Add(this.btnSearchWash);
            this.panel1.Controls.Add(this.cmbVenues);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.cmbParentStyle);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.dtpBegin);
            this.panel1.Controls.Add(this.cmbStyle);
            this.panel1.Controls.Add(this.dtpEnd);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.picImage);
            this.panel1.Controls.Add(this.lblSum);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel1.Location = new System.Drawing.Point(744, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(257, 759);
            this.panel1.TabIndex = 0;
            // 
            // btnPrint
            // 
            this.btnPrint.AutoSize = true;
            this.btnPrint.BackColor = System.Drawing.Color.LightBlue;
            this.btnPrint.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnPrint.Location = new System.Drawing.Point(141, 330);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(91, 39);
            this.btnPrint.TabIndex = 146;
            this.btnPrint.Text = "统计并打印";
            this.btnPrint.UseVisualStyleBackColor = false;
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            // 
            // txtDressBarCode
            // 
            this.txtDressBarCode.Location = new System.Drawing.Point(80, 260);
            this.txtDressBarCode.Name = "txtDressBarCode";
            this.txtDressBarCode.Size = new System.Drawing.Size(152, 26);
            this.txtDressBarCode.TabIndex = 145;
            this.txtDressBarCode.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtDressBarCode_KeyDown);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(27, 263);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(37, 20);
            this.label1.TabIndex = 144;
            this.label1.Text = "条码";
            // 
            // rbName2
            // 
            this.rbName2.AutoSize = true;
            this.rbName2.Location = new System.Drawing.Point(139, 300);
            this.rbName2.Name = "rbName2";
            this.rbName2.Size = new System.Drawing.Size(63, 24);
            this.rbName2.TabIndex = 143;
            this.rbName2.Text = "XXXX";
            this.rbName2.UseVisualStyleBackColor = true;
            // 
            // rbName1
            // 
            this.rbName1.AutoSize = true;
            this.rbName1.Checked = true;
            this.rbName1.Location = new System.Drawing.Point(59, 300);
            this.rbName1.Name = "rbName1";
            this.rbName1.Size = new System.Drawing.Size(63, 24);
            this.rbName1.TabIndex = 142;
            this.rbName1.TabStop = true;
            this.rbName1.Text = "XXXX";
            this.rbName1.UseVisualStyleBackColor = true;
            // 
            // chkDate
            // 
            this.chkDate.AutoSize = true;
            this.chkDate.Checked = true;
            this.chkDate.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkDate.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.chkDate.Location = new System.Drawing.Point(6, 27);
            this.chkDate.Name = "chkDate";
            this.chkDate.Size = new System.Drawing.Size(70, 24);
            this.chkDate.TabIndex = 140;
            this.chkDate.Text = "时间段";
            this.chkDate.UseVisualStyleBackColor = true;
            // 
            // btnSearchWash
            // 
            this.btnSearchWash.AutoSize = true;
            this.btnSearchWash.BackColor = System.Drawing.Color.LightBlue;
            this.btnSearchWash.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnSearchWash.Location = new System.Drawing.Point(31, 330);
            this.btnSearchWash.Name = "btnSearchWash";
            this.btnSearchWash.Size = new System.Drawing.Size(91, 39);
            this.btnSearchWash.TabIndex = 130;
            this.btnSearchWash.Text = "查  询";
            this.btnSearchWash.UseVisualStyleBackColor = false;
            this.btnSearchWash.Click += new System.EventHandler(this.btnSearchWash_Click);
            // 
            // cmbVenues
            // 
            this.cmbVenues.BackColor = System.Drawing.Color.White;
            this.cmbVenues.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cmbVenues.FormattingEnabled = true;
            this.cmbVenues.Location = new System.Drawing.Point(82, 115);
            this.cmbVenues.Name = "cmbVenues";
            this.cmbVenues.Size = new System.Drawing.Size(152, 28);
            this.cmbVenues.TabIndex = 134;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.Location = new System.Drawing.Point(27, 119);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(37, 20);
            this.label2.TabIndex = 133;
            this.label2.Text = "馆名";
            // 
            // cmbParentStyle
            // 
            this.cmbParentStyle.BackColor = System.Drawing.Color.White;
            this.cmbParentStyle.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbParentStyle.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cmbParentStyle.FormattingEnabled = true;
            this.cmbParentStyle.Location = new System.Drawing.Point(80, 163);
            this.cmbParentStyle.Name = "cmbParentStyle";
            this.cmbParentStyle.Size = new System.Drawing.Size(152, 28);
            this.cmbParentStyle.TabIndex = 138;
            this.cmbParentStyle.SelectedValueChanged += new System.EventHandler(this.cmbParentStyle_SelectedValueChanged);
            this.cmbParentStyle.Click += new System.EventHandler(this.cmbParentStyle_SelectedValueChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label4.Location = new System.Drawing.Point(25, 167);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(37, 20);
            this.label4.TabIndex = 137;
            this.label4.Text = "大类";
            // 
            // dtpBegin
            // 
            this.dtpBegin.CalendarMonthBackground = System.Drawing.SystemColors.MenuBar;
            this.dtpBegin.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.dtpBegin.Location = new System.Drawing.Point(82, 26);
            this.dtpBegin.Name = "dtpBegin";
            this.dtpBegin.Size = new System.Drawing.Size(152, 26);
            this.dtpBegin.TabIndex = 131;
            // 
            // cmbStyle
            // 
            this.cmbStyle.BackColor = System.Drawing.Color.White;
            this.cmbStyle.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbStyle.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cmbStyle.FormattingEnabled = true;
            this.cmbStyle.Location = new System.Drawing.Point(80, 213);
            this.cmbStyle.Name = "cmbStyle";
            this.cmbStyle.Size = new System.Drawing.Size(152, 28);
            this.cmbStyle.TabIndex = 136;
            // 
            // dtpEnd
            // 
            this.dtpEnd.CalendarMonthBackground = System.Drawing.SystemColors.MenuBar;
            this.dtpEnd.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.dtpEnd.Location = new System.Drawing.Point(82, 69);
            this.dtpEnd.Name = "dtpEnd";
            this.dtpEnd.Size = new System.Drawing.Size(152, 26);
            this.dtpEnd.TabIndex = 132;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label3.Location = new System.Drawing.Point(27, 217);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(37, 20);
            this.label3.TabIndex = 135;
            this.label3.Text = "类别";
            // 
            // picImage
            // 
            this.picImage.BackColor = System.Drawing.Color.White;
            this.picImage.Location = new System.Drawing.Point(3, 415);
            this.picImage.Name = "picImage";
            this.picImage.Size = new System.Drawing.Size(251, 341);
            this.picImage.TabIndex = 141;
            this.picImage.TabStop = false;
            // 
            // lblSum
            // 
            this.lblSum.AutoSize = true;
            this.lblSum.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.lblSum.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblSum.Location = new System.Drawing.Point(27, 382);
            this.lblSum.Name = "lblSum";
            this.lblSum.Size = new System.Drawing.Size(79, 20);
            this.lblSum.TabIndex = 139;
            this.lblSum.Text = "显示总数：";
            // 
            // printDocument1
            // 
            this.printDocument1.PrintPage += new System.Drawing.Printing.PrintPageEventHandler(this.printDocument1_PrintPage);
            // 
            // dgvStatistic
            // 
            this.dgvStatistic.AllowUserToAddRows = false;
            this.dgvStatistic.AllowUserToDeleteRows = false;
            this.dgvStatistic.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvStatistic.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.TypeName,
            this.Count});
            this.dgvStatistic.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.dgvStatistic.Location = new System.Drawing.Point(0, 609);
            this.dgvStatistic.Name = "dgvStatistic";
            this.dgvStatistic.ReadOnly = true;
            this.dgvStatistic.RowTemplate.Height = 23;
            this.dgvStatistic.Size = new System.Drawing.Size(744, 150);
            this.dgvStatistic.TabIndex = 2;
            // 
            // TypeName
            // 
            this.TypeName.DataPropertyName = "TypeName";
            this.TypeName.HeaderText = "类别";
            this.TypeName.Name = "TypeName";
            this.TypeName.ReadOnly = true;
            // 
            // Count
            // 
            this.Count.DataPropertyName = "Count";
            this.Count.HeaderText = "件数";
            this.Count.Name = "Count";
            this.Count.ReadOnly = true;
            // 
            // dgvShow
            // 
            this.dgvShow.AllowUserToAddRows = false;
            this.dgvShow.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dgvShow.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvShow.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.DressBarCode,
            this.DressStatus,
            this.DressNumbers,
            this.RuleName,
            this.OperatePeople,
            this.OperateTime,
            this.guanmin});
            this.dgvShow.ContextMenuStrip = this.contextMenuStrip1;
            this.dgvShow.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvShow.Location = new System.Drawing.Point(0, 0);
            this.dgvShow.MultiSelect = false;
            this.dgvShow.Name = "dgvShow";
            this.dgvShow.ReadOnly = true;
            this.dgvShow.RowHeadersWidth = 15;
            this.dgvShow.RowTemplate.Height = 23;
            this.dgvShow.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvShow.Size = new System.Drawing.Size(744, 609);
            this.dgvShow.TabIndex = 3;
            this.dgvShow.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvShow_CellClick);
            // 
            // DressBarCode
            // 
            this.DressBarCode.DataPropertyName = "DressBarCode";
            this.DressBarCode.HeaderText = "礼服条码";
            this.DressBarCode.Name = "DressBarCode";
            this.DressBarCode.ReadOnly = true;
            this.DressBarCode.Width = 120;
            // 
            // DressStatus
            // 
            this.DressStatus.DataPropertyName = "DressStatus";
            this.DressStatus.HeaderText = "状态";
            this.DressStatus.Name = "DressStatus";
            this.DressStatus.ReadOnly = true;
            // 
            // DressNumbers
            // 
            this.DressNumbers.DataPropertyName = "DressNumbers";
            this.DressNumbers.HeaderText = "款式编号";
            this.DressNumbers.Name = "DressNumbers";
            this.DressNumbers.ReadOnly = true;
            this.DressNumbers.Width = 120;
            // 
            // RuleName
            // 
            this.RuleName.DataPropertyName = "RuleName";
            this.RuleName.HeaderText = "类别";
            this.RuleName.Name = "RuleName";
            this.RuleName.ReadOnly = true;
            this.RuleName.Width = 70;
            // 
            // OperatePeople
            // 
            this.OperatePeople.DataPropertyName = "OperatePeople";
            this.OperatePeople.HeaderText = "操作人";
            this.OperatePeople.Name = "OperatePeople";
            this.OperatePeople.ReadOnly = true;
            // 
            // OperateTime
            // 
            this.OperateTime.DataPropertyName = "OperateTime";
            this.OperateTime.HeaderText = "操作时间";
            this.OperateTime.Name = "OperateTime";
            this.OperateTime.ReadOnly = true;
            this.OperateTime.Width = 130;
            // 
            // guanmin
            // 
            this.guanmin.DataPropertyName = "guanmin";
            this.guanmin.HeaderText = "所属场馆";
            this.guanmin.Name = "guanmin";
            this.guanmin.ReadOnly = true;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.删除ToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(149, 28);
            // 
            // 删除ToolStripMenuItem
            // 
            this.删除ToolStripMenuItem.Name = "删除ToolStripMenuItem";
            this.删除ToolStripMenuItem.Size = new System.Drawing.Size(148, 24);
            this.删除ToolStripMenuItem.Text = "删除该记录";
            this.删除ToolStripMenuItem.Click += new System.EventHandler(this.删除ToolStripMenuItem_Click);
            // 
            // FrmDressCleanStatistics
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.Controls.Add(this.dgvShow);
            this.Controls.Add(this.dgvStatistic);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Name = "FrmDressCleanStatistics";
            this.Size = new System.Drawing.Size(1001, 759);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picImage)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvStatistic)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvShow)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox picImage;
        private System.Windows.Forms.Label lblSum;
        private System.Windows.Forms.CheckBox chkDate;
        private System.Windows.Forms.Button btnSearchWash;
        private System.Windows.Forms.ComboBox cmbVenues;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cmbParentStyle;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DateTimePicker dtpBegin;
        private System.Windows.Forms.ComboBox cmbStyle;
        private System.Windows.Forms.DateTimePicker dtpEnd;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.RadioButton rbName2;
        private System.Windows.Forms.RadioButton rbName1;
        private System.Windows.Forms.TextBox txtDressBarCode;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnPrint;
        private System.Drawing.Printing.PrintDocument printDocument1;
        private System.Windows.Forms.DataGridView dgvStatistic;
        private System.Windows.Forms.DataGridView dgvShow;
        private System.Windows.Forms.DataGridViewTextBoxColumn DressBarCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn DressStatus;
        private System.Windows.Forms.DataGridViewTextBoxColumn DressNumbers;
        private System.Windows.Forms.DataGridViewTextBoxColumn RuleName;
        private System.Windows.Forms.DataGridViewTextBoxColumn OperatePeople;
        private System.Windows.Forms.DataGridViewTextBoxColumn OperateTime;
        private System.Windows.Forms.DataGridViewTextBoxColumn guanmin;
        private System.Windows.Forms.DataGridViewTextBoxColumn TypeName;
        private System.Windows.Forms.DataGridViewTextBoxColumn Count;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 删除ToolStripMenuItem;



    }
}
