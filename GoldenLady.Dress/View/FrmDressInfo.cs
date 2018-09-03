using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.IO;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Windows.Forms;
using GoldenLady.Dress.Utils;
using GoldenLady.Dress.View.Template;
using GoldenLady.Extension;
using GoldenLady.Utility;
using GoldenLadyWS;

namespace GoldenLady.Dress.View
{
    public partial class FrmDressInfo : UserControl
    {
        private string _imgPath = string.Empty;
        private string _operateStyle;
        public FrmDressInfo(string operateStyle)
        {
            _operateStyle = operateStyle;
            InitializeComponent();
            DgvColumn();

            cmbVenues.DisplayMember = @"Name";
            cmbVenues.ValueMember = @"RuleNo";
            cmbVenues.DataSource = DressManager.GetRules().Where(p => !string.IsNullOrEmpty(p.Tag) && p.ParentRuleNo == RuleStandard.金夫人总店编号).ToList();
            cmbVenues.SelectedIndex = -1;
        }
        private void DgvColumn()
        {
            dgvMemary.Columns.Clear();
            if (_operateStyle == @"礼服记录查询")
            {
                dgvMemary.Columns.AddRange(
                new DataGridViewTextBoxColumn { Name = @"DressBarCode", HeaderText = @"礼服条码", DataPropertyName = @"DressBarCode", Width = 120, ReadOnly = true },
                new DataGridViewTextBoxColumn { Name = @"DressState", HeaderText = @"礼服状态", DataPropertyName = @"DressState", Width = 100, ReadOnly = true },
                new DataGridViewTextBoxColumn { Name = @"DressEmpNO", HeaderText = @"员工工号", DataPropertyName = @"DressEmpNO", Width = 100, ReadOnly = true },
                new DataGridViewTextBoxColumn { Name = @"DressEmpName", HeaderText = @"员工姓名", DataPropertyName = @"DressEmpName", Width = 100, ReadOnly = true },
                new DataGridViewTextBoxColumn { Name = @"LogNotes", HeaderText = @"操作备注", DataPropertyName = @"LogNotes", Width = 120, ReadOnly = true },
                //new DataGridViewTextBoxColumn { Name = @"CustomerName2", HeaderText = @"小姐", DataPropertyName = @"CustomerName2", Width = 100, ReadOnly = true },
                //new DataGridViewTextBoxColumn { Name = @"DressUseDate", HeaderText = @"拍照时间", DataPropertyName = @"DressUseDate", Width = 150, ReadOnly = true },
                new DataGridViewTextBoxColumn { Name = @"OperateTime", HeaderText = @"操作时间", DataPropertyName = @"OperateTime", Width = 150, ReadOnly = true }
               );
            }
            else if (_operateStyle == @"新增礼服查询")
            {
                dgvMemary.Columns.AddRange(
                 new DataGridViewTextBoxColumn { Name = @"DressBarCode", DataPropertyName = @"DressBarCode", HeaderText = @"礼服条码", ReadOnly = true, Width = 120 },
                 new DataGridViewTextBoxColumn { Name = @"DressStatus", DataPropertyName = @"DressStatus", HeaderText = @"状态", ReadOnly = true, Width = 80 },
                 new DataGridViewTextBoxColumn { Name = @"DressNumbers", DataPropertyName = @"DressNumbers", HeaderText = @"编码", ReadOnly = true, Width = 100 },
                 new DataGridViewTextBoxColumn { Name = @"DressCustomCode", DataPropertyName = @"DressCustomCode", HeaderText = @"自编码", ReadOnly = true, Width = 80 },
                 new DataGridViewTextBoxColumn { Name = @"RuleName", DataPropertyName = @"RuleName", HeaderText = @"类别", ReadOnly = true, Width = 80 },
                 new DataGridViewTextBoxColumn { Name = @"DressUse", DataPropertyName = @"DressUse", HeaderText = @"用途", ReadOnly = true, Width = 80 },
                 new DataGridViewTextBoxColumn { Name = @"DressRentPrice", DataPropertyName = @"DressRentPrice", HeaderText = @"出租价格", ReadOnly = true, Width = 120 },
                 new DataGridViewTextBoxColumn { Name = @"DressSalePrice", DataPropertyName = @"DressSalePrice", HeaderText = @"出售价格", ReadOnly = true, Width = 120 },
                 new DataGridViewTextBoxColumn { Name = @"Creator", DataPropertyName = @"Creator", HeaderText = @"创建人", ReadOnly = true, Width = 80 },
                 new DataGridViewTextBoxColumn { Name = @"CreationTime", DataPropertyName = @"CreationTime", HeaderText = @"创建时间", ReadOnly = true, Width = 130 }
               );
                chkInOut.Visible = false;
            }
        }
        private void btnSearch_Click(object sender, EventArgs e)
        {
            string sSql = string.Empty;
            string area = string.Empty;
            if (_operateStyle == @"礼服记录查询")
            {
                if (!string.IsNullOrEmpty(cmbVenues.Text) && cmbVenues.SelectedValue.SafeDbInt32() != RuleStandard.嫁衣馆编号)
                {
                    area += string.Format(@" and  Area = '{0}'", cmbVenues.SelectedValue);
                }
                if (!string.IsNullOrEmpty(cmbVenues.Text) && cmbVenues.SelectedValue.SafeDbInt32() == RuleStandard.嫁衣馆编号) //嫁衣馆
                {
                    area += string.Format(@" and  Area in(select RuleNumbers from  Dress_Rule where ParentRuleNumbers in(select RuleNumbers from Dress_Rule where ParentRuleNumbers='{0}'and WhetherDelete = 0) and WhetherDelete = 0)", cmbVenues.SelectedValue.ToString());
                }
                if (chkDate.Checked)
                {
                    sSql +=
                        string.Format(@" and DATEDIFF(dd,OperateTime,'{0}')<=0 and DATEDIFF(dd,OperateTime,'{1}')>=0",
                            dtpBegin.Value, dtpEnd.Value);
                }
                if (!string.IsNullOrEmpty(txtDressbarcode.Text))
                {
                    sSql += string.Format(@" and  DressBarCode = '{0}' ", txtDressbarcode.Text);
                }
                if (string.IsNullOrEmpty(sSql))
                {
                    MessageBox.Show(@"请添加查询条件！");
                    return;
                }
                if (chkInOut.Checked)
                {
                    sSql += @"  and  DressStatus in('送进','取出')";
                }
                dgvMemary.AutoGenerateColumns = false;
                DataTable dtTable = ErpService.DressManagement.GetDressInOutLog(sSql, area).Tables[0];
                dgvMemary.DataSource = dtTable;
                dtTable.Dispose();
            } 
            else if (_operateStyle == @"新增礼服查询")
            {
                if (!string.IsNullOrEmpty(cmbVenues.Text) && cmbVenues.SelectedValue.SafeDbInt32() != RuleStandard.嫁衣馆编号)
                {
                    sSql += string.Format(@" and  Area = '{0}'", cmbVenues.SelectedValue);
                }
                if (!string.IsNullOrEmpty(cmbVenues.Text) && cmbVenues.SelectedValue.SafeDbInt32() == RuleStandard.嫁衣馆编号) //嫁衣馆
                {
                    sSql += string.Format(@" and  Area in(select RuleNumbers from  Dress_Rule where ParentRuleNumbers in(select RuleNumbers from Dress_Rule where ParentRuleNumbers='{0}'and WhetherDelete = 0) and WhetherDelete = 0)", cmbVenues.SelectedValue.ToString());
                }
                if (chkDate.Checked)
                {
                    sSql +=
                        string.Format(@" and DATEDIFF(dd,CreationTime,'{0}')<=0  and  DATEDIFF(dd,CreationTime,'{1}')>=0",
                            dtpBegin.Value, dtpEnd.Value);
                }
                if (txtDressbarcode.Text != string.Empty)
                {
                    sSql += string.Format(@" and (dn.DressBarCode = '{0}' or dn.DressCustomCode like '%{0}%') ", txtDressbarcode.Text);
                }

                if (string.IsNullOrEmpty(sSql))
                {
                    MessageBox.Show(@"无条件查询，容易造成软件卡死！");
                    return;
                }
                DataTable dtTable = ErpService.DressManagement.GetAllDressInfo(sSql,null).Tables[0];
                dgvMemary.AutoGenerateColumns = false;
                dgvMemary.DataSource = dtTable;
                dtTable.Dispose();
            }
        }

        private void chkDate_CheckedChanged(object sender, EventArgs e)
        {
            dtpBegin.Enabled = dtpEnd.Enabled = chkDate.Checked;
        }

        private void dgvMemary_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            picImage.Image = null;
            if (dgvMemary.CurrentRow != null)
            {
                string dressBarcode = dgvMemary.CurrentRow.Cells["DressBarCode"].Value.ToString();
                DataSet dsSet = ErpService.DressManagement.GetDressSearchInformation(dressBarcode);
                if (dsSet.Tables[0].Rows.Count == 0)
                {
                    return;
                }
                _imgPath = dsSet.Tables[0].Rows[0]["DressImagePath"].SafeDbValue<string>();
                dsSet.Dispose();
                if (string.IsNullOrEmpty(_imgPath))
                {
                    MessageBox.Show(@"该礼服没有照片路径！");
                    return;
                }
                string[] pathInfo = _imgPath.Split(Convert.ToChar(@"\"));
                Ping strPing = new Ping();
                PingReply pingReply = strPing.Send(pathInfo[2]);
                if (pingReply != null && pingReply.Status != IPStatus.Success)
                {
                    MessageBox.Show(@"无法访问照片路径！");
                    return;
                }
                picImage.Image =
                    FileTool.ReadImageFile(_imgPath.Replace("JPG", "lf").Replace("jpg", "lf"))
                        .ZoomImage(picImage.Size, true, Color.LightGray);
            }
        }

        private void picImage_Click(object sender, EventArgs e)
        {
            FrmExampleShow frmExampleShow = new FrmExampleShow(_imgPath, 0);
            frmExampleShow.ShowDialog();
        }

        private void txtDressbarcode_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnSearch_Click(null, null);
            }
        }
    }
}
