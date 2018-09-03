using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace GoldenLady.Utility.UserControls
{
    /// <summary>
    /// 透明区块，可以自定义绘制内容
    /// Designed by: LiuHaiyang
    /// 2017.4.12
    /// </summary>
    public partial class TransparentBlock : UserControl
    {
        private int _alpha = 50;
        private int _mouseOverAlpha = 100;
        private Color _baseColor = Color.Gray;

        /// <summary>
        /// 透明区块本身的底色
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Always), Browsable(true)]
        [Category("自定义属性"), Description("控件本身的底色")]
        public Color BaseColor
        {
            get { return _baseColor; }
            set { _baseColor = value; }
        }

        /// <summary>
        /// 不透明度
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Always), Browsable(true)]
        [Category("自定义属性"), Description("控件的不透明度")]
        public int Alpha
        {
            get { return _alpha; }
            set { _alpha = value; }
        }

        /// <summary>
        /// 鼠标放在控件上时的不透明度
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Always), Browsable(true)]
        [Category("自定义属性"), Description("鼠标放在控件上时的不透明度")]
        public int MouseOverAlpha
        {
            get { return _mouseOverAlpha; }
            set { _mouseOverAlpha = value; }
        }

        /// <summary>
        /// 鼠标放在控件上时改变透明度
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Always), Browsable(true)]
        [Category("自定义属性"), Description("鼠标放在控件上时改变透明度")]
        public bool ChangeAlphaWhenMouseOver { get; set; }

        /// <summary>
        /// 用户自定义的绘制内容
        /// </summary>
        public Action<PaintEventArgs, TransparentBlock> UserDraw { get; set; }

        /// <summary>
        /// 当前用于绘制控件的透明度
        /// </summary>
        public int CurrentAlpha { get; set; }

        public TransparentBlock()
        {
            InitializeComponent();
            Init();
            BindEvents();
        }
        private void Init()
        {
            CurrentAlpha = Alpha;
            SetStyle(ControlStyles.UserPaint | 
                            ControlStyles.AllPaintingInWmPaint | 
                            ControlStyles.Opaque | 
                            ControlStyles.SupportsTransparentBackColor
                             , true); // 不能使用双缓存属性
        }
        private void BindEvents()
        {
            MouseEnter += (sender, args) =>
            {
                if(!ChangeAlphaWhenMouseOver)
                {
                    return;
                }
                CurrentAlpha = MouseOverAlpha;
                if(Parent != null)
                {
                    Parent.Invalidate(true); // 确保父容器先重绘，不然会在之前已经透明化的状态下继续重绘导致叠加。
                }
                else
                {
                    Invalidate();
                }
            };
            MouseLeave += (sender, args) =>
            {
                if(!ChangeAlphaWhenMouseOver)
                {
                    return;
                }
                CurrentAlpha = Alpha;
                if(Parent != null)
                {
                    Parent.Invalidate(true); // 确保父容器先重绘，不然会在之前已经透明化的状态下继续重绘导致叠加。
                }
                else
                {
                    Invalidate();
                }
            };
        }

        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams cp = base.CreateParams;
                cp.ExStyle |= 0x00000020; //开启 WS_EX_TRANSPARENT, 使控件支持透明
                return cp;
            }
        }
        protected override void OnPaint(PaintEventArgs e)
        {
                e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
                using(Brush brush = new SolidBrush(Color.FromArgb(CurrentAlpha, BaseColor)))
                {
                    e.Graphics.FillRectangle(brush, 0, 0, Size.Width, Size.Height);
                    if(UserDraw != null)
                    {
                        UserDraw(e, this);
                    }
                }
        }
    }
}