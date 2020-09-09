using BunIp.Web.Configs.BunIpConfigs.DeploySites;
using System;

namespace BunIp.Web.Extensions
{
    public static class SiteInfoExtensions
    {
        public static Uri GetUri(this SiteInfo siteInfo)
        {
            if (!String.IsNullOrEmpty(siteInfo.Domain) && !String.IsNullOrEmpty(siteInfo.Scheme))
            {
                if (siteInfo.Port.HasValue)
                {
                    return (new UriBuilder(siteInfo.Scheme, siteInfo.Domain, siteInfo.Port.Value)).Uri;
                }

                return (new UriBuilder(siteInfo.Scheme, siteInfo.Domain)).Uri;
            }

            return null;
        }

        public static Uri GetAjaxIpUrl(this SiteInfo siteInfo)
        {
            var baseUrl = siteInfo.GetUri();

            if(baseUrl == null)
            {
                return null;
            }

            return new Uri(baseUrl, "ip");
        }
    }
}
