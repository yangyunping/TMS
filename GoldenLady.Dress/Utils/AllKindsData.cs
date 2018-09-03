
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace GoldenLady.Dress.Utils
{
     public static class AllKindsData
     {
         /// <summary>
         /// 订单详情
         /// </summary>
         public static string OrderNo { set; get; }
         public static int VenueId{ set; get; }
         public static string VenueName { set; get; }
         public static string VenueDepartmentNo { set; get; }
         public static string OrderVenueNo { set; get; }
         public static string SuitName { set; get; }
         public static decimal SuitPrice { set; get; }
         public static string CustomerNo { set; get; }
         public static string CustomerName { set; get; }
         public static string MoblePhone { set; get; }
         public static string ShootDate { set; get; }

         /// <summary>
         /// 风格
         /// </summary>
         /// 
         public static Dictionary<string, string> ThemeInfo { set; get; }

         /// <summary>
         /// 场景
         /// </summary>
          public static Dictionary<string, string> SceneInfo { set; get; }

         /// <summary>
         /// 选中的礼服
         /// </summary>
         /// 
         public static Dictionary<string, string> ChoosedDressInfo { set; get; }

         /// <summary>
         /// 礼服特征
         /// </summary>
         public static List<string> ChoosedDressStyle { set; get; }

         /// <summary>
         /// 选中的妆面
         /// </summary>
         public static Dictionary<string, string> ChoosedFaceInfo { set; get; }
         /// <summary>
         /// 选中的男装
         /// </summary>
         public static Dictionary<string, string> ChoosedManDressInfo { set; get; }
         /// <summary>
         /// 礼服大图路径集合
         /// </summary>
         public static List<string> ImgPathLst { get; set; }
     }
}
