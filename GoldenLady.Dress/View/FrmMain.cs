using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using GoldenLady.Dress.View.DressRent;
using GoldenLady.Global;
using GoldenLady.SMSNew;
using GoldenLady.Standard;

namespace GoldenLady.Dress.View
{
    public partial class FrmMain : Form
    {
        public FrmMain()
        {
            InitializeComponent();
            lblName.Text = Information.CurrentUser.EmployeeDutyChs + @" ：" + Information.CurrentUser.EmployeeName;
            this.Closing += (sender, args) =>
            {
                GC.Collect();
                Application.Exit();
            };
            CheckEmployeePowers();
        }
        private void CheckEmployeePowers()
        {
            btnDressChoose.Visible = btncsSearch.Visible = tsBtnCheck.Visible = Information.CurrentUser.UserPower.Contains(Powers.礼服.礼服预选);
            btnDressManage.Visible = Information.CurrentUser.UserPower.Contains(Powers.礼服.礼服管理);
            btnDressRent.Visible = Information.CurrentUser.UserPower.Contains(Powers.礼服.礼服出租);
        }

        private int _rentNum = 0;
        private void btnDressRent_Click(object sender, EventArgs e)
        {
            if (tspMenues.Items[tspMenues.Items.IndexOf(btnDressRent) + 1].Image == null)
            {
                while (_rentNum>0)
                {
                    tspMenues.Items.RemoveAt(tspMenues.Items.IndexOf(btnDressRent) + 1);
                    _rentNum--;
                }
            }
            else
            {
                ToolStripButton toolStripButton1 = new ToolStripButton()
                {
                    Text = @"订单查询",
                    Font = new Font("微软雅黑", 11),
                    ForeColor = Color.White,
                    Margin = new Padding(60, 5, 0, 5),
                    TextAlign = ContentAlignment.MiddleLeft
                };
                toolStripButton1.Click += (o, args) =>
                {
                    FrmOrdersSearch frmDressRentSearch = new FrmOrdersSearch() { Dock = DockStyle.Fill, AutoSize = false, AutoScaleMode = AutoScaleMode.None };
                    CreateNewPage(toolStripButton1.Text, frmDressRentSearch);
                };
                tspMenues.Items.Insert(tspMenues.Items.IndexOf(btnDressRent) + (_rentNum+1), toolStripButton1);
                _rentNum++;

                ToolStripButton toolStripButton2 = new ToolStripButton()
                {
                    Text = @"排单查询",
                    Font = new Font("微软雅黑", 11),
                    ForeColor = Color.White,
                    Margin = new Padding(60, 5, 0, 5),
                    TextAlign = ContentAlignment.MiddleLeft
                };
                toolStripButton2.Click += (o, args) =>
                {
                    FrmRentList frmRentList = new FrmRentList(String.Empty) { Dock = DockStyle.Fill, AutoSize = false, AutoScaleMode = AutoScaleMode.None };
                    CreateNewPage(toolStripButton2.Text, frmRentList);
                };
                tspMenues.Items.Insert(tspMenues.Items.IndexOf(btnDressRent) + (_rentNum + 1), toolStripButton2);
                _rentNum++;

                ToolStripButton toolStripButton3 = new ToolStripButton()
                {
                    Text = @"出租查询",
                    Font = new Font("微软雅黑", 11),
                    ForeColor = Color.White,
                    Margin = new Padding(60, 5, 0, 5),
                    TextAlign = ContentAlignment.MiddleLeft
                };
                toolStripButton3.Click += (o, args) =>
                {
                    FrmDressRentedInfo frmDressRentedInfo = new FrmDressRentedInfo() { Dock = DockStyle.Fill };
                    CreateNewPage(toolStripButton3.Text, frmDressRentedInfo);
                };
                tspMenues.Items.Insert(tspMenues.Items.IndexOf(btnDressRent) + (_rentNum + 1), toolStripButton3);
                _rentNum++;

                ToolStripButton toolStripButton5 = new ToolStripButton()
                {
                    Text = @"短信设置",
                    Font = new Font("微软雅黑", 11),
                    ForeColor = Color.White,
                    Margin = new Padding(60, 5, 0, 5),
                    TextAlign = ContentAlignment.MiddleLeft
                };
                toolStripButton5.Click += (o, args) =>
                {
                    frmOption frmOption = new frmOption();
                    frmOption.ShowDialog();
                };
                tspMenues.Items.Insert(tspMenues.Items.IndexOf(btnDressRent) + (_rentNum + 1), toolStripButton5);
                _rentNum++;
            }
        }

        private void btnStateChange_Click(object sender, EventArgs e)
        {
            FrmDressStateChange frmDressCheck = new FrmDressStateChange() { Dock = DockStyle.Fill, AutoSize = false, AutoScaleMode = AutoScaleMode.None };
            CreateNewPage(btnStateChange.Text, frmDressCheck);
        }

        private int _dressNum = 0;
        private void btnDressManage_Click(object sender, EventArgs e)
        {
            if (tspMenues.Items[tspMenues.Items.IndexOf(btnDressManage) + 1].Image == null)
            {
                while (_dressNum > 0)
                {
                    tspMenues.Items.RemoveAt(tspMenues.Items.IndexOf(btnDressManage) + 1);
                    _dressNum--;
                }
            }
            else
            {
                ToolStripButton toolStripButton1 = new ToolStripButton
                {
                    Text = @"礼服建档",
                    Font = new Font("微软雅黑", 11),
                    ForeColor = Color.White,
                    Margin = new Padding(60, 5, 0, 5),
                    TextAlign = ContentAlignment.MiddleLeft
                };
                toolStripButton1.Click += (o, args) => { new FrmNewDress().ShowDialog(); };
                tspMenues.Items.Insert(tspMenues.Items.IndexOf(btnDressManage) + (_dressNum+1), toolStripButton1);
                _dressNum++;

                ToolStripButton toolStripButton3 = new ToolStripButton
                {
                    Text = @"礼服修改",
                    Font = new Font("微软雅黑", 11),
                    ForeColor = Color.White,
                    Margin = new Padding(60, 5, 0, 5),
                    TextAlign = ContentAlignment.MiddleLeft
                };
                toolStripButton3.Click += (o, args) =>
                {
                    new FrmDressModify().ShowDialog();
                };
                tspMenues.Items.Insert(tspMenues.Items.IndexOf(btnDressManage) + (_dressNum + 1), toolStripButton3);
                _dressNum++;

                ToolStripButton toolStripButton4 = new ToolStripButton()
                {
                    Text = @"跨馆设置",
                    Font = new Font("微软雅黑", 11),
                    ForeColor = Color.White,
                    Margin = new Padding(60, 5, 0, 5),
                    TextAlign = ContentAlignment.MiddleLeft
                };
                toolStripButton4.Click += (o, args) =>
                {
                    new FrmCrossReservation().ShowDialog();
                };
                tspMenues.Items.Insert(tspMenues.Items.IndexOf(btnDressManage) + (_dressNum + 1), toolStripButton4);
                _dressNum++;

                if (Information.CurrentUser.UserPower.Contains(Powers.礼服.高级删除))
                {
                    ToolStripButton toolStripButton6 = new ToolStripButton()
                    {
                        Text = @"场馆管理",
                        Font = new Font("微软雅黑", 11),
                        ForeColor = Color.White,
                        Margin = new Padding(60, 5, 0, 5),
                        TextAlign = ContentAlignment.MiddleLeft
                    };
                    toolStripButton6.Click += (o, args) =>
                    {
                        FrmVenue frmVenue = new FrmVenue()
                        {
                            Dock = DockStyle.Fill,
                            AutoSize = false,
                            AutoScaleMode = AutoScaleMode.None
                        };
                        CreateNewPage(toolStripButton6.Text, frmVenue);
                    };
                    tspMenues.Items.Insert(tspMenues.Items.IndexOf(btnDressManage) + (_dressNum + 1), toolStripButton6);
                    _dressNum++;
                }

                ToolStripButton toolStripButton7 = new ToolStripButton()
                {
                    Text = @"礼服匹配",
                    Font = new Font("微软雅黑", 11),
                    ForeColor = Color.White,
                    Margin = new Padding(60, 5, 0, 5),
                    TextAlign = ContentAlignment.MiddleLeft
                };
                toolStripButton7.Click += (o, args) =>
                {
                    new FrmSceneDress().ShowDialog();
                };
                tspMenues.Items.Insert(tspMenues.Items.IndexOf(btnDressManage) + (_dressNum + 1), toolStripButton7);
                _dressNum++;

                ToolStripButton toolStripButton8 = new ToolStripButton()
                {
                    Text = @"小件管理",
                    Font = new Font("微软雅黑", 11),
                    ForeColor = Color.White,
                    Margin = new Padding(60, 5, 0, 5),
                    TextAlign = ContentAlignment.MiddleLeft
                };
                toolStripButton8.Click += (o, args) =>
                {
                    new FrmSmallGoods().ShowDialog();
                };
                tspMenues.Items.Insert(tspMenues.Items.IndexOf(btnDressManage) + (_dressNum + 1), toolStripButton8);
                _dressNum++;
            }
        }

        private void btnDressChoose_ButtonClick(object sender, EventArgs e)
        {
            FrmOrdersShootSearch frmDressCheck = new FrmOrdersShootSearch() { Dock = DockStyle.Fill, AutoSize = false, AutoScaleMode = AutoScaleMode.None };
            CreateNewPage(btnDressChoose.Text, frmDressCheck);
        }
        private void CreateNewPage(string titleName, Control control)
        {
            foreach (TabPage tbpage in tbContent.TabPages)
            {
                if (tbpage.Name == titleName)
                {
                    tbContent.SelectedTab = tbpage;
                    return;
                }
            }
            TabPage newPage = new TabPage() { Name = titleName, Text = titleName };
            tbContent.TabPages.Add(newPage);
            newPage.Controls.Add(control);
            control.Parent = newPage;
            tbContent.SelectTab(newPage);
        }

        private void btncsSearch_Click(object sender, EventArgs e)
        {
            FrmDressChoosedSearch frmDressChoosedSearch = new FrmDressChoosedSearch() { Dock = DockStyle.Fill, AutoSize = false, AutoScaleMode = AutoScaleMode.None };
            CreateNewPage(btncsSearch.Text, frmDressChoosedSearch);
        }

        private void tbContent_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            TabControl tabControl1 = (TabControl)sender;
            Point pt = new Point(e.X, e.Y);

            for (int i = 0; i < tabControl1.TabCount; i++)
            {
                Rectangle recTab = tabControl1.GetTabRect(i);
                if (recTab.Contains(pt))
                {
                    TabPage seltab = this.tbContent.SelectedTab;
                    int seltabindex = this.tbContent.SelectedIndex;

                    tabControl1.Controls.Remove(seltab);
                    if (seltabindex != 0)
                        tabControl1.SelectTab(seltabindex - 1);
                    return;
                }
            }
        }

        private void tsBtnCheck_Click(object sender, EventArgs e)
        {
            FrmDailyCount frmDailyCount = new FrmDailyCount() { Dock = DockStyle.Fill, AutoSize = false, AutoScaleMode = AutoScaleMode.None };
            CreateNewPage(tsBtnCheck.Text, frmDailyCount);
        }

        private void tspMenues_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            foreach (ToolStripItem toolStripButton in tspMenues.Items)
            {
                toolStripButton.BackColor = Color.Transparent;
            }
            e.ClickedItem.BackColor = Color.MediumOrchid;
        }

        private void btnStatistics_Click(object sender, EventArgs e)
        {
            FrmAllStatistics frmAllStatistics = new FrmAllStatistics() { Dock = DockStyle.Fill };
            CreateNewPage(btnStatistics.Text, frmAllStatistics);
        }

        private void tsBtnDressInfo_Click(object sender, EventArgs e)
        {
            FrmAllDressSearch frmAllDressSearch = new FrmAllDressSearch() { Dock = DockStyle.Fill, AutoSize = false, AutoScaleMode = AutoScaleMode.None };
            CreateNewPage(tsBtnDressInfo.Text, frmAllDressSearch);
        }

        private int _configNum = 0;
        private void btnConfig_Click(object sender, EventArgs e)
        {
            if (tspMenues.Items.IndexOf(btnConfig) + 1 < tspMenues.Items.Count)
            {
                while (_configNum>0)
                {
                    tspMenues.Items.RemoveAt(tspMenues.Items.IndexOf(btnConfig) + 1);
                    _configNum--;
                }
            }
            else
            {
                if (Information.CurrentUser.UserPower.Contains(Powers.礼服.礼服权限))
                {
                    ToolStripButton toolStripButton1 = new ToolStripButton()
                    {
                        Text = @"权限管理",
                        Font = new Font("微软雅黑", 11),
                        ForeColor = Color.White,
                        Margin = new Padding(60, 5, 0, 5),
                        TextAlign = ContentAlignment.MiddleLeft
                    };
                    toolStripButton1.Click += (o, args) =>
                    {
                        FrmPowerEmp frmPowerEmp = new FrmPowerEmp()
                        {
                            Dock = DockStyle.Fill,
                            AutoSize = false,
                            AutoScaleMode = AutoScaleMode.None
                        };
                        CreateNewPage(toolStripButton1.Text, frmPowerEmp);
                    };
                    tspMenues.Items.Insert(tspMenues.Items.IndexOf(btnConfig) + (_configNum + 1), toolStripButton1);
                    _configNum++;
                }
                ToolStripButton toolStripButton2 = new ToolStripButton()
                {
                    Text = @"密码修改",
                    Font = new Font("微软雅黑", 11),
                    ForeColor = Color.White,
                    Margin = new Padding(60, 5, 0, 5),
                    TextAlign = ContentAlignment.MiddleLeft
                };

                toolStripButton2.Click += (o, args) =>
                {
                    frmEmployeePassword frmEmployeePassword = new frmEmployeePassword();
                    frmEmployeePassword.ShowDialog();
                };
                tspMenues.Items.Insert(tspMenues.Items.IndexOf(btnConfig) + (_configNum + 1), toolStripButton2);
                _configNum++;
            }
        }
    }
}
