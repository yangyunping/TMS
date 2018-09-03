using System;

namespace GoldenLady.Extension
{
    /// <summary>
    /// 用于将数据库获取到的数据对象安全的转换成C#基本类型
    /// LiuHaiyang
    /// 2017.4.21
    /// </summary>
    public static class ObjectExtension
    {
        public static object SafeDbObject(this object val)
        {
            return val == DBNull.Value ? null : val;
        }
        public static string SafeDbString(this object val)
        {
            return Convert.ToString(val.SafeDbObject());
        }
        public static bool SafeDbBoolean(this object val)
        {
            return Convert.ToBoolean(val.SafeDbObject());
        }
        public static decimal SafeDbDecimal(this object val)
        {
            return Convert.ToDecimal(val.SafeDbObject());
        }
        public static int SafeDbInt32(this object val)
        {
            return Convert.ToInt32(val.SafeDbObject());
        }
        public static byte SafeDbByte(this object val)
        {
            return Convert.ToByte(val.SafeDbObject());
        }
        public static byte? SafeDbNullByte(this object val)
        {
            return Convert.IsDBNull(val) ? null : Convert.ToByte(val.SafeDbObject()) as byte?;
        }
        public static DateTime SafeDbDateTime(this object val)
        {
            return Convert.ToDateTime(val.SafeDbObject());
        }
        public static T SafeDbValue<T>(this object val)
        {
            if(val == DBNull.Value)
            {
                return default(T);
            }
            return (T)Convert.ChangeType(val, typeof(T));
        }
    }
}