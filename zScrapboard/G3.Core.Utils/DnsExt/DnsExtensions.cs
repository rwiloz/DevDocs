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

    public static class DnsExtensions
    {
        public static string ToIpV4Address(this string ipAddress)
        {
            try
            {
                if (ipAddress == null) return null;

                if (!IPAddress.TryParse(ipAddress, out var address))
                {
                    //not a valid IPv4 
                    return "0.0.0.0";
                }

                if (address.AddressFamily == AddressFamily.InterNetworkV6)
                {
                    try
                    {
                        address = Dns.GetHostEntry(address).AddressList
                            .FirstOrDefault(x => x.AddressFamily == AddressFamily.InterNetwork);

                        if (address == null || address.AddressFamily == AddressFamily.InterNetworkV6)
                            return "0.0.6.1"; //ipv6
                    }
                    catch
                    {
                        //unknown IPv6
                        return "0.0.6.2";
                    }
                }

                return address.ToString();
            }
            catch
            {
                //not a valid IPv4 
                return "0.0.0.0";
            }
        }

        public static bool IsPrivateAddress(this string ipAddress)
        {
            if (ipAddress == null) return false;

            if (!IPAddress.TryParse(ipAddress, out var ip)) return false;

            if (ip.AddressFamily == AddressFamily.InterNetwork)
            {
                var ips = ip.ToString();

                if (ips == "127.0.0.1")
                    return true;

                if (ips == "0.0.0.0")
                    return true;

                var ipParts = ips.Split(new[] { "." }, StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse).ToArray();

                if (ipParts.Length < 4) return false;

                return ipParts[0] == 10 ||
                       (ipParts[0] == 192 && ipParts[1] == 168) ||
                       (ipParts[0] == 172 && (ipParts[1] >= 16 && ipParts[1] <= 31));
            }

            //https://stackoverflow.com/questions/35374207/how-to-determine-if-ipv6-address-is-private
            var firstWord = ipAddress.Split(new[] { ':' }, StringSplitOptions.RemoveEmptyEntries)[0];

            //localhost
            if (ipAddress == "::1")
                return true;

            // The original IPv6 Site Local addresses (fec0::/10) are deprecated. Unfortunately IsIPv6SiteLocal only checks for the original deprecated version:
            else if (ip.IsIPv6SiteLocal)
                return true;

            // These days Unique Local Addresses (ULA) are used in place of Site Local. 
            // ULA has two variants: 
            //      fc00::/8 is not defined yet, but might be used in the future for internal-use addresses that are registered in a central place (ULA Central). 
            //      fd00::/8 is in use and does not have to registered anywhere.
            else if (firstWord.Length >= 4 && firstWord.Substring(0, 2) == "fc")
                return true;
            else if (firstWord.Length >= 4 && firstWord.Substring(0, 2) == "fd")
                return true;

            // Link local addresses (prefixed with fe80) are not routable
            else if (firstWord == "fe80")
                return true;

            // Discard Prefix
            else if (firstWord == "100")
                return true;

            // Any other IP address is not Unique Local Address (ULA)
            return false;
        }


        public static bool IsValidIpAddress(this string ipAddress)
        {
            return IPAddress.TryParse(ipAddress, out _);
        }

        public static bool IsIpV6(this string ipAddress)
        {
            if (IPAddress.TryParse(ipAddress, out var ip))
            {
                return ip.AddressFamily == AddressFamily.InterNetworkV6;
            }

            return false;
        }

        public static string MyIpAddressOldWay() =>
            Dns.GetHostEntry(Environment.MachineName).AddressList
                .FirstOrDefault(o => o.AddressFamily == AddressFamily.InterNetwork)?.ToString();

        public static string MyIpAddress()
        {
            var adapters = NetworkInterface.GetAllNetworkInterfaces();
            
            //IPV4
            foreach (var networkInterface in adapters)
            {
                var ipProps = networkInterface.GetIPProperties();
                if (!ipProps.GatewayAddresses.Any()) continue;
                var ipAddress = ipProps.UnicastAddresses.FirstOrDefault(u => u.Address.AddressFamily == AddressFamily.InterNetwork)?.Address;
                if (ipAddress != null) return ipAddress.ToString();
            }

            //IPV6
            foreach (var networkInterface in adapters)
            {
                var ipProps = networkInterface.GetIPProperties();
                if (!ipProps.GatewayAddresses.Any()) continue;
                var ipAddress = ipProps.UnicastAddresses.FirstOrDefault(u => u.Address.AddressFamily == AddressFamily.InterNetworkV6)?.Address;
                if (ipAddress != null) return ipAddress.ToString();
            }

            return MyIpAddressOldWay();
       }

        private static bool IsInSubnet(string ipAddress, string cidr)
        {

            string[] parts = cidr.Split('/');

            int baseAddress = BitConverter.ToInt32(IPAddress.Parse(parts[0]).GetAddressBytes(), 0);

            int address = BitConverter.ToInt32(IPAddress.Parse(ipAddress).GetAddressBytes(), 0);

            int mask = IPAddress.HostToNetworkOrder(-1 << (32 - int.Parse(parts[1])));

            return ((baseAddress & mask) == (address & mask));

        }

        public static bool Ip4Matches(this string ipAddress, string[] ipList)
        {
            if (!ipList.Any()) return true;

            var ipOk = false;
            foreach (var ip in ipList)
            {
                try
                {
                    var ipParts = ip.Split('/');
                    if (ipParts.Length == 1) //no subnet
                    {
                        if (ip == ipAddress) ipOk = true;
                        continue;
                    }

                    if (ipParts.Length == 2) //has subnet
                    {
                        if (IsInSubnet(ipAddress, ip)) ipOk = true;
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception($"Error checking IP address {ipAddress} against white list {ip}", ex);
                }
            }

            return ipOk;
        }

        public static bool Ip6Matches(this string ipAddress, string[] ipList)
        {
            if (!ipList.Any()) return false;

            var ipOk = false;
            foreach (var ip in ipList)
            {
                try
                {
                    var ipv6 = IPAddress.Parse(ipAddress);
                    var ipv6Network = IPNetwork2::System.Net.IPNetwork2.Parse(ip);
                    if (ipv6Network.Contains(ipv6)) ipOk = true;
                }
                catch (Exception ex)
                {
                    throw new Exception($"Error checking IPv6 address {ipAddress} against white list {ip}", ex);
                }
            }

            return ipOk;
        }

        public static bool IsWhiteListed(this string ipAddress, string whiteListIps)
        {
            if (whiteListIps.IsNullOrEmpty()) return true;
            var ipList = whiteListIps.Split(';');
            return ipAddress.Ip4Matches(ipList);
        }

    }
}
