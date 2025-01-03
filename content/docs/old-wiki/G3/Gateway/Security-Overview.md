## Processing Order

### Pre Processing
- Health Check (access as IP address or special user agents) returns 200 OK
- Map Host header (URL) to app 
  - if mapping fails 
    - check IP, failure record error
    - if blocked return Forbidden 403 (or Not found for reported IP Abuser)
    - or if not blocked return not found 404
-	Validate UserAgent (Error 500 if invalid Eg injection detected)
- Validate Content Length/chunked for HTTP request smuggling (Error 500 if detected)
- Analysis X-Forwarded-For to determine IP address (using known proxies) 
  - if this fails fall back to IP 0.0.4.1 for consolidated rate limiting
  - Get IP Geo information (cached)
  - Check AbuseIpDb (cached for 30 days, score over 50 indicated a reported abuser)
  - Check Access Control (AC) rules (more below)
- If IP is allowed (cached for 30 min to reduce load)
- Check for accumulated error count (10 min) impose temporary lock
- check rate limiting for temporary lock 

### Processing Pipeline
- Robots (don’t allow in non-prod)
- File upload (inc virus scan)
- File down load (via API)
- UI CMS Content requests (via API, cached)
- API Requests (more below)
- WebDav Calendar Sync (not implemented yet)
- Token support for API OAuth Cred flow
- CORS/OPTIONS processing
- Web Socket connection processing, via REDIS back plane (after CORS)
- API Call 
- Web Static Content (Index, JS CSS etc, via API)

### API Calls
- map API call to routing config (Error 500 if unknown/unmapped)
- Generate swagger/open API JSON (only in Dev if requested)
- Validate API is externally accessible (Error return Forbidden 403)
- Check Rate limiting Rules (rates do vary, default is 10 in 10 min)
- Translate GET (query & form data) to POST for APIs that are configured to accept (Error 500 if GET and not allowed)
- Process Authentication/Authorisation 
  - API attributes
  - Roles
  - Create Signed JWT for Service authentication
- Process Route mapping
- Translate to Server/Service path
- Make internal REST API call (DMZ to LAN services)
- API may have additional Authorisation validation checks
- Process API Response (cache, compression, redirection etc)

### Web Static Content
- Validate allowed extensions 
  - ```html;js;map;css;json;webmanifest;txt;html;otf;eot;ttf;woff;woff2;png;gif;webp;jpg;jpeg;svg;ico;pdf```
  - map files are emulated and always empty
- Return 404 for any others (eg php will always be 404 and isn’t processed)
- CSP processing
- index customization (App settiings, Device, CSP nonce, JavaScript hash, etc)
- Web Manifest, Angular ngsw re-hashing (to compensate for customisation)
- Compression
- Accelerated Caching, index and other content can be generated in 2ms


### Auth (2FA)
- Unverified MFA codes last 10 min before expiring, once validated they remain valid for the session
- Email Verification and Email MFA share the same code, so if an email is verified the other will pass and not send
- Unitywater are using MFA as a 2FA authentication process
- Email being used for 2FA, while not ideal it’s better than no 2FA. We recommend TOTP via an auth app, next best is SMS 2FA
- It was recommend to Send SMS (Aust mobile only) OTC to link customer date in addition to (Payment Ref no, Postcode and account name) We would have had an aust mobile number that could be traced back to an identity (if it’s a burner or virtual phone number) But this was withdrawn at the last minute

### X-Forwarded-For
- invalid and private IPs are removed
- known proxies are removed from the RHS when there are two or more addresses
- if only one address is left it is used, otherwise a consolidate IP 0.0.4.1 is used internally)

### AC Rules
- Rate limited are grouped in 10 min blocks
- Content Errors, invalid requests limit of 10, then locked for 10 min
- If there are invalid host headers (don’t map to an app) the IP will be blocked for 7 days
- if there are more than 100 health check errors (usually direct to the IP address) the IP will be blocked for 7 days
- if the above happens more than 3 times in the previous two week, the IP is blocked for 7 days
- Web socket connects per IP limited to 10 per IP address  to mitigate port exhaustion
- White/Black lists can be setup using IPv4, IPv6, Device ID (cookie based) ISP or country codes 
  - Shared networks can have limit multiplier setup via a whitelist 
- Session are limited to 3 unique IP address, the session is terminated on the server if a forth is detected (to mitigate token theft/sharing)
- if the above happens more than 2 times in the previous one week, the IP is blocked for 7 days
- Rate limits are set on all API calls (the default is 10 in 10 min, but this does vary) 
- if the rate is exceeded the IP address will be blocked for 10 min
- if the above happens more than 3 times in the previous one week, the IP is blocked for 24 hours
- More than 10 unique login in a week from the same IP address will block it for 24 hours (corporate networks can have a multiplier)
- More than 2 unique failed login attempts in a week from the same IP address will block it for 24 hours (corporate networks can have a multiplier)
- More than 2 new registrations in a week from the same IP address will block it for 24 hours (corporate networks can have a multiplier)
- More than 6 unknown username/email logins within 4 hours will block the IP address for 4 hours (to mitigate username/password washing)
- The AC system uses Groups, Rules, Reports and Audit is kept

### Rate limit variations
- Static & CMS content has an increased limit of 100, but can also be cached
- Address Search, NMIMirnCheck and RevGeocode have an increased limit of 100
- Authentication services have a small increase to 15/10 min
- GeoLocation reports have an increase to 150

<a name="api"></a>
API anchor test
### IPv6
- IPv6 Rate limiting differences 
- IPv6 isn’t supported by Computershare, but it can come in X-Forwarded-For headers via other proxies.
- Rate counters are at three level to mitigate IPv6 rotation 
  - Individual IPv6 limit x 1
  - small network mask /64 limit x 4
  - large network mask /48 limit x 16
