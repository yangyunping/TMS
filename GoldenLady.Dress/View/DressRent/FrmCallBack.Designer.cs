namespace GoldenLady.Dress.View.DressRent
{
    partial class FrmCallBack
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
            this.btnExit = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnAddRemark = new System.Windows.Forms.Button();
            this.cmbRemarkTemplete = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.lbOperator = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtRemark = new System.Windows.Forms.RichTextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.lbOrderNo = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnExit
            // 
            this.btnExit.BackColor = System.Drawing.Color.Snow;
            this.btnExit.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnExit.Location = new System.Drawing.Point(107, 361);
            this.btnExit.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(100, 38);
            this.btnExit.TabIndex = 6;
            this.btnExit.Text = "取  消";
            this.btnExit.UseVisualStyleBackColor = false;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // btnSave
            // 
            this.btnSave.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.btnSave.Location = new System.Drawing.Point(268, 361);
            this.btnSave.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(100, 38);
            this.btnSave.TabIndex = 6;
            this.btnSave.Text = "保  存";
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnAddRemark
            // 
            this.btnAddRemark.Location = new System.Drawing.Point(322, 85);
            this.btnAddRemark.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnAddRemark.Name = "btnAddRemark";
            this.btnAddRemark.Size = new System.Drawing.Size(37, 30);
            this.btnAddRemark.TabIndex = 18;
            this.btnAddRemark.Text = "+";
            this.btnAddRemark.UseVisualStyleBackColor = true;
            this.btnAddRemark.Click += new System.EventHandler(this.btnAddRemark_Click);
            // 
            // cmbRemarkTemplete
            // 
            this.cmbRemarkTemplete.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbRemarkTemplete.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmbRemarkTemplete.FormattingEnabled = true;
            this.cmbRemarkTemplete.Location = new System.Drawing.Point(107, 86);
            this.cmbRemarkTemplete.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cmbRemarkTemplete.Name = "cmbRemarkTemplete";
            this.cmbRemarkTemplete.Size = new System.Drawing.Size(197, 28);
            this.cmbRemarkTemplete.TabIndex = 17;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(28, 90);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 20);
            this.label2.TabIndex = 16;
            this.label2.Text = "模    板";
            // 
            // lbOperator
            // 
            this.lbOperator.AutoSize = true;
            this.lbOperator.Location = new System.Drawing.Point(107, 317);
            this.lbOperator.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbOperator.Name = "lbOperator";
            this.lbOperator.Size = new System.Drawing.Size(50, 20);
            this.lbOperator.TabIndex = 15;
            this.lbOperator.Text = "label2";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(28, 317);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(59, 20);
            this.label4.TabIndex = 14;
            this.label4.Text = "操 作 者";
            // 
            // txtRemark
            // 
            this.txtRemark.Location = new System.Drawing.Point(107, 153);
            this.txtRemark.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtRemark.Name = "txtRemark";
            this.txtRemark.Size = new System.Drawing.Size(361, 146);
            this.txtRemark.TabIndex = 13;
            this.txtRemark.Text = "";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(28, 152);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 20);
            this.label3.TabIndex = 12;
            this.label3.Text = "预约备注";
            // 
            // lbOrderNo
            // 
            this.lbOrderNo.AutoSize = true;
            this.lbOrderNo.Location = new System.Drawing.Point(107, 32);
            this.lbOrderNo.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbOrderNo.Name = "lbOrderNo";
            this.lbOrderNo.Size = new System.Drawing.Size(80, 20);
            this.lbOrderNo.TabIndex = 11;
            this.lbOrderNo.Text = "lbOrderNo";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(28, 32);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(59, 20);
            this.label1.TabIndex = 10;
            this.label1.Text = "订 单 号";
            // 
            // FrmCallBack
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(478, 423);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.btnAddRemark);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.cmbRemarkTemplete);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lbOperator);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtRemark);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.lbOrderNo);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "FrmCallBack";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "电话追踪";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnAddRemark;
        private System.Windows.Forms.ComboBox cmbRemarkTemplete;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lbOperator;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.RichTextBox txtRemark;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lbOrderNo;
        private System.Windows.Forms.Label label1;
    }
}