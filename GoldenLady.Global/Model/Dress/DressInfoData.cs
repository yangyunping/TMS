namespace GoldenLady.Global.Model.Dress
{
    public class DressInfoData
    {
        private System.String dressChipNO;//芯片号
        private System.String dressID;//礼服编号
        private System.String dressName;//礼服名称
        private System.String dressBrand;//礼服品牌
        private System.Byte[] dressImageUrl;//礼服照片binary(255)
        private System.Byte[] dressImageUrl2;
        private System.String dressDescription;//礼服描述
        private System.Int32 dressTimes;//使用次数
        private System.String dressState;//礼服状态
        private System.String dressRemark;//备注
        private System.String dressBorrowAddress;//实际所在地点
        private System.String dressCreatName;//操作员
        private System.String dressCreatTime;//创建时间
        private System.String dressRemark1;//预留1   出库日期  淘汰日期
        private System.String dressRemark2;//预留2    出发点
        private System.String dressDestionation;//目的地
        private System.String dressOperator;//操作者

        public System.String DressChipNO
        {
            get { return dressChipNO; }
            set { dressChipNO = value; }
        }

        public System.String DressID
        {
            get { return dressID; }
            set { dressID = value; }
        }
        public System.String DressName
        {
            get { return dressName; }
            set { dressName = value; }
        }
        public System.String DressBrand
        {
            get { return dressBrand; }
            set { dressBrand = value; }
        }
        public System.Byte[] DressImageUrl
        {
            get { return dressImageUrl; }
            set { dressImageUrl = value; }
        }
        public System.Byte[] DressImageUrl2
        {
            get { return dressImageUrl2; }
            set { dressImageUrl2 = value; }
        }
        public System.String DressDescription
        {
            get { return dressDescription; }
            set { dressDescription = value; }
        }
        public System.Int32 DressTimes
        {
            get { return dressTimes; }
            set { dressTimes = value; }
        }
        public System.String DressState
        {
            get { return dressState; }
            set { dressState = value; }
        }
        public System.String DressRemark
        {
            get { return dressRemark; }
            set { dressRemark = value; }
        }
        public System.String DressBorrowAddress
        {
            get { return dressBorrowAddress; }
            set { dressBorrowAddress = value; }
        }
        public System.String DressCreatName
        {
            get { return dressCreatName; }
            set { dressCreatName = value; }
        }
        public System.String DressCreatTime
        {
            get { return dressCreatTime; }
            set { dressCreatTime = value; }
        }
        public System.String DressRemark1
        {
            get { return dressRemark1; }
            set { dressRemark1 = value; }
        }
        public System.String DressRemark2
        {
            get { return dressRemark2; }
            set { dressRemark2 = value; }
        }
        public System.String DressDestionation
        {
            get { return dressDestionation; }
            set { dressDestionation = value; }
        }
        public System.String DressOperator
        {
            get { return dressOperator; }
            set { dressOperator = value; }
        }



    }
}
