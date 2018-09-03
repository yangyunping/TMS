namespace GoldenLady.Dress.View
{
    partial class FrmSceneDress
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
            if(disposing && (components != null))
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
            GoldenLady.Utility.UserControls.CustomizeGroupBox customizeGroupBox1;
            GoldenLady.Utility.UserControls.CustomizedTextBox customizedTextBox1;
            System.Windows.Forms.Label label5;
            System.Windows.Forms.Label label4;
            System.Windows.Forms.Label label3;
            System.Windows.Forms.Label label2;
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnAdd = new System.Windows.Forms.Button();
            this.txtDressBarCode = new GoldenLady.Utility.UserControls.NumericTextBox();
            this.btnDelete = new System.Windows.Forms.Button();
            this.lstDress = new System.Windows.Forms.ListBox();
            this.cmbScene = new System.Windows.Forms.ComboBox();
            this.cmbTheme = new System.Windows.Forms.ComboBox();
            this.cmbVenue = new System.Windows.Forms.ComboBox();
            customizeGroupBox1 = new GoldenLady.Utility.UserControls.CustomizeGroupBox();
            customizedTextBox1 = new GoldenLady.Utility.UserControls.CustomizedTextBox();
            label5 = new System.Windows.Forms.Label();
            label4 = new System.Windows.Forms.Label();
            label3 = new System.Windows.Forms.Label();
            label2 = new System.Windows.Forms.Label();
            customizeGroupBox1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // customizeGroupBox1
            // 
            customizeGroupBox1.BorderColor = System.Drawing.Color.Black;
            customizeGroupBox1.Controls.Add(customizedTextBox1);
            customizeGroupBox1.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            customizeGroupBox1.Location = new System.Drawing.Point(401, 67);
            customizeGroupBox1.Name = "customizeGroupBox1";
            customizeGroupBox1.Size = new System.Drawing.Size(236, 125);
            customizeGroupBox1.TabIndex = 23;
            customizeGroupBox1.TabStop = false;
            customizeGroupBox1.Text = "你知道吗";
            customizeGroupBox1.TitleFontColor = System.Drawing.Color.Black;
            // 
            // customizedTextBox1
            // 
            customizedTextBox1.BackColor = System.Drawing.SystemColors.Control;
            customizedTextBox1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            customizedTextBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            customizedTextBox1.ForeColor = System.Drawing.Color.Navy;
            customizedTextBox1.Location = new System.Drawing.Point(3, 22);
            customizedTextBox1.Multiline = true;
            customizedTextBox1.Name = "customizedTextBox1";
            customizedTextBox1.ReadOnly = true;
            customizedTextBox1.Size = new System.Drawing.Size(230, 100);
            customizedTextBox1.TabIndex = 0;
            customizedTextBox1.Text = "1.双击左边的礼服条码，可以快速复制编号到下方编辑框中\r\n\r\n2.输入要添加的礼服条码后，按回车键就可以快速完成添加\r\n";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            label5.Location = new System.Drawing.Point(397, 217);
            label5.Name = "label5";
            label5.Size = new System.Drawing.Size(65, 20);
            label5.TabIndex = 21;
            label5.Text = "礼服条码";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            label4.Location = new System.Drawing.Point(451, 20);
            label4.Name = "label4";
            label4.Size = new System.Drawing.Size(37, 20);
            label4.TabIndex = 16;
            label4.Text = "场景";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            label3.Location = new System.Drawing.Point(230, 20);
            label3.Name = "label3";
            label3.Size = new System.Drawing.Size(37, 20);
            label3.TabIndex = 14;
            label3.Text = "风格";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            label2.Location = new System.Drawing.Point(12, 20);
            label2.Name = "label2";
            label2.Size = new System.Drawing.Size(37, 20);
            label2.TabIndex = 12;
            label2.Text = "场馆";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(customizeGroupBox1);
            this.panel1.Controls.Add(this.btnAdd);
            this.panel1.Controls.Add(label5);
            this.panel1.Controls.Add(this.txtDressBarCode);
            this.panel1.Controls.Add(this.btnDelete);
            this.panel1.Controls.Add(this.lstDress);
            this.panel1.Controls.Add(this.cmbScene);
            this.panel1.Controls.Add(label4);
            this.panel1.Controls.Add(this.cmbTheme);
            this.panel1.Controls.Add(label3);
            this.panel1.Controls.Add(this.cmbVenue);
            this.panel1.Controls.Add(label2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(648, 456);
            this.panel1.TabIndex = 0;
            // 
            // btnAdd
            // 
            this.btnAdd.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.btnAdd.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnAdd.Location = new System.Drawing.Point(401, 259);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(236, 41);
            this.btnAdd.TabIndex = 22;
            this.btnAdd.Text = "添加该礼服";
            this.btnAdd.UseVisualStyleBackColor = false;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // txtDressBarCode
            // 
            this.txtDressBarCode.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtDressBarCode.Location = new System.Drawing.Point(468, 214);
            this.txtDressBarCode.Name = "txtDressBarCode";
            this.txtDressBarCode.Size = new System.Drawing.Size(169, 26);
            this.txtDressBarCode.TabIndex = 20;
            this.txtDressBarCode.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtDressBarCode_KeyDown);
            // 
            // btnDelete
            // 
            this.btnDelete.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.btnDelete.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnDelete.Location = new System.Drawing.Point(401, 410);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(236, 41);
            this.btnDelete.TabIndex = 19;
            this.btnDelete.Text = "移除选中礼服";
            this.btnDelete.UseVisualStyleBackColor = false;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // lstDress
            // 
            this.lstDress.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lstDress.FormattingEnabled = true;
            this.lstDress.ItemHeight = 20;
            this.lstDress.Location = new System.Drawing.Point(16, 67);
            this.lstDress.Name = "lstDress";
            this.lstDress.Size = new System.Drawing.Size(339, 384);
            this.lstDress.TabIndex = 18;
            this.lstDress.DoubleClick += new System.EventHandler(this.lstDress_DoubleClick);
            // 
            // cmbScene
            // 
            this.cmbScene.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbScene.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cmbScene.FormattingEnabled = true;
            this.cmbScene.Location = new System.Drawing.Point(494, 16);
            this.cmbScene.Name = "cmbScene";
            this.cmbScene.Size = new System.Drawing.Size(140, 28);
            this.cmbScene.TabIndex = 17;
            // 
            // cmbTheme
            // 
            this.cmbTheme.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbTheme.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cmbTheme.FormattingEnabled = true;
            this.cmbTheme.Location = new System.Drawing.Point(273, 16);
            this.cmbTheme.Name = "cmbTheme";
            this.cmbTheme.Size = new System.Drawing.Size(140, 28);
            this.cmbTheme.TabIndex = 15;
            // 
            // cmbVenue
            // 
            this.cmbVenue.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbVenue.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cmbVenue.FormattingEnabled = true;
            this.cmbVenue.Location = new System.Drawing.Point(55, 16);
            this.cmbVenue.Name = "cmbVenue";
            this.cmbVenue.Size = new System.Drawing.Size(140, 28);
            this.cmbVenue.TabIndex = 13;
            // 
            // FrmSceneDress
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(648, 456);
            this.Controls.Add(this.panel1);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "FrmSceneDress";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.FrmSceneDress_Load);
            customizeGroupBox1.ResumeLayout(false);
            customizeGroupBox1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnAdd;
        private Utility.UserControls.NumericTextBox txtDressBarCode;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.ListBox lstDress;
        private System.Windows.Forms.ComboBox cmbScene;
        private System.Windows.Forms.ComboBox cmbTheme;
        private System.Windows.Forms.ComboBox cmbVenue;

    }
}