using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace GoldenLady.Utility.XTool.DataStructure
{
    /// <summary>
    /// 支持排序、查找等功能的绑定列表
    /// </summary>
    /// <typeparam name="T">列表元素类型</typeparam>
    public abstract class XBindingList<T> : BindingList<T>
    {
        #region Constructors

        /// <summary>
        /// 构造器
        /// </summary>
        protected XBindingList()
        {
            //
            // Properties
            //
            AllowNew = AllowRemove = AllowEdit = true;
            RaiseListChangedEvents = true;
            //
            // Events
            //
            AddingNew += (sender, args) => args.NewObject = default(T);
        }

        #endregion

        #region Properties

        /// <summary>
        /// 绑定的控件调用此属性判断列表是否支持排序
        /// </summary>
        protected override bool SupportsSortingCore
        {
            get { return true; }
        }

        #endregion

        #region Methods

        /// <summary>
        /// 绑定的控件调用此方法进行列表的排序，之后自动重新绑定回控件
        /// </summary>
        /// <param name="prop"></param>
        /// <param name="direction"></param>
        protected override void ApplySortCore(PropertyDescriptor prop, ListSortDirection direction)
        {
            List<T> list = Items as List<T>;
            if (list != null) list.Sort((x, y) => Cmp(prop, direction, x, y));
        }

        /// <summary>
        /// 用于排序时比较两个元素的方法
        /// </summary>
        /// <param name="property">要排序的属性</param>
        /// <param name="direction">排序顺序</param>
        /// <param name="x">用于比较的元素</param>
        /// <param name="y">用于比较的元素</param>
        /// <returns></returns>
        protected abstract int Cmp(PropertyDescriptor property, ListSortDirection direction, T x, T y);

        /// <summary>
        /// 查找符合要求的元素
        /// </summary>
        /// <param name="match">需要满足的要求</param>
        /// <returns>第一个符合要求的元素索引，不存在则返回-1</returns>
        public int FindIndex(Predicate<T> match)
        {
            for (int idx = 0; idx < Items.Count; idx++) if (match(Items[idx])) return idx;
            return -1;
        }

        #endregion
    }
}