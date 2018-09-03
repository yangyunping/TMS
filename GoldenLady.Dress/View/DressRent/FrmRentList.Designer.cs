namespace GoldenLady.Dress.View.DressRent
{
    partial class FrmRentList
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblNumber = new System.Windows.Forms.Label();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnMinus = new System.Windows.Forms.Button();
            this.dtpDate = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.cmbAddress = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnChoose = new System.Windows.Forms.Button();
            this.btnTemplates = new System.Windows.Forms.Button();
            this.dgvShowOrders = new System.Windows.Forms.DataGridView();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.排单预定ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.电子选衣ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.添加备注ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.短信发送ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.客人到店ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.婚期确定ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.排单改期ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.可排控ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.不可排ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.新增消费ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.取消排单ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.外建ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvShowOrders)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.MediumSpringGreen;
            this.panel1.Controls.Add(this.lblNumber);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1038, 30);
            this.panel1.TabIndex = 0;
            // 
            // lblNumber
            // 
            this.lblNumber.AutoSize = true;
            this.lblNumber.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblNumber.Location = new System.Drawing.Point(487, 4);
            this.lblNumber.Name = "lblNumber";
            this.lblNumber.Size = new System.Drawing.Size(42, 21);
            this.lblNumber.TabIndex = 0;
            this.lblNumber.Text = "数量";
            this.lblNumber.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnAdd
            // 
            this.btnAdd.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.btnAdd.Location = new System.Drawing.Point(479, 13);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(42, 29);
            this.btnAdd.TabIndex = 5;
            this.btnAdd.Text = "→";
            this.btnAdd.UseVisualStyleBackColor = false;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnMinus
            // 
            this.btnMinus.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.btnMinus.Location = new System.Drawing.Point(236, 13);
            this.btnMinus.Name = "btnMinus";
            this.btnMinus.Size = new System.Drawing.Size(42, 30);
            this.btnMinus.TabIndex = 4;
            this.btnMinus.Text = "←";
            this.btnMinus.UseVisualStyleBackColor = false;
            this.btnMinus.Click += new System.EventHandler(this.btnMinus_Click);
            // 
            // dtpDate
            // 
            this.dtpDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpDate.Location = new System.Drawing.Point(348, 15);
            this.dtpDate.Name = "dtpDate";
            this.dtpDate.Size = new System.Drawing.Size(125, 26);
            this.dtpDate.TabIndex = 3;
            this.dtpDate.ValueChanged += new System.EventHandler(this.dtpDate_ValueChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(276, 18);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 20);
            this.label2.TabIndex = 2;
            this.label2.Text = "选衣时间";
            // 
            // cmbAddress
            // 
            this.cmbAddress.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbAddress.Enabled = false;
            this.cmbAddress.FormattingEnabled = true;
            this.cmbAddress.Location = new System.Drawing.Point(87, 14);
            this.cmbAddress.Name = "cmbAddress";
            this.cmbAddress.Size = new System.Drawing.Size(126, 28);
            this.cmbAddress.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(14, 18);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "排单地点";
            // 
            // textBox1
            // 
            this.textBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.textBox1.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.textBox1.Location = new System.Drawing.Point(554, 13);
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.Size = new System.Drawing.Size(62, 29);
            this.textBox1.TabIndex = 6;
            this.textBox1.Text = " 成  交";
            // 
            // textBox2
            // 
            this.textBox2.BackColor = System.Drawing.Color.LemonChiffon;
            this.textBox2.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.textBox2.Location = new System.Drawing.Point(622, 13);
            this.textBox2.Name = "textBox2";
            this.textBox2.ReadOnly = true;
            this.textBox2.Size = new System.Drawing.Size(62, 29);
            this.textBox2.TabIndex = 7;
            this.textBox2.Text = " 到  店";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.btnChoose);
            this.panel2.Controls.Add(this.btnTemplates);
            this.panel2.Controls.Add(this.textBox2);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Controls.Add(this.btnMinus);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.btnAdd);
            this.panel2.Controls.Add(this.textBox1);
            this.panel2.Controls.Add(this.cmbAddress);
            this.panel2.Controls.Add(this.dtpDate);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 30);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1038, 54);
            this.panel2.TabIndex = 1;
            // 
            // btnChoose
            // 
            this.btnChoose.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.btnChoose.Location = new System.Drawing.Point(718, 11);
            this.btnChoose.Name = "btnChoose";
            this.btnChoose.Size = new System.Drawing.Size(75, 34);
            this.btnChoose.TabIndex = 9;
            this.btnChoose.Text = "电子选衣";
            this.btnChoose.UseVisualStyleBackColor = false;
            this.btnChoose.Click += new System.EventHandler(this.btnChoose_Click);
            // 
            // btnTemplates
            // 
            this.btnTemplates.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.btnTemplates.Location = new System.Drawing.Point(911, 11);
            this.btnTemplates.Name = "btnTemplates";
            this.btnTemplates.Size = new System.Drawing.Size(75, 34);
            this.btnTemplates.TabIndex = 8;
            this.btnTemplates.Text = "设置模板";
            this.btnTemplates.UseVisualStyleBackColor = false;
            this.btnTemplates.Click += new System.EventHandler(this.btnTemplates_Click);
            // 
            // dgvShowOrders
            // 
            this.dgvShowOrders.AllowUserToAddRows = false;
            this.dgvShowOrders.BackgroundColor = System.Drawing.Color.White;
            this.dgvShowOrders.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvShowOrders.ContextMenuStrip = this.contextMenuStrip1;
            this.dgvShowOrders.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvShowOrders.Location = new System.Drawing.Point(0, 84);
            this.dgvShowOrders.Name = "dgvShowOrders";
            dataGridViewCellStyle1.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.dgvShowOrders.RowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvShowOrders.RowTemplate.Height = 23;
            this.dgvShowOrders.Size = new System.Drawing.Size(1038, 579);
            this.dgvShowOrders.TabIndex = 2;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.排单预定ToolStripMenuItem,
            this.电子选衣ToolStripMenuItem,
            this.添加备注ToolStripMenuItem,
            this.短信发送ToolStripMenuItem,
            this.客人到店ToolStripMenuItem,
            this.婚期确定ToolStripMenuItem,
            this.排单改期ToolStripMenuItem,
            this.可排控ToolStripMenuItem,
            this.不可排ToolStripMenuItem,
            this.新增消费ToolStripMenuItem,
            this.取消排单ToolStripMenuItem,
            this.外建ToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(177, 292);
            // 
            // 排单预定ToolStripMenuItem
            // 
            this.排单预定ToolStripMenuItem.Name = "排单预定ToolStripMenuItem";
            this.排单预定ToolStripMenuItem.Size = new System.Drawing.Size(176, 24);
            this.排单预定ToolStripMenuItem.Text = "排单预定";
            this.排单预定ToolStripMenuItem.Click += new System.EventHandler(this.排单预定ToolStripMenuItem_Click);
            // 
            // 电子选衣ToolStripMenuItem
            // 
            this.电子选衣ToolStripMenuItem.Name = "电子选衣ToolStripMenuItem";
            this.电子选衣ToolStripMenuItem.Size = new System.Drawing.Size(176, 24);
            this.电子选衣ToolStripMenuItem.Text = "礼服预定";
            this.电子选衣ToolStripMenuItem.Click += new System.EventHandler(this.电子选衣ToolStripMenuItem_Click);
            // 
            // 添加备注ToolStripMenuItem
            // 
            this.添加备注ToolStripMenuItem.Name = "添加备注ToolStripMenuItem";
            this.添加备注ToolStripMenuItem.Size = new System.Drawing.Size(176, 24);
            this.添加备注ToolStripMenuItem.Text = "添加备注";
            this.添加备注ToolStripMenuItem.Click += new System.EventHandler(this.添加备注ToolStripMenuItem_Click);
            // 
            // 短信发送ToolStripMenuItem
            // 
            this.短信发送ToolStripMenuItem.Name = "短信发送ToolStripMenuItem";
            this.短信发送ToolStripMenuItem.Size = new System.Drawing.Size(176, 24);
            this.短信发送ToolStripMenuItem.Text = "短信发送";
            this.短信发送ToolStripMenuItem.Click += new System.EventHandler(this.短信发送ToolStripMenuItem_Click);
            // 
            // 客人到店ToolStripMenuItem
            // 
            this.客人到店ToolStripMenuItem.Name = "客人到店ToolStripMenuItem";
            this.客人到店ToolStripMenuItem.Size = new System.Drawing.Size(176, 24);
            this.客人到店ToolStripMenuItem.Text = "客人到店";
            this.客人到店ToolStripMenuItem.Click += new System.EventHandler(this.客人到店ToolStripMenuItem_Click);
            // 
            // 婚期确定ToolStripMenuItem
            // 
            this.婚期确定ToolStripMenuItem.Name = "婚期确定ToolStripMenuItem";
            this.婚期确定ToolStripMenuItem.Size = new System.Drawing.Size(176, 24);
            this.婚期确定ToolStripMenuItem.Text = "婚期确定";
            this.婚期确定ToolStripMenuItem.Click += new System.EventHandler(this.婚期确定ToolStripMenuItem_Click);
            // 
            // 排单改期ToolStripMenuItem
            // 
            this.排单改期ToolStripMenuItem.Name = "排单改期ToolStripMenuItem";
            this.排单改期ToolStripMenuItem.Size = new System.Drawing.Size(176, 24);
            this.排单改期ToolStripMenuItem.Text = "排单改期";
            this.排单改期ToolStripMenuItem.Click += new System.EventHandler(this.排单改期ToolStripMenuItem_Click);
            // 
            // 可排控ToolStripMenuItem
            // 
            this.可排控ToolStripMenuItem.Name = "可排控ToolStripMenuItem";
            this.可排控ToolStripMenuItem.Size = new System.Drawing.Size(176, 24);
            this.可排控ToolStripMenuItem.Text = "可排控";
            this.可排控ToolStripMenuItem.Click += new System.EventHandler(this.可排控ToolStripMenuItem_Click);
            // 
            // 不可排ToolStripMenuItem
            // 
            this.不可排ToolStripMenuItem.Name = "不可排ToolStripMenuItem";
            this.不可排ToolStripMenuItem.Size = new System.Drawing.Size(176, 24);
            this.不可排ToolStripMenuItem.Text = "不可排控";
            this.不可排ToolStripMenuItem.Click += new System.EventHandler(this.不可排ToolStripMenuItem_Click);
            // 
            // 新增消费ToolStripMenuItem
            // 
            this.新增消费ToolStripMenuItem.Name = "新增消费ToolStripMenuItem";
            this.新增消费ToolStripMenuItem.Size = new System.Drawing.Size(176, 24);
            this.新增消费ToolStripMenuItem.Text = "新增消费";
            this.新增消费ToolStripMenuItem.Click += new System.EventHandler(this.新增消费ToolStripMenuItem_Click);
            // 
            // 取消排单ToolStripMenuItem
            // 
            this.取消排单ToolStripMenuItem.Name = "取消排单ToolStripMenuItem";
            this.取消排单ToolStripMenuItem.Size = new System.Drawing.Size(176, 24);
            this.取消排单ToolStripMenuItem.Text = "取消排单";
            this.取消排单ToolStripMenuItem.Click += new System.EventHandler(this.取消排单ToolStripMenuItem_Click);
            // 
            // 外建ToolStripMenuItem
            // 
            this.外建ToolStripMenuItem.Name = "外建ToolStripMenuItem";
            this.外建ToolStripMenuItem.Size = new System.Drawing.Size(176, 24);
            this.外建ToolStripMenuItem.Text = "外客建单并安排";
            this.外建ToolStripMenuItem.Click += new System.EventHandler(this.外建ToolStripMenuItem_Click);
            // 
            // FrmRentList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.dgvShowOrders);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "FrmRentList";
            this.Size = new System.Drawing.Size(1038, 663);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvShowOrders)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnMinus;
        private System.Windows.Forms.DateTimePicker dtpDate;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cmbAddress;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label lblNumber;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.DataGridView dgvShowOrders;
        private System.Windows.Forms.Button btnTemplates;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 排单预定ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 取消排单ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 客人到店ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 电子选衣ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 可排控ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 不可排ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 新增消费ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 添加备注ToolStripMenuItem;
        private System.Windows.Forms.Button btnChoose;
        private System.Windows.Forms.ToolStripMenuItem 婚期确定ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 排单改期ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 外建ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 短信发送ToolStripMenuItem;
    }
}
