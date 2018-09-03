using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using GoldenLady.Dress.Utils;
using GoldenLady.Extension;

namespace GoldenLady.Dress.View
{
    public partial class FrmDressShow : Form
    {
        private readonly Form _frmViewStyle;

        public FrmDressShow(Form frmViewStyle)
        {
            InitializeComponent();
            this.WindowState = FormWindowState.Maximized;
            this._frmViewStyle = frmViewStyle;

            Inialization(); //预选礼服加载
        }

        private void Inialization()
        {
            picDressShow.SizeMode = PictureBoxSizeMode.CenterImage;
            try
            {
                //DataTable dt =DressManager.DataAccess.GetDressInformation(AllKindsData.ThemeNo.ToArray()).Tables[0];
                var _path = Directory.GetFiles(@"C:\Users\Administrator\Desktop\礼服");
                for (int j = 0; j < _path.Length; j++)
                {
                    Image img = Image.FromFile(_path[j]);
                    ilstDresses.Images.Add(img.ZoomImage(ilstDresses.ImageSize));
                    lvwGDresses.View = System.Windows.Forms.View.LargeIcon;
                    lvwGDresses.LargeImageList = ilstDresses;
                    lvwGDresses.BeginUpdate();
                    ListViewItem lst = new ListViewItem
                    {
                        ImageIndex = j,
                        //Tag = dt.Rows[j]["DressNumbers"].SafeDbValue<string>()
                    };
                    lvwGDresses.Items.Add(lst);
                    lvwGDresses.EndUpdate();
                }
            }
            catch
            {
                MessageBox.Show(@"没有数据！");
                return;
            }
        }

        private void ptb1_MouseMove(object sender, MouseEventArgs e)
        {
            this.SetStyle(ControlStyles.OptimizedDoubleBuffer |
                   ControlStyles.ResizeRedraw |
                   ControlStyles.AllPaintingInWmPaint, true);
            this.Cursor = e.Location.X < picDressShow.Width >> 1
                ? CustomizedCursor.Left : CustomizedCursor.Right;
        }
        private void ptb1_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = DefaultCursor;
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            FrmDressInformation fdi = new FrmDressInformation(this);
            fdi.Show();
            this.Hide();
            this.Cursor = DefaultCursor;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            _frmViewStyle.Show();
            this.Close();
        }

        private void ptb1_MouseDown(object sender, MouseEventArgs e)
        {
            //Methods.PicClickEvent(_fileName, picDressShow, e);
        }

        private void lvwGDresses_ItemChecked(object sender, ItemCheckedEventArgs e)
        {
            if (lvwGDresses.Items.Count == 0)
            {
                return;
            }
            lvwDressSelected.Items.Clear();
            foreach (ListViewItem _item in lvwGDresses.Items)
            {
                if (_item == null)
                {
                    continue;
                }
                else
                {
                    if (_item.Checked)
                    {
                        Image img = Image.FromFile(null);
                        ilstDressSelected.Images.Add(img.ZoomImage(ilstDressSelected.ImageSize));
                        lvwDressSelected.View = System.Windows.Forms.View.LargeIcon;
                        lvwDressSelected.LargeImageList = ilstDressSelected;
                        lvwDressSelected.BeginUpdate();
                        ListViewItem lst = new ListViewItem
                        {
                            ImageIndex = _item.ImageIndex,
                            Tag = null,
                            Text = null
                        };
                        lvwDressSelected.Items.Add(lst);
                        lvwDressSelected.EndUpdate();
                    }
                }
            }
        }
    }
}
