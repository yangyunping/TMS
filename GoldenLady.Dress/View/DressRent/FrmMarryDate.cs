using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using GoldenLadyWS;

namespace GoldenLady.Dress.View.DressRent
{
    public partial class FrmMarryDate : Form
    {
        private readonly string _customerNo;
        public FrmMarryDate(string customerNo)
        {
            InitializeComponent();
            _customerNo = customerNo;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if(MessageBox.Show(@"婚期确定？",@"提示！",MessageBoxButtons.YesNo,MessageBoxIcon.Question) == DialogResult.Yes)
            {
                if (ErpService.DressManagement.UpdateMarrydate(dtpMarrydate.Value, _customerNo))
                {
                    MessageBox.Show(@"操作成功！");
                    this.Close();
                }
                else
                {
                    MessageBox.Show(@"操作失败,检查后重试！");
                }
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
