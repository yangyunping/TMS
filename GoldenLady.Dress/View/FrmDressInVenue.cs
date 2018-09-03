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
using GoldenLady.Extension;
using GoldenLady.Global;
using GoldenLady.Utility;
using GoldenLadyWS;

namespace GoldenLady.Dress.View
{
    public partial class FrmDressInVenue : UserControl
    {
        private readonly string _state;
        private readonly string _position;

        public FrmDressInVenue(string state, string position)
        {
            InitializeComponent();
            _state = state;
            _position = position;
            lblOperate.Text = state;
            //DgvColumnTitle();
        }

        private void txtDresBarCode_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (txtDresBarCode.Text == String.Empty)
                {
                    return;
                }
                DataSet ds = ErpService.DressManagement.DressesManage(txtDresBarCode.Text);

                if (ds.Tables[0].Rows.Count == 0)
                {
                    MessageBox.Show(@"该礼服不存在或已被淘汰或输错了礼服条码，请重新输入！");
                    return;
                }

                if (
                    dgvDressInfo.Rows.Cast<DataGridViewRow>()
                        .Any(rowView => rowView.Cells["DressBarCode"].Value.ToString() == txtDresBarCode.Text))
                {
                    MessageBox.Show(@"该礼服已录入！");
                    return;
                }

                if (ds.Tables[0].Rows[0]["DressStatus"].SafeDbValue<string>() == _state)
                {
                    MessageBox.Show(@"该礼服已是  " + _state + @"  状态！");
                    return;
                }
                Dictionary<string, string> dressBarCodes = new Dictionary<string, string>
                {
                    {txtDresBarCode.Text, ds.Tables[0].Rows[0]["DressStatus"].SafeDbValue<string>()}
                };
                if (ErpService.DressManagement.UpdateDressState(dressBarCodes, _state, _position, Information.CurrentUser.EmployeeNO))
                {
                    dgvDressInfo.AutoGenerateColumns = false;
                    dgvDressInfo.DataSource = null;
                    DataRow newDataRow = ds.Tables[0].Rows[0];
                    dgvDressInfo.Rows.Add(newDataRow.ItemArray);
                    txtDresBarCode.Clear();
                    lblSum.Text = @"显示总数：" + dgvDressInfo.Rows.Count;
                    dressBarCodes.Clear();
                }
                else
                {
                    MessageBox.Show(@"操作失败，重新操作！");
                    return;
                }

                string imgPath = ds.Tables[0].Rows[0]["DressImagePath"].ToString();
                ds.Dispose();
                if (_state == @"礼服接收" || _state == @"清洗完成")
                {
                    picImage.Visible = false;
                    return;
                }
                if (imgPath != String.Empty)
                {
                    string[] pingStrings = imgPath.Split(Convert.ToChar(@"\"));
                    Ping ping = new Ping();
                    PingReply pingReply = ping.Send(pingStrings[2]);
                    if (pingReply != null && pingReply.Status != IPStatus.Success)
                    {
                        MessageBox.Show(@"照片路径无法访问！");
                        picImage.Image = null;
                        return;
                    }
                    picImage.Image =
                            FileTool.ReadImageFile(imgPath.Replace("jpg", "lf").Replace("JPG", "lf")).ZoomImage(picImage.Size, true, Color.LightGray);
                }
                else
                {
                    picImage.Image = null;
                }
            }
        }

        private void DgvColumnTitle()
        {
            dgvDressInfo.Columns.AddRange(
                    new DataGridViewTextBoxColumn { Name = "DressBarCode", DataPropertyName = "DressBarCode", HeaderText = @"条码", ReadOnly = true, Width = 120 },
                    new DataGridViewTextBoxColumn { Name = "DressNumbers", DataPropertyName = "DressNumbers", HeaderText = @"编号", ReadOnly = true, Width = 120 },
                    new DataGridViewTextBoxColumn { Name = "guanmin", DataPropertyName = "guanmin", HeaderText = @"所在场馆", ReadOnly = true, Width = 100 },
                    new DataGridViewTextBoxColumn { Name = "RuleName", DataPropertyName = "RuleName", HeaderText = @"类别", ReadOnly = true, Width = 80 },
                    new DataGridViewTextBoxColumn { Name = "DressUse", DataPropertyName = "DressUse", HeaderText = @"用途", ReadOnly = true, Width = 80 },
                    new DataGridViewTextBoxColumn { Name = "DressStatus", DataPropertyName = "DressStatus", HeaderText = @"改前状态", ReadOnly = true, Width = 80 }
                );
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (dgvDressInfo.CurrentRow != null)
            {
                ErpService.DressManagement.EliminateDress(
                    dgvDressInfo.CurrentRow.Cells["DressBarCode"].Value.ToString(),
                    dgvDressInfo.CurrentRow.Cells["DressStatus"].Value.ToString(), @"礼服状态由【" + _state + "】还原到【" + dgvDressInfo.CurrentRow.Cells["DressStatus"].Value.ToString());
                dgvDressInfo.Rows.Remove(dgvDressInfo.SelectedRows[0]);
                picImage.Image = null;
            }
        }

        private void FrmDressToVenue_Load(object sender, EventArgs e)
        {
            txtDresBarCode.Focus();
        }
    }
}
