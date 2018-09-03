namespace GoldenLady.Dress.View
{
    partial class FrmDressInVenue
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
            this.lblSum = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.picImage = new System.Windows.Forms.PictureBox();
            this.txtDresBarCode = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.dgvDressInfo = new System.Windows.Forms.DataGridView();
            this.DressBarCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DressNumbers = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DressCurrentPosition = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.RuleName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DressUse = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DressStatus = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.lblOperate = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picImage)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDressInfo)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.lblOperate);
            this.panel1.Controls.Add(this.lblSum);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.picImage);
            this.panel1.Controls.Add(this.txtDresBarCode);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel1.Location = new System.Drawing.Point(725, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(232, 686);
            this.panel1.TabIndex = 0;
            // 
            // lblSum
            // 
            this.lblSum.AutoSize = true;
            this.lblSum.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.lblSum.ForeColor = System.Drawing.Color.Black;
            this.lblSum.Location = new System.Drawing.Point(6, 135);
            this.lblSum.Name = "lblSum";
            this.lblSum.Size = new System.Drawing.Size(87, 20);
            this.lblSum.TabIndex = 13;
            this.lblSum.Text = "显示数量：0";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.ForeColor = System.Drawing.Color.Maroon;
            this.label1.Location = new System.Drawing.Point(48, 38);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(138, 20);
            this.label1.TabIndex = 12;
            this.label1.Text = "(按键盘Enter键操作)";
            // 
            // picImage
            // 
            this.picImage.BackColor = System.Drawing.Color.White;
            this.picImage.Location = new System.Drawing.Point(3, 175);
            this.picImage.Name = "picImage";
            this.picImage.Size = new System.Drawing.Size(226, 343);
            this.picImage.TabIndex = 10;
            this.picImage.TabStop = false;
            // 
            // txtDresBarCode
            // 
            this.txtDresBarCode.Location = new System.Drawing.Point(75, 77);
            this.txtDresBarCode.Name = "txtDresBarCode";
            this.txtDresBarCode.Size = new System.Drawing.Size(148, 26);
            this.txtDresBarCode.TabIndex = 8;
            this.txtDresBarCode.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtDresBarCode_KeyDown);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(4, 80);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 20);
            this.label2.TabIndex = 7;
            this.label2.Text = "礼服条码";
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
            this.DressCurrentPosition,
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
            this.dgvDressInfo.Size = new System.Drawing.Size(725, 686);
            this.dgvDressInfo.TabIndex = 4;
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
            // DressCurrentPosition
            // 
            this.DressCurrentPosition.DataPropertyName = "DressCurrentPosition";
            this.DressCurrentPosition.HeaderText = "所在场馆";
            this.DressCurrentPosition.Name = "DressCurrentPosition";
            this.DressCurrentPosition.ReadOnly = true;
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
            this.toolStripMenuItem1});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(137, 26);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(136, 22);
            this.toolStripMenuItem1.Text = "删除并撤销";
            this.toolStripMenuItem1.Click += new System.EventHandler(this.toolStripMenuItem1_Click);
            // 
            // lblOperate
            // 
            this.lblOperate.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lblOperate.AutoSize = true;
            this.lblOperate.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.lblOperate.Font = new System.Drawing.Font("微软雅黑", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblOperate.ForeColor = System.Drawing.Color.Black;
            this.lblOperate.Location = new System.Drawing.Point(70, 0);
            this.lblOperate.Name = "lblOperate";
            this.lblOperate.Size = new System.Drawing.Size(88, 25);
            this.lblOperate.TabIndex = 20;
            this.lblOperate.Text = "操作类型";
            // 
            // FrmDressToVenue
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.Controls.Add(this.dgvDressInfo);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Name = "FrmDressToVenue";
            this.Size = new System.Drawing.Size(957, 686);
            this.Load += new System.EventHandler(this.FrmDressToVenue_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picImage)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDressInfo)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DataGridView dgvDressInfo;
        private System.Windows.Forms.TextBox txtDresBarCode;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.PictureBox picImage;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblSum;
        private System.Windows.Forms.DataGridViewTextBoxColumn DressBarCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn DressNumbers;
        private System.Windows.Forms.DataGridViewTextBoxColumn DressCurrentPosition;
        private System.Windows.Forms.DataGridViewTextBoxColumn RuleName;
        private System.Windows.Forms.DataGridViewTextBoxColumn DressUse;
        private System.Windows.Forms.DataGridViewTextBoxColumn DressStatus;
        private System.Windows.Forms.Label lblOperate;
    }
}