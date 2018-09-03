using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;

namespace GoldenLady.Extension
{
    public enum ImageQuality
    {
        Heigh,
        Medium,
        Low
    }
    /// <summary>
    /// 图片的一般处理
    /// </summary>
    public static class ImageExtension
    {
        /// <summary>
        /// 将图片缩放到指定的大小,默认不留边。
        /// </summary>
        /// <param name="sourceImage">原始图片</param>
        /// <param name="destSize">指定大小</param>
        /// <returns></returns>
        public static Image ZoomImage(this Image sourceImage, Size destSize)
        {
            return sourceImage.ZoomImage(destSize, false, Color.Transparent);
        }
        /// <summary>
        ///  将图片缩放到指定的大小
        /// </summary>
        /// <param name="sourceImage">原始图片</param>
        /// <param name="destSize">指定大小</param>
        /// <param name="keepSpace">是否保留非图片的边框</param>
        /// <returns></returns>
        public static Image ZoomImage(this Image sourceImage, Size destSize, bool keepSpace)
        {
            return sourceImage.ZoomImage(destSize, keepSpace, Color.Transparent);
        }
        /// <summary>
        /// 将图片缩放到指定的大小
        /// </summary>
        /// <param name="sourceImage">原始图片</param>
        /// <param name="destSize">指定大小</param>
        /// <param name="keepSpace">是否保留非图片的边框</param>
        /// <param name="backColor">背景色</param>
        /// <returns></returns>
        public static Image ZoomImage(this Image sourceImage, Size destSize, bool keepSpace, Color backColor)
        {
            return sourceImage.ZoomImage(destSize.Width, destSize.Height, keepSpace, backColor);
        }
        /// <summary>
        /// 将图片缩放到指定的大小
        /// </summary>
        /// <param name="sourceImage">原始图片</param>
        /// <param name="destWidth">指定的宽</param>
        /// <param name="destHeight">指定的高</param>
        /// <param name="keepSpace">是否保留非图片的边框</param>
        /// <returns></returns>
        public static Image ZoomImage(this Image sourceImage, int destWidth, int destHeight, bool keepSpace)
        {
            return sourceImage.ZoomImage(destWidth, destHeight, keepSpace, Color.Transparent);
        }
        /// <summary>
        /// 将图片缩放到指定的大小
        /// </summary>
        /// <param name="sourceImage">原始图片</param>
        /// <param name="destWidth">指定的宽</param>
        /// <param name="destHeight">指定的高</param>
        /// <param name="keepSpace">是否保留非图片的边框</param>
        /// <param name="backColor">背景色</param>
        /// <returns></returns>
        public static Image ZoomImage(this Image sourceImage, int destWidth, int destHeight, bool keepSpace, Color backColor)
        {
            int _width = 0, _height = 0;
            int srcWidth = sourceImage.Width, srcHeight = sourceImage.Height;
            if (srcHeight * 10000 / srcWidth < destHeight * 10000 / destWidth)//原图按长宽比例比定指宽高要宽
            {
                _width = destWidth;
                _height = ((srcHeight * 10000 / srcWidth) * destWidth) / 10000;
            }
            else//原图按长宽比例比定指宽高要高
            {
                _height = destHeight;
                _width = ((srcWidth * 10000 / srcHeight) * destHeight) / 10000;
            }
            Bitmap bitmap;//缩放的新图
            Rectangle drawRect;//新图的绘图矩形
            if (keepSpace)//保留空白，以给定尺寸建立新图
            {
                bitmap = new Bitmap(destWidth, destHeight);
                drawRect = new Rectangle((destWidth - _width) / 2, (destHeight - _height) / 2, _width, _height);
            }
            else//不保留空白，就要以计算出来的尺寸建立新图
            {
                bitmap = new Bitmap(_width, _height);
                drawRect = new Rectangle(0, 0, _width, _height);
            }
            using (Graphics g = Graphics.FromImage(bitmap))
            {
                g.Clear(backColor);
                g.CompositingQuality = System.Drawing.Drawing2D.CompositingQuality.HighQuality;
                g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
                g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
                GraphicsUnit srcUnit = GraphicsUnit.Pixel;
                g.DrawImage(sourceImage, drawRect, sourceImage.GetBounds(ref srcUnit), srcUnit);
            }
            GC.Collect();//强制回收资源
            return bitmap;
        }

        /// <summary>
        /// 获取图片的文件格式
        /// </summary>
        /// <param name="img">图片对象</param>
        /// <returns>文件格式</returns>
        public static ImageFormat GetFormat(this Image img)
        {
            ImageFormat[] list = 
            {
                ImageFormat.Bmp, 
                ImageFormat.Emf, 
                ImageFormat.Exif, 
                ImageFormat.Gif, 
                ImageFormat.Icon, 
                ImageFormat.Jpeg, 
                ImageFormat.MemoryBmp,
                ImageFormat.Png,
                ImageFormat.Tiff,
                ImageFormat.Wmf
            };
            return list.FirstOrDefault(format => img.RawFormat.Equals(format));
        }
    }
}
