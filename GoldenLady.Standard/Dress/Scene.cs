using System;
using System.Data;
using GoldenLady.Extension;

namespace GoldenLady.Standard.Dress
{
    /// <summary>
    /// 场景
    /// LiuHaiyang
    /// 2017.4.29
    /// </summary>
    public sealed class Scene : ManagedObject
    {
        /// <summary>
        /// 所属风格编号
        /// </summary>
        public int ThemeID { get; set; }

        /// <summary>
        /// 从数据行构造
        /// </summary>
        /// <param name="dr">数据行</param>
        /// <returns>构造好的对象</returns>
        public static Scene FromDataRow(DataRow dr)
        {
            if(dr == null)
            {
                throw new ArgumentNullException(@"dr", @"数据行参数为空！");
            }
            return new Scene
            {
                ID = dr["ID"].SafeDbInt32(),
                Name = dr["Name"].SafeDbString(),
                Description = dr["Description"].SafeDbString(),
                Disabled = dr["Disabled"].SafeDbBoolean(),
                ThemeID = dr["ThemeID"].SafeDbInt32()
            };
        }
        public override ManagedObject ShallowClone()
        {
            return (Scene)MemberwiseClone();
        }
    }
}