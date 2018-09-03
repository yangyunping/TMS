namespace GoldenLady.Dress.View
{
    partial class FrmAllDressSearch
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.cmbArea = new System.Windows.Forms.ComboBox();
            this.label10 = new System.Windows.Forms.Label();
            this.btnExcel = new System.Windows.Forms.Button();
            this.dtpEnd = new System.Windows.Forms.DateTimePicker();
            this.dtpBengin = new System.Windows.Forms.DateTimePicker();
            this.cbYN = new System.Windows.Forms.CheckBox();
            this.picDress = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtKey = new System.Windows.Forms.TextBox();
            this.lblSum = new System.Windows.Forms.Label();
            this.chkDelete = new System.Windows.Forms.CheckBox();
            this.btnSearch = new System.Windows.Forms.Button();
            this.cmbVenues = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cmbParentStyle = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.cmbStyle = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.dgvDressesShow = new System.Windows.Forms.DataGridView();
            this.cmsMenues = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.淘汰ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.入库ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.屏蔽ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picDress)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDressesShow)).BeginInit();
            this.cmsMenues.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.Control;
            this.panel1.Controls.Add(this.cmbArea);
            this.panel1.Controls.Add(this.label10);
            this.panel1.Controls.Add(this.btnExcel);
            this.panel1.Controls.Add(this.dtpEnd);
            this.panel1.Controls.Add(this.dtpBengin);
            this.panel1.Controls.Add(this.cbYN);
            this.panel1.Controls.Add(this.picDress);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.txtKey);
            this.panel1.Controls.Add(this.lblSum);
            this.panel1.Controls.Add(this.chkDelete);
            this.panel1.Controls.Add(this.btnSearch);
            this.panel1.Controls.Add(this.cmbVenues);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.cmbParentStyle);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.cmbStyle);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel1.Location = new System.Drawing.Point(745, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(247, 737);
            this.panel1.TabIndex = 0;
            // 
            // cmbArea
            // 
            this.cmbArea.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbArea.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cmbArea.FormattingEnabled = true;
            this.cmbArea.Location = new System.Drawing.Point(86, 158);
            this.cmbArea.Name = "cmbArea";
            this.cmbArea.Size = new System.Drawing.Size(139, 28);
            this.cmbArea.TabIndex = 156;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label10.Location = new System.Drawing.Point(24, 161);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(41, 20);
            this.label10.TabIndex = 155;
            this.label10.Text = "区 域";
            // 
            // btnExcel
            // 
            this.btnExcel.AutoSize = true;
            this.btnExcel.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.btnExcel.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnExcel.Location = new System.Drawing.Point(145, 333);
            this.btnExcel.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnExcel.Name = "btnExcel";
            this.btnExcel.Size = new System.Drawing.Size(81, 42);
            this.btnExcel.TabIndex = 154;
            this.btnExcel.Text = "导出Excel";
            this.btnExcel.UseVisualStyleBackColor = false;
            this.btnExcel.Click += new System.EventHandler(this.btnExcel_Click);
            // 
            // dtpEnd
            // 
            this.dtpEnd.Enabled = false;
            this.dtpEnd.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpEnd.Location = new System.Drawing.Point(87, 291);
            this.dtpEnd.Name = "dtpEnd";
            this.dtpEnd.Size = new System.Drawing.Size(125, 23);
            this.dtpEnd.TabIndex = 153;
            // 
            // dtpBengin
            // 
            this.dtpBengin.Enabled = false;
            this.dtpBengin.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpBengin.Location = new System.Drawing.Point(87, 253);
            this.dtpBengin.Name = "dtpBengin";
            this.dtpBengin.Size = new System.Drawing.Size(125, 23);
            this.dtpBengin.TabIndex = 152;
            // 
            // cbYN
            // 
            this.cbYN.AutoSize = true;
            this.cbYN.Location = new System.Drawing.Point(27, 254);
            this.cbYN.Name = "cbYN";
            this.cbYN.Size = new System.Drawing.Size(63, 21);
            this.cbYN.TabIndex = 151;
            this.cbYN.Text = "时间段";
            this.cbYN.UseVisualStyleBackColor = true;
            this.cbYN.CheckedChanged += new System.EventHandler(this.cbYN_CheckedChanged);
            // 
            // picDress
            // 
            this.picDress.BackColor = System.Drawing.Color.White;
            this.picDress.Location = new System.Drawing.Point(4, 433);
            this.picDress.Name = "picDress";
            this.picDress.Size = new System.Drawing.Size(241, 300);
            this.picDress.TabIndex = 150;
            this.picDress.TabStop = false;
            this.picDress.Click += new System.EventHandler(this.picDress_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(24, 210);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(51, 20);
            this.label1.TabIndex = 149;
            this.label1.Text = "关键字";
            // 
            // txtKey
            // 
            this.txtKey.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtKey.Location = new System.Drawing.Point(87, 206);
            this.txtKey.Name = "txtKey";
            this.txtKey.Size = new System.Drawing.Size(139, 29);
            this.txtKey.TabIndex = 148;
            this.txtKey.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtKey_KeyDown);
            // 
            // lblSum
            // 
            this.lblSum.AutoSize = true;
            this.lblSum.BackColor = System.Drawing.Color.Transparent;
            this.lblSum.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblSum.ForeColor = System.Drawing.Color.DarkRed;
            this.lblSum.Location = new System.Drawing.Point(24, 400);
            this.lblSum.Name = "lblSum";
            this.lblSum.Size = new System.Drawing.Size(51, 20);
            this.lblSum.TabIndex = 147;
            this.lblSum.Text = "总数：";
            // 
            // chkDelete
            // 
            this.chkDelete.AutoSize = true;
            this.chkDelete.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.chkDelete.Location = new System.Drawing.Point(142, 400);
            this.chkDelete.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.chkDelete.Name = "chkDelete";
            this.chkDelete.Size = new System.Drawing.Size(70, 24);
            this.chkDelete.TabIndex = 146;
            this.chkDelete.Text = "已淘汰";
            this.chkDelete.UseVisualStyleBackColor = true;
            // 
            // btnSearch
            // 
            this.btnSearch.AutoSize = true;
            this.btnSearch.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.btnSearch.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnSearch.Location = new System.Drawing.Point(27, 333);
            this.btnSearch.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(98, 42);
            this.btnSearch.TabIndex = 145;
            this.btnSearch.Text = "查  询";
            this.btnSearch.UseVisualStyleBackColor = false;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // cmbVenues
            // 
            this.cmbVenues.BackColor = System.Drawing.Color.White;
            this.cmbVenues.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cmbVenues.FormattingEnabled = true;
            this.cmbVenues.Location = new System.Drawing.Point(86, 14);
            this.cmbVenues.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.cmbVenues.Name = "cmbVenues";
            this.cmbVenues.Size = new System.Drawing.Size(139, 28);
            this.cmbVenues.TabIndex = 140;
            this.cmbVenues.SelectedIndexChanged += new System.EventHandler(this.cmbVenues_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.Location = new System.Drawing.Point(23, 17);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 20);
            this.label2.TabIndex = 139;
            this.label2.Text = "馆 名";
            // 
            // cmbParentStyle
            // 
            this.cmbParentStyle.BackColor = System.Drawing.Color.White;
            this.cmbParentStyle.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbParentStyle.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cmbParentStyle.FormattingEnabled = true;
            this.cmbParentStyle.Location = new System.Drawing.Point(86, 62);
            this.cmbParentStyle.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.cmbParentStyle.Name = "cmbParentStyle";
            this.cmbParentStyle.Size = new System.Drawing.Size(139, 28);
            this.cmbParentStyle.TabIndex = 144;
            this.cmbParentStyle.SelectedValueChanged += new System.EventHandler(this.cmbParentStyle_SelectedValueChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label4.Location = new System.Drawing.Point(23, 65);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(41, 20);
            this.label4.TabIndex = 143;
            this.label4.Text = "大 类";
            // 
            // cmbStyle
            // 
            this.cmbStyle.BackColor = System.Drawing.Color.White;
            this.cmbStyle.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbStyle.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cmbStyle.FormattingEnabled = true;
            this.cmbStyle.Location = new System.Drawing.Point(86, 110);
            this.cmbStyle.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.cmbStyle.Name = "cmbStyle";
            this.cmbStyle.Size = new System.Drawing.Size(139, 28);
            this.cmbStyle.TabIndex = 142;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label3.Location = new System.Drawing.Point(23, 113);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(41, 20);
            this.label3.TabIndex = 141;
            this.label3.Text = "类 别";
            // 
            // dgvDressesShow
            // 
            this.dgvDressesShow.AllowUserToAddRows = false;
            this.dgvDressesShow.BackgroundColor = System.Drawing.SystemColors.ButtonFace;
            this.dgvDressesShow.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDressesShow.ContextMenuStrip = this.cmsMenues;
            this.dgvDressesShow.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvDressesShow.Location = new System.Drawing.Point(0, 0);
            this.dgvDressesShow.MultiSelect = false;
            this.dgvDressesShow.Name = "dgvDressesShow";
            this.dgvDressesShow.ReadOnly = true;
            this.dgvDressesShow.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToDisplayedHeaders;
            this.dgvDressesShow.RowTemplate.DefaultCellStyle.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.dgvDressesShow.RowTemplate.Height = 23;
            this.dgvDressesShow.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvDressesShow.Size = new System.Drawing.Size(745, 737);
            this.dgvDressesShow.TabIndex = 3;
            this.dgvDressesShow.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvDressesShow_CellClick);
            this.dgvDressesShow.RowStateChanged += new System.Windows.Forms.DataGridViewRowStateChangedEventHandler(this.dgvDressesShow_RowStateChanged);
            // 
            // cmsMenues
            // 
            this.cmsMenues.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cmsMenues.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.淘汰ToolStripMenuItem,
            this.入库ToolStripMenuItem,
            this.屏蔽ToolStripMenuItem});
            this.cmsMenues.Name = "contextMenuStrip1";
            this.cmsMenues.Size = new System.Drawing.Size(107, 76);
            // 
            // 淘汰ToolStripMenuItem
            // 
            this.淘汰ToolStripMenuItem.Name = "淘汰ToolStripMenuItem";
            this.淘汰ToolStripMenuItem.Size = new System.Drawing.Size(106, 24);
            this.淘汰ToolStripMenuItem.Text = "淘汰";
            this.淘汰ToolStripMenuItem.Click += new System.EventHandler(this.淘汰ToolStripMenuItem_Click);
            // 
            // 入库ToolStripMenuItem
            // 
            this.入库ToolStripMenuItem.Name = "入库ToolStripMenuItem";
            this.入库ToolStripMenuItem.Size = new System.Drawing.Size(106, 24);
            this.入库ToolStripMenuItem.Text = "入库";
            this.入库ToolStripMenuItem.Click += new System.EventHandler(this.入库ToolStripMenuItem_Click);
            // 
            // 屏蔽ToolStripMenuItem
            // 
            this.屏蔽ToolStripMenuItem.Name = "屏蔽ToolStripMenuItem";
            this.屏蔽ToolStripMenuItem.Size = new System.Drawing.Size(106, 24);
            this.屏蔽ToolStripMenuItem.Text = "屏蔽";
            this.屏蔽ToolStripMenuItem.Click += new System.EventHandler(this.屏蔽ToolStripMenuItem_Click);
            // 
            // FrmAllDressSearch
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.dgvDressesShow);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "FrmAllDressSearch";
            this.Size = new System.Drawing.Size(992, 737);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picDress)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDressesShow)).EndInit();
            this.cmsMenues.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ComboBox cmbVenues;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cmbParentStyle;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cmbStyle;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.CheckBox chkDelete;
        private System.Windows.Forms.Label lblSum;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtKey;
        private System.Windows.Forms.DataGridView dgvDressesShow;
        private System.Windows.Forms.PictureBox picDress;
        private System.Windows.Forms.DateTimePicker dtpEnd;
        private System.Windows.Forms.DateTimePicker dtpBengin;
        private System.Windows.Forms.CheckBox cbYN;
        private System.Windows.Forms.ContextMenuStrip cmsMenues;
        private System.Windows.Forms.ToolStripMenuItem 淘汰ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 入库ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 屏蔽ToolStripMenuItem;
        private System.Windows.Forms.Button btnExcel;
        private System.Windows.Forms.ComboBox cmbArea;
        private System.Windows.Forms.Label label10;
    }
}