namespace GoldenLady.Dress.View
{
    partial class FrmOrdersShootSearch
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
            this.bntPrintSetting = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.cmbVenues = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.btnSearch = new System.Windows.Forms.Button();
            this.txtKey = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cmbShootEmployee = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.dtpShootDate = new System.Windows.Forms.DateTimePicker();
            this.chkShootDate = new System.Windows.Forms.CheckBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.dgvOrderData = new System.Windows.Forms.DataGridView();
            this.OrderNO = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ShootEmployee = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DressEmployeeN = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DressAssistantEmployeeN = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CustomerName1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MobilePhone1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CustomerName2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MobilePhone2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.shootState = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.shootType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PreShootDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.shootAddress = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PreShootDateW = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.shootAddressW = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ShootMemory = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ShootMemoryW = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.OrderMemory = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.shootDepartment = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SuiteName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SuitePrice = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cmsDressChoose = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.tsmDressChoose = new System.Windows.Forms.ToolStripMenuItem();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvOrderData)).BeginInit();
            this.cmsDressChoose.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.lblSum);
            this.panel1.Controls.Add(this.bntPrintSetting);
            this.panel1.Controls.Add(this.button1);
            this.panel1.Controls.Add(this.cmbVenues);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.btnSearch);
            this.panel1.Controls.Add(this.txtKey);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.cmbShootEmployee);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.dtpShootDate);
            this.panel1.Controls.Add(this.chkShootDate);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1340, 74);
            this.panel1.TabIndex = 0;
            // 
            // lblSum
            // 
            this.lblSum.AutoSize = true;
            this.lblSum.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.lblSum.Location = new System.Drawing.Point(1277, 54);
            this.lblSum.Name = "lblSum";
            this.lblSum.Size = new System.Drawing.Size(51, 20);
            this.lblSum.TabIndex = 13;
            this.lblSum.Text = "总数：";
            // 
            // bntPrintSetting
            // 
            this.bntPrintSetting.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.bntPrintSetting.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.bntPrintSetting.Location = new System.Drawing.Point(1143, 19);
            this.bntPrintSetting.Name = "bntPrintSetting";
            this.bntPrintSetting.Size = new System.Drawing.Size(80, 40);
            this.bntPrintSetting.TabIndex = 11;
            this.bntPrintSetting.Text = "打印机配置";
            this.bntPrintSetting.UseVisualStyleBackColor = false;
            this.bntPrintSetting.Click += new System.EventHandler(this.bntPrintSetting_Click);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.button1.Location = new System.Drawing.Point(1039, 19);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(80, 40);
            this.button1.TabIndex = 10;
            this.button1.Text = "礼服预选";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.tscDressChoose_Click);
            // 
            // cmbVenues
            // 
            this.cmbVenues.FormattingEnabled = true;
            this.cmbVenues.Location = new System.Drawing.Point(339, 24);
            this.cmbVenues.Name = "cmbVenues";
            this.cmbVenues.Size = new System.Drawing.Size(129, 28);
            this.cmbVenues.TabIndex = 9;
            this.cmbVenues.SelectedValueChanged += new System.EventHandler(this.cmbVenues_SelectedValueChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(273, 28);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 20);
            this.label3.TabIndex = 8;
            this.label3.Text = "摄影场馆";
            // 
            // btnSearch
            // 
            this.btnSearch.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.btnSearch.Location = new System.Drawing.Point(935, 19);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(80, 40);
            this.btnSearch.TabIndex = 7;
            this.btnSearch.Text = "查 询";
            this.btnSearch.UseVisualStyleBackColor = false;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // txtKey
            // 
            this.txtKey.Location = new System.Drawing.Point(765, 25);
            this.txtKey.Name = "txtKey";
            this.txtKey.Size = new System.Drawing.Size(132, 26);
            this.txtKey.TabIndex = 6;
            this.txtKey.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtKey_KeyDown);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(699, 28);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(51, 20);
            this.label2.TabIndex = 5;
            this.label2.Text = "关键字";
            // 
            // cmbShootEmployee
            // 
            this.cmbShootEmployee.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbShootEmployee.FormattingEnabled = true;
            this.cmbShootEmployee.Location = new System.Drawing.Point(552, 24);
            this.cmbShootEmployee.Name = "cmbShootEmployee";
            this.cmbShootEmployee.Size = new System.Drawing.Size(129, 28);
            this.cmbShootEmployee.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(486, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(51, 20);
            this.label1.TabIndex = 3;
            this.label1.Text = "摄影师";
            // 
            // dtpShootDate
            // 
            this.dtpShootDate.Location = new System.Drawing.Point(120, 25);
            this.dtpShootDate.Name = "dtpShootDate";
            this.dtpShootDate.Size = new System.Drawing.Size(137, 26);
            this.dtpShootDate.TabIndex = 1;
            // 
            // chkShootDate
            // 
            this.chkShootDate.AutoSize = true;
            this.chkShootDate.Checked = true;
            this.chkShootDate.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkShootDate.Location = new System.Drawing.Point(30, 26);
            this.chkShootDate.Name = "chkShootDate";
            this.chkShootDate.Size = new System.Drawing.Size(84, 24);
            this.chkShootDate.TabIndex = 0;
            this.chkShootDate.Text = "摄影日期";
            this.chkShootDate.UseVisualStyleBackColor = true;
            this.chkShootDate.CheckedChanged += new System.EventHandler(this.chkShootDate_CheckedChanged);
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.dgvOrderData);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 74);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1340, 608);
            this.panel2.TabIndex = 1;
            // 
            // dgvOrderData
            // 
            this.dgvOrderData.AllowUserToAddRows = false;
            this.dgvOrderData.BackgroundColor = System.Drawing.Color.White;
            this.dgvOrderData.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvOrderData.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvOrderData.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.OrderNO,
            this.ShootEmployee,
            this.DressEmployeeN,
            this.DressAssistantEmployeeN,
            this.CustomerName1,
            this.MobilePhone1,
            this.CustomerName2,
            this.MobilePhone2,
            this.shootState,
            this.shootType,
            this.PreShootDate,
            this.shootAddress,
            this.PreShootDateW,
            this.shootAddressW,
            this.ShootMemory,
            this.ShootMemoryW,
            this.OrderMemory,
            this.shootDepartment,
            this.SuiteName,
            this.SuitePrice});
            this.dgvOrderData.ContextMenuStrip = this.cmsDressChoose;
            this.dgvOrderData.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvOrderData.Location = new System.Drawing.Point(0, 0);
            this.dgvOrderData.MultiSelect = false;
            this.dgvOrderData.Name = "dgvOrderData";
            this.dgvOrderData.ReadOnly = true;
            this.dgvOrderData.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.dgvOrderData.RowHeadersWidth = 20;
            this.dgvOrderData.RowTemplate.Height = 23;
            this.dgvOrderData.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvOrderData.Size = new System.Drawing.Size(1338, 606);
            this.dgvOrderData.TabIndex = 0;
            // 
            // OrderNO
            // 
            this.OrderNO.DataPropertyName = "OrderNO";
            this.OrderNO.HeaderText = "订单号";
            this.OrderNO.Name = "OrderNO";
            this.OrderNO.ReadOnly = true;
            this.OrderNO.Width = 120;
            // 
            // ShootEmployee
            // 
            this.ShootEmployee.DataPropertyName = "ShootEmployee";
            this.ShootEmployee.HeaderText = "摄影师";
            this.ShootEmployee.Name = "ShootEmployee";
            this.ShootEmployee.ReadOnly = true;
            this.ShootEmployee.Width = 80;
            // 
            // DressEmployeeN
            // 
            this.DressEmployeeN.DataPropertyName = "DressEmployee";
            this.DressEmployeeN.HeaderText = "化妆师";
            this.DressEmployeeN.Name = "DressEmployeeN";
            this.DressEmployeeN.ReadOnly = true;
            this.DressEmployeeN.Width = 80;
            // 
            // DressAssistantEmployeeN
            // 
            this.DressAssistantEmployeeN.DataPropertyName = "DressAssistantEmployee";
            this.DressAssistantEmployeeN.HeaderText = "化妆助理";
            this.DressAssistantEmployeeN.Name = "DressAssistantEmployeeN";
            this.DressAssistantEmployeeN.ReadOnly = true;
            this.DressAssistantEmployeeN.Width = 90;
            // 
            // CustomerName1
            // 
            this.CustomerName1.DataPropertyName = "CustomerName1";
            this.CustomerName1.HeaderText = "先生";
            this.CustomerName1.Name = "CustomerName1";
            this.CustomerName1.ReadOnly = true;
            this.CustomerName1.Width = 70;
            // 
            // MobilePhone1
            // 
            this.MobilePhone1.DataPropertyName = "MobilePhone1";
            this.MobilePhone1.HeaderText = "手机号1";
            this.MobilePhone1.Name = "MobilePhone1";
            this.MobilePhone1.ReadOnly = true;
            this.MobilePhone1.Width = 120;
            // 
            // CustomerName2
            // 
            this.CustomerName2.DataPropertyName = "CustomerName2";
            this.CustomerName2.HeaderText = "女士";
            this.CustomerName2.Name = "CustomerName2";
            this.CustomerName2.ReadOnly = true;
            this.CustomerName2.Width = 70;
            // 
            // MobilePhone2
            // 
            this.MobilePhone2.DataPropertyName = "MobilePhone2";
            this.MobilePhone2.HeaderText = "手机号2";
            this.MobilePhone2.Name = "MobilePhone2";
            this.MobilePhone2.ReadOnly = true;
            this.MobilePhone2.Width = 120;
            // 
            // shootState
            // 
            this.shootState.DataPropertyName = "shootState";
            this.shootState.FillWeight = 60F;
            this.shootState.HeaderText = "状态";
            this.shootState.Name = "shootState";
            this.shootState.ReadOnly = true;
            this.shootState.Width = 60;
            // 
            // shootType
            // 
            this.shootType.DataPropertyName = "shootType";
            this.shootType.HeaderText = "类别";
            this.shootType.Name = "shootType";
            this.shootType.ReadOnly = true;
            this.shootType.Width = 60;
            // 
            // PreShootDate
            // 
            this.PreShootDate.DataPropertyName = "PreShootDate";
            this.PreShootDate.HeaderText = "内景时间";
            this.PreShootDate.Name = "PreShootDate";
            this.PreShootDate.ReadOnly = true;
            // 
            // shootAddress
            // 
            this.shootAddress.DataPropertyName = "shootAddress";
            this.shootAddress.HeaderText = "内景地点";
            this.shootAddress.Name = "shootAddress";
            this.shootAddress.ReadOnly = true;
            // 
            // PreShootDateW
            // 
            this.PreShootDateW.DataPropertyName = "PreShootDateW";
            this.PreShootDateW.HeaderText = "外景时间";
            this.PreShootDateW.Name = "PreShootDateW";
            this.PreShootDateW.ReadOnly = true;
            // 
            // shootAddressW
            // 
            this.shootAddressW.DataPropertyName = "shootAddressW";
            this.shootAddressW.HeaderText = "外景地点";
            this.shootAddressW.Name = "shootAddressW";
            this.shootAddressW.ReadOnly = true;
            // 
            // ShootMemory
            // 
            this.ShootMemory.DataPropertyName = "ShootMemory";
            this.ShootMemory.HeaderText = "内景摄影备注";
            this.ShootMemory.Name = "ShootMemory";
            this.ShootMemory.ReadOnly = true;
            this.ShootMemory.Width = 150;
            // 
            // ShootMemoryW
            // 
            this.ShootMemoryW.DataPropertyName = "ShootMemoryW";
            this.ShootMemoryW.HeaderText = "外景摄影备注";
            this.ShootMemoryW.Name = "ShootMemoryW";
            this.ShootMemoryW.ReadOnly = true;
            this.ShootMemoryW.Width = 150;
            // 
            // OrderMemory
            // 
            this.OrderMemory.DataPropertyName = "OrderMemory";
            this.OrderMemory.HeaderText = "订单备注";
            this.OrderMemory.Name = "OrderMemory";
            this.OrderMemory.ReadOnly = true;
            this.OrderMemory.Width = 150;
            // 
            // shootDepartment
            // 
            this.shootDepartment.DataPropertyName = "shootDepartment";
            this.shootDepartment.HeaderText = "摄影场馆";
            this.shootDepartment.Name = "shootDepartment";
            this.shootDepartment.ReadOnly = true;
            // 
            // SuiteName
            // 
            this.SuiteName.DataPropertyName = "SuiteName";
            this.SuiteName.HeaderText = "套系名称";
            this.SuiteName.Name = "SuiteName";
            this.SuiteName.ReadOnly = true;
            this.SuiteName.Width = 120;
            // 
            // SuitePrice
            // 
            this.SuitePrice.DataPropertyName = "SuitePrice";
            this.SuitePrice.HeaderText = "成交价格";
            this.SuitePrice.Name = "SuitePrice";
            this.SuitePrice.ReadOnly = true;
            this.SuitePrice.Width = 90;
            // 
            // cmsDressChoose
            // 
            this.cmsDressChoose.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmDressChoose});
            this.cmsDressChoose.Name = "礼服预选";
            this.cmsDressChoose.Size = new System.Drawing.Size(125, 26);
            // 
            // tsmDressChoose
            // 
            this.tsmDressChoose.Name = "tsmDressChoose";
            this.tsmDressChoose.Size = new System.Drawing.Size(124, 22);
            this.tsmDressChoose.Text = "礼服预选";
            this.tsmDressChoose.Click += new System.EventHandler(this.tscDressChoose_Click);
            // 
            // FrmOrdersShootSearch
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "FrmOrdersShootSearch";
            this.Size = new System.Drawing.Size(1340, 682);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvOrderData)).EndInit();
            this.cmsDressChoose.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.TextBox txtKey;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cmbShootEmployee;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker dtpShootDate;
        private System.Windows.Forms.CheckBox chkShootDate;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.ComboBox cmbVenues;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DataGridView dgvOrderData;
        private System.Windows.Forms.ContextMenuStrip cmsDressChoose;
        private System.Windows.Forms.ToolStripMenuItem tsmDressChoose;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button bntPrintSetting;
        private System.Windows.Forms.Label lblSum;
        private System.Windows.Forms.DataGridViewTextBoxColumn OrderNO;
        private System.Windows.Forms.DataGridViewTextBoxColumn ShootEmployee;
        private System.Windows.Forms.DataGridViewTextBoxColumn DressEmployeeN;
        private System.Windows.Forms.DataGridViewTextBoxColumn DressAssistantEmployeeN;
        private System.Windows.Forms.DataGridViewTextBoxColumn CustomerName1;
        private System.Windows.Forms.DataGridViewTextBoxColumn MobilePhone1;
        private System.Windows.Forms.DataGridViewTextBoxColumn CustomerName2;
        private System.Windows.Forms.DataGridViewTextBoxColumn MobilePhone2;
        private System.Windows.Forms.DataGridViewTextBoxColumn shootState;
        private System.Windows.Forms.DataGridViewTextBoxColumn shootType;
        private System.Windows.Forms.DataGridViewTextBoxColumn PreShootDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn shootAddress;
        private System.Windows.Forms.DataGridViewTextBoxColumn PreShootDateW;
        private System.Windows.Forms.DataGridViewTextBoxColumn shootAddressW;
        private System.Windows.Forms.DataGridViewTextBoxColumn ShootMemory;
        private System.Windows.Forms.DataGridViewTextBoxColumn ShootMemoryW;
        private System.Windows.Forms.DataGridViewTextBoxColumn OrderMemory;
        private System.Windows.Forms.DataGridViewTextBoxColumn shootDepartment;
        private System.Windows.Forms.DataGridViewTextBoxColumn SuiteName;
        private System.Windows.Forms.DataGridViewTextBoxColumn SuitePrice;
    }
}