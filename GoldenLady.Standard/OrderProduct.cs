using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using GoldenLady.Extension;

namespace GoldenLady.Standard
{
    /// <summary>
    /// 订单产品操作选项
    /// </summary>
    public enum OrderProductOption
    {
        /// <summary>
        /// 不做操作
        /// </summary>
        None,
        /// <summary>
        /// 新建
        /// </summary>
        New,
        /// <summary>
        /// 更新
        /// </summary>
        Edit,
        /// <summary>
        /// 删除
        /// </summary>
        Delete
    }

    /// <summary>
    /// 订单产品
    /// </summary>
    public sealed class OrderProduct
    {
        /// <summary>
        /// 所属父产品顺序号
        /// </summary>
        public string ParentProductNO
        {
            get;
            set;
        }

        /// <summary>
        /// 产品名称
        /// </summary>
        public string ProductName
        {
            get;
            set;
        }

        /// <summary>
        /// 产品类型名称
        /// </summary>
        public string ProductTypeName
        {
            get;
            set;
        }
        /// <summary>
        /// 所属订单号
        /// </summary>
        public string OrderNo
        {
            get;
            set;
        }
        /// <summary>
        /// 顺序号
        /// </summary>
        public int OrderIndex
        {
            get;
            set;
        }
        /// <summary>
        /// 产品号
        /// </summary>
        public string ProductNo
        {
            get;
            set;
        }
        /// <summary>
        /// 分离号
        /// </summary>
        public string SeparateNo
        {
            get;
            set;
        }
        /// <summary>
        /// 框条
        /// </summary>
        public Frame Fram
        {
            get;
            set;
        }
        /// <summary>
        /// 盒子
        /// </summary>
        public Box Box
        {
            get;
            set;
        }
        /// <summary>
        /// 单位
        /// </summary>
        public string Unit
        {
            get;
            set;
        }
        /// <summary>
        /// 相纸
        /// </summary>
        public string Paper
        {
            get;
            set;
        }
        /// <summary>
        /// 淋膜
        /// </summary>
        public string Film
        {
            get;
            set;
        }
        /// <summary>
        /// 内页
        /// </summary>
        public string InsidePage
        {
            get;
            set;
        }
        /// <summary>
        /// 裱
        /// </summary>
        public string Biao
        {
            get;
            set;
        }
        /// <summary>
        /// 板
        /// </summary>
        public string Ban
        {
            get;
            set;
        }
        /// <summary>
        /// 雕
        /// </summary>
        public string Diao
        {
            get;
            set;
        }
        /// <summary>
        /// 对页数
        /// </summary>
        public int PageQuantity
        {
            get;
            set;
        }
        /// <summary>
        /// 底数
        /// </summary>
        public int NegativeQuantity
        {
            get;
            set;
        }
        /// <summary>
        /// 产品数量
        /// </summary>
        public int ProductQuantity
        {
            get;
            set;
        }
        /// <summary>
        /// 产品备注
        /// </summary>
        public string ProductMemory
        {
            get;
            set;
        }
        /// <summary>
        /// 销售价格
        /// </summary>
        public decimal ProductSellingPrice
        {
            get;
            set;
        }
        /// <summary>
        /// 产品状态
        /// </summary>
        public string ProduceState
        {
            get;
            set;
        }
        /// <summary>
        /// 创建人
        /// </summary>
        public string Create
        {
            get;
            set;
        }
        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime? CreateDate
        {
            get;
            set;
        }
        /// <summary>
        /// 规格
        /// </summary>
        public string Size { get; set; }
        /// <summary>
        /// 操作选项
        /// </summary>
        public OrderProductOption Option { get; set; }

        /// <summary>
        /// 从数据行构造
        /// </summary>
        /// <param name="dr">数据行</param>
        /// <param name="boxes">包装数据集</param>
        /// <param name="frames">框条数据集</param>
        /// <returns>构造好的对象</returns>
        public static OrderProduct FromSuiteProduct(DataRow dr, IEnumerable<Box> boxes, IEnumerable<Frame> frames)
        {
            if(dr == null)
            {
                throw new ArgumentNullException(@"dr", @"数据行参数为空！");
            }
            return new OrderProduct
            {
                ProductNo = dr["ProductNo"].SafeDbString(),
                ProductName = dr["ProductName"].SafeDbString(),
                ProductTypeName = dr["ProductTypeName"].SafeDbString(), 
                Ban = dr["Ban"].SafeDbString(),
                Biao = dr["Biao"].SafeDbString(),
                Box = Box.Parse(dr["Box"].SafeDbString(), boxes),
                Diao = dr["Diao"].SafeDbString(),
                Film = dr["Film"].SafeDbString(),
                Fram = Frame.Parse(dr["Fram"].SafeDbString(), frames),
                Paper = dr["Paper"].SafeDbString(),
                Unit = dr["Unit"].SafeDbString(),
                Size = dr["Size"].SafeDbString(),
                InsidePage = dr["InsidePage"].SafeDbString(),
                NegativeQuantity = dr["NegativeQuantity"].SafeDbInt32(),
                ProductQuantity = dr["ProductQuantity"].SafeDbInt32(),
                PageQuantity = dr["PageQuantity"].SafeDbInt32(),
                Option = OrderProductOption.New, 
                ProduceState = @"正常"
            };
        }
        /// <summary>
        /// 从数据行构造
        /// </summary>
        /// <param name="dr">数据行</param>
        /// <param name="boxes">包装数据集</param>
        /// <param name="frames">框条数据集</param>
        /// <returns>构造好的对象</returns>
        public static OrderProduct FromProduct(DataRow dr, IEnumerable<Box> boxes, IEnumerable<Frame> frames)
        {
            if(dr == null)
            {
                throw new ArgumentNullException(@"dr", @"数据行参数为空！");
            }
            return new OrderProduct
            {
                ProductNo = dr["ProductNo"].SafeDbString(),
                ProductName = dr["ProductName"].SafeDbString(),
                ProductTypeName = dr["ProductTypeName"].SafeDbString(),
                Ban = dr["Ban"].SafeDbString(),
                Biao = dr["Biao"].SafeDbString(),
                Box = Box.Parse(dr["Box"].SafeDbString(), boxes),
                Diao = dr["Diao"].SafeDbString(),
                Film = dr["Film"].SafeDbString(),
                Fram = Frame.Parse(dr["Fram"].SafeDbString(), frames),
                Paper = dr["Paper"].SafeDbString(),
                Unit = dr["Unit"].SafeDbString(),
                Size = dr["Size"].SafeDbString(),
                InsidePage = dr["InsidePage"].SafeDbString(),
                Option = OrderProductOption.New,
                ProduceState = @"正常",
                ProductQuantity = 1
            };
        }

        /// <summary>
        /// 获取浅拷贝副本
        /// </summary>
        /// <returns>浅拷贝副本</returns>
        public OrderProduct ShallowClone()
        {
            return (OrderProduct)MemberwiseClone();
        }
    }
}