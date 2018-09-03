namespace GoldenLady.Standard.Dress
{
    /// <summary>
    /// 可用于管理的对象的类型
    /// LiuHaiyang
    /// 2017.4.29
    /// </summary>
    public enum ManagedObjectType
    {
        /// <summary>
        /// 无
        /// </summary>
        None,
        /// <summary>
        /// 场馆
        /// </summary>
        Venue,
        /// <summary>
        /// 风格
        /// </summary>
        Theme,
        /// <summary>
        /// 场景
        /// </summary>
        Scene
    }

    /// <summary>
    /// 可用于管理的对象
    /// LiuHaiyang
    /// 2017.4.29
    /// </summary>
    public class ManagedObject
    {
        /// <summary>
        /// 编号
        /// </summary>
        public int ID { get; set; }
        /// <summary>
        /// 名称
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// 已禁用
        /// </summary>
        public bool Disabled { get; set; }
        /// <summary>
        /// 描述
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// 获取浅拷贝副本
        /// </summary>
        /// <returns>浅拷贝副本</returns>
        public virtual ManagedObject ShallowClone()
        {
            return (ManagedObject)MemberwiseClone();
        }
    }
}