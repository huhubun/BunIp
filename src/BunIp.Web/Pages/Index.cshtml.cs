using BunIp.Web.Configs;
using BunIp.Web.Configs.BunIpConfigs;
using BunIp.Web.Extensions;
using BunIp.Web.Helpers;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System;
using System.Net;
using System.Net.Sockets;

namespace BunIp.Web.Pages
{
    public class IndexModel : PageModel
    {
        private readonly BunIpConfig _bunIpConfig;

        public IndexModel(
            BunIpConfig bunIpConfig)
        {
            _bunIpConfig = bunIpConfig;
        }

        public void OnGet()
        {
        }

        public IPAddress DisplayIp
        {
            get
            {
                return IpHelper.GetRealIp(HttpContext);
            }
        }

        private DeployMode? CurrentDeployMode => _bunIpConfig.DeploySite.GetDeployMode(Request);

        public bool TryGetIpV4 => DisplayIp.AddressFamily == AddressFamily.InterNetworkV6 && CurrentDeployMode == DeployMode.Hybrid;

        public Uri AjaxIpv4Url => _bunIpConfig.DeploySite.IPv4.GetAjaxIpUrl();

        public bool TryGetIpV6 => DisplayIp.AddressFamily == AddressFamily.InterNetwork && CurrentDeployMode == DeployMode.Hybrid;

        public Uri AjaxIpv6Url => _bunIpConfig.DeploySite.IPv6.GetAjaxIpUrl();
    }
}
