using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace GoldenLady.Utility.GoldenControl
{
    public class GoldenComboBox:ComboBox
    {
        public GoldenComboBox()
        {
            DrawMode = DrawMode.OwnerDrawVariable;
            IntegralHeight = false;
        }

        protected override void OnDrawItem(DrawItemEventArgs e)
        {
            if ((e.State & DrawItemState.Selected) == DrawItemState.Selected)
            {
                using (Brush _brush = new SolidBrush(SystemColors.Highlight))
                {
                    e.Graphics.FillRectangle(_brush, e.Bounds);
                }
            }
            else
            {
                using (Brush _brush = new SolidBrush(BackColor))
                {
                    e.Graphics.FillRectangle(_brush, e.Bounds);
                }
            }
            if (e.Index >= 0)
            {
                using (Brush _brush = new SolidBrush(ForeColor))
                {
                    using (StringFormat sf = new StringFormat())
                    {
                        sf.LineAlignment = StringAlignment.Center;
                        sf.FormatFlags = StringFormatFlags.NoWrap;
                        sf.Trimming = StringTrimming.None;
                        string _text = GetItemText(Items[e.Index]);
                        e.Graphics.DrawString(_text, Font, _brush, e.Bounds, sf);
                    }
                } 
            }
            base.OnDrawItem(e);
        }
    }
}
