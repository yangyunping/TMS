using System.Windows.Forms;
using GoldenLady.Standard.Dress;
using GoldenLady.Utility;

namespace GoldenLady.Dress.View.Template
{
    /// <summary>
    /// 添加对象窗体模版
    /// LiuHaiyang
    /// 2017.4.29
    /// </summary>
    public partial class FrmNew : FrmBackWork
    {
        protected ManagedObject ObjectToNew;

        protected virtual void OnObjectToNewChanged()
        {
            if(ObjectToNew == null)
            {
                txtObjectName.Text = null;
                txtObjectDescription.Text = null;
                chkObjectDisabled.Checked = false;
            }
            else
            {
                txtObjectName.Text = ObjectToNew.Name;
                txtObjectDescription.Text = ObjectToNew.Description;
                chkObjectDisabled.Checked = ObjectToNew.Disabled;
            }
        }
        protected virtual void OnSaveComplete()
        {
            MessageBoxEx.Info(@"添加成功！");
            Close();
        }
        protected virtual void OnSaveFailed()
        {
            MessageBoxEx.Error(@"添加失败！");
        }

        public FrmNew()
        {
            InitializeComponent();
            InitControl();
            BindEvents();
        }

        protected virtual void InitData() {}
        protected virtual void InitControl() {}
        protected virtual void BindEvents()
        {
            //
            // txtObjectName
            //
            txtObjectName.LostFocus += (sender, args) =>
            {
                if(null == ObjectToNew)
                {
                    return;
                }
                ObjectToNew.Name = ((TextBox)sender).Text;
            };
            //
            // txtObjectDescription
            //
            txtObjectDescription.LostFocus += (sender, args) =>
            {
                if(null == ObjectToNew)
                {
                    return;
                }
                ObjectToNew.Description = ((TextBox)sender).Text;
            };
            //
            // chkObjectDisabled
            //
            chkObjectDisabled.CheckedChanged += (sender, args) =>
            {
                if(null == ObjectToNew)
                {
                    return;
                }
                ObjectToNew.Disabled = ((CheckBox)sender).Checked;
            };
            //
            // this
            //
            Load += (sender, args) =>
            {
                InitData();
                OnObjectToNewChanged();
            };
        }
    }
}