using System;
using System.Data;
using System.Data.SqlClient;
using System.Web.Services;
using GoldenLady.Extension;
using GoldenLady.Global;
using GoldenLady.Standard;
using GoldenLady.Utility;
using Microsoft.Office.Interop.Excel;

namespace GoldenLadyWS
{
    /// <summary>
    /// 用于客户管理的数据库操作方法集
    /// </summary>
    public sealed class CustomerManagement : ErpService
    {
        private static CustomerManagement _theInstance;
        private CustomerManagement()
        {
        }

        /// <summary>
        /// 唯一实例
        /// </summary>
        internal static CustomerManagement Instance
        {
            get
            {
                return _theInstance ?? (_theInstance = new CustomerManagement());
            }
        }

        /// <summary>
        /// 查询客户
        /// </summary>
        /// <param name="filter">过滤条件</param>
        [WebMethod]
        public DataSet SearchCustomers(string filter)
        {
            return ExecuteQuery(string.Format(@"SELECT DISTINCT CustomerNO, CardType, CardNO, IntroducerCardNO, CustomerName1, Birthday1, CASE WHEN TheGregorianCalendar1=0 THEN '否' ELSE '是' END AS 'TheGregorianCalendar1', MobilePhone1, CASE WHEN MobilePhoneIsLose1=0 THEN '否' ELSE '是' END AS 'MobilePhoneIsLose1', Telephone1,  CASE WHEN TelephoneIsLose1=0 THEN '否' ELSE '是' END AS 'TelephoneIsLose1', QQ_MSN1, Email1, Job1, (VIEW_Customers.N_Address_1+VIEW_Customers.N_Address_2+VIEW_Customers.N_Address_3+address1) AS Address1, ZipCode1, CustomerName2, Birthday2,CASE WHEN TheGregorianCalendar2=0 THEN '否' ELSE '是' END AS 'TheGregorianCalendar2', MobilePhone2, CASE WHEN MobilePhoneIsLose2=0 THEN '否' ELSE '是' END AS 'MobilePhoneIsLose2', Telephone2,CASE WHEN TelephoneIsLose2=0 THEN '否' ELSE '是' END AS 'TelephoneIsLose2', QQ_MSN2, Email2, Job2, (VIEW_Customers.V_Address_1+VIEW_Customers.V_Address_2+VIEW_Customers.V_Address_3+Address2) AS Address2, ZipCode2, MarryDate, MarryDate2, CustomerSource, ImforMationSource, WishRecommend, CreateEmployee, CreateDate,SUM(RepayNumber)  AS RepayNumber 
                                         FROM dbo.VIEW_Customers 
                                         WHERE (CustomerName1<>'' OR CustomerName2<>'') AND IsDelete=0 {0}
                                         GROUP BY CustomerNO, CardType, CardNO, IntroducerCardNO, CustomerName1, Birthday1, TheGregorianCalendar1, MobilePhone1, MobilePhoneIsLose1, Telephone1, TelephoneIsLose1, QQ_MSN1, Email1, Job1, Address1, ZipCode1, CustomerName2, Birthday2, TheGregorianCalendar2, MobilePhone2, MobilePhoneIsLose2, Telephone2, TelephoneIsLose2, QQ_MSN2, Email2, Job2, Address2, ZipCode2, MarryDate,MarryDate2, CustomerSource, ImforMationSource, WishRecommend, CreateEmployee, CreateDate ,N_Address_1,N_Address_2,N_Address_3,v_Address_1,v_Address_2,v_Address_3 
                                         ORDER BY CreateDate", filter));
        }

        /// <summary>
        /// 创建新入客
        /// </summary>
        /// <returns>生成的客户编号</returns>
        [WebMethod]
        public string CreateNewInCustomer()
        {
            string sCustomerBm = "CS1-";
            string sYear = "8";
            string sMonth = "B";
            string sDay = "15";
            sYear = DateTime.Now.Year.ToString().Substring(DateTime.Now.Year.ToString().Length - 2, 2);
            int iYear = Int32.Parse(sYear);
            sYear = ((char)(iYear + 55)).ToString();

            switch (DateTime.Now.Month)
            {
                case 10:
                    sMonth = "A";
                    break;
                case 11:
                    sMonth = "B";
                    break;
                case 12:
                    sMonth = "C";
                    break;
                default:
                    sMonth = DateTime.Now.Month.ToString();
                    break;
            }
            sDay = string.Format("{0:D2}", DateTime.Now.Day);
            string sCustomerNoPre = sCustomerBm + sYear + sMonth + sDay;
            string strNumber = @"0000";
            object obj =
                ExecuteScalar(
                    string.Format(
                        @"SELECT RIGHT(CustomerNO,4) FROM InCustomers WHERE CustomerNO LIKE '{0}%' ORDER BY CustomerNO DESC",
                        sCustomerNoPre));
            if (obj != null)
            {
                strNumber = obj.ToString();
            } ;
            string strCustomerNo = sCustomerNoPre + (Int32.Parse(strNumber) + 1).ToString("D4");
            ExecuteNonQuery(string.Format(@"INSERT INTO InCustomers(CNumber, CustomerNO, SalesMemory, SalesEmployee, SalesDate, Creater, Completed)
                                            VALUES('{0}', '{1}', '', '{2}', GETDATE(), '{2}', 1)", strNumber, strCustomerNo, Information.CurrentUser.EmployeeNO));
            return strCustomerNo;
        }

        /// <summary>
        /// 获取客户信息
        /// </summary>
        /// <param name="customerNO">客户编号</param>
        /// <returns>客户信息</returns>
        [WebMethod]
        public CustomerInfo GetCustomerInfo(string customerNO)
        {
            using(DataSet dsCustomer = ExecuteQuery(string.Format(@"SELECT * FROM dbo.v_SearchCustomer WHERE CustomerNO = '{0}'", customerNO)))
            {
                DataRow dr = null;
                try
                {
                    dr = dsCustomer.Tables[0].Rows[0];
                }
                catch
                {
                    MessageBoxEx.Error(string.Format(@"在数据库中查询用户信息时遇到了问题导致失败！{0}方法名称：'CustomerManagement.GetCustomerInfo'", Environment.NewLine));
                }
                return CustomerInfo.FromDataRow(dr);
            }
        }

        /// <summary>
        /// 保存介绍回馈信息
        /// </summary>
        /// <param name="introducerCustomerNO">介绍人编号</param>
        /// <param name="customerNO">客人编号</param>
        /// <param name="rNumber">回馈金额</param>
        /// <param name="repayEnableDate">回馈有效时间</param>
        /// <param name="option">处理方式</param>
        [WebMethod]
        public void SaveIntroducerRepay(string introducerCustomerNO, string customerNO, string rNumber, string repayEnableDate, IntroducerOption option)
        {
            string sSql = "";
            switch(option)
            {
                case IntroducerOption.New:
                {
                    sSql = "Insert into IntroducerRepay (IntroducerCustomerNO, CustomerNO, RNumber,IsRepay, RepayEnableDate) values ('" + introducerCustomerNO + "','" + customerNO + "', '" + rNumber + "','0', '" + repayEnableDate + "')";
                    break;
                }
                case IntroducerOption.Edit:
                {
                    sSql = "Update IntroducerRepay set IntroducerCustomerNO='" + introducerCustomerNO + "' where CustomerNO='" + customerNO + "' ";

                    break;
                }
                case IntroducerOption.Delete:
                {
                    sSql = "Delete IntroducerRepay where CustomerNO='" + customerNO + "' ";

                    break;
                }
            }
            ExecuteNonQuery(sSql);
        }

        /// <summary>
        /// 查询作为介绍人的客人信息
        /// </summary>
        /// <param name="customerNO">客人编号</param>
        /// <returns>客人信息</returns>
        [WebMethod]
        public DataSet SearchIntroducerCustomer(string customerNO)
        {
            return ExecuteQuery(string.Format(@"SELECT CardNO, CustomerName1, CustomerName2 FROM dbo.v_SearchCustomer WHERE CustomerNO = '{0}'", customerNO));
        }

        /// <summary>
        /// 添加客户
        /// </summary>
        /// <returns>操作是否成功</returns>
        [WebMethod]
        public bool SaveCustomer(string customerNO, string cardType, string cardNO, string introducerType, string introducerCardNO, 
                                 string customerName1, string birthdayYear1, string birthdayDay1, string birthdayMonth1, string theGregorianCalendar1, 
                                 string mobilePhone1, string mobilePhoneIsLose1, string telephone1, string telephoneIsLose1, string qq_msn1, 
                                 string email1, string job1, string jobName1, string address1, string zipCode1, 
                                 string customerName2, string birthdayYear2, string birthdayDay2, string birthdayMonth2, string theGregorianCalendar2, 
                                 string mobilePhone2, string mobilePhoneIsLose2, string telephone2, string telephoneIsLose2, string qq_msn2, 
                                 string email2, string job2, string jobName2, string address2, string zipCode2, 
                                 string isLetterAddress, string marryDate, string marryDate2, string customerSource, string customerSourceName, 
                                 string imformationSource, string imformationSourceName, string wishRecommend, string wishRecommendName, string customerMemory, 
                                 string customerState, string isDelete, string n_address1, string n_address2, string n_address3,  
                                 string v_address1, string v_address2, string v_address3, string companyBM, 
                                 string address, string zipCode, string isEnableAddress)
        {
            try
            {
                string strSql = string.Format(@"
                                                INSERT INTO Customers 
                                                (
	                                                CustomerNO, CardType, CardNO, IntroducerType, IntroducerCardNO, 
	                                                CustomerName1, BirthdayYear1, BirthdayDay1, BirthdayMonth1, TheGregorianCalendar1, 
	                                                MobilePhone1, MobilePhoneIsLose1, Telephone1, TelephoneIsLose1, QQ_MSN1, 
	                                                Email1, Job1, JobName1, Address1, ZipCode1, 
	                                                CustomerName2, BirthdayYear2, BirthdayDay2, BirthdayMonth2, TheGregorianCalendar2, 
	                                                MobilePhone2, MobilePhoneIsLose2, Telephone2, TelephoneIsLose2, QQ_MSN2, 
	                                                Email2, Job2, JobName2, Address2, ZipCode2,
	                                                IsLetterAddress, MarryDate, MarryDate2, CustomerSource, CustomerSourceName, 
	                                                ImformationSource, ImformationSourceName, WishRecommend, WishRecommendName, CustomerMemory, 
	                                                CreateDepartment, CreateDepartmentName, CreateEmployee, CreateEmployeeName, CreateDate, 
	                                                CustomerState, IsDelete, N_Address_1, N_Address_2, N_Address_3,
	                                                V_Address_1, V_Address_2, V_Address_3, CompanyBM
                                                )
                                                VALUES('{0}', '{1}', '{2}', '{3}', '{4}', 
	                                                   '{5}', '{6}', '{7}', '{8}', '{9}', 
	                                                   '{10}', '{11}', '{12}', '{13}', '{14}', 
	                                                   '{15}', '{16}', '{17}', '{18}', '{19}',
	                                                   '{20}', '{21}', '{22}', '{23}', '{24}', 
	                                                   '{25}', '{26}', '{27}', '{28}', '{29}',
	                                                   '{30}', '{31}', '{32}', '{33}', '{34}', 
	                                                   '{35}', '{36}', '{37}', '{38}', '{39}',
	                                                   '{40}', '{41}', '{42}', '{43}', '{44}', 
	                                                   '{45}', '{46}', '{47}', '{48}', GETDATE(),
	                                                   '{49}', '{50}', '{51}', '{52}', '{53}', 
	                                                   '{54}', '{55}', '{56}', '{57}')

                                                INSERT INTO Letters (CustomerNO, [Address], ZipCode, IsEnableAddress)
                                                VALUES('{0}', '{58}', '{59}', '{60}')", 
                                                       customerNO, cardType, cardNO, introducerType, introducerCardNO,
                                                       customerName1, birthdayYear1, birthdayDay1, birthdayMonth1, theGregorianCalendar1,
                                                       mobilePhone1, mobilePhoneIsLose1, telephone1, telephoneIsLose1, qq_msn1,
                                                       email1, job1, jobName1, address1, zipCode1,
                                                       customerName2, birthdayYear2, birthdayDay2, birthdayMonth2, theGregorianCalendar2,
                                                       mobilePhone2, mobilePhoneIsLose2, telephone2, telephoneIsLose2, qq_msn2,
                                                       email2, job2, jobName2, address2, zipCode2,
                                                       isLetterAddress, marryDate, marryDate2, customerSource, customerSourceName,
                                                       imformationSource, imformationSourceName, wishRecommend, wishRecommendName, customerMemory,
                                                       Information.CurrentUser.EmployeeDepartmentNO, Information.CurrentUser.EmployeeDepartmentName, Information.CurrentUser.EmployeeNO, Information.CurrentUser.EmployeeName,
                                                       customerState, isDelete, n_address1, n_address2, n_address3,
                                                       v_address1, v_address2, v_address3, companyBM,
                                                       address, zipCode, isEnableAddress);
                ExecuteNonQuery(strSql);
                return true;
            }
            catch(Exception ex)
            {
                MessageBoxEx.Error(ex.Message);
                return false;
            }
        }

        /// <summary>
        /// 更新客户
        /// </summary>
        /// <returns>操作是否成功</returns>
        [WebMethod]
        public bool UpdateCustomer(string customerNO, string cardType, string cardNO, string introducerType, string introducerCardNO,
                                  string customerName1, string birthdayYear1, string birthdayDay1, string birthdayMonth1, string theGregorianCalendar1,
                                  string mobilePhone1, string mobilePhoneIsLose1, string telephone1, string telephoneIsLose1, string qq_msn1,
                                  string email1, string job1, string jobName1, string address1, string zipCode1,
                                  string customerName2, string birthdayYear2, string birthdayDay2, string birthdayMonth2, string theGregorianCalendar2,
                                  string mobilePhone2, string mobilePhoneIsLose2, string telephone2, string telephoneIsLose2, string qq_msn2,
                                  string email2, string job2, string jobName2, string address2, string zipCode2,
                                  string isLetterAddress, string marryDate, string marryDate2, string customerSource, string customerSourceName,
                                  string imformationSource, string imformationSourceName, string wishRecommend, string wishRecommendName, string customerMemory,
                                  string customerState, string isDelete, string n_address1, string n_address2, string n_address3,
                                  string v_address1, string v_address2, string v_address3, string address, string zipCode, string isEnableAddress)
        {
            try
            {
                string strSql = string.Format(@"
                                                        UPDATE Customers 
                                                        SET 
                                                        CardType='{1}', CardNO='{2}', IntroducerType='{3}', IntroducerCardNO='{4}', CustomerName1='{5}',
                                                        BirthdayYear1='{6}', BirthdayDay1='{7}', BirthdayMonth1='{8}', TheGregorianCalendar1= '{9}', MobilePhone1='{10}', 
                                                        MobilePhoneIsLose1='{11}', Telephone1='{12}', TelephoneIsLose1='{13}', QQ_MSN1='{14}', Email1='{15}',
                                                        Job1='{16}', JobName1='{17}', Address1='{18}', ZipCode1='{19}', CustomerName2='{20}', 
                                                        BirthdayYear2='{21}', BirthdayDay2='{22}', BirthdayMonth2='{23}', TheGregorianCalendar2='{24}', MobilePhone2='{25}', 
                                                        MobilePhoneIsLose2='{26}', Telephone2='{27}', TelephoneIsLose2='{28}', QQ_MSN2='{29}', Email2='{30}',
                                                        Job2='{31}', JobName2='{32}', Address2='{33}', ZipCode2='{34}', IsLetterAddress='{35}', 
                                                        MarryDate='{36}', MarryDate2='{37}', CustomerSource='{38}', CustomerSourceName='{39}', ImformationSource='{40}',
                                                        ImformationSourceName='{41}', WishRecommend='{42}', WishRecommendName='{43}', CustomerMemory='{44}', CustomerState='{45}',  
                                                        IsDelete='{46}', N_Address_1='{47}', N_Address_2='{48}', N_Address_3='{49}', v_Address_1='{50}',
                                                        v_Address_2='{51}', v_Address_3='{52}'  
                                                        WHERE CustomerNO='{0}' 

                                                        IF EXISTS(SELECT 1 FROM Letters WHERE CustomerNO='{0}') 
                                                        BEGIN
	                                                        UPDATE Letters 
	                                                        SET [Address]='{53}', ZipCode='{54}', IsEnableAddress='{55}' 
	                                                        WHERE CustomerNO='{0}'
                                                        END
                                                        ELSE BEGIN
	                                                        INSERT INTO Letters (CustomerNO, [Address], ZipCode, IsEnableAddress)
	                                                        VALUES('{0}', '{53}', '{54}', '{55}')
                                                        END",
                                                        customerNO, cardType, cardNO, introducerType, introducerCardNO,
                                                        customerName1, birthdayYear1, birthdayDay1, birthdayMonth1, theGregorianCalendar1,
                                                        mobilePhone1, mobilePhoneIsLose1, telephone1, telephoneIsLose1, qq_msn1,
                                                        email1, job1, jobName1, address1, zipCode1,
                                                        customerName2, birthdayYear2, birthdayDay2, birthdayMonth2, theGregorianCalendar2,
                                                        mobilePhone2, mobilePhoneIsLose2, telephone2, telephoneIsLose2, qq_msn2,
                                                        email2, job2, jobName2, address2, zipCode2,
                                                        isLetterAddress, marryDate, marryDate2, customerSource, customerSourceName,
                                                        imformationSource, imformationSourceName, wishRecommend, wishRecommendName, customerMemory,
                                                        customerState, isDelete, n_address1, n_address2, n_address3,
                                                        v_address1, v_address2, v_address3, address, zipCode, isEnableAddress);
                ExecuteNonQuery(strSql);
                return true;
            }
            catch(Exception ex)
            {
                MessageBoxEx.Error(ex.Message);
                return false;
            }
        }
    }
}