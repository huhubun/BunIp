using IpTest.Configs;
using IpTest.Configs.DeploySites;
using IpTest.Helpers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Threading.Tasks;

namespace IpTest.Pages
{
    public class IndexModel : PageModel
    {
        private readonly IOptions<DeploySite> _deploySites;

        public IndexModel(IOptions<DeploySite> deploySites)
        {
            _deploySites = deploySites;
        }

        public void OnGet()
        {

        }

        public IPAddress DisplayIp => IpHelper.GetRealIp(HttpContext);

        public DeployMode CurrentDeployMode
        {
            get
            {
                var host = Request.Headers["Host"];

                foreach (var name in Enum.GetNames<DeployMode>())
                {
                    var siteInfo = typeof(DeploySite).GetProperty(name).GetValue(_deploySites.Value) as SiteInfo;
                    var domainAndPort = siteInfo.Domain;

                    if (siteInfo.Port.HasValue && siteInfo.Port is not (80 or 443))
                    {
                        domainAndPort += $":{siteInfo.Port}";
                    }

                    if (host == domainAndPort)
                    {
                        return Enum.Parse<DeployMode>(name);
                    }
                }

                throw new Exception($"Host 的值 {host} 与 DeploySite 的配置没有匹配项");
            }
        }

        public bool ShouldTryIpv4 => CurrentDeployMode == DeployMode.Hybrid && DisplayIp.AddressFamily == AddressFamily.InterNetworkV6;

        public bool ShouldTryIpv6 => CurrentDeployMode == DeployMode.Hybrid && DisplayIp.AddressFamily == AddressFamily.InterNetwork;

        public Uri Ipv4Url => _deploySites.Value.IPv4.Uri;

        public Uri Ipv6Url => _deploySites.Value.IPv6.Uri;

    }
}
