using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using GoldenLady.Utility.XTool.DataStructure;

namespace GoldenLady.Utility.XTool.Control
{
    /// <summary>
    /// 智能的DataGridView
    /// </summary>
    public partial class XDataGridView<T> : DataGridView
    {
        #region Delegates

        /// <summary>
        /// 用于更新列表中元素的委托
        /// </summary>
        /// <param name="element">要更新的元素</param>
        public delegate void UpdateElementEvent(ref T element);

        #endregion

        #region Members

        /// <summary>
        /// 绑定的数据列表
        /// </summary>
        private XBindingList<T> _dataList;

        #endregion

        #region Constructors

        /// <summary>
        /// 构造器
        /// </summary>
        public XDataGridView()
        {
            InitializeComponent();
            Init();
        }

        #endregion

        #region Indexers

        /// <summary>
        /// 快速访问和设置数据列表中的某个项
        /// </summary>
        /// <param name="index">项所在列表中的索引</param>
        /// <returns>目标数据项</returns>
        public T this[int index]
        {
            get { return DataList[index]; }
            set
            {
                DataList[index] = value;
                Refresh();
            }
        }

        #endregion

        #region Properties

        /// <summary>
        /// 是否启用自动调整列宽
        /// </summary>
        public bool AutoAdaptColumns { get; set; }
        /// <summary>
        /// 数据源列表
        /// </summary>
        public XBindingList<T> DataList
        {
            get { return _dataList; }
            set
            {
                // 记录原先的列表排序规则和选中项
                string strSortedColName = null == SortedColumn ? null : SortedColumn.Name;
                SortOrder order = SortOrder;
                T selectedItem = default(T);
                if(HasSelectedItem) selectedItem = SelectedItem;

                // 更改绑定数据
                if(null != _dataList) _dataList.Clear();
                _dataList = value;
                DataSource = _dataList;

                // 设置不显示的列和不能排序的列
                if(null == value) return;
                if(null != InVisiblePropertyNames) foreach(DataGridViewColumn dgvc in InVisiblePropertyNames.Select(name => Columns[name]).Where(dgvc => null != dgvc)) { dgvc.Visible = false; }
                if(null != UnSortablePropertyNames) foreach(DataGridViewColumn dgvc in UnSortablePropertyNames.Select(name => Columns[name]).Where(dgvc => null != dgvc)) { dgvc.SortMode = DataGridViewColumnSortMode.NotSortable; }

                // 排序（排完后会自动调整列宽）
                if(null != strSortedColName) Sort(Columns[strSortedColName], order);
                else AutoAdapt();

                // 还原选中项
                if(null == selectedItem) return;
                for(int idx = 0; idx < DataList.Count; idx++)
                {
                    if(!IsTheSameItem(DataList[idx], selectedItem)) continue;
                    DataGridViewRow dgvr = Rows[idx];
                    dgvr.Selected = true;
                    if(!dgvr.Displayed) FirstDisplayedScrollingRowIndex = idx;
                    break;
                }
            }
        }
        /// <summary>
        /// 获取是否有选中的项
        /// </summary>
        /// <returns>是否有选中的项</returns>
        public bool HasSelectedItem
        {
            get { return SelectedRows.Count > 0; }
        }
        /// <summary>
        /// 返回不需要显示的所有属性名
        /// </summary>
        public IEnumerable<string> InVisiblePropertyNames { get; set; }
        /// <summary>
        /// 返回最后一个可见列的列名
        /// </summary>
        public string LastVisiblePropertyName { get; set; }
        /// <summary>
        /// 第一个选中的项
        /// </summary>
        public T SelectedItem
        {
            get { return DataList[SelectedRows[0].Index]; }
        }
        /// <summary>
        /// 第一个选中的索引
        /// </summary>
        public int SelectedItemIndex
        {
            get { return SelectedRows[0].Index; }
        }
        /// <summary>
        /// 返回不能排序的所有属性名
        /// </summary>
        public IEnumerable<string> UnSortablePropertyNames { get; set; }

        #endregion

        #region Methods

        /// <summary>
        /// 自动调整列宽度
        /// </summary>
        public void AutoAdapt()
        {
            if(!AutoAdaptColumns || (null == DataList)) return;
            // 计算所有显示列的列宽之和
            int nWidth = 0;
            for(int idx = 0; idx < Columns.Count; idx++)
            {
                // 自动调整列宽后的列，如果元素名称长度列头长度时，排序标志可能显示不出来，所以手动把长度+1
                DataGridViewColumn col = Columns[idx];
                if(!col.Visible) continue;
                col.AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
                AutoResizeColumn(idx, DataGridViewAutoSizeColumnMode.DisplayedCells);
                int nOldWidth = col.Width;
                col.AutoSizeMode = DataGridViewAutoSizeColumnMode.None; // DisplayedCells状态下设置Width无效，所以要改成None
                col.Width = nOldWidth + 1;
                nWidth += col.Width;
            }

            // 若小于控件宽度，则将控件的最后一列列宽调整为Fill模式
            if(nWidth >= Width) return;
            string strColName = LastVisiblePropertyName;
            DataGridViewColumn dgvc = null == strColName ? Columns[Columns.Count - 1] : Columns[strColName];
            if(dgvc != null) dgvc.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
        }
        /// <summary>
        /// 添加新项，并自动按照当前排序规则整理列表，之后定位到该项
        /// </summary>
        /// <param name="t">要添加的新项</param>
        public void AddItem(T t)
        {
            DataList.Add(t);
            ClearSelection();
            Rows[Rows.Count - 1].Selected = true;
            Refresh();
        }
        /// <summary>
        /// 初始化
        /// </summary>
        private void Init()
        {
            //
            // Properties
            //
            InVisiblePropertyNames = null;
            LastVisiblePropertyName = null;
            UnSortablePropertyNames = null;
            AutoAdaptColumns = true;
            DataList = null;
            AllowUserToResizeRows = AllowUserToDeleteRows = AllowUserToAddRows = false;
            AllowUserToResizeColumns = AllowUserToOrderColumns = false;
            RowHeadersVisible = false;
            MultiSelect = false;
            ReadOnly = true;
            BackgroundColor = Color.White;
            SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None;
            AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.None;
            ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            ClipboardCopyMode = DataGridViewClipboardCopyMode.EnableWithAutoHeaderText;
            SetStyle(ControlStyles.OptimizedDoubleBuffer | ControlStyles.AllPaintingInWmPaint, true);
            //
            // Events
            //
            Scroll += (sender, e) => { if(ScrollOrientation.VerticalScroll == e.ScrollOrientation) AutoAdapt(); };
            CellValueChanged += (sender, e) => AutoAdapt();
            Sorted += (sender, e) => AutoAdapt();
        }
        /// <summary>
        /// 判断两个项是否是同样的，用于重载绑定数据后勾选之前以前勾选中的项
        /// </summary>
        /// <param name="t1">比较项</param>
        /// <param name="t2">比较项</param>
        /// <returns>是否是相同项</returns>
        protected virtual bool IsTheSameItem(T t1, T t2)
        {
            return t1.Equals(t2);
        }
        /// <summary>
        /// 重新按照当前设置排序并刷新显示，且定位到刷新前选中的那一行
        /// </summary>
        public override void Refresh()
        {
            // 先确定原来选中的项，按当前排序规则重排
            T selectedItem = default(T);
            if(HasSelectedItem) selectedItem = DataList[SelectedItemIndex];
            if(!Sort(SortedColumn, SortOrder)) return; // 如果重排成功，才需要重新定位到之前的选中行
            int nIdx = DataList.FindIndex(t => selectedItem.Equals(t));
            if(-1 != nIdx)
            {
                ClearSelection();
                DataGridViewRow row = Rows[nIdx];
                row.Selected = true;
                if(!row.Displayed) FirstDisplayedScrollingRowIndex = nIdx; // 选中行不在当前显示区域内，则滚动到选中行
            }
            base.Refresh();
        }
        /// <summary>
        /// 移除当前选中元素
        /// </summary>
        public void RemoveCurrSelectedItem() { RemoveItemAt(SelectedItemIndex); }
        /// <summary>
        /// 移除项，并自动调整列宽
        /// </summary>
        /// <param name="idx">项在列表中的索引</param>
        public void RemoveItemAt(int idx)
        {
            DataList.RemoveAt(idx);
            AutoAdapt();
        }
        /// <summary>
        /// 按照指定规则排序，并自动调整列宽
        /// </summary>
        /// <param name="column">排序的列</param>
        /// <param name="order">排序顺序</param>
        /// <returns>排序是否执行</returns>
        protected virtual bool Sort(DataGridViewColumn column, SortOrder order)
        {
            if(null == column)
            {
                AutoAdapt();
                return false;
            }
            ListSortDirection dir;
            switch(order)
            {
                case SortOrder.None:
                {
                    AutoAdapt();
                    return false;
                }
                case SortOrder.Ascending:
                {
                    dir = ListSortDirection.Ascending;
                    break;
                }
                case SortOrder.Descending:
                {
                    dir = ListSortDirection.Descending;
                    break;
                }
                default:
                {
                    AutoAdapt();
                    return false;
                }
            }
            Sort(column, dir);
            return true;
        }
        /// <summary>
        /// 修改当前选中项
        /// </summary>
        /// <param name="update">修改动作</param>
        public void UpdateCurrSelectedItem(UpdateElementEvent update) { UpdateItemAt(SelectedItemIndex, update); }
        /// <summary>
        /// 修改指定项
        /// </summary>
        /// <param name="idx">项在列表中的索引</param>
        /// <param name="update">修改动作</param>
        public void UpdateItemAt(int idx, UpdateElementEvent update)
        {
            T t = DataList[idx];
            update(ref t);
            if(!t.Equals(DataList[idx])) DataList[idx] = t; // 如果委托中使用new引用了新的对象，则更新成新的对象
            Refresh();
        }

        #endregion
    }
}