using System.Drawing;

namespace GoldenLady.Dress.View
{
    partial class FrmVenueCleanInfo
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
            this.rbCleaning = new System.Windows.Forms.RadioButton();
            this.rbFinish = new System.Windows.Forms.RadioButton();
            this.rbAccept = new System.Windows.Forms.RadioButton();
            this.lblSum = new System.Windows.Forms.Label();
            this.btnSearch = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.cmbVenues = new System.Windows.Forms.ComboBox();
            this.dgvDressCleanInfo = new System.Windows.Forms.DataGridView();
            this.DressBarCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DressStatus = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.EmployeeName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.OperateTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DressCurrentPosition = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.guanmin = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.礼服接收Tsm = new System.Windows.Forms.ToolStripMenuItem();
            this.清洗完成Tsm = new System.Windows.Forms.ToolStripMenuItem();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDressCleanInfo)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.rbCleaning);
            this.panel1.Controls.Add(this.rbFinish);
            this.panel1.Controls.Add(this.rbAccept);
            this.panel1.Controls.Add(this.lblSum);
            this.panel1.Controls.Add(this.btnSearch);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.cmbVenues);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(777, 62);
            this.panel1.TabIndex = 0;
            // 
            // rbCleaning
            // 
            this.rbCleaning.AutoSize = true;
            this.rbCleaning.Checked = true;
            this.rbCleaning.Location = new System.Drawing.Point(253, 18);
            this.rbCleaning.Name = "rbCleaning";
            this.rbCleaning.Size = new System.Drawing.Size(83, 24);
            this.rbCleaning.TabIndex = 6;
            this.rbCleaning.TabStop = true;
            this.rbCleaning.Text = "礼服送洗";
            this.rbCleaning.UseVisualStyleBackColor = true;
            // 
            // rbFinish
            // 
            this.rbFinish.AutoSize = true;
            this.rbFinish.Location = new System.Drawing.Point(451, 18);
            this.rbFinish.Name = "rbFinish";
            this.rbFinish.Size = new System.Drawing.Size(83, 24);
            this.rbFinish.TabIndex = 5;
            this.rbFinish.Text = "清洗完成";
            this.rbFinish.UseVisualStyleBackColor = true;
            // 
            // rbAccept
            // 
            this.rbAccept.AutoSize = true;
            this.rbAccept.Location = new System.Drawing.Point(353, 18);
            this.rbAccept.Name = "rbAccept";
            this.rbAccept.Size = new System.Drawing.Size(83, 24);
            this.rbAccept.TabIndex = 4;
            this.rbAccept.Text = "礼服接收";
            this.rbAccept.UseVisualStyleBackColor = true;
            // 
            // lblSum
            // 
            this.lblSum.AutoSize = true;
            this.lblSum.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.lblSum.Location = new System.Drawing.Point(679, 33);
            this.lblSum.Name = "lblSum";
            this.lblSum.Size = new System.Drawing.Size(79, 20);
            this.lblSum.TabIndex = 3;
            this.lblSum.Text = "显示总数：";
            // 
            // btnSearch
            // 
            this.btnSearch.BackColor = System.Drawing.Color.LightBlue;
            this.btnSearch.Location = new System.Drawing.Point(554, 13);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(89, 35);
            this.btnSearch.TabIndex = 2;
            this.btnSearch.Text = "查询";
            this.btnSearch.UseVisualStyleBackColor = false;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(32, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 20);
            this.label1.TabIndex = 1;
            this.label1.Text = "场 馆";
            // 
            // cmbVenues
            // 
            this.cmbVenues.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbVenues.FormattingEnabled = true;
            this.cmbVenues.Location = new System.Drawing.Point(88, 16);
            this.cmbVenues.Name = "cmbVenues";
            this.cmbVenues.Size = new System.Drawing.Size(133, 28);
            this.cmbVenues.TabIndex = 0;
            this.cmbVenues.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cmbVenues_KeyDown);
            // 
            // dgvDressCleanInfo
            // 
            this.dgvDressCleanInfo.AllowUserToAddRows = false;
            this.dgvDressCleanInfo.BackgroundColor = System.Drawing.Color.White;
            this.dgvDressCleanInfo.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDressCleanInfo.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.DressBarCode,
            this.DressStatus,
            this.EmployeeName,
            this.OperateTime,
            this.DressCurrentPosition,
            this.guanmin});
            this.dgvDressCleanInfo.ContextMenuStrip = this.contextMenuStrip1;
            this.dgvDressCleanInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvDressCleanInfo.Location = new System.Drawing.Point(0, 62);
            this.dgvDressCleanInfo.Name = "dgvDressCleanInfo";
            this.dgvDressCleanInfo.ReadOnly = true;
            this.dgvDressCleanInfo.RowTemplate.Height = 23;
            this.dgvDressCleanInfo.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvDressCleanInfo.Size = new System.Drawing.Size(777, 520);
            this.dgvDressCleanInfo.TabIndex = 1;
            // 
            // DressBarCode
            // 
            this.DressBarCode.DataPropertyName = "DressBarCode";
            this.DressBarCode.HeaderText = "条码";
            this.DressBarCode.Name = "DressBarCode";
            this.DressBarCode.ReadOnly = true;
            this.DressBarCode.Width = 120;
            // 
            // DressStatus
            // 
            this.DressStatus.DataPropertyName = "DressStatus";
            this.DressStatus.HeaderText = "礼服状态";
            this.DressStatus.Name = "DressStatus";
            this.DressStatus.ReadOnly = true;
            this.DressStatus.Width = 120;
            // 
            // EmployeeName
            // 
            this.EmployeeName.DataPropertyName = "EmployeeName";
            this.EmployeeName.HeaderText = "操作人员";
            this.EmployeeName.Name = "EmployeeName";
            this.EmployeeName.ReadOnly = true;
            // 
            // OperateTime
            // 
            this.OperateTime.DataPropertyName = "OperateTime";
            this.OperateTime.HeaderText = "操作时间";
            this.OperateTime.Name = "OperateTime";
            this.OperateTime.ReadOnly = true;
            this.OperateTime.Width = 150;
            // 
            // DressCurrentPosition
            // 
            this.DressCurrentPosition.DataPropertyName = "DressCurrentPosition";
            this.DressCurrentPosition.HeaderText = "位置";
            this.DressCurrentPosition.Name = "DressCurrentPosition";
            this.DressCurrentPosition.ReadOnly = true;
            this.DressCurrentPosition.Width = 120;
            // 
            // guanmin
            // 
            this.guanmin.DataPropertyName = "guanmin";
            this.guanmin.HeaderText = "所在场馆";
            this.guanmin.Name = "guanmin";
            this.guanmin.ReadOnly = true;
            this.guanmin.Width = 120;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.礼服接收Tsm,
            this.清洗完成Tsm});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(125, 48);
            // 
            // 礼服接收Tsm
            // 
            this.礼服接收Tsm.Name = "礼服接收Tsm";
            this.礼服接收Tsm.Size = new System.Drawing.Size(124, 22);
            this.礼服接收Tsm.Text = "礼服接收";
            this.礼服接收Tsm.Click += new System.EventHandler(this.礼服接收Tsm_Click);
            // 
            // 清洗完成Tsm
            // 
            this.清洗完成Tsm.Name = "清洗完成Tsm";
            this.清洗完成Tsm.Size = new System.Drawing.Size(124, 22);
            this.清洗完成Tsm.Text = "清洗完成";
            this.清洗完成Tsm.Click += new System.EventHandler(this.清洗完成Tsm_Click);
            // 
            // FrmVenueCleanInfo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.dgvDressCleanInfo);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Name = "FrmVenueCleanInfo";
            this.Size = new System.Drawing.Size(777, 582);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDressCleanInfo)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmbVenues;
        private System.Windows.Forms.DataGridView dgvDressCleanInfo;
        private System.Windows.Forms.DataGridViewTextBoxColumn DressBarCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn DressStatus;
        private System.Windows.Forms.DataGridViewTextBoxColumn EmployeeName;
        private System.Windows.Forms.DataGridViewTextBoxColumn OperateTime;
        private System.Windows.Forms.DataGridViewTextBoxColumn DressCurrentPosition;
        private System.Windows.Forms.DataGridViewTextBoxColumn guanmin;
        private System.Windows.Forms.Label lblSum;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 礼服接收Tsm;
        private System.Windows.Forms.ToolStripMenuItem 清洗完成Tsm;
        private System.Windows.Forms.RadioButton rbFinish;
        private System.Windows.Forms.RadioButton rbAccept;
        private System.Windows.Forms.RadioButton rbCleaning;
    }
}