using System.Windows.Forms;

namespace GoldenLady.Utility
{
    /// <summary>
    /// 快捷提示窗口
    /// Design By: LiuHaiyang
    /// Date: 2017.1.5
    /// LastUpdate By: LiuHaiyang
    /// LastUpdateDate: 2017.1.14
    /// </summary>
    public static class MessageBoxEx
    {
        public static void Error(string content)
        {
            MessageBox.Show(content, @"错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        public static void Info(string content)
        {
            MessageBox.Show(content, @"信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        public static void Warning(string content)
        {
            MessageBox.Show(content, @"警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
        public static DialogResult Confirm(string content)
        {
            return MessageBox.Show(content, @"请确认", MessageBoxButtons.OKCancel, MessageBoxIcon.None);
        }
    }
}