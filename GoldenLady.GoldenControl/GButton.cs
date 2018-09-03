using System;
using System.Drawing;
using System.Windows.Forms;

namespace GoldenLady.GoldenControl
{
    public class GButton:Button
    {
        public GButton()
        {
            FlatAppearance.BorderSize = 0;
            BackColor = FlatAppearance.MouseDownBackColor = FlatAppearance.MouseOverBackColor = Color.FromArgb(96, 00, 255, 255);
            FlatStyle = System.Windows.Forms.FlatStyle.Flat;
        }
        protected override void OnMouseEnter(EventArgs e)
        {
            FlatAppearance.BorderSize = 1;
            base.OnMouseEnter(e);
        }

        protected override void OnMouseLeave(EventArgs e)
        {
            FlatAppearance.BorderSize = 0;
            base.OnMouseLeave(e);
        }
    }
}
