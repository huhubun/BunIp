using System;

namespace BunIp.Web.Configs.BunIpConfigs.Ads
{
    /// <summary>
    /// 文字推广配置
    /// </summary>
    public class TextAd : IAdType
    {
        /// <summary>
        /// 文案内容
        /// </summary>
        public string Text { get; set; }

        /// <summary>
        /// 目标链接，点击文案后会跳转到该地址
        /// </summary>
        public Uri Url { get; set; }

        /// <summary>
        /// 是否启用
        /// </summary>
        public bool Enable { get; set; }
    }
}
