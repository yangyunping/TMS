using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace GoldenLady.Utility.UserListView
{
    public partial class UserListView : UserControl
    {
        public List<UserListViewItem> ListViewItems = new List<UserListViewItem>();

        private int _num = 3;
        public UserListView()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 添加子项目
        /// </summary>
        /// <param name="SubItem">子项目</param>
        public void Add(UserListViewItem _ListViewItem)
        {
            int iCount = this.Controls.Count;
            _ListViewItem._Index = iCount;
            //位置
            int iRow = iCount / _num;
            int iCol = iCount % _num;
            _ListViewItem.Left = 170 * iCol + 10;
            _ListViewItem.Top = 85 * iRow + 10;
            //添加
            ListViewItems.Add(_ListViewItem);
            this.Controls.Add(_ListViewItem);
            //释放
            //_ListViewItem.Dispose();
        }

        /// <summary>
        /// 添加子项目
        /// </summary>
        /// <param name="SubItem">子项目</param>
        public void Add(UserListViewItem _ListViewItem,string Group)
        {
            int iCount = this.Controls.Count;
            _ListViewItem._Index = iCount;
            //位置
            int iRow = iCount / _num;
            int iCol = iCount % _num;
            _ListViewItem.Left = 170 * iCol + 10;
            _ListViewItem.Top = 85 * iRow + 10;
            //添加
            ListViewItems.Add(_ListViewItem);
            this.Controls.Add(_ListViewItem);
            //释放
            //_ListViewItem.Dispose();
        }

        /// <summary>
        /// 返回选中项数量
        /// </summary>
        /// <returns>选中项数量</returns>
        public int CheckedCount()
        {
            int iReturn = 0;
            foreach (UserListViewItem ulvi in this.Controls)
            {
                if (ulvi._Checked)
                    iReturn++;
            }
            return iReturn;
        }

        public void Clear()
        {
            ListViewItems.Clear();
            this.Controls.Clear();
        }

        private void _Paint()
        {
            int iCount = 0;
            foreach (UserListViewItem ulvi in this.Controls)
            {
                int iRow = iCount / _num;
                int iCol = iCount % _num;
                ulvi.Left = 170 * iCol + 10;
                ulvi.Top = 85 * iRow + 10;
                iCount++;
            }
        }

        private void UserListView_SizeChanged(object sender, EventArgs e)
        {
            _num = this.Width / 170;
            if (_num <= 0)
                _num = 1;
            _Paint();
        }
    }
}
