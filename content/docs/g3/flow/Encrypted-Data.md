---
title: "Data Encryption"
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

# Encrypted data

if a schema property is flagged as isEncrypted, the key defned in the flwo definition will be used to enrypt the data. An extra property will be added with the _hash suffix, this will be a hashed value of the data, this can be used to filter or find based on the encrypted value. However this will only work with an exact match, so it will be case sensative

Encryption is done be the integrated G3 Encryption key management system (AES256)

Indexed properties will also store the hash value in the **G3Flow.CaseIndexes** table