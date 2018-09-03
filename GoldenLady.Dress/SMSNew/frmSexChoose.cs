using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace GoldenLady.SMSNew
{
    public partial class frmSexChoose : Form
    {
        public frmSexChoose()
        {
            InitializeComponent();
            rdbAll.Checked = true;
        }

        public int sex = 0;

        private void rdbAll_CheckedChanged(object sender, EventArgs e)
        {
            if (rdbAll.Checked)
            {
                sex = 2;
            }
        }

        private void rdbBoy_CheckedChanged(object sender, EventArgs e)
        {
            if (rdbBoy.Checked)
            {
                sex = 1;
            }
        }

        private void rdbGirl_CheckedChanged(object sender, EventArgs e)
        {
            if (rdbGirl.Checked)
            {
                sex = 0;
            }
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
