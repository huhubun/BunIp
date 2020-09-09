using BunIp.Web.Configs.BunIpConfigs;
using System;

namespace BunIp.Web.Configs
{
    public class BunIpConfig
    {
        /// <summary>
        /// 部署站点信息，通过请求头中的 Host 进行识别
        /// </summary>
        public DeploySite DeploySite { get; set; }

        /// <summary>
        /// 广告配置
        /// </summary>
        public Ad Ad { get; set; }
    }
}
