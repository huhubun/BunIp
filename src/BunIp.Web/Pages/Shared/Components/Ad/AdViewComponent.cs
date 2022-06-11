using BunIp.Web.Configs;
using BunIp.Web.Configs.BunIpConfigs.Ads;
using Microsoft.AspNetCore.Mvc;

namespace BunIp.Web.Pages.Shared.Components.AdTag
{
    public class AdViewComponent : ViewComponent
    {
        private readonly BunIpConfig _bunIpConfig;

        public AdViewComponent(BunIpConfig bunIpConfig)
        {
            _bunIpConfig = bunIpConfig;
        }

        public IViewComponentResult Invoke(AdPosition position)
        {
            IAdType ad = null;
            var positionString = position.ToString();

            if (_bunIpConfig.Ad != null)
            {
                ad = typeof(Configs.BunIpConfigs.Ad).GetProperty(positionString).GetValue(_bunIpConfig.Ad) as IAdType;
            }

            var model = new ViewModel
            {
                Ad = ad,
                Position = position
            };

            return View(model);
        }
    }
}
