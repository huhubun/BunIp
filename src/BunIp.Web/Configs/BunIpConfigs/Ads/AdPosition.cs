using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BunIp.Web.Configs.BunIpConfigs.Ads
{
    public enum AdPosition
    {
        /// <summary>
        /// IP 结果下方 A 号广告位配置
        /// </summary>
        A,

        /// <summary>
        /// 服务器接收的 Headers 列表和 Footer 之间，B 号广告位配置
        /// </summary>
        B,

        /// <summary>
        /// Footer 中的文字推广，F 号广告位配置
        /// </summary>
        F
    }
}
