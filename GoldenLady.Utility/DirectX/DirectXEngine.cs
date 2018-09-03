using System;
using System.IO;
using System.Threading;
using System.Windows.Forms;

using SharpDX;
using SharpDX.Direct2D1;
using SharpDX.DXGI;
using DXFactory = SharpDX.Direct2D1.Factory;

namespace GoldenLady.Utility
{
    public class DirectXEngine:IDisposable
    {
        bool disposed = false;
        /// <summary>
        /// DXGI 格式。
        /// </summary>
        private static readonly Format Format = Format.B8G8R8A8_UNorm;
        /// <summary>
        /// Direct2D 的像素格式。
        /// </summary>
        public static readonly PixelFormat D2PixelFormat = new PixelFormat(Format, SharpDX.Direct2D1.AlphaMode.Premultiplied);
        /// <summary>
        /// 互斥用的
        /// </summary>
        object _lockObj = new object();
        float _opacity = 0f;
        /// <summary>
        /// 取消线程
        /// </summary>
        CancellationTokenSource _cancelTask = new CancellationTokenSource();
        /// <summary>
        /// 前一张背景图
        /// </summary>
        DXBitmap _preBmp;
        /// <summary>
        /// 背景图
        /// </summary>
        DXBitmap _bmp;
        /// <summary>
        /// Hwnd 渲染目标。
        /// </summary>
        private WindowRenderTarget hwndRenderTarget;
        /// <summary>
        /// Hwnd 画刷。
        /// </summary>
        //private Brush hwndBrush;
        /// <summary>
        /// 字体格式
        /// </summary>
        //SharpDX.DirectWrite.TextFormat _textFormat;
        /// <summary>
        /// 窗口控件
        /// </summary>
        Control _ctrl;
        /// <summary>
        /// 窗口大小
        /// </summary>
        Size2 RenderTargetClientSize
        {
            get { return new Size2(_ctrl.ClientSize.Width, _ctrl.ClientSize.Height); }
        }
        /// <summary>
        /// 用窗口句柄初始化
        /// </summary>
        /// <param name="hwnd">绘制窗口句柄</param>
        public DirectXEngine(Control ctrl)
        {
            _ctrl = ctrl;
            _cancelTask = new CancellationTokenSource();
            InitHwndRenderTarget();
            _bmp = new DXBitmap(hwndRenderTarget);
        }

        /// <summary>
        /// 初始化 HwndRenderTarget。
        /// </summary>
        private void InitHwndRenderTarget()
        {
            // 创建 Direct2D 单线程工厂。
            using (DXFactory dxFactory = new DXFactory(FactoryType.SingleThreaded))
            {
                // 渲染参数。
                RenderTargetProperties renderProps = new RenderTargetProperties
                {
                    PixelFormat = D2PixelFormat,
                    Usage = RenderTargetUsage.None,
                    Type = RenderTargetType.Default
                };
                // 渲染目标属性。
                HwndRenderTargetProperties hwndProps = new HwndRenderTargetProperties()
                {
                    // 承载控件的句柄。
                    Hwnd = _ctrl.Handle,
                    // 控件的尺寸。
                    PixelSize = RenderTargetClientSize,
                    PresentOptions = PresentOptions.None,
                };
                // 渲染目标。
                hwndRenderTarget = new WindowRenderTarget(dxFactory, renderProps, hwndProps)
                {
                    AntialiasMode = AntialiasMode.PerPrimitive,
                };
            }
            // 初始化画刷资源。
            //hwndBrush = new SolidColorBrush(hwndRenderTarget, Color.Black);

            //_textFormat = new SharpDX.DirectWrite.TextFormat(new SharpDX.DirectWrite.Factory(), _ctrl.Font.Name, 15);

            // 在控件大小被改变的时候必须改变渲染目标的大小，
            // 否则会导致绘制结果被拉伸，引起失真。
            _ctrl.SizeChanged += (sender, e) =>
            {
                lock (_lockObj)
                {
                    hwndRenderTarget.Resize(RenderTargetClientSize);
                }
            };
            _ctrl.HandleDestroyed += (sender, e) => _cancelTask.Cancel(true);
        }

        public void ChangeBitmap(string imageFileName)
        {
            if (string.IsNullOrWhiteSpace(imageFileName))
            {
                throw new ArgumentException(imageFileName);
            }
            if (!File.Exists(imageFileName))
            {
                throw new FileNotFoundException(imageFileName);
            }
            lock (_lockObj)
            {
                _preBmp = _bmp;//当前图片变成前一张图片
                _bmp = new DXBitmap(hwndRenderTarget, imageFileName);//新图片赋值给当前图片
                _opacity = 1f;//
            }
        }
        public void ChangeBitmap(Stream s)
        {
            lock (_lockObj)
            {
                _preBmp = _bmp;//当前图片变成前一张图片
                _bmp = new DXBitmap(hwndRenderTarget, s);//新图片赋值给当前图片
                _opacity = 1f;//
            }
        }
        public void ChangeBitmap(byte[] data)
        {
            using(MemoryStream ms = new MemoryStream(data))
            {
                ChangeBitmap(ms);
            }
        }
        /// <summary>
        /// 为了图片不变形，要等比缩放图片，些处计算图片绘制在渲染目标中的矩形
        /// </summary>
        /// <param name="tagSize">渲染目标尺寸</param>
        /// <param name="bmpSize">图片尺寸</param>
        /// <returns></returns>
        RectangleF ZoomBitmap(Size2 tagSize, Size2 bmpSize)
        {
            if (tagSize.Width == 0 || tagSize.Height == 0)
            {
                return new RectangleF(0f, 0f, 1f, 1f);
            }
            float _width, _height;
            float bmpWidth = bmpSize.Width, bmpHeight = bmpSize.Height;
            if (bmpHeight / bmpWidth < (float)tagSize.Height / tagSize.Width)
            {
                _width = tagSize.Width;
                _height = bmpHeight / bmpWidth * tagSize.Width;
            }
            else
            {
                _height = tagSize.Height;
                _width = bmpWidth / bmpHeight * tagSize.Height;
            }
            return new SharpDX.RectangleF((tagSize.Width - _width) / 2, (tagSize.Height - _height) / 2, _width, _height);
        }

        public void Run()
        {
            SharpDX.Threading.TaskUtil.Run(() =>
            {
                while (!_cancelTask.IsCancellationRequested)
                {
                    lock (_lockObj)
                    {
                        hwndRenderTarget.BeginDraw();
                        hwndRenderTarget.Clear(Color.White);

                        if (_opacity > 0.0f)//表示切换中
                        {
                            RectangleF preRenderRect = ZoomBitmap(RenderTargetClientSize, _preBmp.Size);
                            hwndRenderTarget.DrawBitmap(_preBmp.Bmp, preRenderRect, _opacity, BitmapInterpolationMode.NearestNeighbor, _preBmp.BitmapRectangleF);

                            _opacity -= 0.02f;
                        }
                        else
                        {
                            if (_preBmp != null)
                            {
                                _preBmp.Dispose();
                            }
                        }
                        RectangleF renderRect = ZoomBitmap(RenderTargetClientSize, _bmp.Size);
                        hwndRenderTarget.DrawBitmap(_bmp.Bmp, renderRect, 1f - _opacity, BitmapInterpolationMode.NearestNeighbor, _bmp.BitmapRectangleF);

                        hwndRenderTarget.EndDraw();
                    }
                    Thread.Sleep(40);
                }
            });
        }
        public void Stop()
        {
            _cancelTask.Cancel(true);
        }

        // Implement IDisposable.
        // Do not make this method virtual.
        // A derived class should not be able to override this method.
        public void Dispose()
        {
            Dispose(true);
            // This object will be cleaned up by the Dispose method.
            // Therefore, you should call GC.SupressFinalize to
            // take this object off the finalization queue
            // and prevent finalization code for this object
            // from executing a second time.
            GC.SuppressFinalize(this);
        }

        // Use C# destructor syntax for finalization code.
        // This destructor will run only if the Dispose method
        // does not get called.
        // It gives your base class the opportunity to finalize.
        // Do not provide destructors in types derived from this class.
        ~DirectXEngine()
        {
            // Do not re-create Dispose clean-up code here.
            // Calling Dispose(false) is optimal in terms of
            // readability and maintainability.
            Dispose(false);
        }

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
                    // Dispose managed resources.

                    if (hwndRenderTarget != null)
                    {
                        hwndRenderTarget.Dispose();
                        hwndRenderTarget = null;
                    }
                    if (_preBmp != null)
                    {
                        _preBmp.Dispose();
                        _preBmp = null;
                    }

                    if (_bmp != null)
                    {
                        _bmp.Dispose();
                        _bmp = null;
                    }

                }

                // Call the appropriate methods to clean up
                // unmanaged resources here.
                // If disposing is false,
                // only the following code is executed.

                // Note disposing has been done.
                disposed = true;

            }
        }

    }
}
