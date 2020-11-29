using BunIp.Web.Configs.BunIpConfigs.DeploySites;
using System;

namespace BunIp.Web.Extensions
{
    public static class SiteInfoExtensions
    {
        public static Uri GetAjaxIpUrl(this SiteInfo siteInfo)
        {
            var baseUrl = siteInfo.Uri;

            if(baseUrl == null)
            {
                return null;
            }

            return new Uri(baseUrl, "ip");
        }
    }
}
