namespace GoldenLady.Dress
{
    partial class frmPrinter
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.cmbBB = new System.Windows.Forms.ComboBox();
            this.cmbTM = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(34, 33);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "收银打印机";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(34, 62);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 12);
            this.label2.TabIndex = 1;
            this.label2.Text = "常规打印机";
            // 
            // cmbBB
            // 
            this.cmbBB.FormattingEnabled = true;
            this.cmbBB.Location = new System.Drawing.Point(105, 30);
            this.cmbBB.Name = "cmbBB";
            this.cmbBB.Size = new System.Drawing.Size(169, 20);
            this.cmbBB.TabIndex = 2;
            this.cmbBB.SelectedIndexChanged += new System.EventHandler(this.cmbBB_SelectedIndexChanged);
            // 
            // cmbTM
            // 
            this.cmbTM.FormattingEnabled = true;
            this.cmbTM.Location = new System.Drawing.Point(105, 59);
            this.cmbTM.Name = "cmbTM";
            this.cmbTM.Size = new System.Drawing.Size(169, 20);
            this.cmbTM.TabIndex = 3;
            this.cmbTM.SelectedIndexChanged += new System.EventHandler(this.cmbTM_SelectedIndexChanged);
            // 
            // frmPrinter
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(309, 114);
            this.Controls.Add(this.cmbTM);
            this.Controls.Add(this.cmbBB);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "frmPrinter";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "打印机设置";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cmbBB;
        private System.Windows.Forms.ComboBox cmbTM;
    }
}