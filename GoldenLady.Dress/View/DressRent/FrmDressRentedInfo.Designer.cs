namespace GoldenLady.Dress.View.DressRent
{
    partial class FrmDressRentedInfo
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
            this.chkAll = new System.Windows.Forms.CheckBox();
            this.btnExcel = new System.Windows.Forms.Button();
            this.dtpTakeEnd = new System.Windows.Forms.DateTimePicker();
            this.dtpTakeBegin = new System.Windows.Forms.DateTimePicker();
            this.dtpReurnEnd = new System.Windows.Forms.DateTimePicker();
            this.dtpMarryEnd = new System.Windows.Forms.DateTimePicker();
            this.btnPrint = new System.Windows.Forms.Button();
            this.rbBntDress = new System.Windows.Forms.RadioButton();
            this.rbBntCus = new System.Windows.Forms.RadioButton();
            this.lblSum = new System.Windows.Forms.Label();
            this.picImage = new System.Windows.Forms.PictureBox();
            this.cmbDresserss = new System.Windows.Forms.ComboBox();
            this.label15 = new System.Windows.Forms.Label();
            this.lblKey = new System.Windows.Forms.Label();
            this.txbKey = new System.Windows.Forms.TextBox();
            this.chktake = new System.Windows.Forms.CheckBox();
            this.chkMarry = new System.Windows.Forms.CheckBox();
            this.chkBack = new System.Windows.Forms.CheckBox();
            this.dtpMarryBegin = new System.Windows.Forms.DateTimePicker();
            this.dtpReurnBegin = new System.Windows.Forms.DateTimePicker();
            this.btnSeach = new System.Windows.Forms.Button();
            this.dgvOrders = new System.Windows.Forms.DataGridView();
            this.cmsDressOperate = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.礼服记录查询ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.新增礼服Tsm = new System.Windows.Forms.ToolStripMenuItem();
            this.修改总备注Tsm = new System.Windows.Forms.ToolStripMenuItem();
            this.修改单件备注Tsm = new System.Windows.Forms.ToolStripMenuItem();
            this.出租入库ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.删除tsm = new System.Windows.Forms.ToolStripMenuItem();
            this.出件Tsm = new System.Windows.Forms.ToolStripMenuItem();
            this.回件Tsm = new System.Windows.Forms.ToolStripMenuItem();
            this.打印Tsm = new System.Windows.Forms.ToolStripMenuItem();
            this.printDocument1 = new System.Drawing.Printing.PrintDocument();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picImage)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvOrders)).BeginInit();
            this.cmsDressOperate.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.chkAll);
            this.panel1.Controls.Add(this.btnExcel);
            this.panel1.Controls.Add(this.dtpTakeEnd);
            this.panel1.Controls.Add(this.dtpTakeBegin);
            this.panel1.Controls.Add(this.dtpReurnEnd);
            this.panel1.Controls.Add(this.dtpMarryEnd);
            this.panel1.Controls.Add(this.btnPrint);
            this.panel1.Controls.Add(this.rbBntDress);
            this.panel1.Controls.Add(this.rbBntCus);
            this.panel1.Controls.Add(this.lblSum);
            this.panel1.Controls.Add(this.picImage);
            this.panel1.Controls.Add(this.cmbDresserss);
            this.panel1.Controls.Add(this.label15);
            this.panel1.Controls.Add(this.lblKey);
            this.panel1.Controls.Add(this.txbKey);
            this.panel1.Controls.Add(this.chktake);
            this.panel1.Controls.Add(this.chkMarry);
            this.panel1.Controls.Add(this.chkBack);
            this.panel1.Controls.Add(this.dtpMarryBegin);
            this.panel1.Controls.Add(this.dtpReurnBegin);
            this.panel1.Controls.Add(this.btnSeach);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel1.Location = new System.Drawing.Point(720, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(260, 799);
            this.panel1.TabIndex = 0;
            // 
            // chkAll
            // 
            this.chkAll.AutoSize = true;
            this.chkAll.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.chkAll.Location = new System.Drawing.Point(143, 437);
            this.chkAll.Name = "chkAll";
            this.chkAll.Size = new System.Drawing.Size(75, 21);
            this.chkAll.TabIndex = 77;
            this.chkAll.Text = "打印全部";
            this.chkAll.UseVisualStyleBackColor = true;
            // 
            // btnExcel
            // 
            this.btnExcel.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.btnExcel.Font = new System.Drawing.Font("宋体", 11F);
            this.btnExcel.Location = new System.Drawing.Point(30, 390);
            this.btnExcel.Name = "btnExcel";
            this.btnExcel.Size = new System.Drawing.Size(89, 37);
            this.btnExcel.TabIndex = 76;
            this.btnExcel.Text = "导出Excel";
            this.btnExcel.UseVisualStyleBackColor = false;
            this.btnExcel.Click += new System.EventHandler(this.btnExcel_Click);
            // 
            // dtpTakeEnd
            // 
            this.dtpTakeEnd.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.dtpTakeEnd.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpTakeEnd.Location = new System.Drawing.Point(114, 104);
            this.dtpTakeEnd.Name = "dtpTakeEnd";
            this.dtpTakeEnd.Size = new System.Drawing.Size(89, 23);
            this.dtpTakeEnd.TabIndex = 75;
            // 
            // dtpTakeBegin
            // 
            this.dtpTakeBegin.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.dtpTakeBegin.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpTakeBegin.Location = new System.Drawing.Point(114, 75);
            this.dtpTakeBegin.Name = "dtpTakeBegin";
            this.dtpTakeBegin.Size = new System.Drawing.Size(89, 23);
            this.dtpTakeBegin.TabIndex = 74;
            // 
            // dtpReurnEnd
            // 
            this.dtpReurnEnd.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.dtpReurnEnd.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpReurnEnd.Location = new System.Drawing.Point(114, 220);
            this.dtpReurnEnd.Name = "dtpReurnEnd";
            this.dtpReurnEnd.Size = new System.Drawing.Size(89, 23);
            this.dtpReurnEnd.TabIndex = 73;
            // 
            // dtpMarryEnd
            // 
            this.dtpMarryEnd.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.dtpMarryEnd.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpMarryEnd.Location = new System.Drawing.Point(114, 162);
            this.dtpMarryEnd.Name = "dtpMarryEnd";
            this.dtpMarryEnd.Size = new System.Drawing.Size(89, 23);
            this.dtpMarryEnd.TabIndex = 72;
            // 
            // btnPrint
            // 
            this.btnPrint.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.btnPrint.Enabled = false;
            this.btnPrint.Font = new System.Drawing.Font("宋体", 11F);
            this.btnPrint.Location = new System.Drawing.Point(143, 390);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(89, 37);
            this.btnPrint.TabIndex = 70;
            this.btnPrint.Text = "打 印";
            this.btnPrint.UseVisualStyleBackColor = false;
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            // 
            // rbBntDress
            // 
            this.rbBntDress.AutoSize = true;
            this.rbBntDress.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.rbBntDress.Location = new System.Drawing.Point(143, 302);
            this.rbBntDress.Name = "rbBntDress";
            this.rbBntDress.Size = new System.Drawing.Size(74, 21);
            this.rbBntDress.TabIndex = 69;
            this.rbBntDress.Text = "礼服查询";
            this.rbBntDress.UseVisualStyleBackColor = true;
            this.rbBntDress.CheckedChanged += new System.EventHandler(this.rbBntDress_CheckedChanged);
            // 
            // rbBntCus
            // 
            this.rbBntCus.AutoSize = true;
            this.rbBntCus.Checked = true;
            this.rbBntCus.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.rbBntCus.Location = new System.Drawing.Point(42, 302);
            this.rbBntCus.Name = "rbBntCus";
            this.rbBntCus.Size = new System.Drawing.Size(74, 21);
            this.rbBntCus.TabIndex = 68;
            this.rbBntCus.TabStop = true;
            this.rbBntCus.Text = "顾客查询";
            this.rbBntCus.UseVisualStyleBackColor = true;
            this.rbBntCus.CheckedChanged += new System.EventHandler(this.rbBntCus_CheckedChanged);
            // 
            // lblSum
            // 
            this.lblSum.AutoSize = true;
            this.lblSum.BackColor = System.Drawing.Color.Transparent;
            this.lblSum.ForeColor = System.Drawing.Color.Maroon;
            this.lblSum.Location = new System.Drawing.Point(23, 441);
            this.lblSum.Name = "lblSum";
            this.lblSum.Size = new System.Drawing.Size(51, 20);
            this.lblSum.TabIndex = 67;
            this.lblSum.Text = "数量：";
            // 
            // picImage
            // 
            this.picImage.Location = new System.Drawing.Point(6, 464);
            this.picImage.Name = "picImage";
            this.picImage.Size = new System.Drawing.Size(251, 332);
            this.picImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picImage.TabIndex = 56;
            this.picImage.TabStop = false;
            this.picImage.Click += new System.EventHandler(this.picImage_Click);
            // 
            // cmbDresserss
            // 
            this.cmbDresserss.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbDresserss.FormattingEnabled = true;
            this.cmbDresserss.Location = new System.Drawing.Point(114, 29);
            this.cmbDresserss.Name = "cmbDresserss";
            this.cmbDresserss.Size = new System.Drawing.Size(115, 28);
            this.cmbDresserss.TabIndex = 66;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(38, 33);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(67, 20);
            this.label15.TabIndex = 64;
            this.label15.Text = "礼  服  师";
            // 
            // lblKey
            // 
            this.lblKey.AutoSize = true;
            this.lblKey.Location = new System.Drawing.Point(38, 259);
            this.lblKey.Name = "lblKey";
            this.lblKey.Size = new System.Drawing.Size(67, 20);
            this.lblKey.TabIndex = 53;
            this.lblKey.Text = "关  键  字";
            // 
            // txbKey
            // 
            this.txbKey.Location = new System.Drawing.Point(114, 256);
            this.txbKey.Name = "txbKey";
            this.txbKey.Size = new System.Drawing.Size(118, 26);
            this.txbKey.TabIndex = 54;
            this.txbKey.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txbKey_KeyDown);
            // 
            // chktake
            // 
            this.chktake.AutoSize = true;
            this.chktake.Checked = true;
            this.chktake.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chktake.Location = new System.Drawing.Point(26, 74);
            this.chktake.Name = "chktake";
            this.chktake.Size = new System.Drawing.Size(84, 24);
            this.chktake.TabIndex = 60;
            this.chktake.Text = "取衣日期";
            this.chktake.UseVisualStyleBackColor = true;
            // 
            // chkMarry
            // 
            this.chkMarry.AutoSize = true;
            this.chkMarry.Location = new System.Drawing.Point(26, 132);
            this.chkMarry.Name = "chkMarry";
            this.chkMarry.Size = new System.Drawing.Size(84, 24);
            this.chkMarry.TabIndex = 61;
            this.chkMarry.Text = "结婚日期";
            this.chkMarry.UseVisualStyleBackColor = true;
            // 
            // chkBack
            // 
            this.chkBack.AutoSize = true;
            this.chkBack.Location = new System.Drawing.Point(24, 190);
            this.chkBack.Name = "chkBack";
            this.chkBack.Size = new System.Drawing.Size(84, 24);
            this.chkBack.TabIndex = 62;
            this.chkBack.Text = "还衣日期";
            this.chkBack.UseVisualStyleBackColor = true;
            // 
            // dtpMarryBegin
            // 
            this.dtpMarryBegin.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.dtpMarryBegin.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpMarryBegin.Location = new System.Drawing.Point(114, 133);
            this.dtpMarryBegin.Name = "dtpMarryBegin";
            this.dtpMarryBegin.Size = new System.Drawing.Size(89, 23);
            this.dtpMarryBegin.TabIndex = 57;
            // 
            // dtpReurnBegin
            // 
            this.dtpReurnBegin.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.dtpReurnBegin.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpReurnBegin.Location = new System.Drawing.Point(114, 191);
            this.dtpReurnBegin.Name = "dtpReurnBegin";
            this.dtpReurnBegin.Size = new System.Drawing.Size(89, 23);
            this.dtpReurnBegin.TabIndex = 58;
            // 
            // btnSeach
            // 
            this.btnSeach.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.btnSeach.Font = new System.Drawing.Font("宋体", 11F);
            this.btnSeach.Location = new System.Drawing.Point(30, 338);
            this.btnSeach.Name = "btnSeach";
            this.btnSeach.Size = new System.Drawing.Size(202, 37);
            this.btnSeach.TabIndex = 55;
            this.btnSeach.Text = "查 询";
            this.btnSeach.UseVisualStyleBackColor = false;
            this.btnSeach.Click += new System.EventHandler(this.btnSeach_Click);
            // 
            // dgvOrders
            // 
            this.dgvOrders.AllowUserToAddRows = false;
            this.dgvOrders.BackgroundColor = System.Drawing.SystemColors.ControlLight;
            this.dgvOrders.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvOrders.ContextMenuStrip = this.cmsDressOperate;
            this.dgvOrders.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvOrders.Location = new System.Drawing.Point(0, 0);
            this.dgvOrders.MultiSelect = false;
            this.dgvOrders.Name = "dgvOrders";
            this.dgvOrders.ReadOnly = true;
            this.dgvOrders.RowHeadersWidth = 20;
            this.dgvOrders.RowTemplate.Height = 23;
            this.dgvOrders.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvOrders.Size = new System.Drawing.Size(720, 799);
            this.dgvOrders.TabIndex = 3;
            this.dgvOrders.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvOrders_CellClick);
            this.dgvOrders.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dgvOrders_CellFormatting);
            // 
            // cmsDressOperate
            // 
            this.cmsDressOperate.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cmsDressOperate.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.礼服记录查询ToolStripMenuItem,
            this.新增礼服Tsm,
            this.修改总备注Tsm,
            this.修改单件备注Tsm,
            this.出租入库ToolStripMenuItem,
            this.删除tsm,
            this.出件Tsm,
            this.回件Tsm,
            this.打印Tsm});
            this.cmsDressOperate.Name = "cmsDressOperate";
            this.cmsDressOperate.Size = new System.Drawing.Size(163, 220);
            // 
            // 礼服记录查询ToolStripMenuItem
            // 
            this.礼服记录查询ToolStripMenuItem.Enabled = false;
            this.礼服记录查询ToolStripMenuItem.Name = "礼服记录查询ToolStripMenuItem";
            this.礼服记录查询ToolStripMenuItem.Size = new System.Drawing.Size(162, 24);
            this.礼服记录查询ToolStripMenuItem.Text = "礼服记录查询";
            this.礼服记录查询ToolStripMenuItem.Click += new System.EventHandler(this.礼服记录查询ToolStripMenuItem_Click);
            // 
            // 新增礼服Tsm
            // 
            this.新增礼服Tsm.Name = "新增礼服Tsm";
            this.新增礼服Tsm.Size = new System.Drawing.Size(162, 24);
            this.新增礼服Tsm.Text = "新增礼服";
            this.新增礼服Tsm.Click += new System.EventHandler(this.新增礼服Tsm_Click);
            // 
            // 修改总备注Tsm
            // 
            this.修改总备注Tsm.Name = "修改总备注Tsm";
            this.修改总备注Tsm.Size = new System.Drawing.Size(162, 24);
            this.修改总备注Tsm.Text = "修改总备注";
            this.修改总备注Tsm.Click += new System.EventHandler(this.修改备注Tsm_Click);
            // 
            // 修改单件备注Tsm
            // 
            this.修改单件备注Tsm.Enabled = false;
            this.修改单件备注Tsm.Name = "修改单件备注Tsm";
            this.修改单件备注Tsm.Size = new System.Drawing.Size(162, 24);
            this.修改单件备注Tsm.Text = "修改单件备注";
            this.修改单件备注Tsm.Click += new System.EventHandler(this.修改单件备注Tsm_Click);
            // 
            // 出租入库ToolStripMenuItem
            // 
            this.出租入库ToolStripMenuItem.Enabled = false;
            this.出租入库ToolStripMenuItem.Name = "出租入库ToolStripMenuItem";
            this.出租入库ToolStripMenuItem.Size = new System.Drawing.Size(162, 24);
            this.出租入库ToolStripMenuItem.Text = "出租入库";
            this.出租入库ToolStripMenuItem.Click += new System.EventHandler(this.出租入库ToolStripMenuItem_Click);
            // 
            // 删除tsm
            // 
            this.删除tsm.Enabled = false;
            this.删除tsm.Name = "删除tsm";
            this.删除tsm.Size = new System.Drawing.Size(162, 24);
            this.删除tsm.Text = "删除礼服";
            this.删除tsm.Click += new System.EventHandler(this.删除礼服tsm_Click);
            // 
            // 出件Tsm
            // 
            this.出件Tsm.Name = "出件Tsm";
            this.出件Tsm.Size = new System.Drawing.Size(162, 24);
            this.出件Tsm.Text = "出件";
            this.出件Tsm.Click += new System.EventHandler(this.出件Tsm_Click);
            // 
            // 回件Tsm
            // 
            this.回件Tsm.Name = "回件Tsm";
            this.回件Tsm.Size = new System.Drawing.Size(162, 24);
            this.回件Tsm.Text = "回件";
            this.回件Tsm.Click += new System.EventHandler(this.回件Tsm_Click);
            // 
            // 打印Tsm
            // 
            this.打印Tsm.Enabled = false;
            this.打印Tsm.Name = "打印Tsm";
            this.打印Tsm.Size = new System.Drawing.Size(162, 24);
            this.打印Tsm.Text = "打印";
            this.打印Tsm.Click += new System.EventHandler(this.打印Tsm_Click);
            // 
            // printDocument1
            // 
            this.printDocument1.PrintPage += new System.Drawing.Printing.PrintPageEventHandler(this.printDocument1_PrintPage);
            // 
            // FrmDressRentedInfo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.dgvOrders);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "FrmDressRentedInfo";
            this.Size = new System.Drawing.Size(980, 799);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picImage)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvOrders)).EndInit();
            this.cmsDressOperate.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox picImage;
        private System.Windows.Forms.ComboBox cmbDresserss;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label lblKey;
        private System.Windows.Forms.TextBox txbKey;
        private System.Windows.Forms.CheckBox chktake;
        private System.Windows.Forms.CheckBox chkMarry;
        private System.Windows.Forms.CheckBox chkBack;
        private System.Windows.Forms.DateTimePicker dtpMarryBegin;
        private System.Windows.Forms.DateTimePicker dtpReurnBegin;
        private System.Windows.Forms.Button btnSeach;
        private System.Windows.Forms.Label lblSum;
        private System.Windows.Forms.DataGridView dgvOrders;
        private System.Windows.Forms.RadioButton rbBntDress;
        private System.Windows.Forms.RadioButton rbBntCus;
        private System.Windows.Forms.Button btnPrint;
        private System.Drawing.Printing.PrintDocument printDocument1;
        private System.Windows.Forms.ContextMenuStrip cmsDressOperate;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem 删除tsm;
        private System.Windows.Forms.ToolStripMenuItem 打印Tsm;
        private System.Windows.Forms.ToolStripMenuItem 修改总备注Tsm;
        private System.Windows.Forms.ToolStripMenuItem 新增礼服Tsm;
        private System.Windows.Forms.ToolStripMenuItem 出件Tsm;
        private System.Windows.Forms.ToolStripMenuItem 回件Tsm;
        private System.Windows.Forms.DateTimePicker dtpMarryEnd;
        private System.Windows.Forms.DateTimePicker dtpReurnEnd;
        private System.Windows.Forms.ToolStripMenuItem 出租入库ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 礼服记录查询ToolStripMenuItem;
        private System.Windows.Forms.DateTimePicker dtpTakeEnd;
        private System.Windows.Forms.DateTimePicker dtpTakeBegin;
        private System.Windows.Forms.Button btnExcel;
        private System.Windows.Forms.ToolStripMenuItem 修改单件备注Tsm;
        private System.Windows.Forms.CheckBox chkAll;
    }
}
