# DnsExtensions

This class contains extension methods that provide a set of usefull functionalities to handle and manipulate IP addresses.

## Methods

`public static string ToIpV4Address(this string ipAddress)`

This method attempts to convert an IP address into an IPv4 format. If the ipAddress is null, the method will return null. If the IP address is not valid, the method will return "0.0.0.0". If the address is IPv6, a try catch clause processes the IP address, and in case of exceptions, it returns "0.0.6.2". It returns the converted IP address on successful execution.

`public static bool IsPrivateAddress(this string ipAddress)`

This method checks if an IP address is private, based on pre-defined sets of private IP ranges for both IPv6 and IPv4.

`public static bool IsValidIpAddress(this string ipAddress)`

This method checks if an IP address is valid using the `IPAddress.TryParse` function.

`public static bool IsIpV6(this string ipAddress)`

This method validates if the given input IP address is IPv6.

`public static string MyIpAddressOldWay()`

This method fetches the IP address of the machine the application is running on, using older methods. 

`public static string MyIpAddress()`

This method retrieves the machine's IP address using .NET NetworkInterface API. It scans network interfaces for an IPv4 address first, and if not found, an IPv6 address.

`private static bool IsInSubnet(string ipAddress, string cidr)`

This is a private method used internally by the class that checks if an IP address is in a specified subnet.

`public static bool Ip4Matches(this string ipAddress, string[] ipList)`

This method checks if an IPv4 address matches any of the addresses in an array provided.

`public static bool Ip6Matches(this string ipAddress, string[] ipList)`

This method checks if an IPv6 address matches any of the addresses in an array provided.

`public static bool IsWhiteListed(this string ipAddress, string whiteListIps)`

This method checks if an IP address is whitelisted. It splits the string of whitelist IPs by semicolon and checks if the given IP matches against the list using `Ip4Matches` method. It returns true if the IP address is in the whitelist. If the whitelist is empty or null, the function also returns true.