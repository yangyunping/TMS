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
    internal partial class FrmTheme : FrmManage
    {
        private Venue _venue;

        private Venue Venue
        {
            get { return _venue; }
            set
            {
                _venue = value;
                OnVenueChanged();
            }
        }

        private void OnVenueChanged()
        {
            txtVenueName.Text = Venue.Name;
        }
        protected override void OnSelectedObjectChanged()
        {
            base.OnSelectedObjectChanged();
            btnManageScene.Enabled = null != SelectedObject;
        }

        public FrmTheme(Venue venue)
        {
            InitializeComponent();
            if(null == venue)
            {
                throw new ArgumentNullException(@"venue", @"场馆参数不能为空");
            }
            Venue = venue;
        }

        protected override void InitData()
        {
            //OpenWaitFrm();
            LoadThemes();
            //CloseWaitFrm();
        }
        protected override void RefreshData()
        {
            //OpenWaitFrm();
            LoadThemes();
            //CloseWaitFrm();
        }
        private void LoadThemes() 
        {
            Objects = ErpService.DressManagement.GetThemes(Venue).Cast<ManagedObject>().ToList();
        }
        private void ProcDelete()
        {
            try
            {
                //UpdateWaitMessage(@"删除数据库记录及对应文件夹");
                IEnumerable<Scene> themes = DressManager.GetScenes((Theme)SelectedObject);
                foreach (Scene theme in themes)
                {
                    DressManager.DeleteScene(theme);
                }
                DressManager.DeleteThemeObject((Theme)SelectedObject);
                //Invoke()
                //UpdateWaitMessage(@"加载数据");
                Invoke(new MethodInvoker(OnDeleteComplete));
            }
            catch(Exception ex)
            {
                Invoke(new MethodInvoker(() =>
                {
                    //CloseWaitFrm();
                    MessageBoxEx.Info(string.Format(@"删除风格失败！{0}{1}", Environment.NewLine, ex.Message));
                    //Close(); // 关闭窗口防止发生其他意外
                }));
            }
        }

        private void btnNewObject_Click(object sender, EventArgs e)
        {
            new FrmNewTheme(Venue).ShowDialog();
            RefreshData();
        }
        private void btnSaveObject_Click(object sender, EventArgs e)
        {
            Theme selectedTheme = (Theme)SelectedObject;

            // 风格信息是否完整
            if(string.IsNullOrWhiteSpace(selectedTheme.Name))
            {
                MessageBoxEx.Error(@"请填写风格名称！");
                txtObjectName.Highlight();
                return;
            }

            try
            {
                DressManager.UpdateTheme(selectedTheme);
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
            if (DialogResult.OK != MessageBoxEx.Confirm(@"请注意！
删除风格后，从属于该风格的所有场景也将会被删除！
建议使用“停用”功能。
确定要删除该风格吗？"))
            {
                return;
            }

            // 开始删除
            ProcDelete();
        }

        private void btnManageScene_Click(object sender, EventArgs e)
        {
            FrmScene frmScene = new FrmScene((Theme)SelectedObject) { Name = btnManageScene.Text, Text = btnManageScene.Text, Dock = DockStyle.Fill, AutoScaleMode = AutoScaleMode.None };
            FrmDressBase frmDressBase = new FrmDressBase() { Text = btnManageScene.Text };
            frmDressBase.Controls.Add(frmScene);
            frmDressBase.ShowDialog();
        }
    }
}