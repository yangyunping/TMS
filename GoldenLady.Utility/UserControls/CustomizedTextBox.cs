using System.Windows.Forms;

namespace GoldenLady.Utility.UserControls
{
    /// <summary>
    /// 自定义的文本框 具有部分特性
    /// Designed by: LiuHaiyang
    /// 2017.3.23
    /// </summary>
    public partial class CustomizedTextBox : TextBox
    {
        public CustomizedTextBox()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 高亮文本
        /// </summary>
        public void Highlight()
        {
            Focus();
            SelectAll();
        }
    }
}