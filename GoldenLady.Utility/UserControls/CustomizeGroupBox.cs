using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace GoldenLady.Utility.UserControls
{
    /// <summary>
    /// 可定制的GroupBox
    /// 1.标题字体颜色
    /// 2.边框颜色
    /// Design By LiuHaiyang
    /// 2017.3.8
    /// </summary>
    public partial class CustomizeGroupBox : GroupBox
    {
        private Color _titleFontColor = Color.Black;
        private Color _borderColor = Color.Black;

        [Browsable(true)]
        [Description("标题字体颜色"), Category("外观")]
        public Color TitleFontColor
        {
            get { return _titleFontColor; }
            set { _titleFontColor = value; }
        }

        [Browsable(true)]
        [Description("边框颜色"), Category("外观")]
        public Color BorderColor
        {
            get { return _borderColor; }
            set { _borderColor = value; }
        }

        public CustomizeGroupBox()
        {
            InitializeComponent();
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            Size fontSize = e.Graphics.MeasureString(Text, Font).ToSize();
            const int padding = 1;
            const int widthBegin = 10;
            int heightBegin = fontSize.Height >> 1;
            e.Graphics.Clear(BackColor);
            e.Graphics.SmoothingMode = SmoothingMode.HighQuality;
            using(Brush brush = new SolidBrush(TitleFontColor))
            {
                e.Graphics.DrawString(Text, Font, brush, widthBegin + padding, 0);
            }
            using(Pen borderPen = new Pen(BorderColor))
            {
                e.Graphics.DrawLine(borderPen, 0, heightBegin, widthBegin, heightBegin);
                e.Graphics.DrawLine(borderPen, fontSize.Width + widthBegin - padding, heightBegin, Width - padding, heightBegin);
                e.Graphics.DrawLine(borderPen, 0, heightBegin, 0, Height - padding);
                e.Graphics.DrawLine(borderPen, 0, Height - padding, Width - padding, Height - padding);
                e.Graphics.DrawLine(borderPen, Width - padding, heightBegin, Width - padding, Height - padding);
            }
        }
    }
}