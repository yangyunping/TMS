using System;
using System.Drawing;
using System.IO;
using System.Net.Mime;
using System.Windows.Forms;
using GoldenLady.Dress.Utils;
using GoldenLady.Extension;
using GoldenLady.Utility;

namespace GoldenLady.Dress.View.Template
{
    public partial class FrmExampleShow : Form
    {
        const float MaxSizeRatio = 2.6f;
        const float MinSizeRatio = 0.8f;
        const float ZoomStep = 0.2F;
        readonly Color _backColor = Color.DarkGray;
        private int i = 0;
        private int dex;
        /// <summary>
        /// 当前图片
        /// </summary>
        Image _currentImage;
        /// <summary>
        /// mouseDown
        /// </summary>
        bool _isMouseDown = false;
        /// <summary>
        /// 
        /// </summary>
        Point _mousePoint;
        /// <summary>
        /// 默认大小
        /// </summary>
        Size _defaultSize;
        /// <summary>
        /// 当前放大缩小比率
        /// </summary>
        float _currentRatio = 1f;
        /// <summary>
        /// 当前图片绘制矩形
        /// </summary>
        Rectangle _currentRectangle;
        public FrmExampleShow(string image,int dexCnt)
        {
            InitializeComponent();
            dex = dexCnt;
            Rectangle screenArea = Screen.GetWorkingArea(this);
            int heiht = screenArea.Height;
            int wide = screenArea.Width;
            this.Size = new Size(wide * 3/8, heiht);
            this.StartPosition = FormStartPosition.CenterScreen;
            picExample.SizeMode = PictureBoxSizeMode.CenterImage;
            lblClose.Parent = picExample;
            picExample.Image = _currentImage = ImgSizeChange(Image.FromFile(image), picExample.Width, picExample.Height);
                //Image.FromFile(image).ZoomImage(picExample.Size);
            _currentRectangle = picExample.ClientRectangle;
            _defaultSize = _currentRectangle.Size;
            KeyDown += (sender, args) => this.Close();
            picExample.MouseWheel += new MouseEventHandler(picExample_MouseWhee);
        }
        private Image ImgSizeChange(Image sourceImage, int destWidth, int destHeight)
        {
            int width = 0, height = 0;
            int srcWidth = sourceImage.Width, srcHeight = sourceImage.Height;
            if (srcWidth > destWidth)//原图按长宽比例比定指宽高要宽
            {
                width = destWidth;
                height = ((srcHeight * 10000 / srcWidth) * destWidth) / 10000;
            }
            else//原图按长宽比例比定指宽高要高
            {
                height = destHeight;
                width = ((srcWidth * 10000 / srcHeight) * destHeight) / 10000;
            }
            Bitmap bitmap;//缩放的新图
            Rectangle drawRect;//新图的绘图矩形
            if (srcWidth > destWidth)//保留空白，以给定尺寸建立新图
            {
                bitmap = new Bitmap(destWidth, destHeight);
                drawRect = new Rectangle((destWidth - width) / 2, (destHeight - height) / 2, width, height);
            }
            else//不保留空白，就要以计算出来的尺寸建立新图
            {
                bitmap = new Bitmap(width, height);
                drawRect = new Rectangle(0, 0, width, height);
            }
            using (Graphics g = Graphics.FromImage(bitmap))
            {
                g.Clear(Color.DarkGray);
                g.CompositingQuality = System.Drawing.Drawing2D.CompositingQuality.HighQuality;
                g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
                g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
                GraphicsUnit srcUnit = GraphicsUnit.Pixel;
                g.DrawImage(sourceImage, drawRect, sourceImage.GetBounds(ref srcUnit), srcUnit);
            }
            GC.Collect();//强制回收资源
            return bitmap;
        }
        private void picExample_Paint(object sender, PaintEventArgs e)
        {
            BufferedGraphicsContext currentContext = BufferedGraphicsManager.Current;
            using (BufferedGraphics bufferG = currentContext.Allocate(e.Graphics, e.ClipRectangle))
            {
                using (Graphics g = bufferG.Graphics)
                {
                    g.CompositingQuality = System.Drawing.Drawing2D.CompositingQuality.HighQuality;
                    g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighSpeed;
                    g.PixelOffsetMode = System.Drawing.Drawing2D.PixelOffsetMode.HighQuality;
                    g.Clear(_backColor);
                    if (_currentImage != null)
                    {
                        g.DrawImage(_currentImage, _currentRectangle);
                    }
                    bufferG.Render(e.Graphics);
                }
            }
        }

        private void picExample_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left && _currentRectangle.Contains(e.Location))
            {
                _isMouseDown = true;
                Point p = PointToImage(e.Location);
                _mousePoint = new Point(-p.X, -p.Y);
            }
        }

        private void picExample_MouseMove(object sender, MouseEventArgs e)
        {
            this.SetStyle(ControlStyles.OptimizedDoubleBuffer |
                 ControlStyles.ResizeRedraw |
                 ControlStyles.AllPaintingInWmPaint, true);
            this.Cursor = e.Location.X < picExample.Width >> 1
                ? CustomizedCursor.Left : CustomizedCursor.Right;
            if (e.Button == MouseButtons.Left && _isMouseDown && _currentRectangle.Contains(e.Location))
            {
                Point p = e.Location;
                p.Offset(_mousePoint);
                _currentRectangle.Location = p;
                picExample.Invalidate();
            }
        }

        private void picExample_MouseUp(object sender, MouseEventArgs e)
        {
            _isMouseDown = false;
        }
        /// <summary>
        /// 鼠标滚轮 缩放图片
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void picExample_MouseWhee(object sender, MouseEventArgs e)
        {
            //判断鼠标是否在图片上
            if (!_currentRectangle.Contains(e.Location))
            {
                return;
            }
            if (e.Delta > 0)
            {
                //放大
                if (_currentRatio < MaxSizeRatio)
                {
                    _currentRatio += ZoomStep;
                }
            }
            else
            {
                //缩小
                if (_currentRatio > MinSizeRatio)
                {
                    _currentRatio -= ZoomStep;
                }
            }
            //确定鼠标矢量位置
            //鼠标对应图片的位置
            Point mouseInImgPoint = PointToImage(e.Location);
            float vectorX = ((float)mouseInImgPoint.X) / _currentRectangle.Width;
            float vectorY = ((float)mouseInImgPoint.Y) / _currentRectangle.Height;
            //新尺寸
            Size newSize = new Size((int)(_defaultSize.Width * _currentRatio), (int)(_defaultSize.Height * _currentRatio));
            //缩放后的矩形,保持原点不变
            _currentRectangle = new Rectangle(_currentRectangle.Location, newSize);//
            //完成缩放后要进行平移的变量
            //缩放前鼠标对应的点
            Point newMousePoint = new Point((int)(_currentRectangle.Width * vectorX), (int)(_currentRectangle.Height * vectorY));
            //平移
            _currentRectangle.Offset(mouseInImgPoint.X - newMousePoint.X, mouseInImgPoint.Y - newMousePoint.Y);
            picExample.Invalidate(true);
        }

        Point PointToImage(Point p)
        {
            if (_currentRectangle.Contains(p))
            {
                p.Offset(-_currentRectangle.X, -_currentRectangle.Y);
                return p;
            }
            return Point.Empty;
        }
        private void lblClose_MouseEnter(object sender, EventArgs e)
        {
            lblClose.BackColor = Color.Red;
            this.Cursor = DefaultCursor;
        }

        private void lblClose_MouseLeave(object sender, EventArgs e)
        {
            lblClose.BackColor = Color.Transparent;
        }

        private void lblClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FrmExampleShow_Shown(object sender, EventArgs e)
        {
            picExample.Focus();
        }

        private void picExample_Click(object sender, EventArgs e)
        {
            if (AllKindsData.ImgPathLst == null)
            {
                return;
            }
            if (dex >= AllKindsData.ImgPathLst.Count)
            {
                dex = 0;
            }
            if (dex < 0)
            {
                dex = AllKindsData.ImgPathLst.Count - 1;
            }
            if (this.Cursor == CustomizedCursor.Left)
            {
                picExample.Image = _currentImage = ImgSizeChange(Image.FromFile(AllKindsData.ImgPathLst.ToArray()[dex]), picExample.Width, picExample.Height);
                dex--;
            }
            else if (this.Cursor == CustomizedCursor.Right)
            {
                picExample.Image = _currentImage = ImgSizeChange(Image.FromFile(AllKindsData.ImgPathLst.ToArray()[dex]), picExample.Width, picExample.Height);
                dex++;
            }
        }
    }
}
