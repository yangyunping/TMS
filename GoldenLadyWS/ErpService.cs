using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using GoldenLady.Utility;

namespace GoldenLadyWS
{
    /// <summary>
    /// 数据库服务接口 该类中的方法支持将执行过程中的异常抛出
    /// </summary>
    public abstract class ErpService
    {
        protected readonly DateTime DEF_DATETIME = new DateTime(1989, 1, 1);
        protected const int ExecuteTimeout = 60;

        protected static string ConnectionString { get; set; }

        static ErpService() 
        {
            FetchConnString();
        }
        public static void FetchConnString()
        {
            ConnectionString = ConfigurationManager.AppSettings["DSN"];
            ConnectionString = DESTool.Decrypt(ConnectionString, ConfigurationManager.AppSettings["cKey"]);
        }

        /// <summary>
        /// 数据库操作——公司管理部分
        /// </summary>
        public static CompanyManagement CompanyManagement
        {
            get { return CompanyManagement.Instance; }
        }
        /// <summary>
        /// 数据库操作——日志管理部分
        /// </summary>
        public static LogManagement LogManagement
        {
            get { return LogManagement.Instance; }
        }
        /// <summary>
        /// 数据库操作——设计部分
        /// </summary>
        public static OrderDesign OrderDesign
        {
            get { return OrderDesign.Instance; }
        }
        /// <summary>
        /// 数据库操作——订单状态部分
        /// </summary>
        public static OrderState OrderState
        {
            get
            {
                return OrderState.Instance;
            }
        }
        /// <summary>
        /// 数据库操作——订单产品部分
        /// </summary>
        public static OrderProducts OrderProducts
        {
            get
            {
                return OrderProducts.Instance;
            }
        }
        /// <summary>
        /// 数据库操作——订单拍摄部分
        /// </summary>
        public static OrderShoot OrderShoot
        {
            get
            {
                return OrderShoot.Instance;
            }
        }
        /// <summary>
        /// 数据库操作——客户管理部分
        /// </summary>
        public static CustomerManagement CustomerManagement
        {
            get
            {
                return CustomerManagement.Instance;
            }
        }
        /// <summary>
        /// 数据库操作——配置管理部分
        /// </summary>
        public static ConfigManagement ConfigManagement
        {
            get
            {
                return ConfigManagement.Instance;
            }
        }
        /// <summary>
        /// 数据库操作——系统要素配置管理部分
        /// </summary>
        public static ElementManagement ElementManagement
        {
            get
            {
                return ElementManagement.Instance;
            }
        }
        /// <summary>
        /// 数据库操作——收银管理部分
        /// </summary>
        public static CashManagement CashManagement
        {
            get
            {
                return CashManagement.Instance;
            }
        }
        /// <summary>
        /// 数据库操作——订单管理部分
        /// </summary>
        public static OrderManagement OrderManagement
        {
            get
            {
                return OrderManagement.Instance;
            }
        }
        /// <summary>
        /// 数据库操作——礼服管理部分
        /// </summary>
        public static DressManagement DressManagement
        {
            get
            {
                return DressManagement.Instance;
            }
        }
        /// <summary>
        /// 看样
        /// </summary>
        public static ChooseDal ChooseDal
        {
            get
            {
                return ChooseDal.Instance;
            }
        }
        /// <summary>
        /// 看版
        /// </summary>
        public static LookBanDal LookBanDal
        {
            get
            {
                return LookBanDal.Instance;
            }
        }

        /// <summary>
        /// 执行不带返回结果的SQL语句
        /// </summary>
        /// <param name="sql">要执行的SQL语句</param>
        /// <returns>受影响的行数</returns>
        protected int ExecuteNonQuery(string sql)
        {
            using(SqlConnection conn = new SqlConnection(ConnectionString))
            {
                conn.Open();
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = sql;
                cmd.CommandTimeout = ExecuteTimeout;
                return cmd.ExecuteNonQuery();
            }
        }
        /// <summary>
        /// 执行多返回值的SQL语句
        /// </summary>
        /// <param name="sql">要执行的SQL语句</param>
        /// <returns>查询结果</returns>
        protected DataSet ExecuteQuery(string sql)
        {
            using(SqlConnection conn = new SqlConnection(ConnectionString))
            {
                conn.Open();
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = sql;
                cmd.CommandTimeout = ExecuteTimeout;
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                sda.Fill(ds, @"result");
                return ds;
            }
        }
        /// <summary>
        /// 执行单一返回值的SQL语句
        /// </summary>
        /// <param name="sql">要执行的SQL语句</param>
        /// <returns>查询结果</returns>
        protected object ExecuteScalar(string sql)
        {
            using(SqlConnection conn = new SqlConnection(ConnectionString))
            {
                conn.Open();
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = sql;
                cmd.CommandTimeout = ExecuteTimeout;
                return cmd.ExecuteScalar();
            }
        }
        /// <summary>
        /// 测试连接是否成功
        /// </summary>
        /// <returns>成功返回true，否则false</returns>
        protected bool TestConnection()
        {
            try
            {
                using(SqlConnection conn = new SqlConnection(ConnectionString))
                {
                    conn.Open();
                }
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}