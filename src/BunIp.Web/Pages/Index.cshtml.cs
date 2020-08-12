using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Linq;
using System.Net;

namespace BunIp.Web.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;

        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
        }

        public void OnGet()
        {
        }

        public string HeaderRealIp => HttpContext.Request.Headers["X-Real-IP"];

        public IEnumerable<string> HeaderForwardedFor => HttpContext.Request.Headers["X-Forwarded-For"];

        public IPAddress RemoteIpAddress => HttpContext.Connection.RemoteIpAddress;

        public string DisplayIp
        {
            get
            {
                if (HeaderRealIp != null)
                {
                    return HeaderRealIp;
                }

                if (HeaderForwardedFor != null && HeaderForwardedFor.Any())
                {
                    return HeaderForwardedFor.First();
                }

                return RemoteIpAddress.ToString();
            }
        }
    }
}
