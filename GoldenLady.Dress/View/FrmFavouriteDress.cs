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
using GoldenLady.Utility;
using GoldenLadyWS;

namespace GoldenLady.Dress.View
{
    public partial class FrmFavouriteDress : UserControl
    {
        private string _imagePath;//礼服照片路径
        readonly List<string> _areaList = new List<string>(); //场馆区域
        public FrmFavouriteDress()
        {
            InitializeComponent();
            IniteData();
        }

        private void IniteData()
        {
            cmbVenues.DisplayMember = @"Name";
            cmbVenues.ValueMember = @"RuleNo";
            cmbVenues.DataSource = DressManager.GetRules().Where(p => !string.IsNullOrEmpty(p.Tag) && p.ParentRuleNo == RuleStandard.金夫人总店编号).ToList();
            cmbVenues.SelectedIndex = -1;

            DataTable dsStyle = ErpService.DressManagement.GetDressStyle(RuleStandard.类别.ToString()).Tables[0];
            cmbParentStyle.DisplayMember = @"RuleName";
            cmbParentStyle.ValueMember = @"RuleNumbers";
            cmbParentStyle.DataSource = dsStyle;

            DataTable dsArea = ErpService.DressManagement.GetDressStyle(RuleStandard.嫁衣馆区域编号).Tables[0];
            cmbArea.DataSource = dsArea;
            cmbArea.DisplayMember = @"RuleName";
            cmbArea.ValueMember = @"RuleNumbers";
            cmbArea.SelectedIndex = -1;
            for (int i = 0; i < dsArea.Rows.Count; i++)
            {
                _areaList.Add(dsArea.Rows[i]["RuleNumbers"].SafeDbValue<string>());
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            string dateString = string.Empty;
            string keys = string.Empty;
            dgvDresses.DataSource = null;
            dgvDresses.Columns.Clear();
            if (string.IsNullOrEmpty(cmbVenues.Text))
            {
                MessageBox.Show(@"请选择场馆！");
                return;
            }

            if (!string.IsNullOrEmpty(cmbStyle.Text))
            {
                keys += string.Format(@" and dr.RuleNumbers = '{0}'", cmbStyle.SelectedValue);
            }
            if (cmbParentStyle.SelectedValue.SafeDbInt32() == 197) // 礼服类
            {
                keys += string.Format(@" and dr2.RuleNumbers = '{0}' ", cmbParentStyle.SelectedValue);

                if (cmbVenues.SelectedValue.SafeDbInt32() == 106) //嫁衣馆
                {
                    if (cmbArea.Enabled == true)
                    {
                        string areaId = string.IsNullOrEmpty(cmbArea.Text) ? string.Join("','", _areaList.ToArray()) : cmbArea.SelectedValue.ToString();
                        keys += string.Format(@" and dn.Area in('{0}')", areaId);
                    }
                    keys +=
                          @"  and dn.Area in(select RuleNumbers from  Dress_Rule where ParentRuleNumbers in(select RuleNumbers from Dress_Rule where ParentRuleNumbers='" +
                          cmbVenues.SelectedValue + "'and WhetherDelete = 0) and WhetherDelete = 0)";
                    if (cbMarryDate.Checked)
                    {
                        dateString +=
                            string.Format(
                                @" and DATEDIFF(DD,marryDtaTime,'{0}')<=0 and DATEDIFF(DD,marryDtaTime,'{1}')>=0 ",
                                dtpBegin.Value, dtpEnd.Value);
                    }
                    DgvColumnRent();
                    var dsSet = ErpService.DressManagement.FavouriteDresses(keys, dateString);
                    dgvDresses.AutoGenerateColumns = false;
                    dgvDresses.DataSource = dsSet.Tables[0];
                    lblSum.Text = @"显示总数：" + dsSet.Tables[0].Rows.Count;
                    dsSet.Dispose();
                }
                else
                {
                    keys += string.Format(@"  and dn.Area = '{0}'", cmbVenues.SelectedValue);
                    if (cbMarryDate.Checked)
                    {
                        dateString +=
                            string.Format(
                                @" and DATEDIFF(DD,DressUseDate,'{0}')<=0 and DATEDIFF(DD,DressUseDate,'{1}')>=0 ",
                                dtpBegin.Value, dtpEnd.Value);
                    }
                    DgvColumnShoot();
                    DataSet dsDataSet = ErpService.DressManagement.FavouriteShootDresses(keys, dateString);
                    dgvDresses.AutoGenerateColumns = false;
                    dgvDresses.DataSource = dsDataSet.Tables[0];
                    lblSum.Text = @"显示总数：" + dsDataSet.Tables[0].Rows.Count;
                    dsDataSet.Dispose();
                }
            }
            else if (cmbParentStyle.SelectedValue.SafeDbInt32() == 266)//场景类
            {
                DgvColumnScene();
                keys += string.Format(@"  and VenueName = '{0}'", cmbVenues.Text);
                if (cbMarryDate.Checked)
                {
                    dateString +=
                        string.Format(
                            @" and DATEDIFF(DD,ShootDate,'{0}')<=0 and DATEDIFF(DD,ShootDate,'{1}')>=0 ",
                            dtpBegin.Value, dtpEnd.Value);
                }
                DataSet dsDataSet = ErpService.DressManagement.FavouriteScene(keys, dateString);
                dgvDresses.AutoGenerateColumns = false;
                dgvDresses.DataSource = dsDataSet.Tables[0];
                lblSum.Text = @"显示总数：" + dsDataSet.Tables[0].Rows.Count;
                dsDataSet.Dispose();
            }
            else
            {
                MessageBox.Show(@"请选择礼服类或场景类");
            }
        }
        private void DgvColumnRent()
        {
            dgvDresses.Columns.AddRange(
              new DataGridViewTextBoxColumn { Name = "DressBarCode", DataPropertyName = "DressBarCode", HeaderText = @"礼服条码", Width = 120 },
              new DataGridViewTextBoxColumn { Name = "DressCnt", DataPropertyName = "DressCnt", HeaderText = @"使用次数", Width = 100 },
              new DataGridViewTextBoxColumn { Name = "DressNumbers", DataPropertyName = "DressNumbers", HeaderText = @"款式编号", Width = 260 },
              new DataGridViewTextBoxColumn { Name = "RuleName", DataPropertyName = "RuleName", HeaderText = @"类别", Width = 80 },
              new DataGridViewTextBoxColumn { Name = "DressCustomCode", DataPropertyName = "DressCustomCode", HeaderText = @"自编号", Width = 200 },
              new DataGridViewTextBoxColumn { Name = "DressRentPrice", DataPropertyName = "DressRentPrice", HeaderText = @"出租价格", Width = 120 },
              new DataGridViewTextBoxColumn { Name = "DressSalePrice", DataPropertyName = "DressSalePrice", HeaderText = @"出售价格", Width = 120 },
              new DataGridViewTextBoxColumn { Name = "CreationTime", DataPropertyName = "CreationTime", HeaderText = @"创建时间", Width = 160 }
            );
        }
        private void DgvColumnShoot()
        {
            dgvDresses.Columns.AddRange(
              new DataGridViewTextBoxColumn { Name = "DressBarCode", DataPropertyName = "DressBarCode", HeaderText = @"礼服条码", Width = 120 },
              new DataGridViewTextBoxColumn { Name = "DressCnt", DataPropertyName = "DressCnt", HeaderText = @"使用次数", Width = 100 },
              new DataGridViewTextBoxColumn { Name = "DressNumbers", DataPropertyName = "DressNumbers", HeaderText = @"款式编号", Width = 260 },
              new DataGridViewTextBoxColumn { Name = "RuleName", DataPropertyName = "RuleName", HeaderText = @"类别", Width = 80 },
              new DataGridViewTextBoxColumn { Name = "CreationTime", DataPropertyName = "CreationTime", HeaderText = @"创建时间", Width = 160 }
            );
        }
        private void DgvColumnScene()
        {
            dgvDresses.Columns.AddRange
                (

                  new DataGridViewTextBoxColumn { Name = "SceneName", DataPropertyName = "SceneName", HeaderText = @"场景名", ReadOnly = true, Width = 140 },
                  new DataGridViewTextBoxColumn { Name = "SceneCnt", DataPropertyName = "SceneCnt", HeaderText = @"使用次数", Width = 100 },
                  new DataGridViewTextBoxColumn { Name = "VenueName", DataPropertyName = "VenueName", HeaderText = @"场馆", Width = 120 }
                );
        }
        private void cmbParentStyle_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbParentStyle.Text == String.Empty)
            {
                return;
            }
            DataTable dsTable =
                ErpService.DressManagement.GetDressStyle(cmbParentStyle.SelectedValue.ToString()).Tables[0];
            cmbStyle.DataSource = dsTable;
            cmbStyle.DisplayMember = @"RuleName";
            cmbStyle.ValueMember = @"RuleNumbers";
            cmbStyle.SelectedIndex = -1;
        }

        private void dgvDresses_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            picImage.Image = null;
            if (dgvDresses.CurrentRow != null && cmbParentStyle.SelectedValue.SafeDbInt32() != 266)
            {
                string dressBarcode = dgvDresses.CurrentRow.Cells["DressBarCode"].Value.ToString();
                DataSet dsSet = ErpService.DressManagement.GetDressSearchInformation(dressBarcode);
                _imagePath = dsSet.Tables[0].Rows[0]["DressImagePath"].SafeDbValue<string>();
                dsSet.Dispose();
                if (string.IsNullOrEmpty(_imagePath))
                {
                    MessageBox.Show(@"该礼服没有照片");
                    return;
                }
                string[] pathInfo = _imagePath.Split(Convert.ToChar(@"\"));
                Ping strPing = new Ping();
                PingReply pingReply = strPing.Send(pathInfo[2]);
                if (pingReply != null && pingReply.Status != IPStatus.Success)
                {
                    MessageBox.Show(@"无法访问照片路径！");
                    return;
                }
                picImage.Image = FileTool.ReadImageFile(_imagePath).ZoomImage(picImage.Size, true, Color.LightGray);
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
                for (int i = 0; i < dgvDresses.ColumnCount; i++)
                {
                    if (i > 0)
                    {
                        columnTitle += "\t";
                    }
                    columnTitle += dgvDresses.Columns[i].HeaderText;
                }
                sw.WriteLine(columnTitle);

                //写入列内容
                for (int j = 0; j < dgvDresses.Rows.Count; j++)
                {
                    string columnValue = "";
                    for (int k = 0; k < dgvDresses.Columns.Count; k++)
                    {
                        if (k > 0)
                        {
                            columnValue += "\t";
                        }
                        object obj = dgvDresses.Rows[j].Cells[k].Value;
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

        private void cmbVenues_SelectedValueChanged(object sender, EventArgs e)
        {
            if (cmbVenues.Text == string.Empty)
            {
                return;
            }
            if (cmbVenues.SelectedValue.SafeDbInt32() == 106)
            {
                cbMarryDate.Text = @"选择婚期";
                cmbArea.Enabled = true;
            }
            else
            {
                cbMarryDate.Text = @"选衣日期";
                cmbArea.Enabled = false;
            }
        }

        private void picImage_Click(object sender, EventArgs e)
        {
            FrmExampleShow frmExampleShow = new FrmExampleShow(_imagePath, 0);
            frmExampleShow.ShowDialog();
        }

        private void dgvDresses_RowStateChanged(object sender, DataGridViewRowStateChangedEventArgs e)
        {
            e.Row.HeaderCell.Value = string.Format("{0}", e.Row.Index + 1);  
        }
    }
}
