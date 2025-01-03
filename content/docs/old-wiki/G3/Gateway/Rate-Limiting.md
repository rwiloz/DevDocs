
Rate limiting for IPv6 is done at three levels to mitigate IP Addresses cycling
- Full address
- Small network /64, limit is multiplied by 4
- Large network /48, limit is multiplied by 16
The network prefix can be overridden with a whitelist config

Access Control (AC)
The Access Control system has 5 main parts

IP address register
- Used to track IP address information 
- Information is refreshed after 3 months

Groups
- These are groups of IP address (IPv4 & IPv6 with masking support) 
- Network multipliers (used when multiple users are on a shared network to increase rate limits etc)
- G3 Device IDs that can be used to white list devices, this is primary used for mobile devices where the IP is dynamic

Rules
- Rule are used to make decision about allowing access, there are rules types for whitelisting & blacklisting.
- Limit rules that used to imply temporary black listing, 
- These are applied at an application level.

Reports
- Activity can be logged by applications or by the platform, these reports are used by the limit rules to limit access

Audit
- An audit log of who has been blocked and why, it also records when blocks are removed (lock time period has passed)

Adding IP address/s to the groups used by the application rules is how we manage this

Logging
Sorry I’m not sure what Kiwi and SIEM are, can you provide more info

The information is held in an SQL database, so read only access can be provided

Other
Maintaining AC groups is via a admin UI, which we can demonstrate

I’m not sure the tenable scan would provide much help as the G3 Platform doesn’t render pages or execute scripts. But we can discuss this further to see if they can.

The content management system sanitises all request to remove directory traversal attempts

The platform also manages file uploads and does real time in memory virus scanning.