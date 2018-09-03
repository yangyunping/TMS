namespace GoldenLady.Dress.View
{
    partial class FrmCrossReservation
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
            System.Windows.Forms.GroupBox groupBox1;
            System.Windows.Forms.GroupBox groupBox2;
            this.lstVenue = new System.Windows.Forms.ListBox();
            this.btnNew = new System.Windows.Forms.Button();
            this.cmbVenue = new System.Windows.Forms.ComboBox();
            this.btnDelete = new System.Windows.Forms.Button();
            this.lstCrossVenue = new System.Windows.Forms.ListBox();
            groupBox1 = new System.Windows.Forms.GroupBox();
            groupBox2 = new System.Windows.Forms.GroupBox();
            groupBox1.SuspendLayout();
            groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(this.lstVenue);
            groupBox1.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            groupBox1.Location = new System.Drawing.Point(3, 12);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new System.Drawing.Size(216, 465);
            groupBox1.TabIndex = 1;
            groupBox1.TabStop = false;
            groupBox1.Text = "选择场馆";
            // 
            // lstVenue
            // 
            this.lstVenue.DisplayMember = "Name";
            this.lstVenue.FormattingEnabled = true;
            this.lstVenue.ItemHeight = 20;
            this.lstVenue.Location = new System.Drawing.Point(6, 24);
            this.lstVenue.Name = "lstVenue";
            this.lstVenue.Size = new System.Drawing.Size(204, 424);
            this.lstVenue.TabIndex = 0;
            this.lstVenue.ValueMember = "ID";
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(this.btnNew);
            groupBox2.Controls.Add(this.cmbVenue);
            groupBox2.Controls.Add(this.btnDelete);
            groupBox2.Controls.Add(this.lstCrossVenue);
            groupBox2.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            groupBox2.Location = new System.Drawing.Point(237, 12);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new System.Drawing.Size(458, 465);
            groupBox2.TabIndex = 2;
            groupBox2.TabStop = false;
            groupBox2.Text = "可以跨馆选衣的场馆";
            // 
            // btnNew
            // 
            this.btnNew.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.btnNew.Location = new System.Drawing.Point(268, 72);
            this.btnNew.Name = "btnNew";
            this.btnNew.Size = new System.Drawing.Size(160, 50);
            this.btnNew.TabIndex = 3;
            this.btnNew.Text = "添加该场馆";
            this.btnNew.UseVisualStyleBackColor = false;
            this.btnNew.Click += new System.EventHandler(this.btnNew_Click);
            // 
            // cmbVenue
            // 
            this.cmbVenue.DisplayMember = "Name";
            this.cmbVenue.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbVenue.FormattingEnabled = true;
            this.cmbVenue.Location = new System.Drawing.Point(268, 25);
            this.cmbVenue.Name = "cmbVenue";
            this.cmbVenue.Size = new System.Drawing.Size(160, 28);
            this.cmbVenue.TabIndex = 2;
            this.cmbVenue.ValueMember = "ID";
            // 
            // btnDelete
            // 
            this.btnDelete.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.btnDelete.Location = new System.Drawing.Point(268, 153);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(160, 50);
            this.btnDelete.TabIndex = 1;
            this.btnDelete.Text = "删除选中的场馆";
            this.btnDelete.UseVisualStyleBackColor = false;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // lstCrossVenue
            // 
            this.lstCrossVenue.DisplayMember = "CrossVenue";
            this.lstCrossVenue.FormattingEnabled = true;
            this.lstCrossVenue.ItemHeight = 20;
            this.lstCrossVenue.Location = new System.Drawing.Point(6, 24);
            this.lstCrossVenue.Name = "lstCrossVenue";
            this.lstCrossVenue.Size = new System.Drawing.Size(244, 424);
            this.lstCrossVenue.TabIndex = 0;
            this.lstCrossVenue.ValueMember = "ID";
            // 
            // FrmCrossReservation
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(699, 479);
            this.Controls.Add(groupBox2);
            this.Controls.Add(groupBox1);
            this.Font = new System.Drawing.Font("微软雅黑", 10.5F);
            this.Margin = new System.Windows.Forms.Padding(5, 9, 5, 9);
            this.Name = "FrmCrossReservation";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.FrmCrossReservation_Load);
            groupBox1.ResumeLayout(false);
            groupBox2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox lstVenue;
        private System.Windows.Forms.ListBox lstCrossVenue;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.ComboBox cmbVenue;
        private System.Windows.Forms.Button btnNew;
    }
}