using BunIp.Web.Configs;
using BunIp.Web.Configs.BunIpConfigs;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BunIp.Web.Pages.Shared.Components.IpV6Tag
{
    public class IpV6TagViewComponent : ViewComponent
    {
        private readonly BunIpConfig _bunIpConfig;

        public IpV6TagViewComponent(BunIpConfig bunIpConfig)
        {
            _bunIpConfig = bunIpConfig;
        }

        public IViewComponentResult Invoke()
        {
            var model = new ViewModel
            {
                ShowTag = _bunIpConfig.DeployMode != DeployMode.IPv4
            };

            return View(model);
        }
    }
}
