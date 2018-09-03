using System;
using System.Data;
using GoldenLady.Extension;

namespace GoldenLady.Standard
{
    /// <summary>
    /// 用于展示在订单状态窗口的摄影记录信息
    /// </summary>
    public sealed class ShootRecord
    {
        /// <summary>
        /// 状态
        /// </summary>
        public string ShootState
        {
            get;
            set;
        }
        /// <summary>
        /// 类型
        /// </summary>
        public string ShootType
        {
            get;
            set;
        }
        /// <summary>
        /// 排控时间
        /// </summary>
        public DateTime PreShootDate
        {
            get;
            set;
        }
        /// <summary>
        /// 实际拍摄时间
        /// </summary>
        public DateTime ShootDate
        {
            get;
            set;
        }

        /// <summary>
        /// 隐式从数据行赋值
        /// </summary>
        /// <param name="dr">数据行</param>
        /// <returns>记录</returns>
        public static implicit operator ShootRecord(DataRow dr)
        {
            if(null == dr)
                return null;
            return new ShootRecord
            {
                ShootState = dr[@"ShootState"].SafeDbString(),
                ShootType = dr[@"ShootType"].SafeDbString(),
                PreShootDate = dr[@"PreShootDate"].SafeDbDateTime(),
                ShootDate = dr[@"ShootDate"].SafeDbDateTime()
            };
        }

        public override string ToString()
        {
            return string.Format(@"{0}{1}[{2}]", ShootType.Substring(0, 1), ShootDate.Equals(DateTime.MinValue) ? PreShootDate.ToShortDateString() : ShootDate.ToShortDateString(), ShootDate.Equals(DateTime.MinValue) ? @"未拍" : @"完成");
        }
    }
}