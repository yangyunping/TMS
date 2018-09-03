using System;
using System.Windows.Forms;

namespace GoldenLady.Utility.UserControls
{
    /// <summary>
    /// 收钱用的TextBox，只能输入数字和小数点
    /// Design By LiuHaiyang
    /// 2017.1.4
    /// </summary>
    public partial class CashTextBox : CustomizedTextBox
    {
        private ToolTip _tip;
        public CashTextBox()
        {
            InitializeComponent();
            InitEvents();
        }
        private void InitEvents()
        {
            KeyPress += (sender, args) =>
            {
                args.Handled = !(char.IsDigit(args.KeyChar) || args.KeyChar == '-' || args.KeyChar == '.' || args.KeyChar == (char)Keys.Delete || args.KeyChar == (char)Keys.Back);
                if (!args.Handled) return;
                if (null == _tip)
                {
                    _tip = new ToolTip
                           {
                               IsBalloon = true,
                               ToolTipIcon = ToolTipIcon.Error,
                               ToolTipTitle = @"错误",
                               UseFading = true
                           };
                }
                _tip.SetToolTip(this, @"您只能在此处输入数字和小数点！");
            };
        }
    }
}