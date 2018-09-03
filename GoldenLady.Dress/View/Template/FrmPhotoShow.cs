using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using GoldenLady.Dress.Utils;
using GoldenLady.Extension;
using GoldenLady.Standard.Dress;
using GoldenLady.Utility;

namespace GoldenLady.Dress.View.Template
{
    public partial class FrmPhotoShow : Form
    {
        private readonly List<string> _thumbphotos;
        private readonly List<string> _largephotos;
        public FrmPhotoShow(List<string> thumList, List<string> largeList)
        {
            InitializeComponent();
            _thumbphotos = thumList;
            _largephotos = largeList;
        }

        private void AllPhoto()
        {
            lvwSmallView.Items.Clear();
            try
            {
                for (var j = 0; j < _thumbphotos.Count; j++)
                {
                    Image img = FileTool.ReadImageFile(_thumbphotos[j]);
                    ilstAll.Images.Add(img.ZoomImage(ilstAll.ImageSize, true, Color.LightGray));
                    lvwSmallView.View = System.Windows.Forms.View.LargeIcon;
                    lvwSmallView.LargeImageList = ilstAll;
                    ListViewItem lst = new ListViewItem
                    {
                        ImageIndex = j,
                        Tag = _largephotos[j]
                    };
                    lvwSmallView.BeginUpdate();
                    lvwSmallView.Items.Add(lst);
                    lvwSmallView.EndUpdate();
                    lvwSmallView.Refresh();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(@"照片无法访问！" + ex);
                return;
            }
            finally
            {
                GC.Collect();
            }
        }

        private void ptb1_MouseMove(object sender, MouseEventArgs e)
        {
            this.SetStyle(ControlStyles.OptimizedDoubleBuffer |
                  ControlStyles.ResizeRedraw |
                  ControlStyles.AllPaintingInWmPaint, true);
            this.Cursor = e.Location.X < picBigView.Width >> 1
                ? CustomizedCursor.Left : CustomizedCursor.Right;
        }

        private void ptb1_MouseDown(object sender, MouseEventArgs e)
        {
            Utils.Methods.PicClickEvent(_largephotos, picBigView, e);
        }

        private void picView_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = DefaultCursor;
        }

        private void lvwAll_Click(object sender, EventArgs e)
        {
            picBigView.Image = FileTool.ReadImageFile(lvwSmallView.SelectedItems[0].Tag.ToString()).ZoomImage(picBigView.Size);
        }

        private void FrmPhotoShow_Load(object sender, EventArgs e)
        {
            AllPhoto();
            picBigView.Image = FileTool.ReadImageFile(_largephotos[0]).ZoomImage(picBigView.Size);
        }
    }
}
