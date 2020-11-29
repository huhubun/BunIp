using System;

namespace BunIp.Web.Configs.BunIpConfigs.DeploySites
{
    public class SiteInfo
    {
        /// <summary>
        /// 域名
        /// </summary>
        public string Domain { get; set; }

        /// <summary>
        /// 访问协议（http、https）
        /// </summary>
        public string Scheme { get; set; }

        /// <summary>
        /// 端口号
        /// </summary>
        public int? Port { get; set; }

        public Uri Uri
        {
            get
            {
                if (Port.HasValue)
                {
                    return (new UriBuilder(Scheme, Domain, Port.Value)).Uri;
                }

                return (new UriBuilder(Scheme, Domain)).Uri;
            }
        }
    }
}
