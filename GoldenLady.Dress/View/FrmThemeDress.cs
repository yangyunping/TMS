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
    public partial class FrmThemeDress : UserControl
    {
        private IList<string> _dressBarCodes;
        private IList<RuleObject> _types;
        private IList<Venue> _venues;
        private IList<Theme> _themes;
        private Theme _currentTheme;

        private IList<RuleObject> Types
        {
            get { return _types; }
            set
            {
                _types = value;
                OnTypesChanged();
            }
        }
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
        private Theme CurrentTheme
        {
            get { return _currentTheme; }
            set
            {
                _currentTheme = value;
                OnCurrentThemeChanged();
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
        private int CurrentTypeID
        {
            get { return ((RuleObject)cmbType.SelectedItem).RuleNo; }
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
        private void OnCurrentThemeChanged()
        {
            LoadDressBarCodes();
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
        private void OnThemesChanged()
        {
            cmbTheme.DataSource = Themes;
            cmbTheme.DisplayMember = @"Name";
            cmbTheme.ValueMember = @"ID";
            if(null == Themes || 0 == Themes.Count) // 这种情况下不会触发SelectedIndexChanged事件
            {
                CurrentTheme = null;
            }
        }
        private void OnTypesChanged()
        {
            cmbType.DataSource = Types;
            cmbType.DisplayMember = @"Name";
            cmbType.ValueMember = @"RuleNo";
        }

        public FrmThemeDress()
        {
            InitializeComponent();
            InitCtrl();
            BindEvents();
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
                CurrentTheme = null == cmb.SelectedItem ? null : (Theme)cmb.SelectedItem;
            };
            //
            // lstDress
            //
            lstDress.SelectedIndexChanged += (sender, args) =>
            {
                ListBox lst = (ListBox)sender;
                btnDelete.Enabled = null != lst.SelectedItem;
            };
            //
            // cmbType
            //
            cmbType.SelectedIndexChanged += (sender, args) => LoadDressBarCodes();
        }
        private void InitCtrl()
        {
            btnAdd.Enabled = false;
            btnDelete.Enabled = false;
        }
        private void InitData()
        {
            Types = DressManager.GetThemeMatchTypes().ToList();
            Venues = DressManager.GetVenues().ToList();
        }
        private void LoadDressBarCodes()
        {
            if(null == CurrentTheme || 0 == CurrentTypeID)
            {
                btnAdd.Enabled = false;
                DressBarCodes = null;
            }
            else
            {
                btnAdd.Enabled = true;
                DressBarCodes = DressManager.GetDressBarCodes(CurrentTheme, CurrentTypeID).ToList();
            }
        }
        private void ProcAdd()
        {
            try
            {
                DressManager.NewThemeDress(CurrentTheme, DressBarCodeToAdd, CurrentTypeID);
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
                            errMessage = @"当前输入的条码不存在！";
                            break;
                        }
                    case SqlExceptionType.PrimaryKeyDuplicated:
                        {
                            errMessage = @"当前输入的条码已经与该风格关联过了！";
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
            if(DialogResult.OK != MessageBoxEx.Confirm(string.Format(@"确定要移除对象'{0}'吗？", SelectedDressBarCode)))
            {
                return;
            }
            try
            {
                string dressBarCode = SelectedDressBarCode;
                DressManager.DeleteThemeDress(CurrentTheme, dressBarCode, CurrentTypeID);
                DressBarCodes = DressBarCodes.Where(s => s != dressBarCode).ToList();
            }
            catch(Exception ex)
            {
                MessageBoxEx.Error(string.Format(@"移除失败，原因为{0}{1}", Environment.NewLine, ex.Message));
            }
        }

        private void FrmThemeDress_Load(object sender, EventArgs e)
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