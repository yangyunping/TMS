namespace GoldenLady.SMSNew
{
    partial class frmOption
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
            this.label5 = new System.Windows.Forms.Label();
            this.cmbForwardDays = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.txtUsefulExpressions1 = new System.Windows.Forms.TextBox();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.txtAi = new System.Windows.Forms.TextBox();
            this.btnDelete = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cmbMM = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cmbHH = new System.Windows.Forms.ComboBox();
            this.lkbAdd = new System.Windows.Forms.LinkLabel();
            this.label1 = new System.Windows.Forms.Label();
            this.dgv = new System.Windows.Forms.DataGridView();
            this.编号 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.通知类别 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.自定义短语 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.提前通知天数 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.发送时间 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cms = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.tsmiDelete = new System.Windows.Forms.ToolStripMenuItem();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).BeginInit();
            this.cms.SuspendLayout();
            this.SuspendLayout();
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(17, 23);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(68, 20);
            this.label5.TabIndex = 20;
            this.label5.Text = "发送类别:";
            // 
            // cmbForwardDays
            // 
            this.cmbForwardDays.FormattingEnabled = true;
            this.cmbForwardDays.Items.AddRange(new object[] {
            "0",
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8",
            "9",
            "10",
            "11",
            "12",
            "13",
            "14",
            "15",
            "16",
            "17",
            "18",
            "19",
            "20",
            "21",
            "22",
            "23",
            "24",
            "25",
            "26",
            "27",
            "28",
            "29",
            "30",
            "31"});
            this.cmbForwardDays.Location = new System.Drawing.Point(16, 129);
            this.cmbForwardDays.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.cmbForwardDays.Name = "cmbForwardDays";
            this.cmbForwardDays.Size = new System.Drawing.Size(214, 28);
            this.cmbForwardDays.TabIndex = 1;
            this.cmbForwardDays.Text = "0";
            this.cmbForwardDays.TextChanged += new System.EventHandler(this.cmbForwardDays_TextChanged);
            this.cmbForwardDays.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cmbForwardDays_KeyPress);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(15, 99);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(96, 20);
            this.label6.TabIndex = 22;
            this.label6.Text = "提前通知天数:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(14, 248);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(82, 20);
            this.label7.TabIndex = 23;
            this.label7.Text = "设置常用语:";
            // 
            // txtUsefulExpressions1
            // 
            this.txtUsefulExpressions1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtUsefulExpressions1.Location = new System.Drawing.Point(15, 278);
            this.txtUsefulExpressions1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtUsefulExpressions1.Multiline = true;
            this.txtUsefulExpressions1.Name = "txtUsefulExpressions1";
            this.txtUsefulExpressions1.Size = new System.Drawing.Size(215, 97);
            this.txtUsefulExpressions1.TabIndex = 3;
            this.txtUsefulExpressions1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtUsefulExpressions1_KeyDown);
            // 
            // btnUpdate
            // 
            this.btnUpdate.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnUpdate.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.btnUpdate.Location = new System.Drawing.Point(15, 383);
            this.btnUpdate.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(103, 35);
            this.btnUpdate.TabIndex = 4;
            this.btnUpdate.Text = "修改";
            this.btnUpdate.UseVisualStyleBackColor = false;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // txtAi
            // 
            this.txtAi.Location = new System.Drawing.Point(15, 53);
            this.txtAi.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtAi.Name = "txtAi";
            this.txtAi.Size = new System.Drawing.Size(215, 26);
            this.txtAi.TabIndex = 0;
            // 
            // btnDelete
            // 
            this.btnDelete.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnDelete.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.btnDelete.Location = new System.Drawing.Point(140, 383);
            this.btnDelete.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(93, 35);
            this.btnDelete.TabIndex = 5;
            this.btnDelete.Text = "删除";
            this.btnDelete.UseVisualStyleBackColor = false;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.groupBox1.Controls.Add(this.cmbMM);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.cmbHH);
            this.groupBox1.Controls.Add(this.lkbAdd);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.btnDelete);
            this.groupBox1.Controls.Add(this.txtAi);
            this.groupBox1.Controls.Add(this.btnUpdate);
            this.groupBox1.Controls.Add(this.txtUsefulExpressions1);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.cmbForwardDays);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Location = new System.Drawing.Point(3, 10);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupBox1.Size = new System.Drawing.Size(250, 426);
            this.groupBox1.TabIndex = 11;
            this.groupBox1.TabStop = false;
            // 
            // cmbMM
            // 
            this.cmbMM.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cmbMM.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbMM.FormattingEnabled = true;
            this.cmbMM.Location = new System.Drawing.Point(138, 198);
            this.cmbMM.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.cmbMM.MaxLength = 2;
            this.cmbMM.Name = "cmbMM";
            this.cmbMM.Size = new System.Drawing.Size(92, 28);
            this.cmbMM.TabIndex = 33;
            this.cmbMM.TextChanged += new System.EventHandler(this.cmbMM_TextChanged);
            this.cmbMM.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cmbMM_KeyPress);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(115, 202);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(12, 20);
            this.label2.TabIndex = 32;
            this.label2.Text = ":";
            // 
            // cmbHH
            // 
            this.cmbHH.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cmbHH.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbHH.FormattingEnabled = true;
            this.cmbHH.Location = new System.Drawing.Point(15, 198);
            this.cmbHH.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.cmbHH.MaxLength = 2;
            this.cmbHH.Name = "cmbHH";
            this.cmbHH.Size = new System.Drawing.Size(92, 28);
            this.cmbHH.TabIndex = 31;
            this.cmbHH.TextChanged += new System.EventHandler(this.cmbHH_TextChanged);
            this.cmbHH.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cmbHH_KeyPress);
            // 
            // lkbAdd
            // 
            this.lkbAdd.AutoSize = true;
            this.lkbAdd.Location = new System.Drawing.Point(104, 23);
            this.lkbAdd.Name = "lkbAdd";
            this.lkbAdd.Size = new System.Drawing.Size(37, 20);
            this.lkbAdd.TabIndex = 6;
            this.lkbAdd.TabStop = true;
            this.lkbAdd.Text = "添加";
            this.lkbAdd.Click += new System.EventHandler(this.lkbAdd_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(14, 172);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(131, 20);
            this.label1.TabIndex = 30;
            this.label1.Text = "发送时间(HH:MM):";
            // 
            // dgv
            // 
            this.dgv.AllowUserToAddRows = false;
            this.dgv.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.编号,
            this.通知类别,
            this.自定义短语,
            this.提前通知天数,
            this.发送时间});
            this.dgv.ContextMenuStrip = this.cms;
            this.dgv.Location = new System.Drawing.Point(259, 10);
            this.dgv.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.dgv.Name = "dgv";
            this.dgv.ReadOnly = true;
            this.dgv.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders;
            this.dgv.RowTemplate.Height = 23;
            this.dgv.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgv.Size = new System.Drawing.Size(470, 426);
            this.dgv.TabIndex = 12;
            this.dgv.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_CellClick);
            // 
            // 编号
            // 
            this.编号.DataPropertyName = "id";
            this.编号.HeaderText = "编号";
            this.编号.Name = "编号";
            this.编号.ReadOnly = true;
            this.编号.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.编号.Width = 80;
            // 
            // 通知类别
            // 
            this.通知类别.DataPropertyName = "name";
            this.通知类别.HeaderText = "通知类别";
            this.通知类别.Name = "通知类别";
            this.通知类别.ReadOnly = true;
            this.通知类别.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // 自定义短语
            // 
            this.自定义短语.DataPropertyName = "content1";
            this.自定义短语.HeaderText = "自定义短语";
            this.自定义短语.Name = "自定义短语";
            this.自定义短语.ReadOnly = true;
            this.自定义短语.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.自定义短语.Width = 300;
            // 
            // 提前通知天数
            // 
            this.提前通知天数.DataPropertyName = "forwarddays";
            this.提前通知天数.HeaderText = "提前通知天数";
            this.提前通知天数.Name = "提前通知天数";
            this.提前通知天数.ReadOnly = true;
            this.提前通知天数.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // 发送时间
            // 
            this.发送时间.DataPropertyName = "sendtime";
            this.发送时间.HeaderText = "发送时间";
            this.发送时间.Name = "发送时间";
            this.发送时间.ReadOnly = true;
            this.发送时间.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // cms
            // 
            this.cms.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiDelete});
            this.cms.Name = "cms";
            this.cms.Size = new System.Drawing.Size(101, 26);
            // 
            // tsmiDelete
            // 
            this.tsmiDelete.Name = "tsmiDelete";
            this.tsmiDelete.Size = new System.Drawing.Size(100, 22);
            this.tsmiDelete.Text = "删除";
            this.tsmiDelete.Click += new System.EventHandler(this.tsmiDelete_Click);
            // 
            // frmOption
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(741, 442);
            this.Controls.Add(this.dgv);
            this.Controls.Add(this.groupBox1);
            this.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "frmOption";
            this.Opacity = 0.95D;
            this.ShowIcon = false;
            this.Text = "短信设置";
            this.Load += new System.EventHandler(this.frmOption_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).EndInit();
            this.cms.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cmbForwardDays;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtUsefulExpressions1;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.TextBox txtAi;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataGridView dgv;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.LinkLabel lkbAdd;
        private System.Windows.Forms.ContextMenuStrip cms;
        private System.Windows.Forms.ToolStripMenuItem tsmiDelete;
        private System.Windows.Forms.ComboBox cmbMM;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cmbHH;
        private System.Windows.Forms.DataGridViewTextBoxColumn 编号;
        private System.Windows.Forms.DataGridViewTextBoxColumn 通知类别;
        private System.Windows.Forms.DataGridViewTextBoxColumn 自定义短语;
        private System.Windows.Forms.DataGridViewTextBoxColumn 提前通知天数;
        private System.Windows.Forms.DataGridViewTextBoxColumn 发送时间;


    }
}