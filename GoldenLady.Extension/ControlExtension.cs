using System.Windows.Forms;

namespace GoldenLady.Extension
{
    /// <summary>
    /// Winform控件扩展
    /// LiuHaiyang
    /// 2017.4.21
    /// </summary>
    public static class ControlExtension
    {
        /// <summary>
        /// 获取控件所在的容器窗体
        /// </summary>
        /// <param name="ctrl">控件对象</param>
        /// <returns>如果存在，返回容器窗体对象，不存在返回null</returns>
        public static Form GetParentForm(this Control ctrl)
        {
            Control obj = ctrl;
            Form frm;
            do
            {
                obj = obj.Parent;
                if(null == obj)
                {
                    return null;
                }
                frm = obj as Form;
            }
            while(frm == null);
            return frm;
        }
    }
}