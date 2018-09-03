using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using GoldenLady.Dress.Utils;
using GoldenLady.Global;
using GoldenLady.Standard.Dress;
using GoldenLadyWS;

namespace GoldenLady.Dress.View
{
    public partial class FrmVenueCleanInfo : UserControl
    {
        public FrmVenueCleanInfo()
        {
            InitializeComponent();

            cmbVenues.DataSource = DressManager.GetRules().Where(p => !string.IsNullOrEmpty(p.Tag) && p.ParentRuleNo == RuleStandard.金夫人总店编号).ToList();
            cmbVenues.DisplayMember = @"Name";
            cmbVenues.ValueMember = @"RuleNo";
            cmbVenues.SelectedIndex = -1;
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            dgvDressCleanInfo.AutoGenerateColumns = false;
            string dressSate = string.Empty;
            if (rbCleaning.Checked)
            {
                dressSate = rbCleaning.Text;
            }
            if (rbAccept.Checked)
            {
                dressSate = rbAccept.Text;
            }
            else if(rbFinish.Checked)
            {
                dressSate = rbFinish.Text;
            }
            string venueRuleNo = string.Empty;
            if (!string.IsNullOrEmpty(cmbVenues.Text))
            {
                venueRuleNo = cmbVenues.SelectedValue.ToString();
            }
            DataTable dt = ErpService.DressManagement.GetCleaningDress(venueRuleNo, dressSate, null).Tables[0];
            dgvDressCleanInfo.DataSource = dt;
            lblSum.Text = @"显示总数：" + dt.Rows.Count;
            dt.Dispose();
        }

        private void 礼服接收Tsm_Click(object sender, EventArgs e)
        {
            if (dgvDressCleanInfo.CurrentRow != null)
            {
                if (dgvDressCleanInfo.CurrentRow.Cells["DressStatus"].Value.ToString() == @"礼服接收")
                {
                    MessageBox.Show(@"已是礼服接收状态");
                    return;
                }
                Dictionary<string,string > dressBarCode =  new Dictionary<string, string>()
                {
                    {dgvDressCleanInfo.CurrentRow.Cells["DressBarCode"].Value.ToString(),dgvDressCleanInfo.CurrentRow.Cells["DressStatus"].Value.ToString()}
                };
                if (!ErpService.DressManagement.UpdateDressState(dressBarCode,@"礼服接收", @"洗衣房", Information.CurrentUser.EmployeeNO))
                {
                    MessageBox.Show(@"操作失败，重新操作！");
                    return;
                }
                dgvDressCleanInfo.CurrentRow.Cells["DressStatus"].Value = @"礼服接收";
            }
        }

        private void 清洗完成Tsm_Click(object sender, EventArgs e)
        {
            if (dgvDressCleanInfo.CurrentRow != null)
            {
                if (dgvDressCleanInfo.CurrentRow.Cells["DressStatus"].Value.ToString() == @"清洗完成")
                {
                    MessageBox.Show(@"已是清洗完成状态");
                    return;
                }
                Dictionary<string, string> dressBarCode = new Dictionary<string, string>()
                {
                    {dgvDressCleanInfo.CurrentRow.Cells["DressBarCode"].Value.ToString(),dgvDressCleanInfo.CurrentRow.Cells["DressStatus"].Value.ToString()}
                };
                if (!ErpService.DressManagement.UpdateDressState(dressBarCode, @"清洗完成", @"回库中", Information.CurrentUser.EmployeeNO))
                {
                    MessageBox.Show(@"操作失败，重新操作！");
                    return;
                }
                dgvDressCleanInfo.CurrentRow.Cells["DressStatus"].Value = @"清洗完成";
            }
        }

        private void cmbVenues_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnSearch_Click(null, null);
            }
        }
    }
}
