namespace GoldenLady.Dress.View.DressRent
{
    partial class FrmOrdersSearch
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
            this.lblSum = new System.Windows.Forms.Label();
            this.btnSearch = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.chkMarry = new System.Windows.Forms.CheckBox();
            this.chkOrder = new System.Windows.Forms.CheckBox();
            this.txtKey = new System.Windows.Forms.TextBox();
            this.dtpMarryDateE = new System.Windows.Forms.DateTimePicker();
            this.dtpMarryDateG = new System.Windows.Forms.DateTimePicker();
            this.dtpOrderDateE = new System.Windows.Forms.DateTimePicker();
            this.dtpOrderDateG = new System.Windows.Forms.DateTimePicker();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.dgvOrders = new System.Windows.Forms.DataGridView();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.电子排单ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.查看排单ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.婚期确定ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.婚期更改ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.短信发送ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.电话追踪ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dgvCash = new System.Windows.Forms.DataGridView();
            this.dgvMemary = new System.Windows.Forms.DataGridView();
            this.btnExcel = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvOrders)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCash)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMemary)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnExcel);
            this.panel1.Controls.Add(this.lblSum);
            this.panel1.Controls.Add(this.btnSearch);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.chkMarry);
            this.panel1.Controls.Add(this.chkOrder);
            this.panel1.Controls.Add(this.txtKey);
            this.panel1.Controls.Add(this.dtpMarryDateE);
            this.panel1.Controls.Add(this.dtpMarryDateG);
            this.panel1.Controls.Add(this.dtpOrderDateE);
            this.panel1.Controls.Add(this.dtpOrderDateG);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel1.Location = new System.Drawing.Point(831, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(258, 660);
            this.panel1.TabIndex = 0;
            // 
            // lblSum
            // 
            this.lblSum.AutoSize = true;
            this.lblSum.BackColor = System.Drawing.Color.Transparent;
            this.lblSum.ForeColor = System.Drawing.Color.Red;
            this.lblSum.Location = new System.Drawing.Point(33, 392);
            this.lblSum.Name = "lblSum";
            this.lblSum.Size = new System.Drawing.Size(79, 20);
            this.lblSum.TabIndex = 11;
            this.lblSum.Text = "显示总数：";
            // 
            // btnSearch
            // 
            this.btnSearch.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.btnSearch.Location = new System.Drawing.Point(24, 320);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(110, 39);
            this.btnSearch.TabIndex = 10;
            this.btnSearch.Text = "查   询";
            this.btnSearch.UseVisualStyleBackColor = false;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(20, 267);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 20);
            this.label2.TabIndex = 9;
            this.label2.Text = "关键字：";
            // 
            // chkMarry
            // 
            this.chkMarry.AutoSize = true;
            this.chkMarry.Location = new System.Drawing.Point(24, 133);
            this.chkMarry.Name = "chkMarry";
            this.chkMarry.Size = new System.Drawing.Size(84, 24);
            this.chkMarry.TabIndex = 8;
            this.chkMarry.Text = "结婚日期";
            this.chkMarry.UseVisualStyleBackColor = true;
            this.chkMarry.CheckedChanged += new System.EventHandler(this.chkMarry_CheckedChanged);
            // 
            // chkOrder
            // 
            this.chkOrder.AutoSize = true;
            this.chkOrder.Checked = true;
            this.chkOrder.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkOrder.Location = new System.Drawing.Point(24, 18);
            this.chkOrder.Name = "chkOrder";
            this.chkOrder.Size = new System.Drawing.Size(84, 24);
            this.chkOrder.TabIndex = 7;
            this.chkOrder.Text = "订单日期";
            this.chkOrder.UseVisualStyleBackColor = true;
            this.chkOrder.CheckedChanged += new System.EventHandler(this.chkOrder_CheckedChanged);
            // 
            // txtKey
            // 
            this.txtKey.Location = new System.Drawing.Point(92, 264);
            this.txtKey.Name = "txtKey";
            this.txtKey.Size = new System.Drawing.Size(137, 26);
            this.txtKey.TabIndex = 6;
            this.txtKey.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtKey_KeyDown);
            // 
            // dtpMarryDateE
            // 
            this.dtpMarryDateE.Enabled = false;
            this.dtpMarryDateE.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpMarryDateE.Location = new System.Drawing.Point(92, 204);
            this.dtpMarryDateE.Name = "dtpMarryDateE";
            this.dtpMarryDateE.Size = new System.Drawing.Size(137, 26);
            this.dtpMarryDateE.TabIndex = 5;
            // 
            // dtpMarryDateG
            // 
            this.dtpMarryDateG.Enabled = false;
            this.dtpMarryDateG.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpMarryDateG.Location = new System.Drawing.Point(92, 163);
            this.dtpMarryDateG.Name = "dtpMarryDateG";
            this.dtpMarryDateG.Size = new System.Drawing.Size(137, 26);
            this.dtpMarryDateG.TabIndex = 4;
            // 
            // dtpOrderDateE
            // 
            this.dtpOrderDateE.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpOrderDateE.Location = new System.Drawing.Point(92, 89);
            this.dtpOrderDateE.Name = "dtpOrderDateE";
            this.dtpOrderDateE.Size = new System.Drawing.Size(137, 26);
            this.dtpOrderDateE.TabIndex = 3;
            // 
            // dtpOrderDateG
            // 
            this.dtpOrderDateG.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpOrderDateG.Location = new System.Drawing.Point(92, 48);
            this.dtpOrderDateG.Name = "dtpOrderDateG";
            this.dtpOrderDateG.Size = new System.Drawing.Size(137, 26);
            this.dtpOrderDateG.TabIndex = 2;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.dgvOrders);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.dgvCash);
            this.splitContainer1.Panel2.Controls.Add(this.dgvMemary);
            this.splitContainer1.Size = new System.Drawing.Size(831, 660);
            this.splitContainer1.SplitterDistance = 478;
            this.splitContainer1.SplitterWidth = 7;
            this.splitContainer1.TabIndex = 1;
            // 
            // dgvOrders
            // 
            this.dgvOrders.AllowUserToAddRows = false;
            this.dgvOrders.BackgroundColor = System.Drawing.SystemColors.ButtonFace;
            this.dgvOrders.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvOrders.ContextMenuStrip = this.contextMenuStrip1;
            this.dgvOrders.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvOrders.Location = new System.Drawing.Point(0, 0);
            this.dgvOrders.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.dgvOrders.MultiSelect = false;
            this.dgvOrders.Name = "dgvOrders";
            this.dgvOrders.ReadOnly = true;
            this.dgvOrders.RowHeadersWidth = 10;
            this.dgvOrders.RowTemplate.Height = 23;
            this.dgvOrders.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvOrders.Size = new System.Drawing.Size(831, 478);
            this.dgvOrders.TabIndex = 0;
            this.dgvOrders.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvOrders_CellClick);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.电子排单ToolStripMenuItem,
            this.查看排单ToolStripMenuItem,
            this.婚期确定ToolStripMenuItem,
            this.婚期更改ToolStripMenuItem,
            this.短信发送ToolStripMenuItem,
            this.电话追踪ToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(135, 148);
            // 
            // 电子排单ToolStripMenuItem
            // 
            this.电子排单ToolStripMenuItem.Name = "电子排单ToolStripMenuItem";
            this.电子排单ToolStripMenuItem.Size = new System.Drawing.Size(134, 24);
            this.电子排单ToolStripMenuItem.Text = "电子排单";
            this.电子排单ToolStripMenuItem.Click += new System.EventHandler(this.电子排单ToolStripMenuItem_Click);
            // 
            // 查看排单ToolStripMenuItem
            // 
            this.查看排单ToolStripMenuItem.Name = "查看排单ToolStripMenuItem";
            this.查看排单ToolStripMenuItem.Size = new System.Drawing.Size(134, 24);
            this.查看排单ToolStripMenuItem.Text = "查找排单";
            this.查看排单ToolStripMenuItem.Click += new System.EventHandler(this.查看排单ToolStripMenuItem_Click);
            // 
            // 婚期确定ToolStripMenuItem
            // 
            this.婚期确定ToolStripMenuItem.Name = "婚期确定ToolStripMenuItem";
            this.婚期确定ToolStripMenuItem.Size = new System.Drawing.Size(134, 24);
            this.婚期确定ToolStripMenuItem.Text = "婚期确定";
            this.婚期确定ToolStripMenuItem.Click += new System.EventHandler(this.婚期确定ToolStripMenuItem_Click);
            // 
            // 婚期更改ToolStripMenuItem
            // 
            this.婚期更改ToolStripMenuItem.Name = "婚期更改ToolStripMenuItem";
            this.婚期更改ToolStripMenuItem.Size = new System.Drawing.Size(134, 24);
            this.婚期更改ToolStripMenuItem.Text = "婚期更改";
            this.婚期更改ToolStripMenuItem.Click += new System.EventHandler(this.婚期更改ToolStripMenuItem_Click);
            // 
            // 短信发送ToolStripMenuItem
            // 
            this.短信发送ToolStripMenuItem.Name = "短信发送ToolStripMenuItem";
            this.短信发送ToolStripMenuItem.Size = new System.Drawing.Size(134, 24);
            this.短信发送ToolStripMenuItem.Text = "短信发送";
            this.短信发送ToolStripMenuItem.Click += new System.EventHandler(this.短信发送ToolStripMenuItem_Click);
            // 
            // 电话追踪ToolStripMenuItem
            // 
            this.电话追踪ToolStripMenuItem.Name = "电话追踪ToolStripMenuItem";
            this.电话追踪ToolStripMenuItem.Size = new System.Drawing.Size(134, 24);
            this.电话追踪ToolStripMenuItem.Text = "电话追踪";
            this.电话追踪ToolStripMenuItem.Click += new System.EventHandler(this.电话追踪ToolStripMenuItem_Click);
            // 
            // dgvCash
            // 
            this.dgvCash.AllowUserToAddRows = false;
            this.dgvCash.BackgroundColor = System.Drawing.SystemColors.ControlLight;
            this.dgvCash.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCash.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvCash.GridColor = System.Drawing.SystemColors.Control;
            this.dgvCash.Location = new System.Drawing.Point(461, 0);
            this.dgvCash.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.dgvCash.Name = "dgvCash";
            this.dgvCash.ReadOnly = true;
            this.dgvCash.RowHeadersWidth = 10;
            this.dgvCash.RowTemplate.Height = 23;
            this.dgvCash.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvCash.Size = new System.Drawing.Size(370, 175);
            this.dgvCash.TabIndex = 2;
            // 
            // dgvMemary
            // 
            this.dgvMemary.AllowUserToAddRows = false;
            this.dgvMemary.BackgroundColor = System.Drawing.SystemColors.ScrollBar;
            this.dgvMemary.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvMemary.Dock = System.Windows.Forms.DockStyle.Left;
            this.dgvMemary.Location = new System.Drawing.Point(0, 0);
            this.dgvMemary.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.dgvMemary.Name = "dgvMemary";
            this.dgvMemary.ReadOnly = true;
            this.dgvMemary.RowHeadersWidth = 10;
            this.dgvMemary.RowTemplate.Height = 23;
            this.dgvMemary.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvMemary.Size = new System.Drawing.Size(461, 175);
            this.dgvMemary.TabIndex = 1;
            // 
            // btnExcel
            // 
            this.btnExcel.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.btnExcel.Location = new System.Drawing.Point(145, 320);
            this.btnExcel.Name = "btnExcel";
            this.btnExcel.Size = new System.Drawing.Size(84, 39);
            this.btnExcel.TabIndex = 12;
            this.btnExcel.Text = "打印Excel";
            this.btnExcel.UseVisualStyleBackColor = false;
            this.btnExcel.Click += new System.EventHandler(this.btnExcel_Click);
            // 
            // FrmOrdersSearch
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "FrmOrdersSearch";
            this.Size = new System.Drawing.Size(1089, 660);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvOrders)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvCash)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMemary)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.DataGridView dgvOrders;
        private System.Windows.Forms.DataGridView dgvMemary;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.CheckBox chkMarry;
        private System.Windows.Forms.CheckBox chkOrder;
        private System.Windows.Forms.TextBox txtKey;
        private System.Windows.Forms.DateTimePicker dtpMarryDateE;
        private System.Windows.Forms.DateTimePicker dtpMarryDateG;
        private System.Windows.Forms.DateTimePicker dtpOrderDateE;
        private System.Windows.Forms.DateTimePicker dtpOrderDateG;
        private System.Windows.Forms.DataGridView dgvCash;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 电子排单ToolStripMenuItem;
        private System.Windows.Forms.Label lblSum;
        private System.Windows.Forms.ToolStripMenuItem 电话追踪ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 婚期更改ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 短信发送ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 婚期确定ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 查看排单ToolStripMenuItem;
        private System.Windows.Forms.Button btnExcel;
    }
}
