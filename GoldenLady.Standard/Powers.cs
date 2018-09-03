#pragma warning disable 1591
using System.Linq;
namespace GoldenLady.Standard
{
    /// <summary>
    /// 系统权限
    /// </summary>
    public static class Powers
    {
        public static class 收银
        {
            public static readonly int 订单收银 = 1;
            public static readonly int 查询所有收银记录 = 2;
            public static readonly int 打印票据 = 3;
            public static readonly int 收款事由设置 = 4;
            public static readonly int 收款方式设置 = 5;
            public static readonly int 票号设置 = 6;
            public static readonly int 发票作废冲红 = 7;
            public static readonly int 导出收银数据 = 8;
            public static readonly int 打印日报表 = 9;
            public static readonly int 修改票号 = 10;
            public static readonly int 收银扎帐 = 11;
        }

        public static class 门市订单
        {
            public static readonly int 新建订单 = 501;
            public static readonly int 查询个人订单 = 502;
            public static readonly int 查询部门订单 = 503;
            public static readonly int 查询所有订单 = 504;
            public static readonly int 修改订单和客户信息 = 505;
            public static readonly int 删除订单 = 506;
            public static readonly int 导出数据 = 507;
        }

        public static class 邀约控制
        {
            public static readonly int 设置邀约时间表 = 1001;
            public static readonly int 改期邀约时间 = 1002;
            public static readonly int 删除邀约时间 = 1003;
            public static readonly int 安排邀约时间 = 1004;
        }

        public static class 摄影
        {
            public static readonly int 设置摄控表 = 1501;
            public static readonly int 安排摄控 = 1502;
            public static readonly int 改期摄控 = 1503;
            public static readonly int 删除摄控 = 1504;
            public static readonly int 重拍补拍 = 1505;
            public static readonly int 摄影时间人员安排 = 1506;
            public static readonly int 摄控量数量锁定和解锁 = 1507;
            public static readonly int 摄影完成 = 1508;
        }

        public static class 设计
        {
            public static readonly int 分件 = 2001;
            public static readonly int 样前设计 = 2002;
            public static readonly int 样后设计 = 2003;
            public static readonly int 设计质检 = 2004;
            public static readonly int 清空服务器照片 = 2005;
            public static readonly int 生产打包 = 2006;
        }

        public static class 看样
        {
            public static readonly int 设置看控 = 2501;
            public static readonly int 安排看控 = 2502;
            public static readonly int 改期看控 = 2503;
            public static readonly int 删除看控 = 2504;
            public static readonly int 进入选片 = 2505;
            public static readonly int 选片解锁 = 2506;
            public static readonly int 看样下件 = 2507;
            public static readonly int 看样重拍 = 2508;
            public static readonly int 预览照片删除 = 2509;
            public static readonly int 生产要求 = 2510;
        }

        public static class 看版
        {
            public static readonly int 设置看版控 = 3001;
            public static readonly int 安排看版控 = 3002;
            public static readonly int 改期看版控 = 3003;
            public static readonly int 删除看版控 = 3004;
            public static readonly int 看版完成 = 3005;
            public static readonly int 进入看版 = 3006;
        }

        public static class 取件
        {
            public static readonly int 设置取控表 = 3501;
            public static readonly int 安排取控 = 3502;
            public static readonly int 改期取控 = 3503;
            public static readonly int 删除取控 = 3504;
            public static readonly int 后期发货 = 3505;
            public static readonly int 产品对件 = 3506;
            public static readonly int 取件完成 = 3507;
        }

        public static class 归档
        {
            public static readonly int 订单归档 = 4001;
        }

        public static class 短信
        {
            public static readonly int 短信模板设置 = 4501;
            public static readonly int 短信发送 = 4502;
        }

        public static class 报表
        {
            public static readonly int 报表查询 = 5001;
        }

        public static class 系统
        {
            public static readonly int 系统设置要素设置 = 5501;
            public static readonly int 环境设置 = 5502;
            public static readonly int 地区数据 = 5503;
            public static readonly int 订单存储服务器 = 5504;
        }

        public static class 人资
        {
            public static readonly int 公司部门架构设置 = 6001;
            public static readonly int 人员信息权限设置 = 6002;
            public static readonly int 人资考勤 = 6003;
        }

        public static class 套系
        {
            public static readonly int 套系设置 = 6501;
            public static readonly int 产品管理 = 6502;
        }

        public static class 礼服
        {
            public static readonly int 礼服管理 = 7001;
            public static readonly int 礼服预选 = 7002;
            public static readonly int 礼服出租 = 7003;
            public static readonly int 洗衣房 = 7004;
            public static readonly int 礼服权限 = 7005;
            public static readonly int 高级删除 = 7006;
        }

        public static class 客服
        {
            public static readonly int 客服人员 = 7501;
        }
    }

    public static class PowersExtension
    {
        public static bool 包含收银权限(this int[] powers)
        {
            return powers.Any(p => 0 < p && p < 99);
        }
        public static bool 包含订单查询权限(this int[] powers)
        {
            return powers.Any(p => 501 < p && p < 505);
        }
        public static bool 包含门市订单权限(this int[] powers)
        {
            return powers.Any(p => 500 < p && p < 599);
        }
        public static bool 包含邀约时间表权限(this int[] powers)
        {
            return powers.Any(p => 1000 < p && p < 1099);
        }
        public static bool 包含摄影权限(this int[] powers)
        {
            return powers.Any(p => 1500 < p && p < 1599);
        }
        public static bool 包含设计权限(this int[] powers)
        {
            return powers.Any(p => 2000 < p && p < 2099);
        }
        public static bool 包含看样权限(this int[] powers)
        {
            return powers.Any(p => 2500 < p && p < 2599);
        }
        public static bool 包含看版权限(this int[] powers)
        {
            return powers.Any(p => 3000 < p && p < 3099);
        }
        public static bool 包含取件权限(this int[] powers)
        {
            return powers.Any(p => 3500 < p && p < 3599);
        }
        public static bool 包含短信权限(this int[] powers)
        {
            return powers.Any(p => 4500 < p && p < 4599);
        }
        public static bool 包含系统权限(this int[] powers)
        {
            return powers.Any(p => 5500 < p && p < 6599);
        }

        public static bool 包含人资权限(this int[] powers)
        {
            return powers.Any(p => 6000 < p && p < 6099);
        }

        public static bool 包含礼服权限(this int[] powers)
        {
            return powers.Any(p => 7000 < p && p < 7099);
        }  
    }
}