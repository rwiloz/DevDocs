## Gateway Server

The Gateway (Web Server) runs in the DMZ and provides static content and API access

<p style="position: relative;">
  <img src="g3webgateway.svg" width="100%">
  <a style="position: absolute; top: 5%; left: 5%; width: 90%; height: 40%" href="./g3/gateway/access-control"></a>
  <a style="position: absolute; top: 50%; left: 0%; width: 14%; height: 45%" href="./g3/gateway/cdn"></a>
  <a style="position: absolute; top: 50%; left: 14%; width: 14%; height: 45%" href="./g3/gateway/cms"></a>
  <a style="position: absolute; top: 50%; left: 28%; width: 14%; height: 45%" href="./g3/gateway/security-overview#api"></a>
  <a style="position: absolute; top: 50%; left: 42%; width: 14%; height: 45%" href="./g3/gateway/fileup"></a>
  <a style="position: absolute; top: 50%; left: 56%; width: 14%; height: 45%" href="./g3/gateway/websocket"></a>
  <a style="position: absolute; top: 50%; left: 70%; width: 14%; height: 45%" href="./g3/gateway/oauth"></a>
  <a style="position: absolute; top: 50%; left: 84%; width: 14%; height: 45%" href="./g3/gateway/calendar"></a>

</p>


This includes
- Access Control: Whitelisting, Blacklisting and Greylisting (automated temporary black listing) see [Remote IP Address](Remote-IP-Address)
- Session management (including roles)
- Secure access to resources and routes API call to the required services
- API Rate limiting
- API and content caching
- Content Security Policies including script hashing

Everything is API based and stored in memory or Azure Redis (AES encrypted, short term time based expiry). No data is stored on the Gateway Server

Access Control information is cached in memory to enable high load and to protect backend services 




