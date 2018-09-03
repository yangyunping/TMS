using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using GoldenLady.Extension;

namespace GoldenLady.Standard
{
    /// <summary>
    /// 包装
    /// </summary>
    public sealed class Box : KVPair<string>
    {
        private static Box _none;
        /// <summary>
        /// 表示未选中或未知
        /// </summary>
        public static Box None
        {
            get
            {
                return _none ?? (_none = new Box
                {
                    Name = @"无"
                });
            }
        }

        /// <summary>
        /// 从数据行构造
        /// </summary>
        /// <param name="dr">数据行</param>
        /// <returns>构造好的对象</returns>
        public static Box FromDataRow(DataRow dr)
        {
            if(dr == null)
            {
                throw new ArgumentNullException(@"dr", @"数据行参数为空！");
            }
            return new Box
            {
                Name = dr["RequireValue"].SafeDbString(),
                Value = dr["RequireNO"].SafeDbString()
            };
        }

        /// <summary>
        /// 从列表中按编号匹配
        /// </summary>
        /// <param name="boxNo">编号</param>
        /// <param name="boxes">列表</param>
        /// <returns>匹配结果</returns>
        public static Box Parse(string boxNo, IEnumerable<Box> boxes)
        {
            return boxes.FirstOrDefault(box => box.Value == boxNo);
        }
    }
}