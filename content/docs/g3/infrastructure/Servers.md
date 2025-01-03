---
title: "Servers"
description: ""
summary: ""
date: 2023-09-07T16:12:03+02:00
lastmod: 2023-09-07T16:12:03+02:00
draft: false
weight: 100
toc: true
seo:
  title: "" # custom title (optional)
  description: "" # custom description (recommended)
  canonical: "" # custom canonical URL (optional)
  robots: "" # custom robot tags (optional)
---

## Australia

### Web Server Names
||Dev/UAT|Prod Y|Prod D|
|--|--|--|--|
|Oceania Web|MELYVDAUWKWEB04|MELYVPAWEB04|MELDVPAWEB04
|Oceania App|MELYVDAUWK01|MELYVPAUWRKS02|MELDVPAUWRKS02
|DMZ Web|CSOVXCUSHOINET1|MELYVXPAWEB04|MELDVXPAWEB04

### SQL 2019 Server Names
||Dev/UAT|Prod|
|--|--|--|
|Data|CSOVDQSWM50\INS1|CSOVPQCUS02\INS1
|DMZ Session (G2)|CSOVPQCUS03\INS1|CSOVPQCUS03\INS1


<img src="/images/infrastructure.png">


-----  
## UK

### Web Server Names
||UAT BRS|UAT NEP|Prod BRS|Prod NEP|
|--|--|--|--|--|
|DMZ Web|BRSPVXOSSWEBUAT|NEPCVXOSSWEBUAT|BRSPVXOSSWEB1|NEPCVXOSSWEB1
|EMEA LAN|BRSPVOSSAPPUAT1|NEPCVOSSAPPUAT1|BRSPVOSSAPP1|NEPCVOSSAPP1

### SQL Server Names
|UAT|Prod|
|--|--|
|db-ccs-oss-uat.emea.cshare.net,65165|db-ccs-oss-prod.emea.cshare.net,65013|

- I think UAT is read/write
- Prod will be read only

