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
using GoldenLady.Dress.View.Template;
using GoldenLady.Extension;
using GoldenLady.Global;
using GoldenLady.Standard;
using GoldenLady.Utility;
using GoldenLadyWS;

namespace GoldenLady.Dress.View
{
    public partial class FrmAllDressSearch : UserControl
    {
        private string _imagePath;
        readonly List<string> _areaList = new List<string>(); //场馆区域
        public FrmAllDressSearch()
        {
            InitializeComponent();
            InitializeData();
            DgvColumn();
        }

        private void InitializeData()
        {
            cmsMenues.Enabled = Information.CurrentUser.UserPower.Contains(Powers.礼服.礼服管理);

            DataTable dsTable = ErpService.DressManagement.GetDressStyle(RuleStandard.类别.ToString()).Tables[0];
            DataRow drRow = dsTable.NewRow();
            drRow["RuleName"] = "全部";
            drRow["RuleNumbers"] = "-1";
            dsTable.Rows.InsertAt(drRow, 0);
            cmbParentStyle.DisplayMember = @"RuleName";
            cmbParentStyle.ValueMember = @"RuleNumbers";
            cmbParentStyle.DataSource = dsTable;

            cmbVenues.DisplayMember = @"Name";
            cmbVenues.ValueMember = @"RuleNo";
            cmbVenues.DataSource = DressManager.GetRules().Where(p => !string.IsNullOrEmpty(p.Tag) && p.ParentRuleNo == RuleStandard.金夫人总店编号).ToList();
        }

        private void cmbParentStyle_SelectedValueChanged(object sender, EventArgs e)
        {
            if (cmbParentStyle.Text == String.Empty)
            {
                return;
            }
            DataTable dsTable = ErpService.DressManagement.GetDressStyle(cmbParentStyle.SelectedValue.ToString()).Tables[0];
            DataRow drRow = dsTable.NewRow();
            drRow["RuleName"] = "全部";
            drRow["RuleNumbers"] = "-1";
            dsTable.Rows.InsertAt(drRow, 0);
            cmbStyle.DataSource = dsTable;
            cmbStyle.DisplayMember = @"RuleName";
            cmbStyle.ValueMember = @"RuleNumbers";
            cmbStyle.SelectedIndex = -1;

            DataTable dsArea = ErpService.DressManagement.GetDressStyle(RuleStandard.嫁衣馆区域编号).Tables[0];
            DataRow drArea = dsArea.NewRow();
            drArea["RuleName"] = "全部";
            drArea["RuleNumbers"] = "-1";
            dsArea.Rows.InsertAt(drArea, 0);
            cmbArea.DataSource = dsArea;
            cmbArea.DisplayMember = @"RuleName";
            cmbArea.ValueMember = @"RuleNumbers";
            cmbArea.SelectedIndex = -1;
            for (int i = 1; i < dsArea.Rows.Count; i++)
            {
                _areaList.Add(dsArea.Rows[i]["RuleNumbers"].SafeDbValue<string>());
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            picDress.Image = null;
            string sqlString = string.Empty;
            string dateString = string.Empty;
            if (!string.IsNullOrEmpty(cmbVenues.Text))
            {
                if (cmbArea.Enabled == true)
                {
                    string areaId = string.IsNullOrEmpty(cmbArea.Text) ? string.Join("','", _areaList.ToArray()) : cmbArea.SelectedValue.ToString();
                    sqlString += string.Format(@" and  Area in('{0}')", areaId);
                }
                if (cmbVenues.SelectedValue.SafeDbInt32() == RuleStandard.嫁衣馆编号)
                {
                    sqlString += string.Format(@" and  Area in(select RuleNumbers from  Dress_Rule where ParentRuleNumbers in(select RuleNumbers from Dress_Rule where ParentRuleNumbers='{0}'and WhetherDelete = 0) and WhetherDelete = 0)", cmbVenues.SelectedValue.ToString());
                }
                else
                {
                    sqlString += string.Format(@" and  Area =('{0}') ", cmbVenues.SelectedValue);
                }
            }
            if (!string.IsNullOrEmpty(cmbStyle.Text) && !cmbStyle.Text.Trim().Equals(@"全部"))
            {
                sqlString += string.Format(@" and  RuleNumbers = '{0}'", cmbStyle.SelectedValue);
            }
            if (!string.IsNullOrEmpty(cmbParentStyle.Text) && !cmbParentStyle.Text.Trim().Equals(@"全部"))
            {
                sqlString += string.Format(@" and  DressName  = '{0}'", cmbParentStyle.SelectedValue);
            }
            if (cbYN.Checked)
            {
                dateString +=
                    string.Format(@" and DATEDIFF(dd,DressUseDate,'{0}')<=0  and  DATEDIFF(dd,DressUseDate,'{1}')>=0",
                        dtpBengin.Value, dtpEnd.Value);
            }
            if (txtKey.Text != string.Empty)
            {
                sqlString += string.Format(@" and (dn.DressBarCode = '{0}' or dn.DressCustomCode like '%{0}%') ", txtKey.Text);
            }
            if (string.IsNullOrEmpty(sqlString))
            {
                MessageBox.Show(@"无条件查询，容易造成软件卡死！");
                return;
            }
            if (chkDelete.Checked)
            {
                sqlString += @" and DressStatus = '淘汰' ";
            }
            else
            {
                sqlString += @" and (DressStatus != '淘汰' and  DressStatus !='出售' and  DressStatus !='丢失') ";
            }
            dgvDressesShow.AutoGenerateColumns = false;
            DataTable dtTable = ErpService.DressManagement.GetAllDressInfo(sqlString, dateString).Tables[0];
            dgvDressesShow.DataSource = dtTable;
            lblSum.Text = @"总数：" + dtTable.Rows.Count;
            dtTable.Dispose();
        }

        private void DgvColumn()
        {
            dgvDressesShow.Columns.AddRange(
                  new DataGridViewTextBoxColumn { Name = @"DressBarCode", DataPropertyName = @"DressBarCode", HeaderText = @"礼服条码", ReadOnly = true, Width = 120 },
                  new DataGridViewTextBoxColumn { Name = @"DressStatus", DataPropertyName = @"DressStatus", HeaderText = @"状态", ReadOnly = true, Width = 80 },
                  new DataGridViewTextBoxColumn { Name = @"DressNumbers", DataPropertyName = @"DressNumbers", HeaderText = @"编码", ReadOnly = true, Width = 100 },
                  new DataGridViewTextBoxColumn { Name = @"DressCustomCode", DataPropertyName = @"DressCustomCode", HeaderText = @"自编码", ReadOnly = true, Width = 80 },
                  new DataGridViewTextBoxColumn { Name = @"DressNumberOfUsedToday", DataPropertyName = @"DressNumberOfUsedToday", HeaderText = @"每日次数", ReadOnly = true, Width = 90 },
                  new DataGridViewTextBoxColumn { Name = @"EmployeeName", DataPropertyName = @"EmployeeName", HeaderText = @"操作人", ReadOnly = true, Width = 100 },
                  new DataGridViewTextBoxColumn { Name = @"OperateTime", DataPropertyName = @"OperateTime", HeaderText = @"操作时间", ReadOnly = true, Width = 100 },
                  new DataGridViewTextBoxColumn { Name = @"guanmin", DataPropertyName = @"guanmin", HeaderText = @"所属场馆", ReadOnly = true, Width = 100 },
                  new DataGridViewTextBoxColumn { Name = @"ThemeName", DataPropertyName = @"ThemeName", HeaderText = @"主题风格", ReadOnly = true, Width = 130 },
                  new DataGridViewTextBoxColumn { Name = @"RuleName", DataPropertyName = @"RuleName", HeaderText = @"类别", ReadOnly = true, Width = 80 },
                  new DataGridViewTextBoxColumn { Name = @"DressUse", DataPropertyName = @"DressUse", HeaderText = @"用途", ReadOnly = true, Width = 80 },
                  new DataGridViewTextBoxColumn { Name = @"DressRentPrice", DataPropertyName = @"DressRentPrice", HeaderText = @"出租价格", ReadOnly = true, Width = 120 },
                  new DataGridViewTextBoxColumn { Name = @"DressSalePrice", DataPropertyName = @"DressSalePrice", HeaderText = @"出售价格", ReadOnly = true, Width = 120 },
                  new DataGridViewTextBoxColumn { Name = @"UseCnt", DataPropertyName = @"UseCnt", HeaderText = @"总次数", ReadOnly = true, Width = 80 },
                  new DataGridViewTextBoxColumn { Name = @"Creator", DataPropertyName = @"Creator", HeaderText = @"创建人", ReadOnly = true, Width = 80 },
                  new DataGridViewTextBoxColumn { Name = @"CreationTime", DataPropertyName = @"CreationTime", HeaderText = @"创建时间", ReadOnly = true, Width = 130 }
                );
        }

        private void dgvDressesShow_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            picDress.Image = null;
            if (dgvDressesShow.CurrentRow != null)
            {
                string dressBarcode = dgvDressesShow.CurrentRow.Cells["DressBarCode"].Value.ToString();
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
                _imagePath = imgPath;
                picDress.Image =
                           FileTool.ReadImageFile(imgPath.Replace("JPG", "lf").Replace("jpg", "lf"))
                               .ZoomImage(picDress.Size, true, Color.LightGray);
                dsSet.Dispose();
            }
        }

        private void cbYN_CheckedChanged(object sender, EventArgs e)
        {
            dtpEnd.Enabled = dtpBengin.Enabled = cbYN.Checked;
        }

        private void 淘汰ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvDressesShow.CurrentRow != null && dgvDressesShow.CurrentRow.Cells["DressStatus"].Value.ToString() == @"淘汰")
                {
                    MessageBox.Show(@"该礼服已淘汰！");
                    return;
                }
                if (dgvDressesShow.CurrentRow != null)
                {
                    DressManager.EliminateDress(dgvDressesShow.CurrentRow.Cells["DressBarCode"].Value.ToString(), @"淘汰");
                    MessageBoxEx.Info(@"淘汰成功！");
                    dgvDressesShow.CurrentRow.Cells["DressStatus"].Value = @"淘汰";
                }
            }
            catch (Exception ex)
            {
                MessageBoxEx.Error(ex.Message);
            }
        }

        private void 入库ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvDressesShow.CurrentRow != null && dgvDressesShow.CurrentRow.Cells["DressStatus"].Value.ToString() == @"入库")
                {
                    MessageBox.Show(@"该礼服已入库！");
                    return;
                }
                if (dgvDressesShow.CurrentRow != null)
                {
                    DressManager.EliminateDress(dgvDressesShow.CurrentRow.Cells["DressBarCode"].Value.ToString(), @"入库");
                    MessageBoxEx.Info(@"入库成功！");
                    dgvDressesShow.CurrentRow.Cells["DressStatus"].Value = @"入库";
                }
            }
            catch (Exception ex)
            {
                MessageBoxEx.Error(ex.Message);
            }
        }

        private void 屏蔽ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvDressesShow.CurrentRow != null && dgvDressesShow.CurrentRow.Cells["DressStatus"].Value.ToString() == @"屏蔽")
                {
                    MessageBox.Show(@"该礼服已屏蔽！");
                    return;
                }
                if (dgvDressesShow.CurrentRow != null)
                {
                    DressManager.EliminateDress(dgvDressesShow.CurrentRow.Cells["DressBarCode"].Value.ToString(), @"屏蔽");
                    MessageBoxEx.Info(@"屏蔽成功！");
                    dgvDressesShow.CurrentRow.Cells["DressStatus"].Value = @"屏蔽";
                }
            }
            catch (Exception ex)
            {
                MessageBoxEx.Error(ex.Message);
            }
        }

        private void btnExcel_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = @"execl files (*.xls)|*.xls";
            saveFileDialog.FilterIndex = 0;
            saveFileDialog.RestoreDirectory = true;
            saveFileDialog.CreatePrompt = true;
            saveFileDialog.Title = @"保存为Excel文件";
            saveFileDialog.ShowDialog();

            if (saveFileDialog.FileName.IndexOf(":", StringComparison.Ordinal) < 0) return; //被点了"取消"

            Stream myStream;
            myStream = saveFileDialog.OpenFile();
            StreamWriter sw = new StreamWriter(myStream, System.Text.Encoding.GetEncoding(-0));
            string columnTitle = "";
            try
            {
                //写入列标题
                for (int i = 0; i < dgvDressesShow.ColumnCount; i++)
                {
                    if (i > 0)
                    {
                        columnTitle += "\t";
                    }
                    columnTitle += dgvDressesShow.Columns[i].HeaderText;
                }
                sw.WriteLine(columnTitle);

                //写入列内容
                for (int j = 0; j < dgvDressesShow.Rows.Count; j++)
                {
                    string columnValue = "";
                    for (int k = 0; k < dgvDressesShow.Columns.Count; k++)
                    {
                        if (k > 0)
                        {
                            columnValue += "\t";
                        }
                        object obj = dgvDressesShow.Rows[j].Cells[k].Value;
                        if (obj == null)
                            columnValue += "";
                        else
                            columnValue += obj.ToString().Trim().Replace("\t", " ").Replace("\r", " ").Replace("\n", " ");
                    }
                    sw.WriteLine(columnValue);
                }
                sw.Close();
                myStream.Close();
                MessageBox.Show(@"成功将数据导出到EXCEL文件中");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            finally
            {
                sw.Close();
                myStream.Close();
            }
        }

        private void picDress_Click(object sender, EventArgs e)
        {
            FrmExampleShow frmExampleShow = new FrmExampleShow(_imagePath,0);
            frmExampleShow.ShowDialog();
        }

        private void cmbVenues_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbVenues.Text == string.Empty)
            {
                return;
            }
            cmbArea.Enabled = cmbVenues.SelectedValue.SafeDbInt32() == RuleStandard.嫁衣馆编号;
        }

        private void dgvDressesShow_RowStateChanged(object sender, DataGridViewRowStateChangedEventArgs e)
        {
            e.Row.HeaderCell.Value = string.Format("{0}", e.Row.Index + 1);  
        }

        private void txtKey_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnSearch_Click(null, null);
            }
        }
    }
}
