using BunIp.Web.Configs.BunIpConfigs;

namespace BunIp.Web.Configs
{
    public class BunIpConfig
    {
        /// <summary>
        /// 部署站点的绑定模式，用于控制站点是否显示 IPv6 图标（只有纯 IPv6 才应该显示图标）
        /// </summary>
        public DeployMode DeployMode { get; set; }
    }
}
