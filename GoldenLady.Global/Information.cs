using GoldenLady.Standard;

namespace GoldenLady.Global
{
    /// <summary>
    /// 软件全局信息
    /// </summary>
    public static class Information
    {
        static Information()
        {
            CurrentUser = new UserInformation();
            Company = new CompanyInformation();
            Edition = new EditionInformation();
        }

        /// <summary>
        /// 当前登录用户信息
        /// </summary>
        public static UserInformation CurrentUser { get; set; }
        /// <summary>
        /// 公司信息
        /// </summary>
        public static CompanyInformation Company { get; set; }
        /// <summary>
        /// 软件版本信息
        /// </summary>
        public static EditionInformation Edition { get; set; }
    }
}
