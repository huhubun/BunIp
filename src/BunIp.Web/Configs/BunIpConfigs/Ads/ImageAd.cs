using System;

namespace BunIp.Web.Configs.BunIpConfigs.Ads
{
    /// <summary>
    /// 图片推广配置
    /// </summary>
    public class ImageAd : IAdType
    {
        /// <summary>
        /// 图片地址
        /// </summary>
        public Uri ImageUrl { get; set; }

        /// <summary>
        /// 目标链接，点击图片后会跳转到该地址
        /// </summary>
        public Uri Url { get; set; }

        /// <summary>
        /// 描述
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// 是否启用
        /// </summary>
        public bool Enable { get; set; }
    }
}
