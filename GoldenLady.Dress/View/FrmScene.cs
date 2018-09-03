using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using GoldenLady.Dress.Utils;
using GoldenLady.Dress.View.Template;
using GoldenLady.Standard.Dress;
using GoldenLady.Utility;
using GoldenLadyWS;

namespace GoldenLady.Dress.View
{
    internal partial class FrmScene : FrmManage
    {
        private Theme _theme;

        private Theme Theme
        {
            get { return _theme; }
            set
            {
                _theme = value;
                OnThemeChanged();
            }
        }

        private void OnThemeChanged()
        {
            txtThemeName.Text = Theme.Name;
        }

        protected override void OnSelectedObjectChanged()
        {
            base.OnSelectedObjectChanged();
            btnManagePhoto.Enabled = null != SelectedObject;
        }

        public FrmScene(Theme theme)
        {
            InitializeComponent();
            if(null == theme)
            {
                throw new ArgumentNullException(@"theme", @"所属风格对象不能为空");
            }
            Theme = theme;
        }

        protected override void InitData()
        {
            LoadScenes();
        }
        protected override void RefreshData()
        {
            LoadScenes();
        }
        private void LoadScenes()
        {
            Objects = DressManager.GetScenes(Theme).Cast<ManagedObject>().ToList();
        }
        private void ProcDelete()
        {
            try
            {
                DressManager.DeleteScene((Scene)SelectedObject);

                Invoke(new MethodInvoker(OnDeleteComplete));
            }
            catch(Exception ex)
            {
                Invoke(new MethodInvoker(() =>
                {
                    MessageBoxEx.Info(string.Format(@"删除场景失败！{0}{1}", Environment.NewLine, ex.Message));
                }));
            }
        }

        private void btnNewObject_Click(object sender, EventArgs e)
        {
            new FrmNewScene(Theme).ShowDialog();
            RefreshData();
        }
        private void btnSaveObject_Click(object sender, EventArgs e)
        {
            Scene SelectedScene = (Scene)SelectedObject;

            // 场景信息是否完整
            if(string.IsNullOrWhiteSpace(SelectedScene.Name))
            {
                MessageBoxEx.Error(@"请填写场景名称！");
                txtObjectName.Highlight();
                return;
            }

            try
            {
                DressManager.UpdateScene(SelectedScene);
                OnSaveComplete();
            }
            catch(Exception ex)
            {
                MessageBoxEx.Error(ex.Message);
                OnSaveFailed();
            }
        }
        private void btnDeleteObject_Click(object sender, EventArgs e)
        {
            // 删除确认
            if(DialogResult.OK != MessageBoxEx.Confirm(@"确定要删除该场景吗？"))
            {
                return;
            }
            // 开始删除
            ProcDelete();
        }

        private void btnManagePhoto_Click(object sender, EventArgs e)
        {
            new FrmScenePhoto((Scene)SelectedObject).ShowDialog();
        }
    }
}