///////////////////////
//////创建人：陈中波 +猪猪
/////创建时间：2011.11.15
/////
////礼服师管理表
//////////////////////////





namespace GoldenLady.Global.Model.Dress
{
  public   class DresserManagerData
    {
      private System.Int32 id;  //  员工编号
      private System.String employeeNum;//工号
      private System.String employeeName;//姓名
      private System.String postition;//职位
      private System.String sex;//性别
      private System.String floor;//所在楼层
      private System.String states;//状态
      private System.String createrPeople;//创建人
      private System.DateTime createTime;//创建时间
      private System.String remark1;//店名
      private System.String remark2;//备注2
      private System.String remark3;//备注3
      private System.String postition1;//职位1
      //

      public System.Int32 Id
      {
          get { return id; }
          set { id = value; }
      }
      public System.String EmployeeNum
      {
          get { return employeeNum; }
          set { employeeNum = value; }
      }
      public System.String EmployeeName
      {
          get { return employeeName; }
          set { employeeName = value; }
      }
      public System.String Postition
      {
          get { return postition; }
          set { postition = value; }
      }
      public System.String Sex
      {
          get { return sex; }
          set { sex = value; }
      }
      public System.String Floor
      {
          get { return floor;}
          set{floor=value;}
      }
      public System.String States
      {
          get { return states; }
          set { states = value; }
      }
      public System.String CreaterPeople
      {
          get { return createrPeople; }
          set { createrPeople = value; }
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
      public System.String Postition1
      {
          get { return postition1; }
          set{postition1=value;}
      }
    }
}
