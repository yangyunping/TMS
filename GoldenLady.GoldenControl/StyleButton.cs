using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace GoldenLady.GoldenControl
{
    public partial class StyleButton : Control
    {
        private Color _normalBackColor;
        private Color _mouseEnterColor;
        private Color _mouseDownColor;
        public StyleButton()
        {
            InitializeComponent();
            SetStyle(ControlStyles.AllPaintingInWmPaint |
                     ControlStyles.DoubleBuffer | ControlStyles.OptimizedDoubleBuffer |
                     ControlStyles.UserPaint | ControlStyles.Selectable | ControlStyles.ResizeRedraw, true); //自定义绘制控件内容

            _normalBackColor = Color.LightBlue;
            _mouseEnterColor = Color.CornflowerBlue;
            _mouseDownColor = Color.DarkSalmon;

            MouseDown += (sender, f) => BackColor = _mouseDownColor;
            MouseUp += (sender, f) => BackColor = Color.LightBlue;

        }

        [Category("外观"), Description("鼠标进入时的背景色")]
        public Color MouseEnterColor
        {
            get { return _mouseEnterColor; }
            set { _mouseEnterColor = value; }
        }
        [Category("外观"), Description("鼠标点击时的背景色")]
        public Color MouseDownColor
        {
            get { return _mouseDownColor; }
            set { _mouseDownColor = value; }
        }

        #region 重载事件

        protected override void OnPaint(PaintEventArgs e)
        {
            DrawString(e.Graphics);
            //e.Graphics.SmoothingMode = SmoothingMode.HighQuality;
            //e.Graphics.CompositingQuality = CompositingQuality.HighQuality;
            //e.Graphics.PixelOffsetMode = PixelOffsetMode.HighQuality;
            //using(Pen p = new Pen(BackColor,1f))
            //{
            //    e.Graphics.DrawEllipse(p, ClientRectangle);
            //}
            base.OnPaint(e);
        }

        //大小
        protected override void OnResize(EventArgs e)
        {
            GraphicsPath gp = new GraphicsPath();
            gp.AddEllipse(ClientRectangle);
            Region = new Region(gp);
            base.OnResize(e);
        }

        protected override void OnMouseEnter(EventArgs e)
        {
            BackColor=_mouseEnterColor;
            base.OnMouseEnter(e);
        }

        protected override void OnMouseLeave(EventArgs e)
        {
            BackColor = _normalBackColor;
            base.OnMouseLeave(e);
        }

        #endregion

        void DrawString(Graphics g)
        {
            SizeF size = g.MeasureString(Text, Font);
            using (Brush b = new SolidBrush(ForeColor))
            {
                g.DrawString(Text, Font, b, (Width - size.Width)/2, (Height - size.Height)/2);
            }
        }
    }
}

