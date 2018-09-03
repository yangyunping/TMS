using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Windows.Forms;
using GoldenLady.Dress.Utils;
using GoldenLady.Extension;
using GoldenLady.Global;
using GoldenLady.Utility;
using GoldenLadyWS;

namespace GoldenLady.Dress.View
{
    public partial class FrmDailyCount : UserControl
    {
        public FrmDailyCount()
        {
            InitializeComponent();
            InitiaDate();
            DgvColumnHead();
        }

        private void InitiaDate()
        {
            cmbVenues.DataSource = DressManager.GetRules().Where(p => !string.IsNullOrEmpty(p.Tag) && p.ParentRuleNo == RuleStandard.金夫人总店编号).ToList();
            cmbVenues.DisplayMember = @"Name";
            cmbVenues.ValueMember = @"RuleNo";
            cmbVenues.SelectedIndex = -1;
        }

        private void btnDressSearch_Click(object sender, EventArgs e)
        {
            try
            {
                string dateString = String.Empty;
                string venueNo = string.Empty;
                if (!string.IsNullOrEmpty(txtDateCnt.Text))
                {
                    dateString += string.Format(@"  and DATEDIFF(dd,OperateTime,GETDATE()) >= {0}", Convert.ToInt32(txtDateCnt.Text));
                }
                if (!string.IsNullOrEmpty(cmbVenues.Text))
                {
                    venueNo = cmbVenues.SelectedValue.ToString();
                }
                DataTable dtTable = ErpService.DressManagement.GetCleaningDress(venueNo, @"礼服送洗','礼服接收','清洗完成','外景出库','出租送洗','出租','屏蔽", dateString).Tables[0];
                dgvDresses.AutoGenerateColumns = false;
                dgvDresses.DataSource = dtTable;
                lblSum.Text = @"未归还总数：" + dtTable.Rows.Count;
                dtTable.Dispose();
            }
            catch (Exception ex)
            {
                MessageBox.Show(@"异常操作，可能存在输入天数问题！" + ex);
                throw;
                return;
            }
        }

        private void DgvColumnHead()
        {
            dgvDresses.Columns.AddRange
                (
                new DataGridViewTextBoxColumn { Name = @"DressBarCode", DataPropertyName = @"DressBarCode", HeaderText = @"礼服条码", Width = 130 },
                new DataGridViewTextBoxColumn { Name = @"DressStatus", DataPropertyName = @"DressStatus", HeaderText = @"状态", Width = 100 },
                new DataGridViewTextBoxColumn { Name = @"guanmin", DataPropertyName = @"guanmin", HeaderText = @"所属场馆", Width = 120 },
                new DataGridViewTextBoxColumn { Name = @"OperateTime", DataPropertyName = @"OperateTime", HeaderText = @"操作时间", Width = 140 },
                new DataGridViewTextBoxColumn { Name = @"EmployeeName", DataPropertyName = @"EmployeeName", HeaderText = @"操作人员", Width = 120 }
                );
        }

        private void dgvDresses_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            picDress.Image = null;
            if (dgvDresses.CurrentRow != null)
            {
                string dressBarcode = dgvDresses.CurrentRow.Cells["DressBarCode"].Value.ToString();
                DataSet dsSet = ErpService.DressManagement.GetDressSearchInformation(dressBarcode);
                string imgPath = dsSet.Tables[0].Rows[0]["DressImagePath"].SafeDbValue<string>();
                if (string.IsNullOrEmpty(imgPath))
                {
                    MessageBox.Show(@"该礼服没有照片路径！");
                    return;
                }
                string[] pathInfo = imgPath.Split(Convert.ToChar(@"\"));
                Ping strPing = new Ping();
                PingReply pingReply = strPing.Send(pathInfo[2]);
                if (pingReply != null && pingReply.Status != IPStatus.Success)
                {
                    MessageBox.Show(@"无法访问照片路径！");
                    return;
                }
                picDress.Image =
                           FileTool.ReadImageFile(imgPath.Replace("JPG", "lf").Replace("jpg", "lf"))
                               .ZoomImage(picDress.Size, true, Color.LightGray);
            }
        }

        private void 入库Tsm_Click(object sender, EventArgs e)
        {
            if (dgvDresses.CurrentRow != null)
            {
                string dressBarCode = dgvDresses.CurrentRow.Cells["DressBarCode"].Value.ToString();
                string state = dgvDresses.CurrentRow.Cells["DressStatus"].Value.ToString();
                Dictionary<string, string> dressInfo = new Dictionary<string, string>()
                {
                    {dressBarCode,state}
                };
                if (state == @"入库")
                {
                    MessageBox.Show(@"该礼服已入库");
                    return;
                }
                if (ErpService.DressManagement.UpdateDressState(dressInfo, @"入库",
                    Information.CurrentUser.EmployeeDepartmentName, Information.CurrentUser.EmployeeNO2))
                {
                    foreach (DataGridViewRow row in dgvDresses.Rows.Cast<DataGridViewRow>().Where(row => row.Cells["DressBarCode"].Value.ToString() == dressBarCode))
                    {
                        row.Cells["DressStatus"].Value = @"入库";
                    }
                }
                else
                {
                    MessageBox.Show(@"入库失败，请重试！");
                }
            }
        }

        private void txtDateCnt_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnDressSearch_Click(null, null);
            }
        }
    }
}
