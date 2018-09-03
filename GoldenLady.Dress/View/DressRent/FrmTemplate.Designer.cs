namespace GoldenLady.Dress.View.DressRent
{
    partial class FrmTemplate
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnSee = new System.Windows.Forms.Button();
            this.txtRowCnt = new System.Windows.Forms.TextBox();
            this.txtEmp = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.dtpEnd = new System.Windows.Forms.DateTimePicker();
            this.dtpBegin = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.btnAddEmp = new System.Windows.Forms.Button();
            this.cmbEmpDress = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cmbAddress = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.lblSum = new System.Windows.Forms.Label();
            this.lblDateArea = new System.Windows.Forms.Label();
            this.dgvShow = new System.Windows.Forms.DataGridView();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvShow)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Controls.Add(this.btnSave);
            this.panel1.Controls.Add(this.btnSee);
            this.panel1.Controls.Add(this.txtRowCnt);
            this.panel1.Controls.Add(this.txtEmp);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.dtpEnd);
            this.panel1.Controls.Add(this.dtpBegin);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.btnAddEmp);
            this.panel1.Controls.Add(this.cmbEmpDress);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.cmbAddress);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(293, 689);
            this.panel1.TabIndex = 0;
            // 
            // btnSave
            // 
            this.btnSave.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.btnSave.Location = new System.Drawing.Point(204, 638);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(81, 39);
            this.btnSave.TabIndex = 14;
            this.btnSave.Text = "保存";
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnSee
            // 
            this.btnSee.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.btnSee.Location = new System.Drawing.Point(96, 638);
            this.btnSee.Name = "btnSee";
            this.btnSee.Size = new System.Drawing.Size(81, 39);
            this.btnSee.TabIndex = 13;
            this.btnSee.Text = "预览";
            this.btnSee.UseVisualStyleBackColor = false;
            this.btnSee.Click += new System.EventHandler(this.btnSee_Click);
            // 
            // txtRowCnt
            // 
            this.txtRowCnt.Location = new System.Drawing.Point(96, 456);
            this.txtRowCnt.Multiline = true;
            this.txtRowCnt.Name = "txtRowCnt";
            this.txtRowCnt.Size = new System.Drawing.Size(189, 161);
            this.txtRowCnt.TabIndex = 12;
            this.txtRowCnt.Text = "1,2,3,4,5,6,7";
            // 
            // txtEmp
            // 
            this.txtEmp.Location = new System.Drawing.Point(96, 257);
            this.txtEmp.Multiline = true;
            this.txtEmp.Name = "txtEmp";
            this.txtEmp.Size = new System.Drawing.Size(189, 161);
            this.txtEmp.TabIndex = 10;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(21, 458);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(53, 20);
            this.label5.TabIndex = 11;
            this.label5.Text = "排    数";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(21, 259);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(65, 20);
            this.label4.TabIndex = 9;
            this.label4.Text = "礼服人员";
            // 
            // dtpEnd
            // 
            this.dtpEnd.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpEnd.Location = new System.Drawing.Point(96, 191);
            this.dtpEnd.Name = "dtpEnd";
            this.dtpEnd.Size = new System.Drawing.Size(143, 26);
            this.dtpEnd.TabIndex = 7;
            // 
            // dtpBegin
            // 
            this.dtpBegin.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpBegin.Location = new System.Drawing.Point(96, 141);
            this.dtpBegin.Name = "dtpBegin";
            this.dtpBegin.Size = new System.Drawing.Size(143, 26);
            this.dtpBegin.TabIndex = 6;
            this.dtpBegin.ValueChanged += new System.EventHandler(this.dtpBegin_ValueChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(21, 144);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 20);
            this.label3.TabIndex = 5;
            this.label3.Text = "排单时间";
            // 
            // btnAddEmp
            // 
            this.btnAddEmp.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.btnAddEmp.Location = new System.Drawing.Point(246, 78);
            this.btnAddEmp.Name = "btnAddEmp";
            this.btnAddEmp.Size = new System.Drawing.Size(33, 28);
            this.btnAddEmp.TabIndex = 4;
            this.btnAddEmp.Text = "＋";
            this.btnAddEmp.UseVisualStyleBackColor = false;
            this.btnAddEmp.Click += new System.EventHandler(this.btnAddEmp_Click);
            // 
            // cmbEmpDress
            // 
            this.cmbEmpDress.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbEmpDress.FormattingEnabled = true;
            this.cmbEmpDress.Location = new System.Drawing.Point(96, 78);
            this.cmbEmpDress.Name = "cmbEmpDress";
            this.cmbEmpDress.Size = new System.Drawing.Size(143, 28);
            this.cmbEmpDress.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(21, 82);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 20);
            this.label2.TabIndex = 2;
            this.label2.Text = "排单人员";
            // 
            // cmbAddress
            // 
            this.cmbAddress.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbAddress.FormattingEnabled = true;
            this.cmbAddress.Location = new System.Drawing.Point(96, 15);
            this.cmbAddress.Name = "cmbAddress";
            this.cmbAddress.Size = new System.Drawing.Size(143, 28);
            this.cmbAddress.TabIndex = 1;
            this.cmbAddress.SelectedValueChanged += new System.EventHandler(this.cmbAddress_SelectedValueChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(21, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "排单地点";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.panel2.Controls.Add(this.lblSum);
            this.panel2.Controls.Add(this.lblDateArea);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(293, 0);
            this.panel2.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1020, 43);
            this.panel2.TabIndex = 1;
            // 
            // lblSum
            // 
            this.lblSum.AutoSize = true;
            this.lblSum.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblSum.ForeColor = System.Drawing.Color.White;
            this.lblSum.Location = new System.Drawing.Point(436, 15);
            this.lblSum.Name = "lblSum";
            this.lblSum.Size = new System.Drawing.Size(74, 21);
            this.lblSum.TabIndex = 1;
            this.lblSum.Text = "位置数量";
            // 
            // lblDateArea
            // 
            this.lblDateArea.AutoSize = true;
            this.lblDateArea.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblDateArea.ForeColor = System.Drawing.Color.White;
            this.lblDateArea.Location = new System.Drawing.Point(51, 15);
            this.lblDateArea.Name = "lblDateArea";
            this.lblDateArea.Size = new System.Drawing.Size(74, 21);
            this.lblDateArea.TabIndex = 0;
            this.lblDateArea.Text = "时间区域";
            // 
            // dgvShow
            // 
            this.dgvShow.AllowUserToAddRows = false;
            this.dgvShow.BackgroundColor = System.Drawing.Color.Snow;
            this.dgvShow.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvShow.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvShow.Location = new System.Drawing.Point(293, 43);
            this.dgvShow.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.dgvShow.Name = "dgvShow";
            this.dgvShow.ReadOnly = true;
            this.dgvShow.RowTemplate.Height = 23;
            this.dgvShow.Size = new System.Drawing.Size(1020, 646);
            this.dgvShow.TabIndex = 2;
            // 
            // FrmTemplate
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1313, 689);
            this.Controls.Add(this.dgvShow);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "FrmTemplate";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "出租排单模板";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvShow)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnSee;
        private System.Windows.Forms.TextBox txtRowCnt;
        private System.Windows.Forms.TextBox txtEmp;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DateTimePicker dtpEnd;
        private System.Windows.Forms.DateTimePicker dtpBegin;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnAddEmp;
        private System.Windows.Forms.ComboBox cmbEmpDress;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cmbAddress;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label lblSum;
        private System.Windows.Forms.Label lblDateArea;
        private System.Windows.Forms.DataGridView dgvShow;
    }
}