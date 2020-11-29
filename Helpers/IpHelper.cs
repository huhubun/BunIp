using Microsoft.AspNetCore.Http;
using System;
using System.Net;

namespace IpTest.Helpers
{
    public static class IpHelper
    {
        public static IPAddress GetRealIp(HttpContext httpContext)
        {
            // 如果存在 X-Real-IP header，并且值合法，就是用 X-Real-IP 的值
            var headers = httpContext.Request.Headers;
            var realIpHeader = headers["X-Real-IP"];

            if (!String.IsNullOrEmpty(realIpHeader) && IPAddress.TryParse(realIpHeader, out var ipAddress))
            {
                return ipAddress;
            }

            return httpContext.Connection.RemoteIpAddress;
        }
    }
}
