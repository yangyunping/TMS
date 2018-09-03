using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using GoldenLady.Extension;
using GoldenLady.Global;
using GoldenLadyWS;

namespace GoldenLady.Dress.View.DressRent
{
    public partial class FrmAddCost : Form
    {
        public FrmAddCost(string orderInfo)
        {
            InitializeComponent();

            string[] orderStrings = orderInfo.Split(',');
            cmbOrderNo.Text = orderStrings[0];
            lblMan.Text = orderStrings[1];
            lblWomen.Text = orderStrings[2];
            if (string.IsNullOrEmpty(orderStrings[3]))
            {
                txtTelPhoto.Text = orderStrings[4];
            }
            else
            {
                txtTelPhoto.Text = orderStrings[3];
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (ErpService.DressManagement.AddDressCost(cmbOrderNo.Text, Convert.ToDecimal(txtAddCost.Text),Information.CurrentUser.EmployeeNO2))
            {
                MessageBox.Show(@"新增消费成功！");
            }
            else
            {
                MessageBox.Show(@"新增消费失败！");
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
