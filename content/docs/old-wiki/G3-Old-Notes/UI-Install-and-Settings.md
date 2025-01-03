# To create a new app following steps need to be followed: - 
1. Go to app builder  
[App Builder](https://g3-dev.oceania.cshare.net/g3/appbuilder/apps)
2.  Go to **Applications** tab and then to the Card with heading **New Application**
3. Enter in the app code for example **play/hans02**
4. The steps up till now creates a new app and takes you to the page for further app settings. 
# Instantiating an app: - 
## CARD - App Basic
| Field| Description |
| ----------- | ----------- |
| Id| This is Auto generated read only ID|
| App Code| This is the application code, it is unique for every application |
|Description| Description of App|
|Owner|The creater of the app|
|Created date|Read only date the app was created|
|Modified date|Read only date when the app was last modified|

## CARD - Application Urls
| Field| Description |
| ----------- | ----------- |
|URL|A site can have multiple URLs. URL is added in this field|
|Site Store Location|This is the location for the file system for an app|

## CARD - Cors Origin Setting
| Field| Description |
| ----------- | ----------- |
|CORS Origin URL|Cross Origin Resource Sharing - Origin Setting (Allows the specified origin calls to be accepted)|

## CARD - Whitelist IP Setting
| Field| Description |
| ----------- | ----------- |
|White Listing|Dropdown field white lists websites and allows them to open on browser|

## CARD - API Setting
| Field| Description |
| ----------- | ----------- |
|Serialize All Properties||
|Allow Default APIs||
|Swagger||

## CARD - App Setting
| Field| Description |
| ----------- | ----------- |
|Session Time|The time in minutes for the login session to last|
|HTTP Cache Minute(s)|Cache Mins|
|HTTP Cache Type(Experimental)||
|Global Cache Version|Cache version globally|
|Post Login Url|Return URL after the customer has successfully logged in|
|Post Login Action|Action to perform when the customer has successfully logged in|
|Reset Password Url|URL link suffix for the reset password page|
|Verify Email Url|URL link suffix for the verify email page|
|Allow Login Before Email Verification|This checkbox allows login without the email verification|
|Google Tag Manager Code||
|Google Site Tags(";"delimited)||
|Google Analytics Code||
|Session Time||

## CARD - Token Login
| Field| Description |
| ----------- | ----------- |
|Login Page||
|Query Param||
|Api||

## CARD - Maintenance
| Field| Description |
| ----------- | ----------- |
|Under Maintenance| If this checkbox is checked Site is channelled to Maintenance Page|
|Maintenance Site Folder|The location for the folder with Maintenance html file|
|Message|Maintenance message to go on the page|
## CARD - Error Colors
| Field| Description |
| ----------- | ----------- |
|Background 1| Hexadecimal colour code for Background 1 |
|Background 2| Hexadecimal colour code for Background 2 |
|Text|Hexadecimal color code for the Text|

## CARD - Content Security Policy(CSP)
| Field| Description |
| ----------- | ----------- |
|Content Security Policy|Its the response header that allows the web admins to control resources the user is allowed to load. This includes domains from external resources as well.Such as google fonts|
|Secure JavasScript(Experimental)|Experimental|
|Reporting Mode|?|

## CARD - Services Mapped
| Field| Description |
| ----------- | ----------- |
|Interface| This is the location of the Interface services mapped at the EndPoint |
|Mapped|Check this if the services are mapped|
|Endpoint|Location of where the API service is hosted|
|API|We are currently using Two APIs one for Users and other one for Admin (OSS and Admin)|
|Throttle|Number of API requests per Unit of time|
|Button [Add Debug Map]|This button enlists the new mapping in the list|
|Whitelist Groups|Groups to white list such as Facebook|

## CARD - Application Authentication
| Field| Description |
| ----------- | ----------- |
|Authenticator Code|Various modes of Authentications including G3, Microsoft , Google etc|
|Linked|Check this if the app is liked with External Authentication|
|Client Id|Client Id is provided by third party Authenticatino service, such as Google|
|Secret|Secret Key provided by third party Authentication|
|Scope|API scope|
|Points|?|
|Auto Link Email||
|Auto Create User||
|Email as Username||
|Auto Login After Verify||
|Concurrent Logins||
|Treaat Email As Verified||
|SMS MFA||

