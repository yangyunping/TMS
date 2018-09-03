namespace GoldenLady.Standard
{
    /// <summary>
    /// 键值对类
    /// </summary>
    public abstract class KVPair<T>
    {
        /// <summary>
        /// 名称
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// 值
        /// </summary>
        public T Value { get; set; }

        public override string ToString()
        {
            return Name;
        }
    }
}