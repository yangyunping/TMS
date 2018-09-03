using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using GoldenLady.Dress.Utils;
using GoldenLady.Dress.View.Template;
using GoldenLady.Extension;
using GoldenLady.Standard.Dress;
using GoldenLady.Utility;
using GoldenLady.Utility.UserControls;
using GoldenLadyWS;

namespace GoldenLady.Dress.View
{
    /// <summary>
    /// 礼服建档窗口
    /// LiuHaiyang
    /// 2017.4.25
    /// </summary>
    public partial class FrmNewDress : FrmBackWork
    {
        private IList<RuleObject> _types;
        private IList<RuleObject> _colors;
        private IList<RuleObject> _ornamentals;
        private IList<RuleObject> _upperStyles;
        private IList<RuleObject> _upperMaterials;
        private IList<RuleObject> _lowerStyles;
        private IList<RuleObject> _lowerMaterials;
        private IList<RuleObject> _categories;
        private IList<RuleObject> _uses;
        private IList<Supplier> _suppliers;
        private IList<Level> _levels;
        private IList<string> _serverPaths;
        private RuleObject _selectedArea;

        private Standard.Dress.Dress DressToNew { get; set; }
        private IEnumerable<RuleObject> Rules { get; set; }
        private IList<RuleObject> Types
        {
            get { return _types; }
            set
            {
                _types = value;
                OnTypesChanged();
            }
        }
        private IList<RuleObject> Colors
        {
            get { return _colors; }
            set
            {
                _colors = value;
                OnColorsChanged();
            }
        }
        private IList<RuleObject> Ornamentals
        {
            get { return _ornamentals; }
            set
            {
                _ornamentals = value;
                OnOrnamentalsChanged();
            }
        }
        private IList<RuleObject> UpperStyles
        {
            get { return _upperStyles; }
            set
            {
                _upperStyles = value;
                OnUpperStylesChanged();
            }
        }
        private IList<RuleObject> LowerStyles
        {
            get { return _lowerStyles; }
            set
            {
                _lowerStyles = value;
                OnLowerStylesChanged();
            }
        }
        private IList<RuleObject> UpperMaterials
        {
            get { return _upperMaterials; }
            set
            {
                _upperMaterials = value;
                OnUpperMaterialsChanged();
            }
        }
        private IList<RuleObject> LowerMaterials
        {
            get { return _lowerMaterials; }
            set
            {
                _lowerMaterials = value;
                OnLowerMaterialsChanged();
            }
        }
        private IList<RuleObject> Categories
        {
            get { return _categories; }
            set
            {
                _categories = value;
                OnCategoriesChanged();
            }
        }
        private IList<RuleObject> Uses
        {
            get { return _uses; }
            set
            {
                _uses = value;
                OnUsesChanged();
            }
        }
        private IList<Supplier> Suppliers
        {
            get { return _suppliers; }
            set
            {
                _suppliers = value;
                OnSuppliersChanged();
            }
        }
        private IList<Level> Levels
        {
            get { return _levels; }
            set
            {
                _levels = value;
                OnlevelsChanged();
            }
        }
        private IList<string> ServerPaths
        {
            get { return _serverPaths; }
            set
            {
                _serverPaths = value;
                OnServerPathsChanged();
            }
        }
        private RuleObject SelectedArea
        {
            get { return _selectedArea; }
            set
            {
                _selectedArea = value;
                OnSelectedAreaChanged();
            }
        }
        private string PhotoFilePath { get; set; }
        private string ServerPath { get; set; }

        private void OnServerPathsChanged()
        {
            cmbServerPath.DataSource = ServerPaths;
        }
        private void OnSelectedAreaChanged()
        {
            DressToNew.AreaNo = SelectedArea.RuleNo.ToString();
            DressToNew.CurrentPositionName = DressManager.GetDepartmentName(SelectedArea, Rules);
            txtArea.Text = SelectedArea.Name;
        }
        private void OnlevelsChanged()
        {
            cmbLevel.DataSource = Levels;
            cmbLevel.DisplayMember = @"Name";
            cmbLevel.ValueMember = @"No";
        }
        private void OnSuppliersChanged()
        {
            cmbSupplier.DataSource = Suppliers;
            cmbSupplier.DisplayMember = @"Name";
            cmbSupplier.ValueMember = @"No";
        }
        private void OnUsesChanged()
        {
            OnRuleObjectsChanged(cmbUse, Uses);
        }
        private void OnCategoriesChanged()
        {
            OnRuleObjectsChanged(cmbCategory, Categories);
        }
        private void OnLowerStylesChanged()
        {
            OnRuleObjectsChanged(cmbLowerStyle, LowerStyles);
        }
        private void OnUpperStylesChanged()
        {
            OnRuleObjectsChanged(cmbUpperStyle, UpperStyles);
        }
        private void OnLowerMaterialsChanged()
        {
            OnRuleObjectsChanged(cmbLowerMaterial, LowerMaterials);
        }
        private void OnUpperMaterialsChanged()
        {
            OnRuleObjectsChanged(cmbUpperMaterial, UpperMaterials);
        }
        private void OnOrnamentalsChanged()
        {
            OnRuleObjectsChanged(cmbOrnamental, Ornamentals);
        }
        private void OnColorsChanged()
        {
            OnRuleObjectsChanged(cmbColor, Colors);
        }
        private void OnTypesChanged()
        {
            OnRuleObjectsChanged(cmbType, Types);
        }
        private static void OnRuleObjectsChanged(ComboBox cmb, IList<RuleObject> src)
        {
            cmb.DataSource = src;
            cmb.DisplayMember = @"Name";
            cmb.ValueMember = @"RuleNo";
        }

        public FrmNewDress()
        {
            InitializeComponent();
            BindEvents();
        }
        private void InitData()
        {
            DressToNew = new Standard.Dress.Dress { StatusName = @"在库" };
            Rules = DressManager.GetRules();
            Types = DressManager.FilterRules(Rules, RuleNumbers.Type).ToList();
            Colors = DressManager.FilterRules(Rules, RuleNumbers.Color).ToList();
            Ornamentals = DressManager.FilterRules(Rules, RuleNumbers.Ornamental).ToList();
            UpperStyles = DressManager.FilterRules(Rules, RuleNumbers.UpperStyle).ToList();
            LowerStyles = DressManager.FilterRules(Rules, RuleNumbers.LowerStyle).ToList();
            UpperMaterials = DressManager.FilterRules(Rules, RuleNumbers.UpperMaterial).ToList();
            LowerMaterials = DressManager.FilterRules(Rules, RuleNumbers.LowerMaterial).ToList();
            Uses = DressManager.FilterRules(Rules, RuleNumbers.Use).ToList();
            Suppliers = DressManager.GetSuppliers().ToList();
            Levels = DressManager.GetLevels().ToList();
            ServerPaths = DressManager.GetServerPaths().ToList();

            cmbType.SelectedItem = null;
            cmbColor.SelectedItem = null;
            cmbCategory.SelectedItem = null;
            cmbBrand.SelectedItem = null;
            cmbOrnamental.SelectedItem = null;
            cmbUpperStyle.SelectedItem = null;
            cmbLowerStyle.SelectedItem = null;
            cmbUpperMaterial.SelectedItem = null;
            cmbLowerMaterial.SelectedItem = null;
            cmbUse.SelectedItem = null;
            cmbSupplier.SelectedItem = null;
            cmbLevel.SelectedItem = null;
            cmbServerPath.SelectedItem = null;
        }
        private void BindEvents()
        {
            //
            // txtCustomCode
            //
            txtCustomCode.LostFocus += (sender, args) => DressToNew.CustomCode = ((TextBox)sender).Text;
            //
            // txtBarCode
            //
            txtBarCode.LostFocus += (sender, args) => DressToNew.BarCode = ((TextBox)sender).Text;
            //
            // cmbType
            //
            cmbType.SelectedIndexChanged += (sender, args) =>
            {
                ComboBox cmb = (ComboBox)sender;
                RuleObject type = (RuleObject)cmb.SelectedItem;
                if (null == type)
                {
                    DressToNew.TypeNo = null;
                    Categories = null;
                }
                else
                {
                    DressToNew.TypeNo = type.RuleNo.ToString();
                    Categories = DressManager.FilterRules(Rules, type.RuleNo).ToList();
                }
            };
            //
            // cmbColor
            //
            cmbColor.LostFocus += (sender, args) => DressToNew.ColorName = ((ComboBox)sender).Text;
            //
            // cmbCategory
            //
            cmbCategory.SelectedIndexChanged += (sender, args) =>
            {
                ComboBox cmb = (ComboBox)sender;
                RuleObject category = (RuleObject)cmb.SelectedItem;
                DressToNew.CategoryNo = null == category ? null : category.RuleNo.ToString();
            };
            //
            // cmbBrand
            //
            cmbBrand.LostFocus += (sender, args) => DressToNew.BrandName = ((ComboBox)sender).Text;
            //
            // cmbOrnamental
            //
            cmbOrnamental.LostFocus += (sender, args) => DressToNew.OrnamentalName = ((ComboBox)sender).Text;
            //
            // cmbUpperStyle
            //
            cmbUpperStyle.LostFocus += (sender, args) => DressToNew.UpperStyleName = ((ComboBox)sender).Text;
            //
            // cmbLowerStyle
            //
            cmbLowerStyle.LostFocus += (sender, args) => DressToNew.LowerStyleName = ((ComboBox)sender).Text;
            //
            // cmbUpperMaterial
            //
            cmbUpperMaterial.LostFocus += (sender, args) => DressToNew.UpperMaterialName = ((ComboBox)sender).Text;
            //
            // cmbLowerMaterial
            //
            cmbLowerMaterial.LostFocus += (sender, args) => DressToNew.LowerMaterialName = ((ComboBox)sender).Text;
            //
            // cmbUse
            //
            cmbUse.LostFocus += (sender, args) => DressToNew.UseName = ((ComboBox)sender).Text;
            //
            // cmbSupplier
            //
            cmbSupplier.LostFocus += (sender, args) => DressToNew.SupplierName = ((ComboBox)sender).Text;
            //
            // cmbLevel
            //
            cmbLevel.LostFocus += (sender, args) =>
            {
                ComboBox cmb = (ComboBox)sender;
                Level level = (Level)cmb.SelectedItem;
                DressToNew.LevelNo = null == level ? null : level.No;
            };
            //
            // txtBuyer
            //
            txtBuyer.LostFocus += (sender, args) => DressToNew.SupplierName = ((TextBox)sender).Text;
            //
            // numUsedToday
            //
            numUsedToday.LostFocus += (sender, args) =>
            {
                NumericUpDown numric = (NumericUpDown)sender;
                DressToNew.NumOfUsedToday = string.IsNullOrWhiteSpace(numric.Text) ? 0 : Convert.ToInt32(numric.Value);
            };
            //
            // numNOTime
            //
            numNOTime.LostFocus += (sender, args) =>
            {
                NumericUpDown numric = (NumericUpDown)sender;
                DressToNew.NOTime = string.IsNullOrWhiteSpace(numric.Text) ? 0 : Convert.ToInt32(numric.Value);
            };
            //
            // txtCost
            //
            txtCost.LostFocus += (sender, args) =>
            {
                CashTextBox txt = (CashTextBox)sender;
                if (string.IsNullOrWhiteSpace(txt.Text))
                {
                    DressToNew.CostPrice = decimal.Zero;
                }
                else
                {
                    decimal cost;
                    if (decimal.TryParse(txt.Text, out cost))
                    {
                        DressToNew.CostPrice = cost;
                    }
                    else
                    {
                        MessageBoxEx.Error(@"价格输入有误！");
                        txt.Highlight();
                    }
                }
            };
            //
            // txtRent
            //
            txtRent.LostFocus += (sender, args) =>
            {
                CashTextBox txt = (CashTextBox)sender;
                if (string.IsNullOrWhiteSpace(txt.Text))
                {
                    DressToNew.RentPrice = decimal.Zero;
                }
                else
                {
                    decimal rent;
                    if (decimal.TryParse(txt.Text, out rent))
                    {
                        DressToNew.RentPrice = rent;
                    }
                    else
                    {
                        MessageBoxEx.Error(@"价格输入有误！");
                        txt.Highlight();
                    }
                }
            };
            //
            // txtSale
            //
            txtSale.LostFocus += (sender, args) =>
            {
                CashTextBox txt = (CashTextBox)sender;
                if (string.IsNullOrWhiteSpace(txt.Text))
                {
                    DressToNew.SalePrice = decimal.Zero;
                }
                else
                {
                    decimal sale;
                    if (decimal.TryParse(txt.Text, out sale))
                    {
                        DressToNew.SalePrice = sale;
                    }
                    else
                    {
                        MessageBoxEx.Error(@"价格输入有误！");
                        txt.Highlight();
                    }
                }
            };
            //
            // txtSource
            //
            txtSource.LostFocus += (sender, args) => DressToNew.Source = ((TextBox)sender).Text;
            //
            // txtDescription
            //
            txtDescription.LostFocus += (sender, args) => DressToNew.Description = ((TextBox)sender).Text;
            //
            // txtNote
            //
            txtNote.LostFocus += (sender, args) => DressToNew.Notes = ((TextBox)sender).Text;
            //
            // cmbServer
            //
            cmbServerPath.LostFocus += (sender, args) => ServerPath = ((ComboBox)sender).Text;
            //
            // photoPicker
            //
            photoPicker.PhotoFilePathChanged += (sender, args) => PhotoFilePath = ((SinglePhotoPicker)sender).PhotoFilePath;
        }
        private bool CanNew()
        {
            if (string.IsNullOrWhiteSpace(DressToNew.BarCode))
            {
                MessageBoxEx.Info(@"请填写礼服条码！");
                txtBarCode.Highlight();
                return false;
            }
            if (string.IsNullOrWhiteSpace(DressToNew.UseName))
            {
                MessageBoxEx.Info(@"请填写礼服用途！");
                cmbUse.Focus();
                return false;
            }
            if (string.IsNullOrWhiteSpace(DressToNew.SupplierName))
            {
                MessageBoxEx.Info(@"请填写供应商！");
                cmbSupplier.Focus();
                return false;
            }
            if (string.IsNullOrWhiteSpace(DressToNew.AreaNo))
            {
                MessageBoxEx.Info(@"请选择礼服区域！");
                btnPickArea.Focus();
                return false;
            }
            if (string.IsNullOrWhiteSpace(DressToNew.LevelNo))
            {
                MessageBoxEx.Info(@"请选择规格档次！");
                cmbLevel.Focus();
                return false;
            }
            if (string.IsNullOrWhiteSpace(PhotoFilePath))
            {
                MessageBoxEx.Info(@"请打开一张礼服图片！");
                photoPicker.Focus();
                return false;
            }
            if (string.IsNullOrWhiteSpace(ServerPath))
            {
                MessageBoxEx.Info(@"请选择服务器路径！");
                cmbServerPath.Focus();
                return false;
            }
            if (!Directory.Exists(ServerPath))
            {
                MessageBoxEx.Info(@"当前选择的服务器路径不存在或无法访问！");
                cmbServerPath.Focus();
                return false;
            }
            return true;
        }
        private void ProcNew()
        {
            string serverPhotoPath = null;
            try
            {
                UpdateWaitMessage(@"上传照片");
                serverPhotoPath = DressManager.UploadDressPhoto(PhotoFilePath, ServerPath);

                UpdateWaitMessage(@"写入数据库");
                DressManager.NewDress(DressToNew, serverPhotoPath);

                Invoke((Action)(() =>
                {
                    CloseWaitFrm();
                    MessageBoxEx.Info(@"添加礼服成功！");
                    txtBarCode.Text = string.Empty;
                }));
            }
            catch (Exception ex)
            {
                try
                {
                    // 删除服务器上已经上传的照片
                    if (null != serverPhotoPath)
                    {
                        DressManager.DeleteDressPhoto(serverPhotoPath);
                    }

                    Invoke((Action)(() =>
                    {
                        CloseWaitFrm();
                        MessageBoxEx.Error(string.Format(@"添加礼服失败！{0}{1}", Environment.NewLine, ex.Message));
                    }));
                }
                catch
                {
                    // 防止二次报错
                }
            }
        }
        private void ModifyOld()
        {
            string serverPhotoPath = null;
            try
            {
                UpdateWaitMessage(@"上传照片");
                serverPhotoPath = DressManager.UploadDressPhoto(PhotoFilePath, ServerPath);

                UpdateWaitMessage(@"写入数据库");
                DressManager.OldDressModify(DressToNew, serverPhotoPath);

                Invoke((Action)(() =>
                {
                    CloseWaitFrm();
                    MessageBoxEx.Info(@"修改礼服成功！");
                    txtBarCode.Text = string.Empty;
                }));
            }
            catch (Exception ex)
            {
                try
                {
                    // 删除服务器上已经上传的照片
                    if (null != serverPhotoPath)
                    {
                        DressManager.DeleteDressPhoto(serverPhotoPath);
                    }

                    Invoke((Action)(() =>
                    {
                        CloseWaitFrm();
                        MessageBoxEx.Error(string.Format(@"修改礼服失败！{0}{1}", Environment.NewLine, ex.Message));
                    }));
                }
                catch
                {
                    // 防止二次报错
                }
            }
        }
        private void FrmNewDress_Load(object sender, EventArgs e)
        {
            InitData();
        }
        private void btnPickArea_Click(object sender, EventArgs e)
        {
            new FrmAreaPicker
            {
                AfterPick = node => SelectedArea = (RuleObject)node.Tag
            }.Show();
        }
        private void btnNew_Click(object sender, EventArgs e)
        {
            if (!CanNew())
            {
                return;
            }
            StartBackWork(ProcNew);
        }

        private void txtBarCode_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                photoPicker.CurrentPhoto = null;
                DataTable dt = ErpService.DressManagement.GetDressSearchInformation(txtBarCode.Text).Tables[0];
                if (dt.Rows.Count == 0)
                {
                    MessageBox.Show(@"不存在该礼服!");
                    return;
                }
                txtCustomCode.Text = DressToNew.CustomCode = dt.Rows[0]["DressCustomCode"].SafeDbValue<string>();
                txtDressNo.Text = dt.Rows[0]["DressNumbers"].SafeDbValue<string>();
                IEnumerable<RuleObject> rulecmbType = DressManager.GetRules().Where(p => p.RuleNo == dt.Rows[0]["DressName"].SafeDbInt32());
                cmbType.Text = DressToNew.DressNo = rulecmbType.ToArray()[0].Name;
                DressToNew.TypeNo = dt.Rows[0]["DressName"].SafeDbValue<string>();
                cmbColor.Text =DressToNew.ColorName =  dt.Rows[0]["DressColor"].SafeDbValue<string>();

                IEnumerable<RuleObject> ruleCategory = DressManager.GetRules().Where(p => p.RuleNo == dt.Rows[0]["DressCategories"].SafeDbInt32());
                cmbCategory.Text = ruleCategory.ToArray()[0].Name;
                DressToNew.CategoryNo = dt.Rows[0]["DressCategories"].SafeDbValue<string>();

                cmbBrand.Text =DressToNew.BrandName = dt.Rows[0]["DressBrand"].SafeDbValue<string>();
                cmbOrnamental.Text =DressToNew.OrnamentalName =  dt.Rows[0]["DressOrnamental"].SafeDbValue<string>();
                cmbUpperStyle.Text =DressToNew.UpperStyleName = dt.Rows[0]["DressUpperStyle"].SafeDbValue<string>();
                cmbUpperMaterial.Text = DressToNew.UpperMaterialName = dt.Rows[0]["DressUpperMaterial"].SafeDbValue<string>();
                cmbLowerStyle.Text =DressToNew.LowerStyleName = dt.Rows[0]["DressLowerStyle"].SafeDbValue<string>();
                cmbLowerMaterial.Text =DressToNew.LowerMaterialName = dt.Rows[0]["DressLowerMaterial"].SafeDbValue<string>();
                cmbUse.Text =DressToNew.UseName = dt.Rows[0]["DressUse"].SafeDbValue<string>();
                cmbSupplier.Text =DressToNew.SupplierName = dt.Rows[0]["SuppliersNumbers"].SafeDbValue<string>();
                cmbLevel.Text =DressToNew.LevelNo = dt.Rows[0]["LevelOfNum"].SafeDbValue<string>();
                txtBuyer.Text =DressToNew.BuyerName = dt.Rows[0]["DressBuyer"].SafeDbValue<string>();
                txtArea.Text = DressToNew.CurrentPositionName = dt.Rows[0]["guanmin"].SafeDbValue<string>();
                DressToNew.AreaNo = dt.Rows[0]["Area"].SafeDbValue<string>();
                numUsedToday.Value =DressToNew.NumOfUsedToday = dt.Rows[0]["DressNumberOfUsedToday"].SafeDbValue<int>();
                numNOTime.Value =DressToNew.NOTime = dt.Rows[0]["NOtime"].SafeDbValue<int>();
                txtCost.Text = dt.Rows[0]["DressCostPrice"].SafeDbValue<string>();
                DressToNew.CostPrice = dt.Rows[0]["DressCostPrice"].SafeDbValue<decimal>();
                txtRent.Text = dt.Rows[0]["DressRentPrice"].SafeDbValue<string>();
                DressToNew.RentPrice = dt.Rows[0]["DressRentPrice"].SafeDbValue<decimal>();
                txtSale.Text = dt.Rows[0]["DressSalePrice"].SafeDbValue<string>();
                DressToNew.SalePrice = dt.Rows[0]["DressSalePrice"].SafeDbValue<decimal>();
                txtSource.Text =DressToNew.Source = dt.Rows[0]["ChannelsToBuy"].SafeDbValue<string>();
                txtDescription.Text =DressToNew.Description = dt.Rows[0]["DressDescribe"].SafeDbValue<string>();
                txtNote.Text =DressToNew.Notes = dt.Rows[0]["DressNotes"].SafeDbValue<string>();
                //cmbServerPath.Text = dt.Rows[0]["??"].SafeDbValue<string>();
                if (!string.IsNullOrEmpty(dt.Rows[0]["DressImagePath"].ToString()))
                {
                    photoPicker.PhotoFilePath = dt.Rows[0]["DressImagePath"].SafeDbValue<string>().Replace("JPG","jpg");
                }
            }
        }
        private void btnModify_Click(object sender, EventArgs e)
        {
            if (!CanNew())
            {
                return;
            }
            StartBackWork(ModifyOld);
        }
    }
}