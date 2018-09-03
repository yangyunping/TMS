using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using GoldenLady.Dress.Utils;
using GoldenLady.Dress.View.Template;
using GoldenLady.Global;
using GoldenLady.Standard;

namespace GoldenLady.Dress.View
{
    public partial class FrmDressStateChange : UserControl
    {
        public FrmDressStateChange()
        {
            InitializeComponent();
            EmplyoyeePower();
        }

        private void btnClean_Click(object sender, EventArgs e)
        {
            FrmDressCleaning frmDressCleaning = new FrmDressCleaning(DressState.礼服送洗.ToString(), @"送洗中");
            grpControl.Controls.Clear();
            grpControl.Controls.Add(frmDressCleaning);
            frmDressCleaning.Dock = DockStyle.Fill;
        }

        private void btnCleanedIn_Click(object sender, EventArgs e)
        {
            FrmDressInVenue frmDressToVenue = new FrmDressInVenue(DressState.送洗入库.ToString(),
                Information.CurrentUser.EmployeeDepartmentName);
            grpControl.Controls.Clear();
            grpControl.Controls.Add(frmDressToVenue);
            frmDressToVenue.Dock = DockStyle.Fill;
        }

        private void btnShootedIn_Click(object sender, EventArgs e)
        {
            FrmDressInOut frmDressInOut = new FrmDressInOut();
            grpControl.Controls.Clear();
            grpControl.Controls.Add(frmDressInOut);
            frmDressInOut.Dock = DockStyle.Fill;
        }

        private void btnVenuesCleanInfo_Click(object sender, EventArgs e)
        {
            FrmVenueCleanInfo frmVenueCleanInfo = new FrmVenueCleanInfo();
            grpControl.Controls.Clear();
            grpControl.Controls.Add(frmVenueCleanInfo);
            frmVenueCleanInfo.Dock = DockStyle.Fill;
        }

        private void btnDressReceive_Click(object sender, EventArgs e)
        {
            FrmDressCleaning frmDressCleaning = new FrmDressCleaning(DressState.礼服接收.ToString(), @"洗衣房");
            grpControl.Controls.Clear();
            grpControl.Controls.Add(frmDressCleaning);
            frmDressCleaning.Dock = DockStyle.Fill;
        }

        private void btnCleanFinished_Click(object sender, EventArgs e)
        {
            FrmDressInVenue frmDressToVenue = new FrmDressInVenue(DressState.清洗完成.ToString(), @"回库途中");
            grpControl.Controls.Clear();
            grpControl.Controls.Add(frmDressToVenue);
            frmDressToVenue.Dock = DockStyle.Fill;
        }

        private void btnRentCleaning_Click(object sender, EventArgs e)
        {
            FrmDressCleaning frmDressCleaning = new FrmDressCleaning(DressState.出租送洗.ToString(), @"送洗中");
            grpControl.Controls.Clear();
            grpControl.Controls.Add(frmDressCleaning);
            frmDressCleaning.Dock = DockStyle.Fill;
        }

        private void btnRentToVenue_Click(object sender, EventArgs e)
        {
            FrmDressInVenue frmDressToVenue = new FrmDressInVenue(DressState.出租入库.ToString(),
                Information.CurrentUser.EmployeeDepartmentName);
            grpControl.Controls.Clear();
            grpControl.Controls.Add(frmDressToVenue);
            frmDressToVenue.Dock = DockStyle.Fill;
        }

        private void btnWashToVenue_Click(object sender, EventArgs e)
        {
            FrmDressInVenue frmDressToVenue = new FrmDressInVenue(DressState.送洗入库.ToString(),
                Information.CurrentUser.EmployeeDepartmentName);
            grpControl.Controls.Clear();
            grpControl.Controls.Add(frmDressToVenue);
            frmDressToVenue.Dock = DockStyle.Fill;
        }

        private void EmplyoyeePower()
        {
            btnShootClean.Enabled =
                btnShootedIn.Enabled =
                    btnCleanedIn.Enabled =Information.CurrentUser.UserPower.Contains(Powers.礼服.礼服预选);
            btnRentCleaning.Enabled = btnRentToVenue.Enabled = btnWashToVenue.Enabled = Information.CurrentUser.UserPower.Contains(Powers.礼服.礼服出租);
            btnDressReceive.Enabled = btnCleanFinished.Enabled = btnVenuesCleanInfo.Enabled = Information.CurrentUser.UserPower.Contains(Powers.礼服.洗衣房);
        }

        private void btnShootIn_Click(object sender, EventArgs e)
        {
            FrmDressInVenue frmDressToVenue = new FrmDressInVenue(DressState.拍照入库.ToString(),
              Information.CurrentUser.EmployeeDepartmentName);
            grpControl.Controls.Clear();
            grpControl.Controls.Add(frmDressToVenue);
            frmDressToVenue.Dock = DockStyle.Fill;
        }
    }
}
