using System;
using System.Data;
using GoldenLady.Extension;

namespace GoldenLady.Standard.Dress
{
    /// <summary>
    /// 场馆
    /// LiuHaiyang
    /// 2017.4.29
    /// </summary>
    public sealed class Venue : ManagedObject
    {
        /// <summary>
        /// 关联的部门编号
        /// </summary>
        public string DepartmentNo { get; set; }

        /// <summary>
        /// 从数据行构造
        /// </summary>
        /// <param name="dr">数据行</param>
        /// <returns>构造好的对象</returns>
        public static Venue FromDataRow(DataRow dr)
        {
            if(dr == null)
            {
                throw new ArgumentNullException(@"dr", @"数据行参数为空！");
            }
            return new Venue
            {
                ID = dr["ID"].SafeDbInt32(),
                Name = dr["Name"].SafeDbString(),
                Description = dr["Description"].SafeDbString(),
                Disabled = dr["Disabled"].SafeDbBoolean(),
                DepartmentNo = dr["DepartmentNO"].SafeDbString()
            };
        }
        public override ManagedObject ShallowClone()
        {
            return (Venue)MemberwiseClone();
        }
    }
}