﻿using BunIp.Web.Configs;
using BunIp.Web.Extensions;
using BunIp.Web.Helpers;
using Microsoft.AspNetCore.Mvc;

namespace BunIp.Web.Pages.Shared.Components.PiLogo
{
    public class PiLogoViewComponent : ViewComponent
    {
        private readonly BunIpConfig _bunIpConfig;

        public PiLogoViewComponent(BunIpConfig bunIpConfig)
        {
            _bunIpConfig = bunIpConfig;
        }

        public IViewComponentResult Invoke()
        {

            var model = new ViewModel
            {
                DeployMode = _bunIpConfig.DeploySite.GetDeployMode(Request),
                Model = PiHelper.GetModel(),
            };

            return View(model);
        }
    }
}
