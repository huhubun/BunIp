using Microsoft.AspNetCore.Mvc;
using System.Net.Sockets;

namespace BunIp.Web.Pages.Shared.Components.IpTag
{
    public class IpTagViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke(AddressFamily addressFamily)
        {
            var model = new ViewModel
            {
                AddressFamily = addressFamily
            };

            return View(model);
        }
    }
}
