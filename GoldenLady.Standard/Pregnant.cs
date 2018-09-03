namespace GoldenLady.Standard
{
    /// <summary>
    /// 怀孕情况
    /// </summary>
    public sealed class Pregnant : KVPair<bool>
    {
        /// <summary>
        /// 防止显式构造
        /// </summary>
        private Pregnant() {}

        private static Pregnant _yes;
        private static Pregnant _no;

        /// <summary>
        /// 怀孕
        /// </summary>
        public static Pregnant Yes
        {
            get
            {
                return _yes ?? (_yes = new Pregnant
                {
                    Name = @"是",
                    Value = true
                });
            }
        }

        /// <summary>
        /// 未怀孕
        /// </summary>
        public static Pregnant No
        {
            get
            {
                return _no ?? (_no = new Pregnant
                {
                    Name = @"否",
                    Value = false
                });
            }
        }

        /// <summary>
        /// 未知
        /// </summary>
        public static Pregnant Unknown
        {
            get { return null; }
        }

        /// <summary>
        /// 转换为Pregnant对象
        /// </summary>
        /// <param name="isPregnant">是否怀孕</param>
        /// <returns>构造好的Pregnant对象</returns>
        public static Pregnant Parse(bool isPregnant)
        {
            return isPregnant ? Yes : No;
        }
    }
}