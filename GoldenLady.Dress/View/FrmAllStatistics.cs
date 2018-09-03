using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace GoldenLady.Dress.View
{
    public partial class FrmAllStatistics : UserControl
    {
        public FrmAllStatistics()
        {
            InitializeComponent();
        }

        private void tsBtnDressEmpAchieve_Click(object sender, EventArgs e)
        {
            FrmEmpAchieve frmEmpAchieve = new FrmEmpAchieve(){Dock = DockStyle.Fill};
            gbShow.Controls.Clear();
            gbShow.Controls.Add(frmEmpAchieve);
        }

        private void tsBtnCleanMemary_Click(object sender, EventArgs e)
        {
            FrmDressCleanStatistics frmDressStatistics = new FrmDressCleanStatistics(tsBtnCleanMemary.Text) { Dock = DockStyle.Fill, Name = tsBtnCleanMemary.Text };
            gbShow.Controls.Clear();
            gbShow.Controls.Add(frmDressStatistics);
        }

        private void tsBtnRoom_Click(object sender, EventArgs e)
        {
            FrmDressCleanStatistics frmDressStatistics = new FrmDressCleanStatistics(tsBtnRoom.Text) { Dock = DockStyle.Fill, Name = tsBtnRoom.Text };
            gbShow.Controls.Clear();
            gbShow.Controls.Add(frmDressStatistics);
        }

        private void toolStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            foreach (ToolStripItem toolStripButton in toolStrip1.Items)
            {
                toolStripButton.BackColor = Color.Transparent;
            }
            e.ClickedItem.BackColor = Color.BurlyWood;
        }

        private void tsBtnDressInOut_Click(object sender, EventArgs e)
        {
            FrmDressInfo frmDressInOutMemary = new FrmDressInfo(tsBtnDressInOut.Text) { Dock = DockStyle.Fill };
            gbShow.Controls.Clear();
            gbShow.Controls.Add(frmDressInOutMemary);
        }

        private void btnFavourite_Click(object sender, EventArgs e)
        {
            FrmFavouriteDress frmFavouriteDress = new FrmFavouriteDress() { Dock = DockStyle.Fill };
            gbShow.Controls.Clear();
            gbShow.Controls.Add(frmFavouriteDress);
        }

        private void sBtnCreate_Click(object sender, EventArgs e)
        {
            FrmDressInfo frmDressInfo = new FrmDressInfo(sBtnCreate.Text) { Dock = DockStyle.Fill };
            gbShow.Controls.Clear();
            gbShow.Controls.Add(frmDressInfo);
        }
    }
}
