using System.Data;
using GoldenLady.Extension;

namespace GoldenLady.Standard
{
    /// <summary>
    /// 订单状态信息
    /// </summary>
    public sealed class OrderStateInformation
    {
        /// <summary>
        /// 订单号
        /// </summary>
        public string OrderNO
        {
            get;
            set;
        }
        /// <summary>
        /// 当前状态中文名称
        /// </summary>
        public string CurrentStateName
        {
            get;
            set;
        }
        /// <summary>
        /// 新订单
        /// </summary>
        public bool NewOrder
        {
            get;
            set;
        }
        /// <summary>
        /// 等待拍摄
        /// </summary>
        public bool WaitShoot
        {
            get;
            set;
        }
        /// <summary>
        /// 拍摄完成
        /// </summary>
        public bool ShootFinished
        {
            get;
            set;
        }
        /// <summary>
        /// 等待样前设计
        /// </summary>
        public bool WaitPreDesign
        {
            get;
            set;
        }
        /// <summary>
        /// 样前设计中
        /// </summary>
        public bool PreDesigning
        {
            get;
            set;
        }
        /// <summary>
        /// 样前设计完成
        /// </summary>
        public bool PreDesignFinished
        {
            get;
            set;
        }
        /// <summary>
        /// 看样中
        /// </summary>
        public bool Choosing
        {
            get;
            set;
        }
        /// <summary>
        /// 看样完成
        /// </summary>
        public bool ChooseFinished
        {
            get;
            set;
        }
        /// <summary>
        /// 等待样后设计
        /// </summary>
        public bool WaitDesign
        {
            get;
            set;
        }
        /// <summary>
        /// 样后设计中
        /// </summary>
        public bool Designing
        {
            get;
            set;
        }
        /// <summary>
        /// 样后设计完成
        /// </summary>
        public bool DesignFinished
        {
            get;
            set;
        }
        /// <summary>
        /// 生产中
        /// </summary>
        public bool Producing
        {
            get;
            set;
        }
        /// <summary>
        /// 等待取件
        /// </summary>
        public bool WaitGetGoods
        {
            get;
            set;
        }
        /// <summary>
        /// 取件完成
        /// </summary>
        public bool GetGoodsFinished
        {
            get;
            set;
        }
        /// <summary>
        /// 归档完成
        /// </summary>
        public bool OrderFinished
        {
            get;
            set;
        }
        /// <summary>
        /// 隐式从数据行赋值
        /// </summary>
        /// <param name="dr">数据行</param>
        /// <returns>记录</returns>
        public static implicit operator OrderStateInformation(DataRow dr)
        {
            if(null == dr)
                return null;
            return new OrderStateInformation
            {
                OrderNO = dr[@"OrderNO"].SafeDbString(),
                CurrentStateName = dr[@"CurrentStateName"].SafeDbString(),
                NewOrder = dr[@"NewOrder"].SafeDbBoolean(),
                WaitShoot = dr[@"WaitShoot"].SafeDbBoolean(),
                ShootFinished = dr[@"ShootFinished"].SafeDbBoolean(),
                WaitPreDesign = dr[@"WaitPreDesign"].SafeDbBoolean(),
                PreDesigning = dr[@"PreDesigning"].SafeDbBoolean(),
                PreDesignFinished = dr[@"PreDesignFinished"].SafeDbBoolean(),
                Choosing = dr[@"Choosing"].SafeDbBoolean(),
                ChooseFinished = dr[@"ChooseFinished"].SafeDbBoolean(),
                WaitDesign = dr[@"WaitDesign"].SafeDbBoolean(),
                Designing = dr[@"Designing"].SafeDbBoolean(),
                DesignFinished = dr[@"DesignFinished"].SafeDbBoolean(),
                Producing = dr[@"Producing"].SafeDbBoolean(),
                WaitGetGoods = dr[@"WaitGetGoods"].SafeDbBoolean(),
                GetGoodsFinished = dr[@"GetGoodsFinished"].SafeDbBoolean(),
                OrderFinished = dr[@"OrderFinished"].SafeDbBoolean()
            };
        }
    }
}