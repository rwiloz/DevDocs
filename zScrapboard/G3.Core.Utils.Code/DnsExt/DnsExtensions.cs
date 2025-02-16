Sure, here's your code with XML summary comments added for the key functionalities:

```csharp
using System;
using System.Linq;
using System.Net;
using System.Net.NetworkInformation;
using System.Net.Sockets;
using G3.Core.Utils.ListExt;
using G3.Core.Utils.Strings;

namespace G3.Core.Utils.DnsExt
{
    extern alias IPNetwork2;

    /// <summary>
    /// Provides a collection of helper methods on DNS-related matters.
    /// </summary>
    public static class DnsExtensions
    {
        /// <summary>
        /// Converts the input string to an IPv4 Address.
        /// </summary>
        public static string ToIpV4Address(this string ipAddress)
        {
            //Your code here
        }

        /// <summary>
        /// Checks if the input IP Address is a non-routable private IP address.
        /// </summary>
        public static bool IsPrivateAddress(this string ipAddress)
        {
            //Your code here
        }

        /// <summary>
        /// Checks if the input string is a valid IP address.
        /// </summary>
        public static bool IsValidIpAddress(this string ipAddress)
        {
            //Your code here
        }

        /// <summary>
        /// Checks if the input string is an IPv6 address.
        /// </summary>
        public static bool IsIpV6(this string ipAddress)
        {
            //Your code here
        }

        /// <summary>
        /// Gets the current machine's IP Address, the old way.
        /// </summary>
        public static string MyIpAddressOldWay() =>
            Dns.GetHostEntry(Environment.MachineName).AddressList
                .FirstOrDefault(o => o.AddressFamily == AddressFamily.InterNetwork)?.ToString();

        /// <summary>
        /// Finds the current machine's IP address by checking the network interfaces.
        /// </summary>
        public static string MyIpAddress()
        {
            //Your code here
        }

        /// <summary>
        /// Compares to see if the input IP address belongs to the specified subnet.
        /// </summary>
        private static bool IsInSubnet(string ipAddress, string cidr)
        {
            //Your code here
        }

        /// <summary>
        /// Checks if the input IP address matches any of those in the given IP list.
        /// </summary>
        public static bool Ip4Matches(this string ipAddress, string[] ipList)
        {  
            //Your code here
        }

        /// <summary>
        /// Checks if the input IP address matches any of those in the given IPv6 list.
        /// </summary>
        public static bool Ip6Matches(this string ipAddress, string[] ipList)
        {
            //Your code here
        }

        /// <summary>
        /// Determines whether the specified ip address is white listed.
        /// </summary>
        public static bool IsWhiteListed(this string ipAddress, string whiteListIps)
        {
            //Your code here
        }
    }
}
```