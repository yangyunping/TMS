using System.Security.Cryptography;
using System.Windows.Forms;

namespace GoldenLady.Utility.UserControls
{
    /// <summary>
    /// 只能输入数字的TextBox
    /// Design By LiuHaiyang
    /// 2017.3.9
    /// </summary>
    public partial class NumericTextBox : CustomizedTextBox
    {
        private ToolTip _tip;
        public NumericTextBox()
        {
            InitializeComponent();
            InitEvents();
        }
        private void InitEvents()
        {
            KeyPress += (sender, args) =>
            {
                if((ModifierKeys & Keys.Control) == Keys.Control) // 保证Ctrl+C和Ctrl+V的复制粘贴功能等可以使用
                {
                    args.Handled = false;
                    return;
                }

                args.Handled = !(char.IsDigit(args.KeyChar) || args.KeyChar == (char)Keys.Delete || args.KeyChar == (char)Keys.Back);
                if(!args.Handled)
                {
                    return;
                }
                if(null == _tip)
                {
                    _tip = new ToolTip
                    {
                        IsBalloon = true,
                        ToolTipIcon = ToolTipIcon.Error,
                        ToolTipTitle = @"错误",
                        UseFading = true
                    };
                }
                //_tip.SetToolTip(this, @"您只能在此处输入数字！");
            };
        }
    }
}