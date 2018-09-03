using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GoldenLadyWS.Model
{
    public static class ProcessItem
    {
        /// <summary>
        /// 新订单
        /// </summary>
        public static double NewOrder = 0;//	新订单
        /// <summary>
        /// 订单补拍
        /// </summary>
        public static double OrderAdditional = 0.1d;//	订单补拍
        /// <summary>
        /// 订单重拍
        /// </summary>
        public static double OrderRepeat = 0.2d;//	订单重拍
        /// <summary>
        /// 安排摄影
        /// </summary>
        public static double ScheduleShootDate = 10;//	安排摄影
        /// <summary>
        /// 安排补拍
        /// </summary>
        public static double ScheduleAdditionalDate = 10.1d;//	安排补拍
        /// <summary>
        /// 安排重拍
        /// </summary>
        public static double ScheduleRepeatDate = 10.2d;//	安排重拍
        /// <summary>
        /// 摄影完成
        /// </summary>
        public static double ShootComplete = 15;//	摄影完成
        /// <summary>
        /// 补拍完成
        /// </summary>
        public static double AdditionalComplete = 15.1d;//	补拍完成
        /// <summary>
        /// 重拍完成
        /// </summary>
        public static double RepeatComplete = 15.2d;//重拍完成
        /// <summary>
        /// 分件
        /// </summary>
        public static double Dispatch = 20;//	分件
        /// <summary>
        /// 样前设计完成
        /// </summary>
        public static double PreDesignComplete = 25;//	样前设计完成
        /// <summary>
        /// 安排看样
        /// </summary>
        public static double ScheduleChoose = 30;//	安排看样
        /// <summary>
        /// 看样完成
        /// </summary>
        public static double ChooseComplete = 35;//	看样完成
        /// <summary>
        /// 安排看版
        /// </summary>
        public static double ScheduleLookBan = 40;//	安排看版
        /// <summary>
        /// 看版完成
        /// </summary>
        public static double LookBanComplete = 45;//	看版完成
        /// <summary>
        /// 样后设计
        /// </summary>
        public static double Design = 50;//	样后设计
        /// <summary>
        /// 样后设计完成
        /// </summary>
        public static double DesignComplete = 53;//	样后设计完成
        /// <summary>
        /// 生产打包
        /// </summary>
        public static double Package = 56;//	生产打包
        /// <summary>
        /// 安排取件
        /// </summary>
        public static double ScheduleGetGoods = 60;//	安排取件
        /// <summary>
        /// 取件完成
        /// </summary>
        public static double GetGoodsComplete = 65;//	取件完成
        /// <summary>
        /// 归档
        /// </summary>
        public static double OrderFinish = 70;//	归档

        public static  string GetProcessName(double ProcessId)
        {
            if (ProcessId == 0)
            {
                return "新订单";
            }
            else if (ProcessId == 0.1f)
            {
                return "订单补拍";
            }
            else if (ProcessId == 0.2f)
            {
                return "订单重拍";
            }
            else if (ProcessId == 10)
            {
                return "安排摄影";
            }
            else if (ProcessId == 10.1f)
            {
                return "安排补拍";
            }
            else if (ProcessId == 10.2f)
            {
                return "安排重拍";
            }
            else if (ProcessId == 15)
            {
                return "摄影完成";
            }
            else if (ProcessId == 15.1f)
            {
                return "补拍完成";
            }
            else if (ProcessId == 15.2f)
            {
                return "重拍完成";
            }
            else if (ProcessId == 20)
            {
                return "分件";
            }
            else if (ProcessId == 25)
            {
                return "样前设计完成";
            }
            else if (ProcessId == 30)
            {
                return "安排看样";
            }
            else if (ProcessId == 35)
            {
                return "看样完成";
            }
            else if (ProcessId == 40)
            {
                return "安排看版";
            }
            else if (ProcessId == 45)
            {
                return "看版完成";
            }
            else if (ProcessId == 50)
            {
                return "样后设计";
            }
            else if (ProcessId == 53)
            {
                return "样后设计完成";
            }
            else if (ProcessId == 56)
            {
                return "生产打包";
            }
            else if (ProcessId == 60)
            {
                return "安排取件";
            }
            else if (ProcessId == 65)
            {
                return "取件完成";
            }
            else if (ProcessId == 70)
            {
                return "归档";
            }
            else
            { return string.Empty; }
        }
    }
}
