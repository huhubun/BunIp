using Microsoft.AspNetCore.Http;
using System;
using System.Net;

namespace BunIp.Web.Helpers
{
    public static class IpHelper
    {
        /// <summary>
        /// 获取发起请求一方的 IP 地址。<br />
        /// 首先从 HTTP Header 中获取 X-Real-IP 头（适用于有反向代理的情况），如果不存在则使用 httpContext.Connection.RemoteIpAddress 来获取（适用于没有反向代理的情况）。
        /// 注：忽略代理服务器，因此不会处理 X-Forwarded-For 头。
        /// </summary>
        /// <param name="httpContext">带有请求头的 HTTP 上下文</param>
        /// <returns>发起请求一方的 IP 地址</returns>
        public static IPAddress GetRealIp(HttpContext httpContext)
        {
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
