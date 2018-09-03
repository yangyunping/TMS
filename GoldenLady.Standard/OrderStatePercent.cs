using System.Collections.Generic;

namespace GoldenLady.Standard
{
    /// <summary>
    /// 订单状态对应的完成度百分比
    /// </summary>
    public static class OrderStatePercent
    {
        private static readonly Dictionary<string, int> _dicPercent;
        static OrderStatePercent()
        {
            _dicPercent = new Dictionary<string, int>
            {
                 {OrderStateName.NewOrder, 5}, 
                 {OrderStateName.WaitShoot, 10}, 
                 {OrderStateName.ShootFinished, 20}, 
                 {OrderStateName.WaitPreDesign, 25}, 
                 {OrderStateName.PreDesigning, 30}, 
                 {OrderStateName.PreDesignFinished, 40}, 
                 {OrderStateName.Choosing, 45}, 
                 {OrderStateName.ChooseFinished, 55}, 
                 {OrderStateName.WaitDesign, 60}, 
                 {OrderStateName.Designing, 70}, 
                 {OrderStateName.DesignFinished, 75}, 
                 {OrderStateName.Producing, 85}, 
                 {OrderStateName.WaitGetGoods, 90}, 
                 {OrderStateName.GetGoodsFinished, 95}, 
                 {OrderStateName.OrderFinished, 100}
            };
        }
        /// <summary>
        /// 获取状态对应的完成度百分比
        /// </summary>
        /// <param name="key">状态名</param>
        /// <returns></returns>
        public static int GetVal(string key)
        {
            int val;
            _dicPercent.TryGetValue(key, out val);
            return val;
        }
    }
}