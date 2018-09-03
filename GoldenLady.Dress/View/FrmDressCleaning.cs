using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Windows.Forms;
using GoldenLady.Dress.View.Template;
using GoldenLady.Extension;
using GoldenLady.Global;
using GoldenLady.Standard;
using GoldenLady.Utility;
using GoldenLadyWS;

namespace GoldenLady.Dress.View
{
    public partial class FrmDressCleaning : UserControl
    {
        private readonly string _state;
        private readonly string _position;
        private string _imgPath = string.Empty;
        public FrmDressCleaning(string state, string position)
        {
            InitializeComponent();
            _state = state;
            _position = position;
            lblOperate.Text = state;

            DataSet ds = ErpService.DressManagement.GetSmallGoods("小件类别");
            cmbSmallGoods.DataSource = ds.Tables[0];
            cmbSmallGoods.DisplayMember = @"ConfigValue";
            cmbSmallGoods.ValueMember = @"ID";
            cmbSmallGoods.SelectedIndex = -1;
            ds.Dispose();
            txtDresBarCode.Focus();
        }

        private void txtDresBarCode_KeyDown(object sender, KeyEventArgs e)
        {
            picImage.Image = null;
            if (e.KeyCode == Keys.Enter)
            {
                if (txtDresBarCode.Text == String.Empty)
                {
                    return;
                }
                DataSet dsDataSet = ErpService.DressManagement.DressesManage(txtDresBarCode.Text);
                DataTable dataTable = dsDataSet.Tables[0];

                if (dataTable.Rows.Count == 0)
                {
                    MessageBox.Show(@"不存在该礼服或输错了礼服条码，请重新输入！");
                    return;
                }

                if (
                    dgvDressInfo.Rows.Cast<DataGridViewRow>()
                        .Any(rowView => rowView.Cells["DressBarCode"].Value.ToString() == txtDresBarCode.Text))
                {
                    MessageBox.Show(@"该礼服已录入！");
                    return;
                }

                if ((string)dataTable.Rows[0]["DressStatus"] == _state)
                {
                    MessageBox.Show(@"该礼服已是  " + _state + @"  状态！");
                    return;
                }
                Dictionary<string, string> dressBarCodes = new Dictionary<string, string>
                {
                    {txtDresBarCode.Text, dataTable.Rows[0]["DressStatus"].SafeDbValue<string>()}
                };
                if (ErpService.DressManagement.UpdateDressState(dressBarCodes, _state, _position, Information.CurrentUser.EmployeeNO))
                {
                    dgvDressInfo.AutoGenerateColumns = false;
                    dgvDressInfo.DataSource = null;
                    DataRow newDataRow = dataTable.Rows[0];
                    dgvDressInfo.Rows.Add(newDataRow.ItemArray);
                    txtDresBarCode.Clear();
                    lblSum.Text = @"显示总数：" + dgvDressInfo.Rows.Count;
                    dressBarCodes.Clear();
                }
                string imgPath = dataTable.Rows[0]["DressImagePath"].ToString();
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
                picImage.Image = FileTool.ReadImageFile(imgPath.Replace("jpg", "lf").Replace("JPG", "lf")).ZoomImage(picImage.Size, true, Color.LightGray);
                dsDataSet.Dispose();
            }
        }

        private void tsmDelete_Click(object sender, EventArgs e)
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

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (dgvCount.SelectedRows.Count == 0) { return; }
            dgvCount.Rows.Remove(dgvCount.SelectedRows[0]);
        }
        private void btnSum_Click(object sender, EventArgs e)
        {
            while (dgvCount.Rows.Count != 0)
            {
                dgvCount.Rows.RemoveAt(0);
            }
            if (dgvDressInfo.Rows.Count == 0)
            {
                return;
            }
            foreach (DataGridViewRow drViewRow in dgvDressInfo.Rows)
            {
                if (dgvCount.Rows.Count != 0)
                {
                    var row = drViewRow;
                    foreach (DataGridViewRow drRow in dgvCount.Rows.Cast<DataGridViewRow>().Where(drRow => drRow.Cells[0].Value.ToString() == row.Cells["RuleName"].Value.ToString()))
                    {
                        drRow.Cells[1].Value = int.Parse(drRow.Cells[1].Value.ToString()) + 1;
                    }
                    if (dgvCount.Rows.Cast<DataGridViewRow>().All(p => p.Cells[0].Value.ToString() != drViewRow.Cells["RuleName"].Value.ToString()))
                    {
                        int index = dgvCount.Rows.Add();
                        dgvCount.Rows[index].Cells[0].Value = drViewRow.Cells["RuleName"].Value.ToString();
                        dgvCount.Rows[index].Cells[1].Value = 1;
                    }
                }
                else
                {
                    int index = dgvCount.Rows.Add();
                    dgvCount.Rows[index].Cells[0].Value = drViewRow.Cells["RuleName"].Value.ToString();
                    dgvCount.Rows[index].Cells[1].Value = 1;
                }
            }
        }
        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (numerUd.Value == 0)
            {
                return;
            }
            foreach (DataGridViewRow drViewRow in dgvCount.Rows)
            {
                if (drViewRow.Cells[0].Value.ToString() == cmbSmallGoods.Text)
                {
                    drViewRow.Cells[1].Value = int.Parse(drViewRow.Cells[1].Value.ToString()) + numerUd.Value;
                    return;
                }
            }
            int index = dgvCount.Rows.Add();
            dgvCount.Rows[index].Cells[0].Value = cmbSmallGoods.Text;
            dgvCount.Rows[index].Cells[1].Value = numerUd.Value.ToString(CultureInfo.InvariantCulture);
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            PrintPreviewDialog previewDialog = new PrintPreviewDialog() { Document = printResuilt };
            previewDialog.ShowDialog();
        }

        private void printResuilt_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            e.Graphics.DrawString(@"礼服清洗清单"+@"-"+ Information.CurrentUser.EmployeeDepartmentName, new Font("宋体", 13), new SolidBrush(Color.Black), new PointF(52, 25));
            e.Graphics.DrawLine(new Pen(Color.Black), 50,60,300,60);
            e.Graphics.DrawString(@"类别", new Font("宋体", 12.5f), new SolidBrush(Color.Black), new PointF(50, 65));
            e.Graphics.DrawString(@"件数", new Font("宋体", 12.5f), new SolidBrush(Color.Black), new PointF(170, 65));
            e.Graphics.DrawLine(new Pen(Color.Black), 50, 103, 300, 100);

            int x1 = 70; //初始值
            int y1 = 65;
            int x2 = 165;
            int y2 = 65;
            for (int i = 0; i < dgvCount.Columns.Count; i++)
            {
                for (int j = 0; j < dgvCount.Rows.Count; j++)
                {
                    if (dgvCount.Columns[i].HeaderText.Trim() == "类别")
                    {
                        y1 += 40;
                        e.Graphics.DrawString(dgvCount.Rows[j].Cells[i].Value.ToString(), new Font("宋体", 12), new SolidBrush(Color.Black), new PointF(x1-20, y1));
                        e.Graphics.DrawLine(new Pen(Color.Black), 50, y1 + 35, 300, y1 + 35);
                    }
                    else if (dgvCount.Columns[i].HeaderText.Trim() == "件数")
                    {
                        y2 += 40;
                        e.Graphics.DrawString(dgvCount.Rows[j].Cells[i].Value.ToString(), new Font("宋体", 12), new SolidBrush(Color.Black), new PointF(x2, y2));
                        e.Graphics.DrawLine(new Pen(Color.Black), 50, y2 + 35, 300, y2 + 35);
                    }
                }
            }
            e.Graphics.DrawString(@"操作人：", new Font("宋体", 11), new SolidBrush(Color.Black), new PointF(x1 - 20, y1 + 40));
            e.Graphics.DrawString(Information.CurrentUser.EmployeeName, new Font("宋体", 11), new SolidBrush(Color.Black), new PointF(x1 + 100, y1 + 40));
            e.Graphics.DrawLine(new Pen(Color.Black), 50, y1 + 75, 300, y1 + 75);
            e.Graphics.DrawString(@"操作时间：", new Font("宋体", 11), new SolidBrush(Color.Black), new PointF(x1 - 20, y1 + 80));
            e.Graphics.DrawString(DateTime.Now.ToShortDateString(), new Font("宋体", 11), new SolidBrush(Color.Black), new PointF(x1 + 100, y1 + 80));
            //e.Graphics.DrawLine(new Pen(Color.Black), 50, y1 + 115, 300, y1 + 115);
            e.Graphics.DrawLine(new Pen(Color.Black), 150, 60, 150, y1 + 115);
            e.Graphics.DrawRectangle(new Pen(Color.Black), 50, 20, 250, y1 + 95);
        }

        private void FrmDressCleaning_Load(object sender, EventArgs e)
        {
            txtDresBarCode.Focus();
        }

        private void dgvDressInfo_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            picImage.Image = null;
            if (dgvCount.CurrentRow != null)
            {
                string dressBarcode = dgvCount.CurrentRow.Cells["DressBarCode"].Value.ToString();
                DataSet dsSet = ErpService.DressManagement.GetDressSearchInformation(dressBarcode);
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
    }
}
