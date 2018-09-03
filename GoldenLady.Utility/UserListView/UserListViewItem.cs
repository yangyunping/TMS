using System;
using System.Drawing;
using System.Windows.Forms;

namespace GoldenLady.Utility.UserListView
{
    public partial class UserListViewItem : UserControl
    {
        private bool _selected = true;
        /// <summary>
        /// 是否被选中
        /// </summary>
        public bool _Selected
        {
            set { _selected = value; this.ChangeBackColor(); }
            get { return _selected; }
        }

        private bool _checked = false;
        /// <summary>
        /// 是否被勾选
        /// </summary>
        public bool _Checked
        {
            set { _checked = value; }
            get { return _checked; }
        }

        private int _index = -1;
        /// <summary>
        /// 索引
        /// </summary>
        public int _Index
        {
            set { _index = value; }
            get { return _index; }
        }

        private string _name = "";
        /// <summary>
        /// 名称
        /// </summary>
        public string _Name
        {
            set { _name = value; }
            get { return _name; }
        }

        private string _text = "";
        /// <summary>
        /// 显示文本
        /// </summary>
        public string _Text
        {
            set { _text = value; label1.Text = value; }
            get { return _text; }
        }

        private string _tag = "";
        /// <summary>
        /// 补充信息
        /// </summary>
        public string _Tag
        {
            set { _tag = value; }
            get { return _tag; }
        }

        private Icon _ico = null;
        /// <summary>
        /// 补充信息
        /// </summary>
        public Icon _Ico
        {
            set
            {
                _ico = value;
                if (_ico != null)
                {
                    pictureBox1.Image = null;//暂时不加载任何图片
                }
            }
            get { return _ico; }
        }

        public UserListViewItem()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 显示的内容
        /// </summary>
        /// <param name="ico">图片信息</param>
        /// <param name="sText">文本信息</param>
        //public void Context(Icon ico,string sText)
        //{
        //    //if (ico != null)
        //    //{
        //    //    pictureBox1.Image = (Image)ico;
        //    //}
        //    label1.Text = sText;
        //    this._text = sText;
        //}

        private void ChangeBackColor()
        {
            if (_selected)
            {
                this.BackColor = Color.Pink;
                this.label1.BackColor = Color.Pink;
                this.pictureBox1.BackColor = Color.Pink;
                _selected = !_selected;
            }
            else
            {
                this.BackColor = Color.White;
                this.label1.BackColor = Color.White;
                this.pictureBox1.BackColor = Color.White;
                _selected = !_selected;
            }
        }

        private void pictureBox1_MouseClick(object sender, MouseEventArgs e)
        {
            ChangeBackColor();
        }

        private void checkBox1_MouseClick(object sender, MouseEventArgs e)
        {
            ChangeBackColor();
        }

        private void UserListViewItem_MouseClick(object sender, MouseEventArgs e)
        {
            ChangeBackColor();
        }

        private void UserListViewItem_BackColorChanged(object sender, EventArgs e)
        {
            _checked = !_checked;
            checkBox1.Checked = _checked;
        }

        private void pictureBox1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            ChangeBackColor();
        }

        private void UserListViewItem_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            ChangeBackColor();
        }

        private void label1_MouseClick(object sender, MouseEventArgs e)
        {
            ChangeBackColor();
        }

        private void label1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            ChangeBackColor();
        }
    }
}
