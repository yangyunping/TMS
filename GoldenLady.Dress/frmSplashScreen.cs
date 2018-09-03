using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace GoldenLady.Dress
{
    internal partial class frmSplashScreen : Form
    {
        bool _isMouseDown = false;
        Point _mousePoint;

        internal frmSplashScreen()
        {
            InitializeComponent();
        }

        //protected override void OnHandleCreated(EventArgs e)
        //{
        //    if (this.Handle != IntPtr.Zero)
        //    {
        //        IntPtr hWndDeskTop = Utility.WinAPI.GetDesktopWindow();
        //        Utility.WinAPI.SetParent(this.Handle, hWndDeskTop);
        //    }
        //    base.OnHandleCreated(e);
        //}

        internal void UpdateTest(string text)
        {
            if (this.lblCaption.InvokeRequired)
            {
                this.lblCaption.Invoke(new Action<string>(caption => this.lblCaption.Text = caption), text);
            }
            else
            {
                this.lblCaption.Text = text;
            }
        }

        private void frmSplashScreen_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                _isMouseDown = true;
                _mousePoint = e.Location;
            }
        }

        private void frmSplashScreen_MouseUp(object sender, MouseEventArgs e)
        {
            _isMouseDown = false;
            _mousePoint = Point.Empty;
        }

        private void frmSplashScreen_MouseMove(object sender, MouseEventArgs e)
        {
            if (_isMouseDown)
            {
                Point currentPoint = Control.MousePosition;
                currentPoint.Offset(-_mousePoint.X, -_mousePoint.Y);
                Location = currentPoint;
            }
        }
    }
}
