using BunIp.Web.Configs.BunIpConfigs;
using BunIp.Web.Configs.BunIpConfigs.DeploySites;
using Microsoft.AspNetCore.Http;
using System;

namespace BunIp.Web.Extensions
{
    public static class DeploySiteExtension
    {
        public static DeployMode? GetDeployMode(this DeploySite deploySite, HttpRequest request)
        {
            if (deploySite == null)
            {
                throw new ArgumentNullException(nameof(deploySite));
            }

            if (request == null)
            {
                throw new ArgumentNullException(nameof(request));
            }

            var host = request.Headers["Host"];

            if (!String.IsNullOrEmpty(host))
            {
                foreach (var name in Enum.GetNames(typeof(DeployMode)))
                {
                    var info = typeof(DeploySite).GetProperty(name).GetValue(deploySite) as SiteInfo;
                    if (info != null)
                    {
                        var domain = info.Domain;
                        if (info.Port.HasValue && (info.Port != 80 || info.Port != 443))
                        {
                            domain += $":{info.Port}";
                        }

                        if (domain == host)
                        {
                            return Enum.Parse<DeployMode>(name);
                        }
                    }
                }
            }

            return null;
        }
    }
}
