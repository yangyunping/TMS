using System.Windows.Forms;

namespace GoldenLady.Dress.View
{
    partial class FrmDressCleaning
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
            this.lblOperate = new System.Windows.Forms.Label();
            this.lblSum = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.picImage = new System.Windows.Forms.PictureBox();
            this.btnAdd = new System.Windows.Forms.Button();
            this.numerUd = new System.Windows.Forms.NumericUpDown();
            this.cmbSmallGoods = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnPrint = new System.Windows.Forms.Button();
            this.btnSum = new System.Windows.Forms.Button();
            this.txtDresBarCode = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.dgvCount = new System.Windows.Forms.DataGridView();
            this.TypeName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Count = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.contextMenuStrip2 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.dgvDressInfo = new System.Windows.Forms.DataGridView();
            this.DressBarCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DressNumbers = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.guanmin = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.RuleName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DressUse = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DressStatus = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.tsmDelete = new System.Windows.Forms.ToolStripMenuItem();
            this.printResuilt = new System.Drawing.Printing.PrintDocument();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picImage)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numerUd)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCount)).BeginInit();
            this.contextMenuStrip2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDressInfo)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.lblOperate);
            this.panel1.Controls.Add(this.lblSum);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.picImage);
            this.panel1.Controls.Add(this.btnAdd);
            this.panel1.Controls.Add(this.numerUd);
            this.panel1.Controls.Add(this.cmbSmallGoods);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.btnPrint);
            this.panel1.Controls.Add(this.btnSum);
            this.panel1.Controls.Add(this.txtDresBarCode);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel1.Location = new System.Drawing.Point(756, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(266, 614);
            this.panel1.TabIndex = 1;
            // 
            // lblOperate
            // 
            this.lblOperate.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lblOperate.AutoSize = true;
            this.lblOperate.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.lblOperate.Font = new System.Drawing.Font("微软雅黑", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblOperate.ForeColor = System.Drawing.Color.Black;
            this.lblOperate.Location = new System.Drawing.Point(91, 0);
            this.lblOperate.Name = "lblOperate";
            this.lblOperate.Size = new System.Drawing.Size(88, 25);
            this.lblOperate.TabIndex = 19;
            this.lblOperate.Text = "操作类型";
            // 
            // lblSum
            // 
            this.lblSum.AutoSize = true;
            this.lblSum.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.lblSum.ForeColor = System.Drawing.Color.Black;
            this.lblSum.Location = new System.Drawing.Point(7, 211);
            this.lblSum.Name = "lblSum";
            this.lblSum.Size = new System.Drawing.Size(87, 20);
            this.lblSum.TabIndex = 18;
            this.lblSum.Text = "显示数量：0";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.ForeColor = System.Drawing.Color.Maroon;
            this.label3.Location = new System.Drawing.Point(73, 28);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(138, 20);
            this.label3.TabIndex = 17;
            this.label3.Text = "(按Enter键录入操作)";
            // 
            // picImage
            // 
            this.picImage.BackColor = System.Drawing.Color.White;
            this.picImage.Location = new System.Drawing.Point(3, 245);
            this.picImage.Name = "picImage";
            this.picImage.Size = new System.Drawing.Size(260, 366);
            this.picImage.TabIndex = 11;
            this.picImage.TabStop = false;
            this.picImage.Click += new System.EventHandler(this.picImage_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.AutoSize = true;
            this.btnAdd.BackColor = System.Drawing.Color.LightBlue;
            this.btnAdd.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnAdd.Location = new System.Drawing.Point(219, 99);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.btnAdd.Size = new System.Drawing.Size(42, 35);
            this.btnAdd.TabIndex = 15;
            this.btnAdd.Text = "添加";
            this.btnAdd.UseVisualStyleBackColor = false;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // numerUd
            // 
            this.numerUd.Location = new System.Drawing.Point(171, 103);
            this.numerUd.Name = "numerUd";
            this.numerUd.Size = new System.Drawing.Size(49, 26);
            this.numerUd.TabIndex = 14;
            // 
            // cmbSmallGoods
            // 
            this.cmbSmallGoods.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbSmallGoods.FormattingEnabled = true;
            this.cmbSmallGoods.Location = new System.Drawing.Point(74, 102);
            this.cmbSmallGoods.Name = "cmbSmallGoods";
            this.cmbSmallGoods.Size = new System.Drawing.Size(96, 28);
            this.cmbSmallGoods.TabIndex = 13;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(7, 105);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 20);
            this.label1.TabIndex = 12;
            this.label1.Text = "小件类别";
            // 
            // btnPrint
            // 
            this.btnPrint.BackColor = System.Drawing.Color.LightBlue;
            this.btnPrint.Location = new System.Drawing.Point(154, 152);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(106, 40);
            this.btnPrint.TabIndex = 10;
            this.btnPrint.Text = "打 印";
            this.btnPrint.UseVisualStyleBackColor = false;
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            // 
            // btnSum
            // 
            this.btnSum.BackColor = System.Drawing.Color.LightBlue;
            this.btnSum.Location = new System.Drawing.Point(10, 152);
            this.btnSum.Name = "btnSum";
            this.btnSum.Size = new System.Drawing.Size(106, 40);
            this.btnSum.TabIndex = 7;
            this.btnSum.Text = "统 计";
            this.btnSum.UseVisualStyleBackColor = false;
            this.btnSum.Click += new System.EventHandler(this.btnSum_Click);
            // 
            // txtDresBarCode
            // 
            this.txtDresBarCode.Location = new System.Drawing.Point(77, 51);
            this.txtDresBarCode.Name = "txtDresBarCode";
            this.txtDresBarCode.Size = new System.Drawing.Size(183, 26);
            this.txtDresBarCode.TabIndex = 1;
            this.txtDresBarCode.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtDresBarCode_KeyDown);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 54);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 20);
            this.label2.TabIndex = 5;
            this.label2.Text = "礼服条码";
            // 
            // dgvCount
            // 
            this.dgvCount.AllowUserToAddRows = false;
            this.dgvCount.BackgroundColor = System.Drawing.SystemColors.ButtonFace;
            this.dgvCount.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCount.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.TypeName,
            this.Count});
            this.dgvCount.ContextMenuStrip = this.contextMenuStrip2;
            this.dgvCount.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.dgvCount.Location = new System.Drawing.Point(0, 463);
            this.dgvCount.Name = "dgvCount";
            this.dgvCount.RowTemplate.Height = 23;
            this.dgvCount.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvCount.Size = new System.Drawing.Size(756, 151);
            this.dgvCount.TabIndex = 4;
            // 
            // TypeName
            // 
            this.TypeName.DataPropertyName = "TypeName";
            this.TypeName.HeaderText = "类别";
            this.TypeName.Name = "TypeName";
            // 
            // Count
            // 
            this.Count.DataPropertyName = "Count";
            this.Count.HeaderText = "件数";
            this.Count.Name = "Count";
            this.Count.Width = 80;
            // 
            // contextMenuStrip2
            // 
            this.contextMenuStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem1});
            this.contextMenuStrip2.Name = "contextMenuStrip1";
            this.contextMenuStrip2.Size = new System.Drawing.Size(101, 26);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(100, 22);
            this.toolStripMenuItem1.Text = "删除";
            this.toolStripMenuItem1.Click += new System.EventHandler(this.toolStripMenuItem1_Click);
            // 
            // dgvDressInfo
            // 
            this.dgvDressInfo.AllowUserToAddRows = false;
            this.dgvDressInfo.BackgroundColor = System.Drawing.Color.White;
            this.dgvDressInfo.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvDressInfo.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDressInfo.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.DressBarCode,
            this.DressNumbers,
            this.guanmin,
            this.RuleName,
            this.DressUse,
            this.DressStatus});
            this.dgvDressInfo.ContextMenuStrip = this.contextMenuStrip1;
            this.dgvDressInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvDressInfo.Location = new System.Drawing.Point(0, 0);
            this.dgvDressInfo.MultiSelect = false;
            this.dgvDressInfo.Name = "dgvDressInfo";
            this.dgvDressInfo.ReadOnly = true;
            this.dgvDressInfo.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.dgvDressInfo.RowHeadersWidth = 20;
            this.dgvDressInfo.RowTemplate.Height = 23;
            this.dgvDressInfo.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvDressInfo.Size = new System.Drawing.Size(756, 463);
            this.dgvDressInfo.TabIndex = 5;
            this.dgvDressInfo.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvDressInfo_CellClick);
            // 
            // DressBarCode
            // 
            this.DressBarCode.DataPropertyName = "DressBarCode";
            this.DressBarCode.HeaderText = "礼服条码";
            this.DressBarCode.Name = "DressBarCode";
            this.DressBarCode.ReadOnly = true;
            // 
            // DressNumbers
            // 
            this.DressNumbers.DataPropertyName = "DressNumbers";
            this.DressNumbers.HeaderText = "款式编号";
            this.DressNumbers.Name = "DressNumbers";
            this.DressNumbers.ReadOnly = true;
            // 
            // guanmin
            // 
            this.guanmin.DataPropertyName = "guanmin";
            this.guanmin.HeaderText = "所在场馆";
            this.guanmin.Name = "guanmin";
            this.guanmin.ReadOnly = true;
            // 
            // RuleName
            // 
            this.RuleName.DataPropertyName = "RuleName";
            this.RuleName.HeaderText = "类别";
            this.RuleName.Name = "RuleName";
            this.RuleName.ReadOnly = true;
            this.RuleName.Width = 70;
            // 
            // DressUse
            // 
            this.DressUse.DataPropertyName = "DressUse";
            this.DressUse.HeaderText = "礼服用途";
            this.DressUse.Name = "DressUse";
            this.DressUse.ReadOnly = true;
            // 
            // DressStatus
            // 
            this.DressStatus.DataPropertyName = "DressStatus";
            this.DressStatus.HeaderText = "改前状态";
            this.DressStatus.Name = "DressStatus";
            this.DressStatus.ReadOnly = true;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmDelete});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(137, 26);
            // 
            // tsmDelete
            // 
            this.tsmDelete.Name = "tsmDelete";
            this.tsmDelete.Size = new System.Drawing.Size(136, 22);
            this.tsmDelete.Text = "删除并撤销";
            this.tsmDelete.Click += new System.EventHandler(this.tsmDelete_Click);
            // 
            // printResuilt
            // 
            this.printResuilt.DocumentName = "XX(打印清单可能需要一到两分钟，请稍等...)";
            this.printResuilt.PrintPage += new System.Drawing.Printing.PrintPageEventHandler(this.printResuilt_PrintPage);
            // 
            // FrmDressCleaning
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.Controls.Add(this.dgvDressInfo);
            this.Controls.Add(this.dgvCount);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Name = "FrmDressCleaning";
            this.Size = new System.Drawing.Size(1022, 614);
            this.Load += new System.EventHandler(this.FrmDressCleaning_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picImage)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numerUd)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCount)).EndInit();
            this.contextMenuStrip2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDressInfo)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Panel panel1;
        private Button btnSum;
        private TextBox txtDresBarCode;
        private Label label2;
        private Button btnPrint;
        private PictureBox picImage;
        private Button btnAdd;
        private NumericUpDown numerUd;
        private ComboBox cmbSmallGoods;
        private Label label1;
        private DataGridView dgvCount;
        private DataGridView dgvDressInfo;
        private ContextMenuStrip contextMenuStrip1;
        private ToolStripMenuItem tsmDelete;
        private ContextMenuStrip contextMenuStrip2;
        private ToolStripMenuItem toolStripMenuItem1;
        private DataGridViewTextBoxColumn TypeName;
        private DataGridViewTextBoxColumn Count;
        private System.Drawing.Printing.PrintDocument printResuilt;
        private Label label3;
        private Label lblSum;
        private Label lblOperate;
        private DataGridViewTextBoxColumn DressBarCode;
        private DataGridViewTextBoxColumn DressNumbers;
        private DataGridViewTextBoxColumn guanmin;
        private DataGridViewTextBoxColumn RuleName;
        private DataGridViewTextBoxColumn DressUse;
        private DataGridViewTextBoxColumn DressStatus;
    }
}