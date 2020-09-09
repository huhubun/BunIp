using BunIp.Web.Configs;
using BunIp.Web.Configs.BunIpConfigs;
using BunIp.Web.Extensions;
using Microsoft.AspNetCore.Mvc;

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
            var deployMode = _bunIpConfig.DeploySite.GetDeployMode(Request);

            var model = new ViewModel
            {
                ShowTag = deployMode.HasValue && deployMode != DeployMode.IPv4
            };

            return View(model);
        }
    }
}
