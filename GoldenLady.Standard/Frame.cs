using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using GoldenLady.Extension;

namespace GoldenLady.Standard
{
    /// <summary>
    /// 框条
    /// </summary>
    public sealed class Frame : KVPair<string>
    {
        private static Frame _none;
        /// <summary>
        /// 表示未选中或未知
        /// </summary>
        public static Frame None
        {
            get
            {
                return _none ?? (_none = new Frame
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
        public static Frame FromDataRow(DataRow dr)
        {
            if(dr == null)
            {
                throw new ArgumentNullException(@"dr", @"数据行参数为空！");
            }
            return new Frame
            {
                Name = dr["RequireValue"].SafeDbString(),
                Value = dr["RequireNO"].SafeDbString()
            };
        }

        /// <summary>
        /// 从列表中按编号匹配
        /// </summary>
        /// <param name="frameNo">编号</param>
        /// <param name="frames">列表</param>
        /// <returns>匹配结果</returns>
        public static Frame Parse(string frameNo, IEnumerable<Frame> frames)
        {
            return frames.FirstOrDefault(frame => frame.Value == frameNo);
        }
    }
}