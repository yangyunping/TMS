using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using GoldenLady.Dress.UIControl;
using GoldenLady.Dress.Utils;
using GoldenLady.Extension;
using GoldenLadyWS;

namespace GoldenLady.Dress.View
{
    public partial class FrmViewStyle : Form
    {
        private readonly Form _frmVenueShow;//上一个窗体
        private int i = 0; //风格照片Index
        private string[] _themePhoto;//选中风格照片路径

        private DataTable _dataTable;//风格预选的数据
        private readonly List<string> _fileName = new List<string>(); //风格预选照片路径
        private readonly List<string> _themeName = new List<string>();//风格名字
        private readonly List<string> _themeNO = new List<string>();//风格名字
        private readonly List<string> _themePhotoFirst = new List<string>();//风格下第一张照片路径

        public FrmViewStyle(FrmVenueShow frmVenueShow)
        {
            InitializeComponent();
            this._frmVenueShow = frmVenueShow;
            picStyle.SizeMode = PictureBoxSizeMode.CenterImage;
            Inialization(); //初始化
        }

        private void Inialization()
        {
            //DataSet myds = GoldenLady.Program.ErpWs.GetTheme();
            //DataRow dr = myds.Tables[0].NewRow();
            //dr["ElementName"] = "请选择";
            //dr["ElementNO"] = string.Empty;
            //myds.Tables[0].Rows.InsertAt(dr, 0);
            //cmbTheme.DataSource = myds.Tables[0];
            //cmbTheme.DisplayMember = "ElementName";
            //cmbTheme.ValueMember = "ElementNO";
            //cmbTheme.SelectedIndex = 0;
        }
        private void btnSearch_Click(object sender, EventArgs e)
        {
            lvwStyleViewData();//风格加载
            lvwVenueSceneData();//场景加载
        }

        /// <summary>
        /// 风格预选显示加载
        /// </summary>
        private void lvwStyleViewData()
        {
            string _themeString = string.Empty;
            if(txtKeys.Text != string.Empty && cmbTheme.Text != string.Empty)
            {
                _themeString = cmbTheme.Text == string.Empty ? txtKeys.Text.ToString() : cmbTheme.Text.ToString();
            }
            DataSet ds = GoldenLady.Program.ErpWs.GetThemeInformation(AllKindsData.venueName, null);
            _dataTable = ds.Tables[0];
            if(_dataTable.Rows.Count == 0)
            {
                MessageBox.Show(@"没有查询到数据！");
                return;
            }
            AllKindsData.venueNO = _dataTable.Rows[0]["VenueNO"].SafeDbValue<string>();
            for(int j = 0; j < _dataTable.Rows.Count; j++)
            {
                _fileName.Add(_dataTable.Rows[j]["ThemePhotoDirectory"].SafeDbValue<string>());
                _themeName.Add(_dataTable.Rows[j]["ThemeName"].SafeDbValue<string>());
                _themeNO.Add(_dataTable.Rows[j]["ThemeNO"].SafeDbValue<string>());
            }

            for(int j = 0; j < _fileName.Count; j++)
            {
                string[] _iamgeStrings = Directory.GetFiles(_fileName[j]);
                _themePhotoFirst.Add(_iamgeStrings[0]);
                Image _imageFirst = Image.FromFile(_iamgeStrings[0]);
                ilstThemes.Images.Add(_imageFirst.ZoomImage(ilstThemes.ImageSize));
                lvwStyleView.View = System.Windows.Forms.View.LargeIcon;
                lvwStyleView.LargeImageList = ilstThemes;
                lvwStyleView.BeginUpdate();
                ListViewItem lst = new ListViewItem
                {
                    ImageIndex = j,
                    Text = _themeName[j],
                    Tag = _themeNO[j]
                };
                lvwStyleView.Items.Add(lst);
                lvwStyleView.EndUpdate();
            }
        }
        /// <summary>
        /// 场景加载
        /// </summary>
        private void lvwVenueSceneData()
        {
            //DataTable dt = GoldenLady.Program.ErpWs.GetVenueInformation(AllKindsData.venueName).Tables[0];
            //if (dt.Rows.Count == 0)
            //{
            //    return;
            //}

            //string _sceneTheme = dt.Rows[0]["ScenePhotoDirectory"].SafeDbValue<string>();
            //string[] _imageScene = Directory.GetFiles(_sceneTheme);
            //foreach (string _image in _imageScene)
            //{
            //    Image img = Image.FromFile(_image);
            //    ilstScene.Images.Add(img.ZoomImage(ilstScene.ImageSize));
            //    lvwVenueScene.View = System.Windows.Forms.View.LargeIcon;
            //    lvwVenueScene.LargeImageList = ilstScene;
            //    lvwVenueScene.BeginUpdate();
            //    for (int j = 0; j < ilstScene.Images.Count; j++)
            //    {
            //        lvwSelected.Items.Add();
            //    }
                
                
            //    lvwSelected.EndUpdate();
            //}
            

        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            _frmVenueShow.Show();
            this.Close();
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            foreach (ListViewItem _item in lvwSelected.Items)
            {
                AllKindsData.themeNO.Add(_item.Tag.ToString());
                AllKindsData.themeName.Add(_item.Text);
            }

            FrmDressShow fds = new FrmDressShow(this);
            fds.Show();
            this.Hide();
            this.Cursor = DefaultCursor;
        }

        private void ptb1_MouseMove(object sender, MouseEventArgs e)
        {
            this.SetStyle(ControlStyles.OptimizedDoubleBuffer |
                  ControlStyles.ResizeRedraw |
                  ControlStyles.AllPaintingInWmPaint, true);
            this.Cursor = e.Location.X < picStyle.Width >> 1
                ? CustomizedCursor.Left : CustomizedCursor.Right;
        }

        private void ptb1_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = DefaultCursor;
        }

        private void ptb1_MouseDown(object sender, MouseEventArgs e)
        {
            string themeNo = lvwStyleView.FocusedItem.Tag.ToString();
            DataRow[] dr = _dataTable.Select(" ThemeNO = '" + themeNo + "'") as DataRow[];
            string _path = dr[0]["ThemePhotoDirectory"].SafeDbValue<string>();
            _themePhoto = Directory.GetFiles(_path);

            Utils.Methods.PicClickEvent(_themePhoto, picStyle,e);
        }

        private void lvwStyleView_SelectedIndexChanged(object sender, EventArgs e)
        {
            int i = lvwStyleView.FocusedItem.ImageIndex;
            Image img = Image.FromFile(_fileName[i]).ZoomImage(picStyle.Size);
            picStyle.Image = img;
        }
        /// <summary>
        /// 选中
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lvwStyleView_ItemChecked(object sender, ItemCheckedEventArgs e)
        {
            if (lvwStyleView.Items.Count == 0)
            {
                return;
            }
            lvwSelected.Items.Clear();
            foreach (ListViewItem _item in lvwStyleView.Items)
            {
                if (_item == null)
                {
                    continue;
                }
                else
                {
                    if (_item.Checked)
                    {
                        Image img = Image.FromFile(_themePhotoFirst[_item.ImageIndex]);
                        ilstSelected.Images.Add(img.ZoomImage(ilstSelected.ImageSize));
                        lvwSelected.View = System.Windows.Forms.View.LargeIcon;
                        lvwSelected.LargeImageList = ilstThemes;
                        lvwSelected.BeginUpdate();
                        ListViewItem lst = new ListViewItem
                        {
                            ImageIndex = _item.ImageIndex,
                            Text = _themeName[_item.ImageIndex],
                            Tag = _themeNO[_item.ImageIndex]
                        };
                        lvwSelected.Items.Add(lst);
                        lvwSelected.EndUpdate();
                    }
                }
            }
        }
    }
}
