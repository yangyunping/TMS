using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using GoldenLady.Extension;
using GoldenLadyWS;

namespace GoldenLady.Dress.View.DressRent
{
    public partial class FrmAddRemark : Form
    {
        private readonly string _orderNo;
        private readonly string _batchNum ;
        private readonly string _dressbarcode ;
        public FrmAddRemark(string orderNo,string batchNum, string dressbarcode,string historyRemark)
        {
            InitializeComponent();
            _orderNo = orderNo;
            _batchNum = batchNum;
            _dressbarcode = dressbarcode;
            txtContent.Text = historyRemark; //出租查询修改备注显示已有备注

            if (!string.IsNullOrEmpty(_orderNo) && string.IsNullOrEmpty(_batchNum) && string.IsNullOrEmpty(dressbarcode)) //排单
            {
                DataTable dtDressConfig = ErpService.DressManagement.GetSmallGoods(@"排单备注").Tables[0];
                cmbTemplet.DataSource = dtDressConfig;
                cmbTemplet.DisplayMember = @"ConfigValue";
                cmbTemplet.ValueMember = @"ID";
                cmbTemplet.SelectedIndex = -1;
            }
            else //礼服单件、总备注
            {
                DataTable dtDressConfig = ErpService.DressManagement.GetSmallGoods(@"礼服出租总体备注','礼服出租单件备注").Tables[0];
                cmbTemplet.DataSource = dtDressConfig;
                cmbTemplet.DisplayMember = @"ConfigValue";
                cmbTemplet.ValueMember = @"ID";
                cmbTemplet.SelectedIndex = -1;
            }
            //排单添加备注自动显示已有备注
            if (!string.IsNullOrEmpty(_orderNo) && string.IsNullOrEmpty(_batchNum))
            {
                DataTable dt = ErpService.DressManagement.GetOrderRent(orderNo).Tables[0];
                if (dt.Rows.Count > 0)
                {
                    txtContent.Text = dt.Rows[0]["Dress_ChooseRemak"].SafeDbValue<string>();
                }
                dt.Dispose();
            }
        }

        private void btnCancle_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(_orderNo) && string.IsNullOrEmpty(_batchNum))
            {
                if (ErpService.DressManagement.AddOrderRemark(_orderNo, txtContent.Text)) //订单排单备注
                {
                    MessageBox.Show(@"添加备注成功！");
                    this.Close();
                }
                else
                {
                    MessageBox.Show(@"添加备注失败！");
                }
            }
            else if (!string.IsNullOrEmpty(_batchNum))
            {
                if (ErpService.DressManagement.AddDressRemarks(_batchNum, txtContent.Text, _dressbarcode)) //礼服单件、总备注 （根据是否存在礼服条码判断）
                {
                    MessageBox.Show(@"添加备注成功！");
                    this.Close();
                }
                else
                {
                    MessageBox.Show(@"添加备注失败！");
                }
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            txtContent.Text += cmbTemplet.Text;
        }
    }
}
