namespace GoldenLady.Dress
{
    partial class frmEmployee
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

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.opfEmployeePhoto = new System.Windows.Forms.OpenFileDialog();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.txtDepartmentNO = new System.Windows.Forms.TextBox();
            this.txtEmployeePhone = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.btnDistributeCard = new System.Windows.Forms.Button();
            this.txtEmployeeNO2 = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtCardNO = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cmbDepartment = new System.Windows.Forms.ComboBox();
            this.txtEmployeePassword = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.lbCreateDate = new System.Windows.Forms.Label();
            this.lbCreate = new System.Windows.Forms.Label();
            this.lbCreateDateCaption = new System.Windows.Forms.Label();
            this.lbCreateCaption = new System.Windows.Forms.Label();
            this.chbIsDelete = new System.Windows.Forms.CheckBox();
            this.txtEmployeeDescribe = new System.Windows.Forms.TextBox();
            this.cmbEmployeeDuty = new System.Windows.Forms.ComboBox();
            this.cmbEmployeeLevel = new System.Windows.Forms.ComboBox();
            this.dtpEmployeeBirthday = new System.Windows.Forms.DateTimePicker();
            this.cmbEmployeeSex = new System.Windows.Forms.ComboBox();
            this.txtEmployeeName = new System.Windows.Forms.TextBox();
            this.txtEmployeeNO = new System.Windows.Forms.TextBox();
            this.label15 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.trwPowers = new System.Windows.Forms.TreeView();
            this.btnQuit = new System.Windows.Forms.Button();
            this.btnSaveAndQuit = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.SuspendLayout();
            // 
            // opfEmployeePhoto
            // 
            this.opfEmployeePhoto.Filter = "图片|*.bmp;*.jpg;*.jpeg";
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(12, 12);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(753, 425);
            this.tabControl1.TabIndex = 14;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.groupBox2);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(745, 399);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "基本信息";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.txtDepartmentNO);
            this.groupBox2.Controls.Add(this.txtEmployeePhone);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.btnDistributeCard);
            this.groupBox2.Controls.Add(this.txtEmployeeNO2);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.txtCardNO);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.cmbDepartment);
            this.groupBox2.Controls.Add(this.txtEmployeePassword);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.lbCreateDate);
            this.groupBox2.Controls.Add(this.lbCreate);
            this.groupBox2.Controls.Add(this.lbCreateDateCaption);
            this.groupBox2.Controls.Add(this.lbCreateCaption);
            this.groupBox2.Controls.Add(this.chbIsDelete);
            this.groupBox2.Controls.Add(this.txtEmployeeDescribe);
            this.groupBox2.Controls.Add(this.cmbEmployeeDuty);
            this.groupBox2.Controls.Add(this.cmbEmployeeLevel);
            this.groupBox2.Controls.Add(this.dtpEmployeeBirthday);
            this.groupBox2.Controls.Add(this.cmbEmployeeSex);
            this.groupBox2.Controls.Add(this.txtEmployeeName);
            this.groupBox2.Controls.Add(this.txtEmployeeNO);
            this.groupBox2.Controls.Add(this.label15);
            this.groupBox2.Controls.Add(this.label14);
            this.groupBox2.Controls.Add(this.label13);
            this.groupBox2.Controls.Add(this.label12);
            this.groupBox2.Controls.Add(this.label11);
            this.groupBox2.Controls.Add(this.label10);
            this.groupBox2.Controls.Add(this.label9);
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Location = new System.Drawing.Point(6, 6);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(735, 387);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "员工信息";
            // 
            // txtDepartmentNO
            // 
            this.txtDepartmentNO.Location = new System.Drawing.Point(590, 11);
            this.txtDepartmentNO.Name = "txtDepartmentNO";
            this.txtDepartmentNO.Size = new System.Drawing.Size(139, 21);
            this.txtDepartmentNO.TabIndex = 34;
            // 
            // txtEmployeePhone
            // 
            this.txtEmployeePhone.Location = new System.Drawing.Point(115, 242);
            this.txtEmployeePhone.Name = "txtEmployeePhone";
            this.txtEmployeePhone.Size = new System.Drawing.Size(139, 21);
            this.txtEmployeePhone.TabIndex = 33;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(332, 245);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 12);
            this.label4.TabIndex = 32;
            this.label4.Text = "员工描述";
            // 
            // btnDistributeCard
            // 
            this.btnDistributeCard.Location = new System.Drawing.Point(536, 41);
            this.btnDistributeCard.Name = "btnDistributeCard";
            this.btnDistributeCard.Size = new System.Drawing.Size(45, 23);
            this.btnDistributeCard.TabIndex = 31;
            this.btnDistributeCard.Text = "发卡";
            this.btnDistributeCard.UseVisualStyleBackColor = true;
            // 
            // txtEmployeeNO2
            // 
            this.txtEmployeeNO2.Location = new System.Drawing.Point(408, 82);
            this.txtEmployeeNO2.Name = "txtEmployeeNO2";
            this.txtEmployeeNO2.Size = new System.Drawing.Size(139, 21);
            this.txtEmployeeNO2.TabIndex = 3;
            this.txtEmployeeNO2.TextChanged += new System.EventHandler(this.txtEmployeeNO2_TextChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(296, 85);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(89, 12);
            this.label3.TabIndex = 30;
            this.label3.Text = "(二代)员工编号";
            // 
            // txtCardNO
            // 
            this.txtCardNO.Location = new System.Drawing.Point(408, 42);
            this.txtCardNO.Name = "txtCardNO";
            this.txtCardNO.ReadOnly = true;
            this.txtCardNO.Size = new System.Drawing.Size(122, 21);
            this.txtCardNO.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(332, 45);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 12);
            this.label2.TabIndex = 28;
            this.label2.Text = "积分卡号";
            // 
            // cmbDepartment
            // 
            this.cmbDepartment.FormattingEnabled = true;
            this.cmbDepartment.Location = new System.Drawing.Point(115, 42);
            this.cmbDepartment.Name = "cmbDepartment";
            this.cmbDepartment.Size = new System.Drawing.Size(139, 20);
            this.cmbDepartment.TabIndex = 0;
            // 
            // txtEmployeePassword
            // 
            this.txtEmployeePassword.Location = new System.Drawing.Point(408, 122);
            this.txtEmployeePassword.Name = "txtEmployeePassword";
            this.txtEmployeePassword.PasswordChar = '#';
            this.txtEmployeePassword.Size = new System.Drawing.Size(139, 21);
            this.txtEmployeePassword.TabIndex = 5;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(332, 125);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 25;
            this.label1.Text = "员工密码";
            // 
            // lbCreateDate
            // 
            this.lbCreateDate.AutoSize = true;
            this.lbCreateDate.ForeColor = System.Drawing.Color.Blue;
            this.lbCreateDate.Location = new System.Drawing.Point(119, 351);
            this.lbCreateDate.Name = "lbCreateDate";
            this.lbCreateDate.Size = new System.Drawing.Size(47, 12);
            this.lbCreateDate.TabIndex = 24;
            this.lbCreateDate.Text = "label11";
            this.lbCreateDate.TextChanged += new System.EventHandler(this.lbCreateDate_TextChanged);
            // 
            // lbCreate
            // 
            this.lbCreate.AutoSize = true;
            this.lbCreate.ForeColor = System.Drawing.Color.Blue;
            this.lbCreate.Location = new System.Drawing.Point(171, 306);
            this.lbCreate.Name = "lbCreate";
            this.lbCreate.Size = new System.Drawing.Size(47, 12);
            this.lbCreate.TabIndex = 23;
            this.lbCreate.Text = "label10";
            this.lbCreate.TextChanged += new System.EventHandler(this.lbCreate_TextChanged);
            // 
            // lbCreateDateCaption
            // 
            this.lbCreateDateCaption.AutoSize = true;
            this.lbCreateDateCaption.Location = new System.Drawing.Point(33, 351);
            this.lbCreateDateCaption.Name = "lbCreateDateCaption";
            this.lbCreateDateCaption.Size = new System.Drawing.Size(53, 12);
            this.lbCreateDateCaption.TabIndex = 22;
            this.lbCreateDateCaption.Text = "创建时间";
            // 
            // lbCreateCaption
            // 
            this.lbCreateCaption.AutoSize = true;
            this.lbCreateCaption.Location = new System.Drawing.Point(113, 306);
            this.lbCreateCaption.Name = "lbCreateCaption";
            this.lbCreateCaption.Size = new System.Drawing.Size(41, 12);
            this.lbCreateCaption.TabIndex = 21;
            this.lbCreateCaption.Text = "创建人";
            // 
            // chbIsDelete
            // 
            this.chbIsDelete.AutoSize = true;
            this.chbIsDelete.Location = new System.Drawing.Point(35, 305);
            this.chbIsDelete.Name = "chbIsDelete";
            this.chbIsDelete.Size = new System.Drawing.Size(72, 16);
            this.chbIsDelete.TabIndex = 11;
            this.chbIsDelete.Text = "是否离职";
            this.chbIsDelete.UseVisualStyleBackColor = true;
            // 
            // txtEmployeeDescribe
            // 
            this.txtEmployeeDescribe.Location = new System.Drawing.Point(334, 277);
            this.txtEmployeeDescribe.Multiline = true;
            this.txtEmployeeDescribe.Name = "txtEmployeeDescribe";
            this.txtEmployeeDescribe.Size = new System.Drawing.Size(321, 55);
            this.txtEmployeeDescribe.TabIndex = 10;
            // 
            // cmbEmployeeDuty
            // 
            this.cmbEmployeeDuty.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbEmployeeDuty.FormattingEnabled = true;
            this.cmbEmployeeDuty.Location = new System.Drawing.Point(408, 202);
            this.cmbEmployeeDuty.Name = "cmbEmployeeDuty";
            this.cmbEmployeeDuty.Size = new System.Drawing.Size(139, 20);
            this.cmbEmployeeDuty.TabIndex = 9;
            // 
            // cmbEmployeeLevel
            // 
            this.cmbEmployeeLevel.FormattingEnabled = true;
            this.cmbEmployeeLevel.Location = new System.Drawing.Point(115, 202);
            this.cmbEmployeeLevel.Name = "cmbEmployeeLevel";
            this.cmbEmployeeLevel.Size = new System.Drawing.Size(139, 20);
            this.cmbEmployeeLevel.TabIndex = 8;
            // 
            // dtpEmployeeBirthday
            // 
            this.dtpEmployeeBirthday.Location = new System.Drawing.Point(408, 159);
            this.dtpEmployeeBirthday.Name = "dtpEmployeeBirthday";
            this.dtpEmployeeBirthday.Size = new System.Drawing.Size(139, 21);
            this.dtpEmployeeBirthday.TabIndex = 7;
            // 
            // cmbEmployeeSex
            // 
            this.cmbEmployeeSex.FormattingEnabled = true;
            this.cmbEmployeeSex.Location = new System.Drawing.Point(115, 162);
            this.cmbEmployeeSex.Name = "cmbEmployeeSex";
            this.cmbEmployeeSex.Size = new System.Drawing.Size(139, 20);
            this.cmbEmployeeSex.TabIndex = 6;
            // 
            // txtEmployeeName
            // 
            this.txtEmployeeName.Location = new System.Drawing.Point(115, 122);
            this.txtEmployeeName.Name = "txtEmployeeName";
            this.txtEmployeeName.Size = new System.Drawing.Size(139, 21);
            this.txtEmployeeName.TabIndex = 4;
            // 
            // txtEmployeeNO
            // 
            this.txtEmployeeNO.BackColor = System.Drawing.Color.White;
            this.txtEmployeeNO.Location = new System.Drawing.Point(115, 82);
            this.txtEmployeeNO.Name = "txtEmployeeNO";
            this.txtEmployeeNO.ReadOnly = true;
            this.txtEmployeeNO.Size = new System.Drawing.Size(139, 21);
            this.txtEmployeeNO.TabIndex = 2;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(33, 245);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(53, 12);
            this.label15.TabIndex = 7;
            this.label15.Text = "联系电话";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(33, 205);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(53, 12);
            this.label14.TabIndex = 6;
            this.label14.Text = "员工级别";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(332, 205);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(53, 12);
            this.label13.TabIndex = 5;
            this.label13.Text = "员工职务";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(33, 165);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(53, 12);
            this.label12.TabIndex = 4;
            this.label12.Text = "员工性别";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(332, 165);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(53, 12);
            this.label11.TabIndex = 3;
            this.label11.Text = "员工生日";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(33, 85);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(53, 12);
            this.label10.TabIndex = 2;
            this.label10.Text = "员工编号";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(33, 125);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(53, 12);
            this.label9.TabIndex = 1;
            this.label9.Text = "员工姓名";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(33, 45);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(41, 12);
            this.label8.TabIndex = 0;
            this.label8.Text = "部  门";
            // 
            // tabPage2
            // 
            this.tabPage2.BackColor = System.Drawing.SystemColors.Menu;
            this.tabPage2.Controls.Add(this.trwPowers);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(745, 399);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "权限设置";
            // 
            // trwPowers
            // 
            this.trwPowers.BackColor = System.Drawing.SystemColors.Menu;
            this.trwPowers.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.trwPowers.CheckBoxes = true;
            this.trwPowers.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.trwPowers.Location = new System.Drawing.Point(56, 6);
            this.trwPowers.Name = "trwPowers";
            this.trwPowers.Size = new System.Drawing.Size(689, 390);
            this.trwPowers.TabIndex = 1;
            this.trwPowers.AfterCheck += new System.Windows.Forms.TreeViewEventHandler(this.trwPowers_AfterCheck);
            this.trwPowers.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.trwPowers_AfterSelect);
            // 
            // btnQuit
            // 
            this.btnQuit.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.btnQuit.Location = new System.Drawing.Point(462, 443);
            this.btnQuit.Name = "btnQuit";
            this.btnQuit.Size = new System.Drawing.Size(93, 38);
            this.btnQuit.TabIndex = 13;
            this.btnQuit.Text = "返  回";
            this.btnQuit.UseVisualStyleBackColor = false;
            this.btnQuit.Click += new System.EventHandler(this.btnQuit_Click);
            // 
            // btnSaveAndQuit
            // 
            this.btnSaveAndQuit.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.btnSaveAndQuit.Location = new System.Drawing.Point(314, 443);
            this.btnSaveAndQuit.Name = "btnSaveAndQuit";
            this.btnSaveAndQuit.Size = new System.Drawing.Size(93, 38);
            this.btnSaveAndQuit.TabIndex = 12;
            this.btnSaveAndQuit.Text = "保存并关闭";
            this.btnSaveAndQuit.UseVisualStyleBackColor = false;
            this.btnSaveAndQuit.Click += new System.EventHandler(this.btnSaveAndQuit_Click);
            // 
            // btnSave
            // 
            this.btnSave.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.btnSave.Location = new System.Drawing.Point(161, 443);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(93, 38);
            this.btnSave.TabIndex = 11;
            this.btnSave.Text = "保  存";
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // frmEmployee
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(779, 493);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.btnQuit);
            this.Controls.Add(this.btnSaveAndQuit);
            this.Controls.Add(this.btnSave);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmEmployee";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "员工管理";
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox txtEmployeeDescribe;
        private System.Windows.Forms.ComboBox cmbEmployeeDuty;
        private System.Windows.Forms.ComboBox cmbEmployeeLevel;
        private System.Windows.Forms.DateTimePicker dtpEmployeeBirthday;
        private System.Windows.Forms.ComboBox cmbEmployeeSex;
        private System.Windows.Forms.TextBox txtEmployeeName;
        private System.Windows.Forms.TextBox txtEmployeeNO;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.CheckBox chbIsDelete;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnSaveAndQuit;
        private System.Windows.Forms.Button btnQuit;
        private System.Windows.Forms.Label lbCreateDate;
        private System.Windows.Forms.Label lbCreate;
        private System.Windows.Forms.Label lbCreateDateCaption;
        private System.Windows.Forms.Label lbCreateCaption;
        private System.Windows.Forms.OpenFileDialog opfEmployeePhoto;
        private System.Windows.Forms.TextBox txtEmployeePassword;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.ComboBox cmbDepartment;
        private System.Windows.Forms.TextBox txtCardNO;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtEmployeeNO2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnDistributeCard;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtEmployeePhone;
        private System.Windows.Forms.TreeView trwPowers;
        private System.Windows.Forms.TextBox txtDepartmentNO;
    }
}