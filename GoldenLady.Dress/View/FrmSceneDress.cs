using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Windows.Forms;
using GoldenLady.Dress.Utils;
using GoldenLady.Dress.View.Template;
using GoldenLady.Global.Exception;
using GoldenLady.Standard.Dress;
using GoldenLady.Utility;

namespace GoldenLady.Dress.View
{
    /// <summary>
    /// 场景礼服匹配窗口
    /// LiuHaiyang
    /// 2017.5.3
    /// </summary>
    public partial class FrmSceneDress : Form
    {
        private IList<Venue> _venues;
        private IList<Theme> _themes;
        private IList<Scene> _scenes;
        private Scene _currentScene;
        private IList<string> _dressBarCodes;

        private IList<Venue> Venues
        {
            get { return _venues; }
            set
            {
                _venues = value;
                OnVenuesChanged();
            }
        }
        private IList<Theme> Themes
        {
            get { return _themes; }
            set
            {
                _themes = value;
                OnThemesChanged();
            }
        }
        private IList<Scene> Scenes
        {
            get { return _scenes; }
            set
            {
                _scenes = value;
                OnScenesChanged();
            }
        }
        private Scene CurrentScene
        {
            get { return _currentScene; }
            set
            {
                _currentScene = value;
                OnCurrentSceneChanged();
            }
        }
        private IList<string> DressBarCodes
        {
            get { return _dressBarCodes; }
            set
            {
                _dressBarCodes = value;
                OnDressBarCodesChanged();
            }
        }
        private string DressBarCodeToAdd
        {
            get { return txtDressBarCode.Text; }
        }
        private string SelectedDressBarCode
        {
            get { return (string)lstDress.SelectedItem; }
        }

        private void OnDressBarCodesChanged()
        {
            lstDress.DataSource = DressBarCodes;
            if(null == DressBarCodes || 0 == DressBarCodes.Count) // 这种情况下不会触发SelectedIndexChanged事件
            {
                btnDelete.Enabled = false;
            }
            txtDressBarCode.Text = null;
        }
        private void OnCurrentSceneChanged()
        {
            if(null == CurrentScene)
            {
                btnAdd.Enabled = false;
                DressBarCodes = null;
            }
            else
            {
                btnAdd.Enabled = true;
                DressBarCodes = DressManager.GetDressBarCodes(CurrentScene).ToList();
            }
        }
        private void OnScenesChanged()
        {
            cmbScene.DataSource = Scenes;
            cmbScene.DisplayMember = @"Name";
            cmbScene.ValueMember = @"ID";
            if(null == Scenes || 0 == Scenes.Count) // 这种情况下不会触发SelectedIndexChanged事件
            {
                CurrentScene = null;
            }
        }
        private void OnThemesChanged()
        {
            cmbTheme.DataSource = Themes;
            cmbTheme.DisplayMember = @"Name";
            cmbTheme.ValueMember = @"ID";
            if(null == Themes || 0 == Themes.Count) // 这种情况下不会触发SelectedIndexChanged事件
            {
                Scenes = null;
            }
        }
        private void OnVenuesChanged()
        {
            cmbVenue.DataSource = Venues;
            cmbVenue.DisplayMember = @"Name";
            cmbVenue.ValueMember = @"ID";
            if(null == Venues || 0 == Venues.Count) // 这种情况下不会触发SelectedIndexChanged事件
            {
                Themes = null;
            }
        }

        public FrmSceneDress()
        {
            InitializeComponent();
            InitCtrl();
            BindEvents();
        }
        private void InitCtrl()
        {
            btnAdd.Enabled = false;
            btnDelete.Enabled = false;
        }
        private void InitData()
        {
            Venues = DressManager.GetVenues().ToList();
        }
        private void BindEvents()
        {
            //
            // cmbVenue
            //
            cmbVenue.SelectedIndexChanged += (sender, args) =>
            {
                ComboBox cmb = (ComboBox)sender;
                if(null == cmb.SelectedItem)
                {
                    Themes = null;
                }
                else
                {
                    Venue venue = (Venue)cmb.SelectedItem;
                    Themes = DressManager.GetThemes(venue).ToList();
                }
            };
            //
            // cmbTheme
            //
            cmbTheme.SelectedIndexChanged += (sender, args) =>
            {
                ComboBox cmb = (ComboBox)sender;
                if(null == cmb.SelectedItem)
                {
                    Scenes = null;
                }
                else
                {
                    Theme theme = (Theme)cmb.SelectedItem;
                    Scenes = DressManager.GetScenes(theme).ToList();
                }
            };
            //
            // cmbScene
            //
            cmbScene.SelectedIndexChanged += (sender, args) =>
            {
                ComboBox cmb = (ComboBox)sender;
                CurrentScene = null == cmb.SelectedItem ? null : (Scene)cmb.SelectedItem;
            };
            //
            // lstDress
            //
            lstDress.SelectedIndexChanged += (sender, args) =>
            {
                ListBox lst = (ListBox)sender;
                btnDelete.Enabled = null != lst.SelectedItem;
            };
        }
        private void ProcAdd()
        {
            try
            {
                DressManager.NewSceneDress(CurrentScene, DressBarCodeToAdd);
                IList<string> DressNosNow = new List<string>(DressBarCodes);
                DressNosNow.Add(DressBarCodeToAdd);
                DressBarCodes = DressNosNow;
            }
            catch(SqlException sqlEx)
            {
                string errMessage;
                switch(sqlEx.Number)
                {
                    case SqlExceptionType.DressBarCodeNotExists:
                    {
                        errMessage = @"当前输入的礼服条码不存在！";
                        break;
                    }
                    case SqlExceptionType.PrimaryKeyDuplicated:
                    {
                        errMessage = @"当前输入的礼服已经与该场景关联过了！";
                        break;
                    }
                    default:
                    {
                        errMessage = string.Format(@"添加失败，原因为{0}{1}", Environment.NewLine, sqlEx.Message);
                        break;
                    }
                }
                MessageBoxEx.Error(errMessage);
                txtDressBarCode.Highlight();
            }
            catch(Exception ex)
            {
                MessageBoxEx.Error(string.Format(@"添加失败，原因为{0}{1}", Environment.NewLine, ex.Message));
                txtDressBarCode.Highlight();
            }
        }
        private void ProcDelete()
        {
            if(DialogResult.OK != MessageBoxEx.Confirm(string.Format(@"确定要移除礼服'{0}'吗？", SelectedDressBarCode)))
            {
                return;
            }
            try
            {
                string dressBarCode = SelectedDressBarCode;
                DressManager.DeleteSceneDress(CurrentScene, dressBarCode);
                DressBarCodes = DressBarCodes.Where(s => s != dressBarCode).ToList();
            }
            catch(Exception ex)
            {
                MessageBoxEx.Error(string.Format(@"移除失败，原因为{0}{1}", Environment.NewLine, ex.Message));
            }
        }

        private void FrmSceneDress_Load(object sender, EventArgs e)
        {
            InitData();
        }
        private void btnAdd_Click(object sender, EventArgs e)
        {
            ProcAdd();
        }
        private void btnDelete_Click(object sender, EventArgs e)
        {
            ProcDelete();
        }
        private void lstDress_DoubleClick(object sender, EventArgs e)
        {
            txtDressBarCode.Text = (string)lstDress.SelectedItem;
        }

        private void txtDressBarCode_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                ProcAdd();
            }
        }
    }
}