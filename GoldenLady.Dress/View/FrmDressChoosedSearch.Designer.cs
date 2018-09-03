namespace GoldenLady.Dress.View
{
    partial class FrmDressChoosedSearch
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
            this.panel4 = new System.Windows.Forms.Panel();
            this.btnExcel = new System.Windows.Forms.Button();
            this.btnUseCount = new System.Windows.Forms.Button();
            this.rnbScene = new System.Windows.Forms.RadioButton();
            this.rnbDress = new System.Windows.Forms.RadioButton();
            this.btnCount = new System.Windows.Forms.Button();
            this.cmbDressEmp = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.lblSum = new System.Windows.Forms.Label();
            this.dtpUseEnd = new System.Windows.Forms.DateTimePicker();
            this.btnDressSearch = new System.Windows.Forms.Button();
            this.txtKey = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.dtpDressEnd = new System.Windows.Forms.DateTimePicker();
            this.chkChooseDress = new System.Windows.Forms.CheckBox();
            this.dtpUseBegin = new System.Windows.Forms.DateTimePicker();
            this.chkUse = new System.Windows.Forms.CheckBox();
            this.dtpDressBegin = new System.Windows.Forms.DateTimePicker();
            this.cmbVenue = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.dgvDress = new System.Windows.Forms.DataGridView();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.tsmDelete = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmDressPhoto = new System.Windows.Forms.ToolStripMenuItem();
            this.panel1 = new System.Windows.Forms.Panel();
            this.dgvCount = new System.Windows.Forms.DataGridView();
            this.panel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDress)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCount)).BeginInit();
            this.SuspendLayout();
            // 
            // panel4
            // 
            this.panel4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel4.Controls.Add(this.btnExcel);
            this.panel4.Controls.Add(this.btnUseCount);
            this.panel4.Controls.Add(this.rnbScene);
            this.panel4.Controls.Add(this.rnbDress);
            this.panel4.Controls.Add(this.btnCount);
            this.panel4.Controls.Add(this.cmbDressEmp);
            this.panel4.Controls.Add(this.label1);
            this.panel4.Controls.Add(this.lblSum);
            this.panel4.Controls.Add(this.dtpUseEnd);
            this.panel4.Controls.Add(this.btnDressSearch);
            this.panel4.Controls.Add(this.txtKey);
            this.panel4.Controls.Add(this.label3);
            this.panel4.Controls.Add(this.dtpDressEnd);
            this.panel4.Controls.Add(this.chkChooseDress);
            this.panel4.Controls.Add(this.dtpUseBegin);
            this.panel4.Controls.Add(this.chkUse);
            this.panel4.Controls.Add(this.dtpDressBegin);
            this.panel4.Controls.Add(this.cmbVenue);
            this.panel4.Controls.Add(this.label2);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel4.Location = new System.Drawing.Point(0, 0);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(1200, 89);
            this.panel4.TabIndex = 1;
            // 
            // btnExcel
            // 
            this.btnExcel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnExcel.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.btnExcel.Location = new System.Drawing.Point(1086, 48);
            this.btnExcel.Name = "btnExcel";
            this.btnExcel.Size = new System.Drawing.Size(111, 35);
            this.btnExcel.TabIndex = 19;
            this.btnExcel.Text = "导出Excel";
            this.btnExcel.UseVisualStyleBackColor = false;
            this.btnExcel.Click += new System.EventHandler(this.btnExcel_Click);
            // 
            // btnUseCount
            // 
            this.btnUseCount.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.btnUseCount.Enabled = false;
            this.btnUseCount.Location = new System.Drawing.Point(942, 48);
            this.btnUseCount.Name = "btnUseCount";
            this.btnUseCount.Size = new System.Drawing.Size(84, 35);
            this.btnUseCount.TabIndex = 18;
            this.btnUseCount.Text = "使用次数";
            this.btnUseCount.UseVisualStyleBackColor = false;
            this.btnUseCount.Click += new System.EventHandler(this.btnUseCount_Click);
            // 
            // rnbScene
            // 
            this.rnbScene.AutoSize = true;
            this.rnbScene.Location = new System.Drawing.Point(1014, 12);
            this.rnbScene.Name = "rnbScene";
            this.rnbScene.Size = new System.Drawing.Size(55, 24);
            this.rnbScene.TabIndex = 17;
            this.rnbScene.Text = "场景";
            this.rnbScene.UseVisualStyleBackColor = true;
            // 
            // rnbDress
            // 
            this.rnbDress.AutoSize = true;
            this.rnbDress.Checked = true;
            this.rnbDress.Location = new System.Drawing.Point(942, 12);
            this.rnbDress.Name = "rnbDress";
            this.rnbDress.Size = new System.Drawing.Size(55, 24);
            this.rnbDress.TabIndex = 16;
            this.rnbDress.TabStop = true;
            this.rnbDress.Text = "礼服";
            this.rnbDress.UseVisualStyleBackColor = true;
            // 
            // btnCount
            // 
            this.btnCount.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.btnCount.Enabled = false;
            this.btnCount.Location = new System.Drawing.Point(814, 48);
            this.btnCount.Name = "btnCount";
            this.btnCount.Size = new System.Drawing.Size(84, 35);
            this.btnCount.TabIndex = 15;
            this.btnCount.Text = "业绩统计";
            this.btnCount.UseVisualStyleBackColor = false;
            this.btnCount.Click += new System.EventHandler(this.btnCount_Click);
            // 
            // cmbDressEmp
            // 
            this.cmbDressEmp.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbDressEmp.FormattingEnabled = true;
            this.cmbDressEmp.Location = new System.Drawing.Point(759, 10);
            this.cmbDressEmp.Name = "cmbDressEmp";
            this.cmbDressEmp.Size = new System.Drawing.Size(139, 28);
            this.cmbDressEmp.TabIndex = 14;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(688, 14);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(51, 20);
            this.label1.TabIndex = 13;
            this.label1.Text = "礼服师";
            // 
            // lblSum
            // 
            this.lblSum.AutoSize = true;
            this.lblSum.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.lblSum.Location = new System.Drawing.Point(1082, 65);
            this.lblSum.Name = "lblSum";
            this.lblSum.Size = new System.Drawing.Size(79, 20);
            this.lblSum.TabIndex = 12;
            this.lblSum.Text = "礼服总数：";
            // 
            // dtpUseEnd
            // 
            this.dtpUseEnd.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpUseEnd.Location = new System.Drawing.Point(326, 52);
            this.dtpUseEnd.Name = "dtpUseEnd";
            this.dtpUseEnd.Size = new System.Drawing.Size(106, 26);
            this.dtpUseEnd.TabIndex = 11;
            // 
            // btnDressSearch
            // 
            this.btnDressSearch.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.btnDressSearch.Location = new System.Drawing.Point(692, 48);
            this.btnDressSearch.Name = "btnDressSearch";
            this.btnDressSearch.Size = new System.Drawing.Size(84, 35);
            this.btnDressSearch.TabIndex = 10;
            this.btnDressSearch.Text = "查  询";
            this.btnDressSearch.UseVisualStyleBackColor = false;
            this.btnDressSearch.Click += new System.EventHandler(this.btnDressSearch_Click);
            // 
            // txtKey
            // 
            this.txtKey.Location = new System.Drawing.Point(524, 52);
            this.txtKey.Name = "txtKey";
            this.txtKey.Size = new System.Drawing.Size(139, 26);
            this.txtKey.TabIndex = 9;
            this.txtKey.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtKey_KeyDown);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(453, 55);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(51, 20);
            this.label3.TabIndex = 8;
            this.label3.Text = "关键字";
            // 
            // dtpDressEnd
            // 
            this.dtpDressEnd.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpDressEnd.Location = new System.Drawing.Point(112, 52);
            this.dtpDressEnd.Name = "dtpDressEnd";
            this.dtpDressEnd.Size = new System.Drawing.Size(106, 26);
            this.dtpDressEnd.TabIndex = 7;
            // 
            // chkChooseDress
            // 
            this.chkChooseDress.AutoSize = true;
            this.chkChooseDress.Checked = true;
            this.chkChooseDress.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkChooseDress.Location = new System.Drawing.Point(22, 12);
            this.chkChooseDress.Name = "chkChooseDress";
            this.chkChooseDress.Size = new System.Drawing.Size(84, 24);
            this.chkChooseDress.TabIndex = 6;
            this.chkChooseDress.Text = "选衣时间";
            this.chkChooseDress.UseVisualStyleBackColor = true;
            // 
            // dtpUseBegin
            // 
            this.dtpUseBegin.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpUseBegin.Location = new System.Drawing.Point(326, 11);
            this.dtpUseBegin.Name = "dtpUseBegin";
            this.dtpUseBegin.Size = new System.Drawing.Size(106, 26);
            this.dtpUseBegin.TabIndex = 5;
            // 
            // chkUse
            // 
            this.chkUse.AutoSize = true;
            this.chkUse.Location = new System.Drawing.Point(236, 12);
            this.chkUse.Name = "chkUse";
            this.chkUse.Size = new System.Drawing.Size(84, 24);
            this.chkUse.TabIndex = 4;
            this.chkUse.Text = "拍照时间";
            this.chkUse.UseVisualStyleBackColor = true;
            // 
            // dtpDressBegin
            // 
            this.dtpDressBegin.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpDressBegin.Location = new System.Drawing.Point(112, 11);
            this.dtpDressBegin.Name = "dtpDressBegin";
            this.dtpDressBegin.Size = new System.Drawing.Size(106, 26);
            this.dtpDressBegin.TabIndex = 3;
            // 
            // cmbVenue
            // 
            this.cmbVenue.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbVenue.FormattingEnabled = true;
            this.cmbVenue.Location = new System.Drawing.Point(524, 10);
            this.cmbVenue.Name = "cmbVenue";
            this.cmbVenue.Size = new System.Drawing.Size(139, 28);
            this.cmbVenue.TabIndex = 1;
            this.cmbVenue.SelectedValueChanged += new System.EventHandler(this.cmbVenue_SelectedValueChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(453, 14);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 20);
            this.label2.TabIndex = 0;
            this.label2.Text = "所属场馆";
            // 
            // dgvDress
            // 
            this.dgvDress.AllowUserToAddRows = false;
            this.dgvDress.BackgroundColor = System.Drawing.Color.White;
            this.dgvDress.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dgvDress.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDress.ContextMenuStrip = this.contextMenuStrip1;
            this.dgvDress.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvDress.Location = new System.Drawing.Point(0, 89);
            this.dgvDress.Name = "dgvDress";
            this.dgvDress.ReadOnly = true;
            this.dgvDress.RowHeadersWidth = 10;
            this.dgvDress.RowTemplate.Height = 23;
            this.dgvDress.RowTemplate.ReadOnly = true;
            this.dgvDress.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvDress.Size = new System.Drawing.Size(939, 558);
            this.dgvDress.TabIndex = 2;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmDelete,
            this.tsmDressPhoto});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(173, 48);
            // 
            // tsmDelete
            // 
            this.tsmDelete.Name = "tsmDelete";
            this.tsmDelete.Size = new System.Drawing.Size(172, 22);
            this.tsmDelete.Text = "删除选中礼服";
            this.tsmDelete.Click += new System.EventHandler(this.tsmDelete_Click);
            // 
            // tsmDressPhoto
            // 
            this.tsmDressPhoto.Name = "tsmDressPhoto";
            this.tsmDressPhoto.Size = new System.Drawing.Size(172, 22);
            this.tsmDressPhoto.Text = "显示选中礼服照片";
            this.tsmDressPhoto.Click += new System.EventHandler(this.tsmDressPhoto_Click);
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel1.Controls.Add(this.dgvCount);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel1.Location = new System.Drawing.Point(939, 89);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(261, 558);
            this.panel1.TabIndex = 3;
            // 
            // dgvCount
            // 
            this.dgvCount.AllowUserToAddRows = false;
            this.dgvCount.BackgroundColor = System.Drawing.SystemColors.ButtonFace;
            this.dgvCount.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvCount.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCount.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvCount.Location = new System.Drawing.Point(0, 0);
            this.dgvCount.Name = "dgvCount";
            this.dgvCount.ReadOnly = true;
            this.dgvCount.RowHeadersWidth = 20;
            this.dgvCount.RowTemplate.Height = 23;
            this.dgvCount.Size = new System.Drawing.Size(257, 554);
            this.dgvCount.TabIndex = 0;
            // 
            // FrmDressChoosedSearch
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.dgvDress);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel4);
            this.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "FrmDressChoosedSearch";
            this.Size = new System.Drawing.Size(1200, 647);
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDress)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvCount)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.DateTimePicker dtpUseEnd;
        private System.Windows.Forms.Button btnDressSearch;
        private System.Windows.Forms.TextBox txtKey;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DateTimePicker dtpDressEnd;
        private System.Windows.Forms.CheckBox chkChooseDress;
        private System.Windows.Forms.DateTimePicker dtpUseBegin;
        private System.Windows.Forms.CheckBox chkUse;
        private System.Windows.Forms.DateTimePicker dtpDressBegin;
        private System.Windows.Forms.ComboBox cmbVenue;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridView dgvDress;
        private System.Windows.Forms.Label lblSum;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem tsmDelete;
        private System.Windows.Forms.ComboBox cmbDressEmp;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ToolStripMenuItem tsmDressPhoto;
        private System.Windows.Forms.Button btnCount;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DataGridView dgvCount;
        private System.Windows.Forms.RadioButton rnbScene;
        private System.Windows.Forms.RadioButton rnbDress;
        private System.Windows.Forms.Button btnUseCount;
        private System.Windows.Forms.Button btnExcel;
    }
}