﻿using BunIp.Web.Configs;
using Microsoft.AspNetCore.Mvc;

namespace BunIp.Web.Pages.Shared.Components.IpOnlyMessage
{
    public class IpOnlyMessageViewComponent : ViewComponent
    {
        private readonly BunIpConfig _bunIpConfig;

        public IpOnlyMessageViewComponent(BunIpConfig bunIpConfig)
        {
            _bunIpConfig = bunIpConfig;
        }

        public IViewComponentResult Invoke()
        {
            var model = new ViewModel
            {
                DeployMode = _bunIpConfig.DeployMode
            };

            return View(model);
        }
    }
}