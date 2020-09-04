using BunIp.Web.Helpers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BunIp.Web.Pages
{
    public class IPModel : PageModel
    {
        public JsonResult OnGet()
        {
            var ipAddress = IpHelper.GetRealIp(HttpContext);
            return new JsonResult(new { Ip = ipAddress.ToString(), Type = ipAddress.AddressFamily });
        }
    }
}
