using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace GoldenLady.Dress
{
    //class DoubleBufferDataGridView
    //{
    //}
    /// <summary>
    ///双缓冲DataGridView，解决闪烁
    /// </summary>
    public class DoubleBufferDataGridView : DataGridView
    {
        public DoubleBufferDataGridView()
        {
            SetStyle(ControlStyles.DoubleBuffer | ControlStyles.OptimizedDoubleBuffer | ControlStyles.AllPaintingInWmPaint, true);
            UpdateStyles();

        }
    }

}
