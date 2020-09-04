namespace BunIp.Web.Configs.BunIpConfigs
{
    /// <summary>
    /// 部署站点的绑定模式，用于控制站点是否显示 IPv6 图标（只有纯 IPv6 才应该显示图标）
    /// </summary>
    public enum DeployMode
    {
        /// <summary>
        /// 混合模式，即支持 IPv4 访问，又支持 IPv6 访问
        /// </summary>
        Hybrid,

        /// <summary>
        /// IPv4 模式，仅支持 IPv4 访问
        /// </summary>
        IPv4,

        /// <summary>
        /// IPv6 模式，仅支持 IPv6 访问
        /// </summary>
        IPv6
    }
}
