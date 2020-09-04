using BunIp.Web.Configs;
using BunIp.Web.Configs.BunIpConfigs;
using BunIp.Web.Helpers;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Reflection.Metadata.Ecma335;

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



        public bool TryGetIpV4 => DisplayIp.AddressFamily == AddressFamily.InterNetworkV6 && _bunIpConfig.DeployMode == DeployMode.Hybrid;

        public bool TryGetIpV6 => DisplayIp.AddressFamily == AddressFamily.InterNetwork && _bunIpConfig.DeployMode == DeployMode.Hybrid;
    }
}
