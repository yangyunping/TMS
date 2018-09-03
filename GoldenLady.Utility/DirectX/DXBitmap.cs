using System;
using System.IO;

using SharpDX;
using SharpDX.Direct2D1;

namespace GoldenLady.Utility
{
    public class DXBitmap:IDisposable
    {
        bool disposed;
        // Dispose(bool disposing) executes in two distinct scenarios.
        // If disposing equals true, the method has been called directly
        // or indirectly by a user's code. Managed and unmanaged resources
        // can be disposed.
        // If disposing equals false, the method has been called by the
        // runtime from inside the finalizer and you should not reference
        // other objects. Only unmanaged resources can be disposed.
        protected virtual void Dispose(bool disposing)
        {
            // Check to see if Dispose has already been called.
            if (!this.disposed)
            {
                // If disposing equals true, dispose all managed
                // and unmanaged resources.
                if (disposing)
                {
                    if (Bmp != null)
                    {
                        Bmp.Dispose();
                    }
                }
                // Dispose managed resources.

                // Note disposing has been done.
                disposed = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        ~DXBitmap()
        {
            // Do not re-create Dispose clean-up code here.
            // Calling Dispose(false) is optimal in terms of
            // readability and maintainability.
            Dispose(false);
        }

        

        /// <summary>
        /// 图
        /// </summary>
        public SharpDX.Direct2D1.Bitmap Bmp { get; private set; }

        /// <summary>
        /// 图片大小矩形
        /// </summary>
        public RectangleF BitmapRectangleF
        {
            get
            {
                return new SharpDX.RectangleF(0.0f, 0.0f, Size.Width, Size.Height);
            }
        }

        public Size2 Size { get { return Bmp.PixelSize; } }

        public DXBitmap(RenderTarget target, string imgFile)
        {
            if (!File.Exists(imgFile))
            {
                throw new FileNotFoundException(imgFile);
            }
            using (FileStream fs = new FileStream(imgFile, FileMode.Open, FileAccess.Read))
            {
                Bmp = GetBitmap(target, fs);
            }
        
        }
        public DXBitmap(RenderTarget target, Stream stream)
        {
            Bmp = GetBitmap(target, stream);
        }
        Bitmap GetBitmap(RenderTarget target, Stream stream)
        {
            using (SharpDX.WIC.ImagingFactory wicFactory = new SharpDX.WIC.ImagingFactory())
            {
                using (SharpDX.WIC.BitmapDecoder bmpDecoder = new SharpDX.WIC.BitmapDecoder(wicFactory, stream, SharpDX.WIC.DecodeOptions.CacheOnLoad))
                {
                    using (SharpDX.WIC.FormatConverter converter = new SharpDX.WIC.FormatConverter(wicFactory))
                    {
                        using (SharpDX.WIC.BitmapFrameDecode frameDecode = bmpDecoder.GetFrame(0))
                        {
                            converter.Initialize(frameDecode, SharpDX.WIC.PixelFormat.Format32bppBGR);
                            return SharpDX.Direct2D1.Bitmap.FromWicBitmap(target, converter);
                        }
                    }
                }
            }
        }
        public DXBitmap(RenderTarget target)
        {
            Bmp = new SharpDX.Direct2D1.Bitmap(target, target.PixelSize, new BitmapProperties(new PixelFormat(SharpDX.DXGI.Format.B8G8R8A8_UNorm, SharpDX.Direct2D1.AlphaMode.Premultiplied)));
        }
    }
}
