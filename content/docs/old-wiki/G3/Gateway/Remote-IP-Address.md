
## Report IP Analysis

### X-Forwarded-For
The **X-Forwarded-For** header is used to determining the correct remote IP address is fundamental in proving reliable access controls
- It can’t be assumed that the last IP address is the users remote IP address as if the traffic comes via a web proxy, the proxy address will be added by the load balancer and we don’t want to whitelist everyone using the same proxy
- It can’t be assumed that the first IP address is the users remote IP address as it can be an internal private IP addressed added by a corporate web proxy, or the header could be injected by a bad actor with a fake IP address
- Bad actors can also try to use a NULL character to cause some software to detect this as the end of input and ignore the correct IP address

### IP Address validation
If there is only one address left after any of the steps below that address will be used and no further validation steps will be taken

1. Standardise delimiters, NULL space comma. (have seen nulls injected to cause software to only read the first part)
2. Validate IP addresses
3. If there is only one use the address
4. Remove the first address if it’s private
5. Remove internal/private IPv6 addresses (noted in traffic from Google Bots) we are just starting to add Ipv6 support and collecting data
6. Remove Known Proxies from the right (not the left)
    - List of known proxies
    - Recorded as a proxy in IP address Geolocation data from IP-API
    - ISP contains ZSCALER (from Geolocation data)
7. If there are multiple addresses and that last one is private use the private address and assume it’s an internal scan
8. If a single address wasn’t found, use a fake IP address (0.0.4.3) to consolidate all activity. If a valid IP address has been injected in the original request we will be left with two addresses and 0.0.4.3 will be used
9. If there isn’t a X-Forwarded-For the source IP address is used (normally this is internal direct to the server)

### Examples

**Legend:** <span style="color:red">Invalid</span>, <span style="color:blue">Private</span>, Valid, <span style="color:#00cc00">Proxy</span>

|X-Forwarded-For|Remote IP Address|Comment|
|--|--|--|
|202.70.142.254|202.70.142.254||
|202.70.142.254, <span style="color:#00cc00">165.225.233.98</span>|202.70.142.254||
|235.32.134.188, 142.54.177.163|0.0.4.3|Suspicious|
|<span style="color:blue">10.10.6.16,</span> 202.70.142.254|202.70.142.254||
|<span style="color:blue">10.10.6.16</span>, 202.70.142.254, <span style="color:#00cc00">165.225.233.98</span>|202.70.142.254||
|202.70.142.254, <span style="color:blue">10.200.1.4</span>|10.200.1.4||
|<span style="color:red">${xxx:yyy://172.16.16.239:59874/nnnn}</span>, 4.106.118.139|4.106.118.139||
|<span style="color:red">${xxx:yyy://172.16.16.239:59874/nnnn}</span>, <span style="color:blue">10.200.1.4</span>|10.200.1.4||
|<span style="color:blue">fe80:::3c5c:cdd4:5765:d848</span> 2406:3401:304:f5b0:d809:9734:c1f1:7ac2|2406:3401:304:f5b0:d809:9734:c1f1:7ac2||
|<span style="color:blue">2001:0DB8:6e70:bd64:48df:a0db:32e3:c311</span>, 103.246.39.237|103.246.39.237||
||10.200.1.4|Source IP|
|<span style="color:red">127.0.0.000170</span>, 210.8.164.185|0.0.4.3|Suspicious, invalid local IP|
|<span style="color:blue">127.0.0.000168</span>, 210.8.164.185|210.8.164.185|Valid local IP Removed|
|<span style="color:red">3393621505</span>, 210.8.164.185|0.0.4.3|Suspicious, invalid local IP|
|<span style="color:blue">0x00</span>, 210.8.164.185|210.8.164.185|Valid local IP Removed|
