namespace GoldenLady.Dress.View
{
    partial class FrmVenueShow
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
            this.picVenues = new System.Windows.Forms.PictureBox();
            this.customizeGroupBox2 = new GoldenLady.Utility.UserControls.CustomizeGroupBox();
            this.lblInformationW = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.lblPhone = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.lblName = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.lblOrderNO = new System.Windows.Forms.Label();
            this.lblSuit = new System.Windows.Forms.Label();
            this.lblInformationN = new System.Windows.Forms.Label();
            this.lblPrice = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.customizeGroupBox1 = new GoldenLady.Utility.UserControls.CustomizeGroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.picVenues)).BeginInit();
            this.customizeGroupBox2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.customizeGroupBox1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // picVenues
            // 
            this.picVenues.BackColor = System.Drawing.Color.White;
            this.picVenues.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.picVenues.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.picVenues.Dock = System.Windows.Forms.DockStyle.Fill;
            this.picVenues.Location = new System.Drawing.Point(0, 0);
            this.picVenues.Name = "picVenues";
            this.picVenues.Size = new System.Drawing.Size(837, 710);
            this.picVenues.TabIndex = 8;
            this.picVenues.TabStop = false;
            this.picVenues.MouseDown += new System.Windows.Forms.MouseEventHandler(this.picView_MouseDown);
            this.picVenues.MouseLeave += new System.EventHandler(this.ptbView_MouseLeave);
            this.picVenues.MouseMove += new System.Windows.Forms.MouseEventHandler(this.ptbView_MouseMove);
            // 
            // customizeGroupBox2
            // 
            this.customizeGroupBox2.BorderColor = System.Drawing.Color.Black;
            this.customizeGroupBox2.Controls.Add(this.lblInformationW);
            this.customizeGroupBox2.Controls.Add(this.label4);
            this.customizeGroupBox2.Controls.Add(this.label8);
            this.customizeGroupBox2.Controls.Add(this.label1);
            this.customizeGroupBox2.Controls.Add(this.lblPhone);
            this.customizeGroupBox2.Controls.Add(this.label7);
            this.customizeGroupBox2.Controls.Add(this.lblName);
            this.customizeGroupBox2.Controls.Add(this.label5);
            this.customizeGroupBox2.Controls.Add(this.label6);
            this.customizeGroupBox2.Controls.Add(this.lblOrderNO);
            this.customizeGroupBox2.Controls.Add(this.lblSuit);
            this.customizeGroupBox2.Controls.Add(this.lblInformationN);
            this.customizeGroupBox2.Controls.Add(this.lblPrice);
            this.customizeGroupBox2.Dock = System.Windows.Forms.DockStyle.Top;
            this.customizeGroupBox2.Location = new System.Drawing.Point(0, 0);
            this.customizeGroupBox2.Name = "customizeGroupBox2";
            this.customizeGroupBox2.Size = new System.Drawing.Size(325, 300);
            this.customizeGroupBox2.TabIndex = 5;
            this.customizeGroupBox2.TabStop = false;
            this.customizeGroupBox2.Text = "订单信息";
            this.customizeGroupBox2.TitleFontColor = System.Drawing.Color.Black;
            // 
            // lblInformationW
            // 
            this.lblInformationW.AutoSize = true;
            this.lblInformationW.BackColor = System.Drawing.Color.Linen;
            this.lblInformationW.Location = new System.Drawing.Point(115, 255);
            this.lblInformationW.Name = "lblInformationW";
            this.lblInformationW.Size = new System.Drawing.Size(45, 20);
            this.lblInformationW.TabIndex = 9;
            this.lblInformationW.Text = "XXXX";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(30, 114);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(63, 20);
            this.label4.TabIndex = 3;
            this.label4.Text = "电   话：";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(30, 224);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(79, 20);
            this.label8.TabIndex = 8;
            this.label8.Text = "拍摄信息：";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(30, 42);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(67, 20);
            this.label1.TabIndex = 2;
            this.label1.Text = "姓    名：";
            // 
            // lblPhone
            // 
            this.lblPhone.AutoSize = true;
            this.lblPhone.BackColor = System.Drawing.Color.Linen;
            this.lblPhone.Location = new System.Drawing.Point(115, 114);
            this.lblPhone.Name = "lblPhone";
            this.lblPhone.Size = new System.Drawing.Size(36, 20);
            this.lblPhone.TabIndex = 1;
            this.lblPhone.Text = "XXX";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(30, 184);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(79, 20);
            this.label7.TabIndex = 7;
            this.label7.Text = "成交价格：";
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.BackColor = System.Drawing.Color.Linen;
            this.lblName.Location = new System.Drawing.Point(115, 42);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(36, 20);
            this.lblName.TabIndex = 0;
            this.lblName.Text = "XXX";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(30, 77);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(79, 20);
            this.label5.TabIndex = 5;
            this.label5.Text = "订单编号：";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(30, 149);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(63, 20);
            this.label6.TabIndex = 6;
            this.label6.Text = "套   系：";
            // 
            // lblOrderNO
            // 
            this.lblOrderNO.AutoSize = true;
            this.lblOrderNO.BackColor = System.Drawing.Color.Linen;
            this.lblOrderNO.Location = new System.Drawing.Point(115, 77);
            this.lblOrderNO.Name = "lblOrderNO";
            this.lblOrderNO.Size = new System.Drawing.Size(36, 20);
            this.lblOrderNO.TabIndex = 1;
            this.lblOrderNO.Text = "XXX";
            // 
            // lblSuit
            // 
            this.lblSuit.AutoSize = true;
            this.lblSuit.BackColor = System.Drawing.Color.Linen;
            this.lblSuit.Location = new System.Drawing.Point(115, 149);
            this.lblSuit.Name = "lblSuit";
            this.lblSuit.Size = new System.Drawing.Size(36, 20);
            this.lblSuit.TabIndex = 2;
            this.lblSuit.Text = "XXX";
            // 
            // lblInformationN
            // 
            this.lblInformationN.AutoSize = true;
            this.lblInformationN.BackColor = System.Drawing.Color.Linen;
            this.lblInformationN.Location = new System.Drawing.Point(115, 224);
            this.lblInformationN.Name = "lblInformationN";
            this.lblInformationN.Size = new System.Drawing.Size(45, 20);
            this.lblInformationN.TabIndex = 4;
            this.lblInformationN.Text = "XXXX";
            // 
            // lblPrice
            // 
            this.lblPrice.AutoSize = true;
            this.lblPrice.BackColor = System.Drawing.Color.Linen;
            this.lblPrice.Location = new System.Drawing.Point(115, 184);
            this.lblPrice.Name = "lblPrice";
            this.lblPrice.Size = new System.Drawing.Size(36, 20);
            this.lblPrice.TabIndex = 3;
            this.lblPrice.Text = "XXX";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.customizeGroupBox1);
            this.panel1.Controls.Add(this.customizeGroupBox2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(325, 710);
            this.panel1.TabIndex = 9;
            // 
            // customizeGroupBox1
            // 
            this.customizeGroupBox1.BorderColor = System.Drawing.Color.Black;
            this.customizeGroupBox1.Controls.Add(this.label2);
            this.customizeGroupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.customizeGroupBox1.Location = new System.Drawing.Point(0, 300);
            this.customizeGroupBox1.Name = "customizeGroupBox1";
            this.customizeGroupBox1.Size = new System.Drawing.Size(325, 410);
            this.customizeGroupBox1.TabIndex = 6;
            this.customizeGroupBox1.TabStop = false;
            this.customizeGroupBox1.Text = "场馆介绍";
            this.customizeGroupBox1.TitleFontColor = System.Drawing.Color.Black;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Linen;
            this.label2.Location = new System.Drawing.Point(48, 46);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(45, 20);
            this.label2.TabIndex = 10;
            this.label2.Text = "XXXX";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.picVenues);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(325, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(837, 710);
            this.panel2.TabIndex = 10;
            // 
            // FrmVenueShow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1162, 710);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "FrmVenueShow";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "场馆信息";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            ((System.ComponentModel.ISupportInitialize)(this.picVenues)).EndInit();
            this.customizeGroupBox2.ResumeLayout(false);
            this.customizeGroupBox2.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.customizeGroupBox1.ResumeLayout(false);
            this.customizeGroupBox1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblPhone;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label lblInformationN;
        private System.Windows.Forms.Label lblPrice;
        private System.Windows.Forms.Label lblSuit;
        private System.Windows.Forms.Label lblOrderNO;
        private System.Windows.Forms.PictureBox picVenues;
        private Utility.UserControls.CustomizeGroupBox customizeGroupBox2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label lblInformationW;
        private Utility.UserControls.CustomizeGroupBox customizeGroupBox1;
        private System.Windows.Forms.Label label2;
    }
}