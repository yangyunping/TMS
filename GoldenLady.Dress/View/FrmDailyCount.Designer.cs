namespace GoldenLady.Dress.View
{
    partial class FrmDailyCount
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
            this.txtDateCnt = new System.Windows.Forms.TextBox();
            this.picDress = new System.Windows.Forms.PictureBox();
            this.lblSum = new System.Windows.Forms.Label();
            this.btnDressSearch = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.cmbVenues = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.dgvDresses = new System.Windows.Forms.DataGridView();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.入库Tsm = new System.Windows.Forms.ToolStripMenuItem();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picDress)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDresses)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.txtDateCnt);
            this.panel1.Controls.Add(this.picDress);
            this.panel1.Controls.Add(this.lblSum);
            this.panel1.Controls.Add(this.btnDressSearch);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.cmbVenues);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel1.Location = new System.Drawing.Point(689, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(230, 596);
            this.panel1.TabIndex = 0;
            // 
            // txtDateCnt
            // 
            this.txtDateCnt.Location = new System.Drawing.Point(36, 130);
            this.txtDateCnt.Name = "txtDateCnt";
            this.txtDateCnt.Size = new System.Drawing.Size(165, 26);
            this.txtDateCnt.TabIndex = 147;
            this.txtDateCnt.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtDateCnt_KeyDown);
            // 
            // picDress
            // 
            this.picDress.Location = new System.Drawing.Point(0, 279);
            this.picDress.Name = "picDress";
            this.picDress.Size = new System.Drawing.Size(224, 301);
            this.picDress.TabIndex = 146;
            this.picDress.TabStop = false;
            // 
            // lblSum
            // 
            this.lblSum.AutoSize = true;
            this.lblSum.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.lblSum.ForeColor = System.Drawing.Color.Black;
            this.lblSum.Location = new System.Drawing.Point(36, 229);
            this.lblSum.Name = "lblSum";
            this.lblSum.Size = new System.Drawing.Size(87, 20);
            this.lblSum.TabIndex = 145;
            this.lblSum.Text = "显示数量：0";
            // 
            // btnDressSearch
            // 
            this.btnDressSearch.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.btnDressSearch.Location = new System.Drawing.Point(36, 181);
            this.btnDressSearch.Name = "btnDressSearch";
            this.btnDressSearch.Size = new System.Drawing.Size(165, 35);
            this.btnDressSearch.TabIndex = 144;
            this.btnDressSearch.Text = "查  询";
            this.btnDressSearch.UseVisualStyleBackColor = false;
            this.btnDressSearch.Click += new System.EventHandler(this.btnDressSearch_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(32, 107);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(79, 20);
            this.label1.TabIndex = 143;
            this.label1.Text = "未归还天数";
            // 
            // cmbVenues
            // 
            this.cmbVenues.BackColor = System.Drawing.Color.White;
            this.cmbVenues.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cmbVenues.FormattingEnabled = true;
            this.cmbVenues.Location = new System.Drawing.Point(36, 52);
            this.cmbVenues.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.cmbVenues.Name = "cmbVenues";
            this.cmbVenues.Size = new System.Drawing.Size(165, 28);
            this.cmbVenues.TabIndex = 142;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.Location = new System.Drawing.Point(32, 28);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 20);
            this.label2.TabIndex = 141;
            this.label2.Text = "场馆名称";
            // 
            // dgvDresses
            // 
            this.dgvDresses.AllowUserToAddRows = false;
            this.dgvDresses.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dgvDresses.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDresses.ContextMenuStrip = this.contextMenuStrip1;
            this.dgvDresses.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvDresses.Location = new System.Drawing.Point(0, 0);
            this.dgvDresses.MultiSelect = false;
            this.dgvDresses.Name = "dgvDresses";
            this.dgvDresses.ReadOnly = true;
            this.dgvDresses.RowHeadersWidth = 10;
            this.dgvDresses.RowTemplate.Height = 23;
            this.dgvDresses.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvDresses.Size = new System.Drawing.Size(689, 596);
            this.dgvDresses.TabIndex = 1;
            this.dgvDresses.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvDresses_CellClick);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.入库Tsm});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(101, 26);
            // 
            // 入库Tsm
            // 
            this.入库Tsm.Name = "入库Tsm";
            this.入库Tsm.Size = new System.Drawing.Size(100, 22);
            this.入库Tsm.Text = "入库";
            this.入库Tsm.Click += new System.EventHandler(this.入库Tsm_Click);
            // 
            // FrmDailyCount
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.dgvDresses);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "FrmDailyCount";
            this.Size = new System.Drawing.Size(919, 596);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picDress)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDresses)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DataGridView dgvDresses;
        private System.Windows.Forms.ComboBox cmbVenues;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblSum;
        private System.Windows.Forms.Button btnDressSearch;
        private System.Windows.Forms.PictureBox picDress;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 入库Tsm;
        private System.Windows.Forms.TextBox txtDateCnt;
    }
}