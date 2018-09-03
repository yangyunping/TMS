using System.Windows.Forms;
using GoldenLady.Dress.Utils;
using GoldenLady.Dress.View.Template;

namespace GoldenLady.Dress.View
{
    /// <summary>
    /// 配置管理窗口
    /// LiuHaiyang
    /// 2017.5.8
    /// </summary>
    public partial class FrmConfig : FrmBackWork
    {
        public FrmConfig()
        {
            InitializeComponent();
        }

        private void FrmConfig_Load(object sender, System.EventArgs e)
        {
            if(null == DressManager.ConfigManager.Config.BeforeMoveCache)
            {
                DressManager.ConfigManager.Config.BeforeMoveCache = () =>
                {
                    OpenWaitFrm();
                    UpdateWaitMessage(@"正在迁移缓存文件");
                };
            }
            if(null == DressManager.ConfigManager.Config.AfterMoveCache)
            {
                DressManager.ConfigManager.Config.AfterMoveCache = () => Invoke(new MethodInvoker(CloseWaitFrm));
            }

            prgConfig.SelectedObject = DressManager.ConfigManager.Config;
        }
    }
}