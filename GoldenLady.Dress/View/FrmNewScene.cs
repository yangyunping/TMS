using System;
using GoldenLady.Dress.Utils;
using GoldenLady.Dress.View.Template;
using GoldenLady.Standard.Dress;
using GoldenLady.Utility;
using GoldenLadyWS;

namespace GoldenLady.Dress.View
{
    public partial class FrmNewScene : FrmNew
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

        /// <summary>
        /// 构造
        /// </summary>
        /// <param name="theme">所属风格对象</param>
        public FrmNewScene(Theme theme)
        {
            InitializeComponent();
            if(null == theme)
            {
                throw new ArgumentNullException(@"theme", @"所属风格对象不能为空");
            }
            Theme = theme;
            BindEvents();
        }
        private new void BindEvents()
        {
            //
            // this
            //
            Shown += (sender, args) => txtObjectName.Focus();
        }
        protected override void InitData()
        {
            base.InitData();
            ObjectToNew = new Scene {ThemeID = Theme.ID};
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            Scene scene = (Scene)ObjectToNew;

            // 场景信息是否完整
            if(string.IsNullOrWhiteSpace(scene.Name))
            {
                MessageBoxEx.Error(@"请填写场景名称！");
                txtObjectName.Highlight();
                return;
            }

            // 检测场景是否已存在
            if(DressManager.IsSceneExists(scene))
            {
                MessageBoxEx.Error(string.Format(@"名称为'{0}'的场景已经存在！", scene.Name));
                txtObjectName.Highlight();
                return;
            }

            try
            {
                DressManager.NewScene(scene);
                OnSaveComplete();
            }
            catch(Exception ex)
            {
                MessageBoxEx.Error(ex.Message);
                OnSaveFailed();
            }
        }
    }
}