namespace GoldenLady.Global.Model.Dress
{
   public class DressControlTable
    {

       //private System.String customerNOCreatePeople
       private System.Int32 id;//主键
       private System.String customerName;//姓名
       private System.String customerTel;//电话
       private System.String dateTime;//时间（小时 分钟）
       private System.DateTime marryDate;//婚期
       private System.String dresser;//礼服师
       private System.String remark;//备注
       private System.String createPeople;//创建人
       private System.DateTime createTime;//创建时间
       private System.DateTime createTimes;//日期（年月日）
       private System.String remark1;
       private System.String remark2;
       private System.String remark3;

       public System.Int32 Id
       {
           get { return id; }
           set { id = value; }
       }
       public System.String CustomerName
       {
           get { return customerName; }
           set { customerName = value; }
       }
       public System.String CustomerTel
       {
           get { return customerTel; }
           set { customerTel = value; }
       }
       public System.String DateTime
       {
           get { return dateTime; }
           set { dateTime = value; }
       }
       public System.DateTime MarryDate
       {
           get { return marryDate; }
           set { marryDate = value; }
       }

       public System.DateTime CreateTimes
       {
           get { return createTimes; }
           set { createTimes = value; }
       }
       public System.String Dresser
       {
           get { return dresser; }
           set { dresser = value; }
       }
       public System.String Remark
       {
           get { return remark; }
           set { remark = value; }
       }
       public System.String CreatePeople
       {
           get { return createPeople; }
           set { createPeople = value; }
       }
       public System.DateTime CreateTime
       {
           get { return createTime; }
           set { createTime = value; }
       }
       public System.String Remark1
       {
           get { return remark1; }
           set { remark1 = value; }
       }
       public System.String Remark2
       {
           get { return remark2; }
           set { remark2 = value; }
       }
       public System.String Remark3
       {
           get { return remark3; }
           set { remark3 = value; }
       }


    }
}
