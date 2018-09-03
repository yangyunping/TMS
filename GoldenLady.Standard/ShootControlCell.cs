namespace GoldenLady.Standard
{
    /// <summary>
    /// 摄控表单元格
    /// </summary>
    public sealed class ShootControlCell
    {
        /// <summary>
        /// 放量
        /// </summary>
        public int Arranged { get; set; }
        /// <summary>
        /// 拍摄量
        /// </summary>
        public int Setted { get; set; }

        /// <summary>
        /// 加法运算
        /// </summary>
        /// <param name="a">参数1</param>
        /// <param name="b">参数2</param>
        /// <returns>结果</returns>
        public static ShootControlCell operator+(ShootControlCell a, ShootControlCell b)
        {
            return new ShootControlCell
            {
                Arranged = a.Arranged + b.Arranged,
                Setted = a.Setted + b.Setted
            };
        }
        public override string ToString()
        {
            return string.Format(@"{0}/{1}", Arranged, Setted);
        }
    }
}