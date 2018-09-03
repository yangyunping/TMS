using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GoldenLady.Dress.Utils;
using GoldenLady.Extension;
using GoldenLady.Global;
using GoldenLady.SMSNew;
using GoldenLady.Standard;
using GoldenLadyWS;

namespace GoldenLady.Dress.View.DressRent
{
    public partial class FrmRentList : UserControl
    {
        private string _sOrderNo;
        public FrmRentList(string orderNo)
        {
            InitializeComponent();
            _sOrderNo = orderNo;
            排单预定ToolStripMenuItem.Enabled = !string.IsNullOrEmpty(orderNo);
            cmbAddress.DataSource = DressManager.GetRules().Where(p => !string.IsNullOrEmpty(p.Tag) && p.ParentRuleNo == RuleStandard.金夫人总店编号).ToList();
            cmbAddress.DisplayMember = @"Name";
            cmbAddress.ValueMember = @"BindingNo";
            LoadControlTable();
        }

        public FrmRentList(DateTime chooseDate,string orderNo)
        {
            InitializeComponent();
            _sOrderNo = orderNo;
            cmbAddress.DataSource = DressManager.GetRules().Where(p => !string.IsNullOrEmpty(p.Tag) && p.ParentRuleNo == RuleStandard.金夫人总店编号).ToList();
            cmbAddress.DisplayMember = @"Name";
            cmbAddress.ValueMember = @"BindingNo";

            排单预定ToolStripMenuItem.Enabled = !string.IsNullOrEmpty(_sOrderNo);
            取消排单ToolStripMenuItem.Enabled =
                可排控ToolStripMenuItem.Enabled =
                    不可排ToolStripMenuItem.Enabled =
                     外建ToolStripMenuItem.Enabled = Information.CurrentUser.EmployeeDuty.Equals(@"Duty_22");
            dtpDate.Value = chooseDate;
            LoadControlTable();
        }

        private void LoadControlTable()
        {
            try
            {
                dgvShowOrders.Columns.Clear();
                dgvShowOrders.Rows.Clear();
                DataTable dtColTable =
                    ErpService.DressManagement.GetRentColTable(cmbAddress.SelectedValue.ToString(),
                        dtpDate.Value.ToShortDateString()).Tables[0];
                if (dtColTable.Rows.Count == 0)
                {
                    return;
                }
                string[] columnName = dtColTable.Rows[0]["ColTitle"].ToString().Split(',');
                for (int i = 0; i < columnName.Length; i++)
                {
                    dgvShowOrders.Columns.Add(columnName[i], columnName[i]);
                    dgvShowOrders.Columns[i].SortMode = DataGridViewColumnSortMode.NotSortable;
                    dgvShowOrders.Columns[i].Width = 180;
                }
                dgvShowOrders.ColumnHeadersHeight = 50;
                dgvShowOrders.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
                dgvShowOrders.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dgvShowOrders.ReadOnly = true;

                string[] rowName = dtColTable.Rows[0]["RowTime"].ToString().Split(',');
                ;
                dgvShowOrders.Rows.Add(rowName.Length);
                dgvShowOrders.RowHeadersWidth = 20;
                for (int j = 0; j < rowName.Length; j++)
                {
                    dgvShowOrders.Rows[j].HeaderCell.Value = rowName[j];
                    dgvShowOrders.Rows[j].Height = 180;
                    dgvShowOrders.Rows[j].DefaultCellStyle.WrapMode = DataGridViewTriState.True;
                }
                dtColTable.Dispose();

                DataTable dtEnable =
                    ErpService.DressManagement.GetDressColEnable(dtpDate.Value, cmbAddress.SelectedValue.ToString())
                        .Tables[0];
                int unEnableCnt = 0;
                for (int j = 0; j < dtEnable.Rows.Count; j++)
                {
                    int iRow = dtEnable.Rows[j]["RowIndex"].SafeDbValue<int>();
                    int iCol = dtEnable.Rows[j]["ColumnIndex"].SafeDbValue<int>();
                    int isEnable = dtEnable.Rows[j]["IsEnable"].SafeDbValue<int>();
                    if (isEnable == 1)
                    {
                        dgvShowOrders.Rows[iRow].Cells[iCol].Style.BackColor = Color.Gray;
                        unEnableCnt++;
                    }
                }
                dtEnable.Dispose();

                DataTable dtOrder =
                    ErpService.DressManagement.GetReventions(dtpDate.Value, cmbAddress.SelectedValue.ToString()).Tables[
                        0];
                Task.Factory.StartNew(() => LodingData(dtOrder));
                lblNumber.Text = @"可排：" + Convert.ToInt32(columnName.Length * rowName.Length - unEnableCnt) + @" 对" +
                                 @"   已排：" + dtOrder.Rows.Count + @" 对";
            }
            catch
            {
                return;
            }
        }

        private void LodingData(DataTable dtOrder)
        {
            foreach (DataGridViewCell cell in dgvShowOrders.SelectedCells)
            {
                cell.Selected = false;
            }
            for (int i = 0; i < dtOrder.Rows.Count; i++)
            {
                try
                {
                    int iRow = dtOrder.Rows[i]["ChooseRow"].SafeDbValue<int>();
                    int iCol = dtOrder.Rows[i]["ChooseCol"].SafeDbValue<int>();
                    dgvShowOrders.Rows[iRow].Cells[iCol].Value = @"时  间：" +
                                                                 dtOrder.Rows[i]["Dress_ChooseDate"].SafeDbValue<DateTime>().ToShortTimeString() +
                                                                 "\r\n" +
                                                                 @"订单号：" +
                                                                 dtOrder.Rows[i]["OrderNO"].SafeDbValue<string>() +
                                                                 "\r\n" +
                                                                 @"先  生：" +
                                                                 dtOrder.Rows[i]["CustomerName1"].SafeDbValue<string>() + @"(" + dtOrder.Rows[i]["MobilePhone1"].SafeDbValue<string>() + @")" +
                                                                 "\r\n" +
                                                                 @"小  姐：" +
                                                                 dtOrder.Rows[i]["CustomerName2"].SafeDbValue<string>() + @"(" + dtOrder.Rows[i]["MobilePhone2"].SafeDbValue<string>() + @")" +
                                                                 "\r\n" +
                                                                 @"金  额：" +
                                                                 dtOrder.Rows[i]["CashNumber"].SafeDbValue<decimal>() +
                                                                 "\r\n" +
                                                                 @"操作人: " +
                                                                 dtOrder.Rows[i]["DressStylist"].SafeDbValue<string>() +
                                                                 "\r\n" +
                                                                 @"婚  期：" +
                                                                 dtOrder.Rows[i]["MarryDate"].SafeDbValue<string>() +
                                                                 "\r\n" +
                                                                 @"订单时间：" +
                                                                 dtOrder.Rows[i]["OrderDate"].SafeDbValue<string>() +
                                                                 "\r\n" +
                                                                 @"门市人员：" +
                                                                 dtOrder.Rows[i]["OrderEmployee"].SafeDbValue<string>() +
                                                                 "\r\n" +
                                                                 @"门市：" +
                                                                 dtOrder.Rows[i]["OrderDepartment"].SafeDbValue<string>();

                    dgvShowOrders.Rows[iRow].Cells[iCol].Tag = dtOrder.Rows[i]["OrderNO"].SafeDbValue<string>() + @"," + dtOrder.Rows[i]["CustomerNO"].SafeDbValue<string>() + @"," + dtOrder.Rows[i]["CustomerName1"].SafeDbValue<string>()
                        + @"," + dtOrder.Rows[i]["CustomerName2"].SafeDbValue<string>() + @"," + dtOrder.Rows[i]["MobilePhone1"].SafeDbValue<string>() + @"," + dtOrder.Rows[i]["MobilePhone2"].SafeDbValue<string>() + @"," + dtOrder.Rows[i]["batchNum"].SafeDbValue<string>() + @"," + dtOrder.Rows[i]["MarryDate"].SafeDbValue<string>() + @"," + dtOrder.Rows[i]["Dress_ChooseDate"].SafeDbValue<DateTime>().ToShortTimeString();
                    if (dtOrder.Rows[i]["IsArrive"].SafeDbValue<int>() == 1)
                    {
                        dgvShowOrders.Rows[iRow].Cells[iCol].Style.BackColor = Color.LemonChiffon;
                    }
                    if (dtOrder.Rows[i]["ChooseComplete"].SafeDbValue<int>() == 1)
                    {
                        dgvShowOrders.Rows[iRow].Cells[iCol].Style.BackColor = Color.Pink;
                    }
                    if (_sOrderNo.Equals(dtOrder.Rows[i]["OrderNO"].SafeDbValue<string>()))
                    {
                        dgvShowOrders.Rows[iRow].Cells[iCol].Selected = true;
                    }
                }
                catch (Exception ex)
                {
                   // MessageBox.Show(@"存在排单加载失败！" + ex);
                    continue;
                }
                dtOrder.Dispose();
            }
        }

        private void btnTemplates_Click(object sender, EventArgs e)
        {
            FrmTemplate frmTemplate = new FrmTemplate();
            frmTemplate.ShowDialog();
        }

        private void dtpDate_ValueChanged(object sender, EventArgs e)
        {
            LoadControlTable();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            dtpDate.Value = dtpDate.Value.AddDays(1);
        }

        private void btnMinus_Click(object sender, EventArgs e)
        {
            dtpDate.Value = dtpDate.Value.AddDays(-1);
        }

        private void 不可排ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dgvShowOrders.SelectedCells.Count > 0)
            {
                for (int i = 0; i < dgvShowOrders.SelectedCells.Count; i++)
                {
                    int rowIndex = dgvShowOrders.SelectedCells[i].RowIndex;
                    int colIndex = dgvShowOrders.SelectedCells[i].ColumnIndex;
                    if (ErpService.DressManagement.UpdateModelUnEnable(1, cmbAddress.SelectedValue.ToString(), rowIndex,
                        colIndex, dtpDate.Value))
                    {
                        dgvShowOrders.SelectedCells[i].Style.BackColor = Color.Gray;
                    }
                }
            }
        }

        private void 客人到店ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dgvShowOrders.CurrentCell.Value == null)
            {
                MessageBox.Show(@"请选中需操作的订单！");
                return;
            }
            if (dgvShowOrders.SelectedCells.Count > 1)
            {
                MessageBox.Show(@"该操作只允许点击一个单元格！");
                return;
            }
            if (ErpService.DressManagement.CustomerArrive(dgvShowOrders.CurrentCell.Tag.ToString().Split(',')[0], dtpDate.Value))
            {
                dgvShowOrders.CurrentCell.Style.BackColor = Color.LemonChiffon;
            }
            else
            {
                MessageBox.Show(@"操作失败！");
            }
        }

        private void 可排控ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dgvShowOrders.SelectedCells.Count > 0)
            {
                for (int i = 0; i < dgvShowOrders.SelectedCells.Count; i++)
                {
                    int rowIndex = dgvShowOrders.SelectedCells[i].RowIndex;
                    int colIndex = dgvShowOrders.SelectedCells[i].ColumnIndex;
                    if (ErpService.DressManagement.UpdateModelUnEnable(0, cmbAddress.SelectedValue.ToString(), rowIndex, colIndex, dtpDate.Value))
                    {
                        dgvShowOrders.SelectedCells[i].Style.BackColor = Color.White;
                    }
                }
            }
        }

        private void 排单预定ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ArrangeOrder();
        }

        private DateTime _arriveTime;
        private string _operator;
        private void ArrangeOrder()
        {
            if (string.IsNullOrEmpty(cmbAddress.Text))
            {
                MessageBox.Show(@"请选择排单地点！");
                return;
            }
            if (dgvShowOrders.CurrentCell.Style.BackColor == Color.Gray)
            {
                MessageBox.Show(@"该位置不可排！");
                return;
            }
            if (dgvShowOrders.SelectedCells.Count > 1)
            {
                MessageBox.Show(@"该操作只允许点击一个单元格！");
                return;
            }
            if (string.IsNullOrEmpty(_sOrderNo))
            {
                MessageBox.Show(@"订单号不存在，检查后重试！");
                return;
            }
            FrmArrangeTime frmArrangeTime = new FrmArrangeTime(new Action<DateTime>(p => _arriveTime = p), new Action<string>(p => _operator = p));
            frmArrangeTime.ShowDialog();
            DateTime dresschooseDate = dtpDate.Value.Date + _arriveTime.TimeOfDay;
            if (dgvShowOrders.CurrentCell != null && dgvShowOrders.CurrentCell.Value == null)
            {
                if (ErpService.DressManagement.SaveOrderTable(_sOrderNo, cmbAddress.SelectedValue.ToString(), dresschooseDate, dgvShowOrders.CurrentCell.RowIndex, dgvShowOrders.CurrentCell.ColumnIndex, _operator, Information.CurrentUser.EmployeeNO2))
                {
                    MessageBox.Show(@"排单成功！");
                    LoadControlTable();
                }
                else
                {
                    MessageBox.Show(@"排单失败，检查后重试！");
                }
            }
            else
            {
                MessageBox.Show(@"该位置不可排或已排其他订单！");
            }
        }

        private void 取消排单ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dgvShowOrders.CurrentCell.Value == null)
            {
                MessageBox.Show(@"请选中需操作的订单！");
                return;
            }
            if (dgvShowOrders.SelectedCells.Count > 1)
            {
                MessageBox.Show(@"该操作只允许点击一个单元格！");
                return;
            }
            if (MessageBox.Show(@"确定取消排单，请谨慎操作！", @"提示！", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                string orderNo = dgvShowOrders.CurrentCell.Tag.ToString().Split(',')[0];
                if (ErpService.DressManagement.CancelOrderTable(orderNo, cmbAddress.SelectedValue.ToString(), dgvShowOrders.Columns[dgvShowOrders.CurrentCell.ColumnIndex].HeaderText, Information.CurrentUser.EmployeeNO2))
                {
                    MessageBox.Show(@"取消排单成功！");
                    dgvShowOrders.CurrentCell.Value = string.Empty;
                    dgvShowOrders.CurrentCell.Tag = string.Empty;
                }
                else
                {
                    MessageBox.Show(@"取消排单失败，请检查重试！");
                }
            }
        }

        private void 电子选衣ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dgvShowOrders.CurrentCell.Value == null)
            {
                MessageBox.Show(@"请选中需操作的订单！");
                return;
            }
            if (dgvShowOrders.SelectedCells.Count > 1)
            {
                MessageBox.Show(@"该操作只允许点击一个单元格！");
                return;
            }
            FrmDressRentChoose frmDressRentChoose = new FrmDressRentChoose(dgvShowOrders.CurrentCell.Tag.ToString()) { Dock = DockStyle.Fill };
            frmDressRentChoose.ShowDialog();
        }

        private void 添加备注ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dgvShowOrders.CurrentCell.Value == null)
            {
                MessageBox.Show(@"请选中需操作的订单！");
                return;
            }
            if (dgvShowOrders.SelectedCells.Count > 1)
            {
                MessageBox.Show(@"该操作只允许点击一个单元格！");
                return;
            }
            FrmAddRemark frmAddRemark = new FrmAddRemark(dgvShowOrders.CurrentCell.Tag.ToString().Split(',')[0], null, null, null);
            frmAddRemark.ShowDialog();
        }

        private void 新增消费ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dgvShowOrders.CurrentCell.Value == null)
            {
                MessageBox.Show(@"请选中需操作的订单！");
                return;
            }
            if (dgvShowOrders.SelectedCells.Count > 1)
            {
                MessageBox.Show(@"该操作只允许点击一个单元格！");
                return;
            }
            FrmAddCost frmAddCost = new FrmAddCost(dgvShowOrders.CurrentCell.Tag.ToString());
            frmAddCost.ShowDialog();
        }

        private void btnChoose_Click(object sender, EventArgs e)
        {
            电子选衣ToolStripMenuItem_Click(null, null);
        }

        private void 婚期确定ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dgvShowOrders.SelectedCells.Count > 1)
            {
                MessageBox.Show(@"该操作只允许点击一个单元格！");
                return;
            }
            if (dgvShowOrders.CurrentCell != null)
            {
                FrmMarryDate frmMarryDate = new FrmMarryDate(dgvShowOrders.CurrentCell.Tag.ToString().Split(',')[1]);
                frmMarryDate.ShowDialog();
            }
        }

        private void 排单改期ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dgvShowOrders.CurrentCell.Value == null)
            {
                MessageBox.Show(@"请选中需操作的订单！");
                return;
            }
            if (dgvShowOrders.SelectedCells.Count > 1)
            {
                MessageBox.Show(@"该操作只允许点击一个单元格！");
                return;
            }
            _sOrderNo = dgvShowOrders.CurrentCell.Tag.ToString().Split(',')[0];

            FrmChangeDate frmChangeDate = new FrmChangeDate(dtpDate.Value, new Action<DateTime>((p) => dtpDate.Value = p), new Action(ArrangeOrder));
            frmChangeDate.Show(this);
        }

        private void 外建ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dgvShowOrders.CurrentCell.Value != null || dgvShowOrders.CurrentCell.Style.BackColor == Color.Gray)
            {
                MessageBox.Show(@"该位置不可排！");
                return;
            }
            string sCustomerNo = ErpService.CustomerManagement.CreateNewInCustomer();
            FrmQuickOrder frmQuickOrder = new FrmQuickOrder(sCustomerNo, 0);
            frmQuickOrder.ShowDialog();
            _sOrderNo = frmQuickOrder.OrderNo;
            ArrangeOrder();
        }

        private void 短信发送ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dgvShowOrders.CurrentRow != null)
            {
                string moblePhone, customerName, customerNo, content;
                customerNo = dgvShowOrders.CurrentCell.Tag.ToString().Split(',')[1];
                customerName = string.IsNullOrEmpty(dgvShowOrders.CurrentCell.Tag.ToString().Split(',')[3]) ? dgvShowOrders.CurrentCell.Tag.ToString().Split(',')[2] : dgvShowOrders.CurrentCell.Tag.ToString().Split(',')[3];
                moblePhone = string.IsNullOrEmpty(dgvShowOrders.CurrentCell.Tag.ToString().Split(',')[5]) ? dgvShowOrders.CurrentCell.Tag.ToString().Split(',')[4] : dgvShowOrders.CurrentCell.Tag.ToString().Split(',')[5];
                //发送短信内容
                content = @"尊敬的";
                if (!string.IsNullOrEmpty(dgvShowOrders.CurrentCell.Tag.ToString().Split(',')[2]))
                {
                    content += dgvShowOrders.CurrentCell.Tag.ToString().Split(',')[2] + @"先生、";
                }
                if (!string.IsNullOrEmpty(dgvShowOrders.CurrentCell.Tag.ToString().Split(',')[3]))
                {
                    content += dgvShowOrders.CurrentCell.Tag.ToString().Split(',')[3] + @"女士";
                }
                content += "：您好！我是金夫人嫁衣馆礼服师" + dgvShowOrders.Columns[dgvShowOrders.CurrentCell.ColumnIndex].HeaderText + @"，你预约的挑选婚礼当天婚纱时间是" + dtpDate.Value.ToLongDateString() + dgvShowOrders.CurrentCell.Tag.ToString().Split(',')[8] + "，请准时到达，感谢您的支持与配合，解放碑不好停车，最好是选择轻轨或公交出行，以免耽搁你的时间，谢谢。";
                if (string.IsNullOrEmpty(moblePhone))
                {
                    MessageBox.Show(@"手机号码无效,检查后重试！");
                    return;
                }
                List<string> customerInfo = new List<string>();
                customerInfo.Add(customerNo);
                customerInfo.Add(customerName);
                customerInfo.Add(moblePhone);
                customerInfo.Add(content);
                frmSendSms frmSendSms = new frmSendSms(customerInfo);
                frmSendSms.ShowDialog();
            }
        }
    }
}
