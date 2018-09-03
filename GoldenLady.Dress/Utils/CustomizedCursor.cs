using System.Windows.Forms;

namespace GoldenLady.Dress.Utils
{
    public static class CustomizedCursor
    {
        private static Cursor _left;
        private static Cursor _right;

        public static Cursor Left
        {
            get
            {
                return _left ?? (_left = new Cursor(Properties.Resources.ImageLeft.GetHicon()));
            }
        }
        public static Cursor Right
        {
            get
            {
                return _right ?? (_right = new Cursor(Properties.Resources.ImageRight.GetHicon()));
            }
        }
    }
}
