using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace GoldenLady.Dress
{
    public partial class frmInputBox : Form
    {
        public string sDefault = "";
        public frmInputBox(string sTitle,string sCaption,string sDefault)
        {
            InitializeComponent();
            this.Text = sTitle;
            this.lbCaption.Text = sCaption;
            this.txtContent.Text = sDefault;
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            this.sDefault = txtContent.Text.ToString();

            this.DialogResult = DialogResult.Yes;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.sDefault = "";
            this.DialogResult = DialogResult.No;
        }
    }
}