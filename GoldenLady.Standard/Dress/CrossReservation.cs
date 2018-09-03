using System.Data;
using GoldenLady.Extension;

namespace GoldenLady.Standard.Dress
{
    /// <summary>
    /// 跨馆选衣配置记录
    /// LiuHaiyang
    /// 2017.7.22
    /// </summary>
    public sealed class CrossReservation
    {
        /// <summary>
        /// 记录编号
        /// </summary>
        public int ID { get; set; }
        /// <summary>
        /// 场馆编号
        /// </summary>
        public int VenueID { get; set; }
        /// <summary>
        /// 跨馆编号
        /// </summary>
        public int CrossVenueID { get; set; }
        /// <summary>
        /// 跨馆名称
        /// </summary>
        public string CrossVenue { get; set; }

        /// <summary>
        /// 从数据行生成对象
        /// </summary>
        /// <param name="row"></param>
        /// <returns></returns>
        public static CrossReservation FromDataRow(DataRow row)
        {
            return new CrossReservation
            {
                ID = row["ID"].SafeDbInt32(),
                VenueID = row["VenueID"].SafeDbInt32(),
                CrossVenueID = row["CrossVenueID"].SafeDbInt32(),
                CrossVenue = row["CrossVenue"].SafeDbString()
            };
        }
    }
}