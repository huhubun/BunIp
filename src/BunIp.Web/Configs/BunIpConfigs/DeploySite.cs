using BunIp.Web.Configs.BunIpConfigs.DeploySites;

namespace BunIp.Web.Configs.BunIpConfigs
{
    public class DeploySite
    {
        /// <summary>
        /// 混合部署，同时支持 IPv4 和 IPv6 访问
        /// </summary>
        public SiteInfo Hybrid { get; set; }

        /// <summary>
        /// IPv4 Only
        /// </summary>
        public SiteInfo IPv4 { get; set; }

        /// <summary>
        /// IPv6 Only
        /// </summary>
        public SiteInfo IPv6 { get; set; }
    }
}
