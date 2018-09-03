using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.IO;
using System.Linq;
using System.Net.NetworkInformation;
using System.Security.Permissions;
using System.Text;
using System.Windows.Forms;
using GoldenLady.Dress.Utils;
using GoldenLady.Extension;
using GoldenLady.Global;
using GoldenLady.Standard.Dress;
using GoldenLady.Utility;
using GoldenLadyWS;

namespace GoldenLady.Dress.View
{
    public partial class FrmDressCleanStatistics : UserControl
    {
        private readonly string _statisticStyle;

        public FrmDressCleanStatistics(string statistcStyle)
        {
            InitializeComponent();
            _statisticStyle = statistcStyle;
            InitializeData();
        }

        public void InitializeData()
        {
            //大类2
            DataTable dsTable = ErpService.DressManagement.GetDressStyle("2").Tables[0];
            cmbParentStyle.DisplayMember = @"RuleName";
            cmbParentStyle.ValueMember = @"RuleNumbers";
            cmbParentStyle.DataSource = dsTable;

            cmbVenues.DataSource = DressManager.GetRules().Where(p => !string.IsNullOrEmpty(p.Tag) && p.ParentRuleNo == RuleStandard.金夫人总店编号).ToList();
            cmbVenues.DisplayMember = @"Name";
            cmbVenues.ValueMember = @"BindingNo";
            cmbVenues.SelectedIndex = -1;

            if (_statisticStyle == @"礼服送洗统计")
            {
                rbName1.Text = @"入库";
                rbName2.Text = @"送洗";
            }
            else if (_statisticStyle == @"洗衣房统计")
            {
                rbName1.Text = @"接收";
                rbName2.Text = @"完成";
            }
        }

        private void cmbParentStyle_SelectedValueChanged(object sender, EventArgs e)
        {
            //类别
            if (cmbParentStyle.Text == String.Empty)
            {
                return;
            }
            DataTable dsTable =
                ErpService.DressManagement.GetDressStyle(cmbParentStyle.SelectedValue.ToString()).Tables[0];
            DataRow drRow = dsTable.NewRow();
            drRow["RuleName"] = "全部";
            drRow["RuleNumbers"] = "-1";
            dsTable.Rows.InsertAt(drRow, 0);
            cmbStyle.DataSource = dsTable;
            cmbStyle.DisplayMember = @"RuleName";
            cmbStyle.ValueMember = @"RuleNumbers";
        }

        private void btnSearchWash_Click(object sender, EventArgs e)
        {
            string sqlString = string.Empty;
            dgvShow.DataSource = null;
            if (rbName1.Checked)
            {
                sqlString = string.Format(@"  and dl.DressStatus like '%{0}'  ",rbName1.Text);
            }
            else if (rbName2.Checked)
            {
                sqlString = string.Format(@"  and dl.DressStatus like '%{0}' ", rbName2.Text);
            }
            if (chkDate.Checked)
            {
                sqlString +=
                    string.Format(
                        @" and (DATEDIFF(dd,dl.OperateTime,'{0}')<=0 and DATEDIFF(dd,dl.OperateTime,'{1}')>=0)",
                        dtpBegin.Value.ToShortDateString(), dtpEnd.Value.ToShortDateString());
            }
            if (cmbStyle.SelectedValue != null && !cmbStyle.Text.Trim().Equals(@"全部"))
            {
                sqlString += string.Format(@"  and dr.RuleNumbers = '{0}'", cmbStyle.SelectedValue.ToString());
            }
            if (!string.IsNullOrEmpty(cmbVenues.Text))
            {
                sqlString += string.Format(@" and guanmin = '{0}'", cmbVenues.Text);
            }
            if (!string.IsNullOrEmpty(txtDressBarCode.Text))
            {
                sqlString += string.Format(@" and dl.DressBarCode = '{0}'", txtDressBarCode.Text);
            }
            DataTable dtTable = ErpService.DressManagement.GetDressLogInfo(sqlString).Tables[0];
            dgvShow.AutoGenerateColumns = false;
            dgvShow.DataSource = dtTable;
            if (dtTable.Rows.Count == 0)
            {
                MessageBox.Show(@"没有数据。");
            }
            lblSum.Text = @"显示总数：" + dtTable.Rows.Count;
        }

        private void dgvShow_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            picImage.Image = null;
            if (dgvShow.CurrentRow != null)
            {
                string dressBarcode = dgvShow.CurrentRow.Cells["DressBarCode"].Value.ToString();
                DataSet dsSet = ErpService.DressManagement.GetDressSearchInformation(dressBarcode);
                string imgPath = dsSet.Tables[0].Rows[0]["DressImagePath"].SafeDbValue<string>();
                dsSet.Dispose();
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
                picImage.Image =
                    FileTool.ReadImageFile(imgPath.Replace("JPG", "lf").Replace("jpg", "lf"))
                        .ZoomImage(picImage.Size, true, Color.LightGray);
            }
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            while (dgvStatistic.Rows.Count != 0)
            {
                dgvStatistic.Rows.RemoveAt(0);
            }
            if (dgvShow.Rows.Count == 0)
            {
                return;
            }
            foreach (DataGridViewRow drViewRow in dgvShow.Rows)
            {
                if (dgvStatistic.Rows.Count != 0)
                {
                    var row = drViewRow;
                    foreach (DataGridViewRow drRow in dgvStatistic.Rows.Cast<DataGridViewRow>().Where(drRow => drRow.Cells[0].Value.ToString() == row.Cells["RuleName"].Value.ToString()))
                    {
                        drRow.Cells[1].Value = int.Parse(drRow.Cells[1].Value.ToString()) + 1;
                    }
                    if (dgvStatistic.Rows.Cast<DataGridViewRow>().All(p => p.Cells[0].Value.ToString() != drViewRow.Cells["RuleName"].Value.ToString()))
                    {
                        int index = dgvStatistic.Rows.Add();
                        dgvStatistic.Rows[index].Cells[0].Value = drViewRow.Cells["RuleName"].Value.ToString();
                        dgvStatistic.Rows[index].Cells[1].Value = 1;
                    }
                }
                else
                {
                    int index = dgvStatistic.Rows.Add();
                    dgvStatistic.Rows[index].Cells[0].Value = drViewRow.Cells["RuleName"].Value.ToString();
                    dgvStatistic.Rows[index].Cells[1].Value = 1;
                }
            }
            PrintPreviewDialog printPreview = new PrintPreviewDialog();
            printPreview.Document = printDocument1;
            printPreview.ShowDialog();
        }

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            e.Graphics.DrawString(@"礼服清洗清单" + @"-" + Information.CurrentUser.EmployeeDepartmentName, new Font("宋体", 13), new SolidBrush(Color.Black), new PointF(52, 25));
            e.Graphics.DrawLine(new Pen(Color.Black), 50, 60, 300, 60);
            e.Graphics.DrawString(@"类别", new Font("宋体", 12.5f), new SolidBrush(Color.Black), new PointF(50, 65));
            e.Graphics.DrawString(@"件数", new Font("宋体", 12.5f), new SolidBrush(Color.Black), new PointF(170, 65));
            e.Graphics.DrawLine(new Pen(Color.Black), 50, 103, 300, 100);

            int x1 = 70; //初始值
            int y1 = 65;
            int x2 = 165;
            int y2 = 65;
            for (int i = 0; i < dgvStatistic.Columns.Count; i++)
            {
                for (int j = 0; j < dgvStatistic.Rows.Count; j++)
                {
                    if (dgvStatistic.Columns[i].HeaderText.Trim() == "类别")
                    {
                        y1 += 40;
                        e.Graphics.DrawString(dgvStatistic.Rows[j].Cells[i].Value.ToString(), new Font("宋体", 12), new SolidBrush(Color.Black), new PointF(x1 - 20, y1));
                        e.Graphics.DrawLine(new Pen(Color.Black), 50, y1 + 35, 300, y1 + 35);
                    }
                    else if (dgvStatistic.Columns[i].HeaderText.Trim() == "件数")
                    {
                        y2 += 40;
                        e.Graphics.DrawString(dgvStatistic.Rows[j].Cells[i].Value.ToString(), new Font("宋体", 12), new SolidBrush(Color.Black), new PointF(x2, y2));
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

        private void 删除ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dgvShow.CurrentRow != null)
            {
                dgvShow.Rows.Remove(dgvShow.CurrentRow);
                lblSum.Text = @"显示总数：" + dgvShow.Rows.Count;
                MessageBox.Show(@"删除成功！");
            }
        }

        private void txtDressBarCode_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnSearchWash_Click(null, null);
            }
        }
    }
}
