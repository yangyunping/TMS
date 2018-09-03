namespace GoldenLady.Dress.View
{
    partial class FrmDressModify
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
            System.Windows.Forms.Label label1;
            this.picDress = new System.Windows.Forms.PictureBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtCnt = new System.Windows.Forms.TextBox();
            this.btnChangeUse = new System.Windows.Forms.Button();
            this.cmbUse = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.nmUpDm = new System.Windows.Forms.NumericUpDown();
            this.btnCount = new System.Windows.Forms.Button();
            this.btnChangeArea = new System.Windows.Forms.Button();
            this.txtBarcode = new System.Windows.Forms.TextBox();
            label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.picDress)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nmUpDm)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new System.Drawing.Point(6, 37);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(65, 20);
            label1.TabIndex = 13;
            label1.Text = "礼服条码";
            // 
            // picDress
            // 
            this.picDress.BackColor = System.Drawing.Color.White;
            this.picDress.Location = new System.Drawing.Point(327, 12);
            this.picDress.Name = "picDress";
            this.picDress.Size = new System.Drawing.Size(275, 427);
            this.picDress.TabIndex = 4;
            this.picDress.TabStop = false;
            this.picDress.Click += new System.EventHandler(this.picDress_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.White;
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.txtCnt);
            this.groupBox1.Controls.Add(this.btnChangeUse);
            this.groupBox1.Controls.Add(this.cmbUse);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.nmUpDm);
            this.groupBox1.Controls.Add(this.btnCount);
            this.groupBox1.Controls.Add(this.btnChangeArea);
            this.groupBox1.Controls.Add(this.txtBarcode);
            this.groupBox1.Controls.Add(label1);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(309, 427);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "礼服信息";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(255, 37);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(23, 20);
            this.label3.TabIndex = 22;
            this.label3.Text = "次";
            // 
            // txtCnt
            // 
            this.txtCnt.Location = new System.Drawing.Point(223, 34);
            this.txtCnt.Name = "txtCnt";
            this.txtCnt.ReadOnly = true;
            this.txtCnt.Size = new System.Drawing.Size(26, 26);
            this.txtCnt.TabIndex = 21;
            // 
            // btnChangeUse
            // 
            this.btnChangeUse.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.btnChangeUse.Location = new System.Drawing.Point(173, 211);
            this.btnChangeUse.Name = "btnChangeUse";
            this.btnChangeUse.Size = new System.Drawing.Size(105, 40);
            this.btnChangeUse.TabIndex = 20;
            this.btnChangeUse.Text = "修改用途";
            this.btnChangeUse.UseVisualStyleBackColor = false;
            this.btnChangeUse.Click += new System.EventHandler(this.btnChangeUse_Click);
            // 
            // cmbUse
            // 
            this.cmbUse.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbUse.FormattingEnabled = true;
            this.cmbUse.Location = new System.Drawing.Point(74, 218);
            this.cmbUse.Name = "cmbUse";
            this.cmbUse.Size = new System.Drawing.Size(93, 28);
            this.cmbUse.TabIndex = 19;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.ForeColor = System.Drawing.Color.Maroon;
            this.label2.Location = new System.Drawing.Point(63, 77);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(215, 20);
            this.label2.TabIndex = 18;
            this.label2.Text = "(输入条码后按下确认再进行操作)";
            // 
            // nmUpDm
            // 
            this.nmUpDm.Location = new System.Drawing.Point(74, 136);
            this.nmUpDm.Name = "nmUpDm";
            this.nmUpDm.Size = new System.Drawing.Size(93, 26);
            this.nmUpDm.TabIndex = 17;
            // 
            // btnCount
            // 
            this.btnCount.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.btnCount.Location = new System.Drawing.Point(173, 129);
            this.btnCount.Name = "btnCount";
            this.btnCount.Size = new System.Drawing.Size(105, 40);
            this.btnCount.TabIndex = 16;
            this.btnCount.Text = "修改次数";
            this.btnCount.UseVisualStyleBackColor = false;
            this.btnCount.Click += new System.EventHandler(this.btnCount_Click);
            // 
            // btnChangeArea
            // 
            this.btnChangeArea.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.btnChangeArea.Location = new System.Drawing.Point(74, 293);
            this.btnChangeArea.Name = "btnChangeArea";
            this.btnChangeArea.Size = new System.Drawing.Size(204, 40);
            this.btnChangeArea.TabIndex = 15;
            this.btnChangeArea.Text = "所在场馆变更";
            this.btnChangeArea.UseVisualStyleBackColor = false;
            this.btnChangeArea.Click += new System.EventHandler(this.btnChangeArea_Click);
            // 
            // txtBarcode
            // 
            this.txtBarcode.Location = new System.Drawing.Point(77, 34);
            this.txtBarcode.Name = "txtBarcode";
            this.txtBarcode.Size = new System.Drawing.Size(140, 26);
            this.txtBarcode.TabIndex = 14;
            this.txtBarcode.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtBarcode_KeyDown);
            // 
            // FrmDressModify
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(625, 451);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.picDress);
            this.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Name = "FrmDressModify";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            ((System.ComponentModel.ISupportInitialize)(this.picDress)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nmUpDm)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox picDress;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtCnt;
        private System.Windows.Forms.Button btnChangeUse;
        private System.Windows.Forms.ComboBox cmbUse;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown nmUpDm;
        private System.Windows.Forms.Button btnCount;
        private System.Windows.Forms.Button btnChangeArea;
        private System.Windows.Forms.TextBox txtBarcode;
    }
}