namespace GoldenLady.Standard.Dress
{
    public sealed class DressStorage
    {
        /// <summary>
        /// 订单号
        /// </summary>
        public string orderNO
        {
            set;
            get;    
        }
        /// <summary>
        /// 礼服编号
        /// </summary>
        public string dressNO
        {
            set;
            get;   
        }
        /// <summary>
        /// 场景
        /// </summary>
        public string SceneNO { set; get; }

        public string SceneName { set; get; }

        /// <summary>
        /// 男装
        /// </summary>
        public string ManDressNO { set; get; }
    }
}
