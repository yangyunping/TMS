using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using GoldenLady.Standard.Dress;
using GoldenLady.Utility;

namespace GoldenLady.Dress.View.Template
{
    /// <summary>
    /// 场馆管理窗口模版
    /// Design By : LiuHaiyang
    /// 2017.4.1
    /// </summary>
    internal partial class FrmManage : UserControl
    {
        protected IList<ManagedObject> _objects;
        protected ManagedObject _selectedObject;

        protected IList<ManagedObject> Objects
        {
            get { return _objects; }
            set
            {
                _objects = value;
                OnObjectsChanged();
            }
        }
        protected ManagedObject SelectedObject
        {
            get { return _selectedObject; }
            set
            {
                _selectedObject = value;
                OnSelectedObjectChanged();
            }
        }

        protected virtual void OnObjectsChanged()
        {
            lstObject.DataSource = Objects;
            lstObject.DisplayMember = @"Name";
            lstObject.ValueMember = @"ID";
        }
        protected virtual void OnSelectedObjectChanged()
        {
            if(null == SelectedObject)
            {
                txtObjectName.Text = null;
                txtObjectDescription.Text = null;
                chkObjectDisabled.Checked = false;
                btnSaveObject.Enabled = false;
                btnDeleteObject.Enabled = false;
            }
            else
            {
                txtObjectName.Text = SelectedObject.Name;
                txtObjectDescription.Text = SelectedObject.Description;
                chkObjectDisabled.Checked = SelectedObject.Disabled;
                btnSaveObject.Enabled = true;
                btnDeleteObject.Enabled = true;
            }
        }
        protected virtual void OnDeleteFailed()
        {
            MessageBoxEx.Error(@"删除失败！");
        }
        protected virtual void OnDeleteComplete()
        {
            MessageBoxEx.Info(@"删除成功！");
            Objects = Objects.Where(o => o.ID != SelectedObject.ID).ToList();
            if(Objects.Count == 0)
            {
                SelectedObject = null;
            }
        }
        protected virtual void OnSaveFailed()
        {
            MessageBoxEx.Error(@"修改信息失败！");
        }
        protected virtual void OnSaveComplete()
        {
            MessageBoxEx.Info(@"修改信息成功！");
            RefreshData();
        }

        protected FrmManage()
        {
            InitializeComponent();
            BindingEvents();
        }

        protected virtual void InitData() {}
        protected virtual void RefreshData() {}
        protected virtual void BindingEvents()
        {
            //
            // txtObjectName
            //
            txtObjectName.LostFocus += (sender, args) =>
            {
                if(null == SelectedObject)
                {
                    return;
                }
                SelectedObject.Name = ((TextBox)sender).Text;
            };
            //
            // txtObjectDescription
            //
            txtObjectDescription.LostFocus += (sender, args) =>
            {
                if(null == SelectedObject)
                {
                    return;
                }
                SelectedObject.Description = ((TextBox)sender).Text;
            };
            //
            // chkObjectDisabled
            //
            chkObjectDisabled.CheckedChanged += (sender, args) =>
            {
                if(null == SelectedObject)
                {
                    return;
                }
                SelectedObject.Disabled = ((CheckBox)sender).Checked;
            };
            //
            // lstObject
            //
            lstObject.SelectedIndexChanged += (sender, args) => SelectedObject = ((ManagedObject)((ListBox)sender).SelectedItem).ShallowClone();
            //
            // this
            //
            Load += (sender, args) => InitData();
            //Shown += (sender, args) =>
            //{
            //    OnSelectedObjectChanged();
            //    lstObject.Focus();
            //};
        }
    }
}