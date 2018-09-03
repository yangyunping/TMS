using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using GoldenLady.Global;
using GoldenLadyWS;

namespace GoldenLady.Dress.View.DressRent
{
    public partial class FrmCallBack : Form
    {
        public FrmCallBack(string orderNo)
        {
            InitializeComponent();
            lbOrderNo.Text = orderNo;
            lbOperator.Text = Information.CurrentUser.EmployeeName;

            DataSet dsRemark = ErpService.DressManagement.GetDressRemarkTemplete();
            cmbRemarkTemplete.DataSource = dsRemark.Tables[0];
            cmbRemarkTemplete.DisplayMember = "RemarkContent";
            cmbRemarkTemplete.ValueMember = "ID";  
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (ErpService.DressManagement.SaveCallBack(lbOrderNo.Text,txtRemark.Text,Information.CurrentUser.EmployeeNO2))
            {
                MessageBox.Show(@"保存成功！");
                this.Close();
            }
            else
            {
                MessageBox.Show(@"保存失败，检查网络后重试！");
            }
        }

        private void btnAddRemark_Click(object sender, EventArgs e)
        {
            txtRemark.Clear();
            txtRemark.Text = cmbRemarkTemplete.Text;
        }
    }
}
