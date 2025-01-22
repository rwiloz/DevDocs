---
title: "DnsExtensions Utilities"
date: 2023-10-10
draft: false
---

# DnsExtensions Utilities

This namespace provides extension methods for processing and validating IP addresses in both IPv4 and IPv6 formats. It includes utilities for converting, validating, and checking if IP addresses are private or match specified criteria.

## Namespace
`G3.Core.Utils.DnsExt`

## Methods

### ToIpV4Address

```csharp
public static string ToIpV4Address(this string ipAddress)
```

Converts a given IP address string to its IPv4 representation. If conversion fails, returns default invalid IPv4 addresses.

**Parameters:**
- `ipAddress` (string): The IP address to convert.

**Returns:**
- (string): The IPv4 string representation of the address.

### IsPrivateAddress

```csharp
public static bool IsPrivateAddress(this string ipAddress)
```

Determines if the provided IP address is a private address.

**Parameters:**
- `ipAddress` (string): The IP address to check.

**Returns:**
- (bool): `true` if the IP address is private; otherwise, `false`.

### IsValidIpAddress

```csharp
public static bool IsValidIpAddress(this string ipAddress)
```

Checks the validity of the given IP address.

**Parameters:**
- `ipAddress` (string): The IP address to validate.

**Returns:**
- (bool): `true` if the IP address is valid; otherwise, `false`.

### IsIpV6

```csharp
public static bool IsIpV6(this string ipAddress)
```

Determines if the provided IP address is of the IPv6 type.

**Parameters:**
- `ipAddress` (string): The IP address to evaluate.

**Returns:**
- (bool): `true` if the IP address is IPv6; otherwise, `false`.

### MyIpAddressOldWay

```csharp
public static string MyIpAddressOldWay()
```

Retrieves the IPv4 address of the local machine using host entry.

**Returns:**
- (string): The IPv4 address as a string.

### MyIpAddress

```csharp
public static string MyIpAddress()
```

Gets the primary IPv4 or IPv6 address of the local machine by iterating over network interfaces.

**Returns:**
- (string): The IP address as a string.

### Ip4Matches

```csharp
public static bool Ip4Matches(this string ipAddress, string[] ipList)
```

Checks if the given IPv4 address matches any in the supplied list, including subnet checks.

**Parameters:**
- `ipAddress` (string): The IP address to check.
- `ipList` (string[]): An array of IP addresses and optional subnets to match against.

**Returns:**
- (bool): `true` if a match is found; otherwise, `false`.

### Ip6Matches

```csharp
public static bool Ip6Matches(this string ipAddress, string[] ipList)
```

Evaluates whether the supplied IPv6 address is within any specified network.

**Parameters:**
- `ipAddress` (string): The IPv6 address to check.
- `ipList` (string[]): An array of IPv6 addresses and networks to match against.

**Returns:**
- (bool): `true` if a match is found; otherwise, `false`.

### IsWhiteListed

```csharp
public static bool IsWhiteListed(this string ipAddress, string whiteListIps)
```

Determines if the given IP address is included within a whitelist.

**Parameters:**
- `ipAddress` (string): The IP address to check.
- `whiteListIps` (string): A semicolon-separated string of whitelisted IP addresses.

**Returns:**
- (bool): `true` if the IP address is whitelisted; otherwise, `false`.
