using BunIp.Web.Configs.BunIpConfigs.Ads;

namespace BunIp.Web.Configs.BunIpConfigs
{
    /// <summary>
    /// 广告配置
    /// </summary>
    public class Ad
    {
        /// <summary>
        /// IP 结果下方 A 号广告位配置
        /// </summary>
        public ImageAd A { get; set; }

        /// <summary>
        /// 服务器接收的 Headers 列表和 Footer 之间，B 号广告位配置
        /// </summary>
        public ImageAd B { get; set; }

        /// <summary>
        /// Footer 中的文字推广，F 号广告位配置
        /// </summary>
        public TextAd F { get; set; }
    }
}
