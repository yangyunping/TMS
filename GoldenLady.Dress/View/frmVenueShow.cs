using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Runtime.Versioning;
using System.Windows.Forms;
using GoldenLady.Dress.Properties;
using GoldenLady.Dress.Utils;
using GoldenLady.Extension;
using GoldenLady.Order;
using GoldenLady.Standard;
using GoldenLady.Utility;
using GoldenLadyWS;

namespace GoldenLady.Dress.View
{
    public partial class FrmVenueShow : Form
    {
        private readonly List<string> _photoes;

        public FrmVenueShow()
        {
            InitializeComponent();
            Initialization();
            _photoes = null;//DressManager.GetSceneCacheLarge(ErpService.DressManagement.GetVenue(AllKindsData.VenueNo)).ToList();
            //picVenues.Image = FileTool.ReadImageFile(_photoes[_photoes.Count - 1].ToString());
        }

        private void Initialization()
        {
            lblName.Text = AllKindsData.CustomerName;
            lblPhone.Text = AllKindsData.MoblePhone;
            lblOrderNO.Text = AllKindsData.OrderNo;
            lblSuit.Text = AllKindsData.SuitName;
            lblInformationN.Text = AllKindsData.ShootDetailN;
            lblInformationW.Text = AllKindsData.ShootDetailW;
            lblPrice.Text = AllKindsData.SuitPrice.ToString(CultureInfo.InvariantCulture);
            picVenues.SizeMode = PictureBoxSizeMode.CenterImage;
        }

        private void ptbView_MouseMove(object sender, MouseEventArgs e)
        {
            this.SetStyle(ControlStyles.OptimizedDoubleBuffer |
                  ControlStyles.ResizeRedraw |
                  ControlStyles.AllPaintingInWmPaint, true);
            this.Cursor = e.Location.X < picVenues.Width >> 1
                ? CustomizedCursor.Left : CustomizedCursor.Right;
        }

        private void ptbView_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = DefaultCursor;
        }

        private void picView_MouseDown(object sender, MouseEventArgs e)
        {
            Methods.PicClickEvent(_photoes, picVenues, e);
        }
    }
}
