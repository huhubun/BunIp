using System.Net.Sockets;

namespace BunIp.Web.Pages.Shared.Components.IpTag
{
    public class ViewModel
    {
        public AddressFamily AddressFamily { get; set; }

        public string DisplayIpFamily => AddressFamily switch
        {
            AddressFamily.InterNetwork => "IPv4",
            AddressFamily.InterNetworkV6 => "IPv6",
            _ => null
        };
    }
}
