---
title: "Request ECC Certificates"
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

# Certificates

## ECC for internal API authentication JWTs

Create a custom cert request via MMC
Proceed without enrolment policy (won't auto renew because there isn't a template for what I want yet)
Set Properties
- Friendly Name > G3ApiAuth-UAT
- Key Usage > Digital Signature, Key Encipherment, Data Encipherment (b0)
- Private Key
  - Crypto Service Provider > ECDH_P256, Microsoft Software Key Storage Provider
  - Make private key exportable
