using System;
using GoldenLady.Dress.Utils;
using GoldenLady.Dress.View.Template;
using GoldenLady.Standard.Dress;
using GoldenLady.Utility;
using GoldenLadyWS;

namespace GoldenLady.Dress.View
{
    public partial class FrmNewTheme : FrmNew
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

        /// <summary>
        /// 构造
        /// </summary>
        /// <param name="venue">所属场馆对象，不能为空</param>
        public FrmNewTheme(Venue venue)
        {
            InitializeComponent();
            if(null == venue)
            {
                throw new ArgumentNullException(@"venue", @"场馆参数不能为空");
            }
            Venue = venue;
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
            ObjectToNew = new Theme { VenueID = Venue.ID };
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            Theme theme = (Theme)ObjectToNew;

            // 风格信息是否完整
            if(string.IsNullOrWhiteSpace(theme.Name))
            {
                MessageBoxEx.Error(@"请填写风格名称！");
                txtObjectName.Highlight();
                return;
            }

            // 检测风格是否已存在
            if(DressManager.IsThemeExists(theme))
            {
                MessageBoxEx.Error(string.Format(@"名称为'{0}'的风格已经存在！", theme.Name));
                txtObjectName.Highlight();
                return;
            }

            try
            {
                DressManager.NewTheme(theme);
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