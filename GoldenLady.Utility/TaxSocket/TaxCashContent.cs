namespace GoldenLady.Utility.TaxSocket
{
    public class TaxCashContent
    {
        private string _fkfmc;
        /// <summary>
        /// 付款方名称
        /// </summary>
        public string fkfmc
        {
            set { _fkfmc = value; }
            get { return _fkfmc; }
        }

        private string _OrderNO;
        /// <summary>
        /// 订单号码
        /// </summary>
        public string OrderNO
        {
            set { _OrderNO = value; }
            get { return _OrderNO; }
        }

        private string _bz;
        /// <summary>
        /// 备注
        /// </summary>
        public string bz
        {
            set { _bz = value; }
            get { return _bz; }
        }

        private string _kpr;
        /// <summary>
        /// 开票人
        /// </summary>
        public string kpr
        {
            set { _kpr = value; }
            get { return _kpr; }
        }

        private string _kprq;
        /// <summary>
        /// 开票日期
        /// </summary>
        public string kprq
        {
            set { _kprq = value; }
            get { return _kprq; }
        }

        private string _fphm;
        /// <summary>
        /// 发票号码
        /// </summary>
        public string fphm
        {
            set { _fphm = value; }
            get { return _fphm; }
        }

        private string[] _auto;
        /// <summary>
        /// 自动增长号
        /// </summary>
        public string[] auto
        {
            set { _auto = value; }
            get { return _auto; }
        }

        private string[] _sl;
        /// <summary>
        /// 数量
        /// </summary>
        public string[] sl
        {
            set { _sl = value; }
            get { return _sl; }
        }

        private string[] _dj;
        /// <summary>
        /// 单价
        /// </summary>
        public string[] dj
        {
            set { _dj = value; }
            get { return _dj; }
        }

        private string[] _je;
        /// <summary>
        /// 金额
        /// </summary>
        public string[] je
        {
            set { _je = value; }
            get { return _je; }
        }

        private string[] _pmmc;
        /// <summary>
        /// 品目名称
        /// </summary>
        public string[] pmmc
        {
            set { _pmmc = value; }
            get { return _pmmc; }
        }

        private string[] _pmbm;
        /// <summary>
        /// 品目编码
        /// </summary>
        public string[] pmbm
        {
            set { _pmbm = value; }
            get { return _pmbm; }
        }

        private string[] _zmdm;
        /// <summary>
        /// 子目编码
        /// </summary>
        public string[] zmdm
        {
            set { _zmdm = value; }
            get { return _zmdm; }
        }
    }
}
