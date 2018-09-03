using System.Drawing;

namespace GoldenLady.Utility
{
    /// <summary>
    /// 通用转换器，提供一些常用转换方法
    /// LiuHaiyang
    /// 2017.4.21
    /// </summary>
    public static class CommonConverter
    {
        /// <summary>
        /// 将字符串表示的尺寸转换成尺寸对象
        /// </summary>
        /// <param name="size">符串表示的尺寸</param>
        /// <returns>尺寸对象</returns>
        public static Size StringToSize(string size)
        {
            int flag = size.IndexOf(',');
            if(-1 == flag)
            {
                return new Size();
            }

            string strWidth = size.Substring(0, flag);
            string strHeight = size.Substring(flag + 1);
            int width, height;
            width = int.TryParse(strWidth, out width) ? width : 0;
            height = int.TryParse(strHeight, out height) ? height : 0;
            return new Size(width, height);
        }
        /// <summary>
        /// 将尺寸对象转换成字符串表示的尺寸
        /// </summary>
        /// <param name="size">尺寸对象</param>
        /// <returns>字符串表示的尺寸</returns>
        public static string SizeToString(Size size)
        {
            return string.Format(@"{0},{1}", size.Width, size.Height);
        }
    }
}