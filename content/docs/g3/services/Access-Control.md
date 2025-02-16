---
title: "Access Control"
linkTitle: ""
description: ""
summary: ""
date: 2023-09-07T16:12:03+02:00
lastmod: 2023-09-07T16:12:03+02:00
draft: false
weight: 999
toc: true
seo:
  title: "" # custom title (optional)
  description: "" # custom description (recommended)
  canonical: "" # custom canonical URL (optional)
  robots: "" # custom robot tags (optional)
---

# Access Control (AC)

Altering IP address info via Appbuilder has been updated to cointinue to work with the new AC system

<hr>

## Access Control Groups

|Type|Description|
|--|--|
|IPv4|IP v4 Address with optional mask, migrated from system settings|
|IPv6|IP v6 Address|
|Device|G3 Device ID|
|CountryCode|IP Address country code, Eg VN|
|ISP|IP Address ISP, Eg Amazon Technologies Inc.|

**LimitMultiplier** can be used with whitelists for shared networks to increase rate limits and limit checks (multi login etc)

**WhiteHatCode** is for future use and will be used to identify friend port scans or pen testers.

Processing priority order is
- Device
- IPv4
- IPv6
- ISP
- CountryCode

<hr>

## Access Control Rules

|Rule|Description|
|--|--|
|WhiteList|Allow Access & apply Limit Multipler|
|BlackList|Deny Access|
|Limit|Check Reports and apply limits|
|Proxy|Known Proxies (not implemented yet, still using old logic)


### Whitelist
**Code:** Group to use

### Blacklist
**Code:** Group to use
**BlockHours** How long to blacklist access

### Limit
**Code:** Report AccessType
**PriorHours:** How far back to check
**UniqueRef:** Check only unique AccessRef values (Eg unique logins)
**Limit:** Limit before automatic black listing
**BlockHours** How long to blacklist access

<hr>

## Access Control Reports

logging of AC events/reports

<hr>


## Access Control Audit

Log of what what blocked and why

#

## To Do

New X-Forward-For processing of multiple IP address for private IP and known proxies validation

## System Settings

AccessControl/AllowIPv6 allow IPv6 processing

AccessControl/ForceIPv4 force IPv4 downgrade for old service processing

AccessControl/EnforceWhiteListing force whitelisting for all external access if the Appbuilder UseWhiteLists hasn't been set