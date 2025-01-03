---
title: "File Structures"
description: ""
summary: ""
date: 2023-09-07T16:12:03+02:00
lastmod: 2023-09-07T16:12:03+02:00
draft: false
weight: 110
toc: true
seo:
  title: "" # custom title (optional)
  description: "" # custom description (recommended)
  canonical: "" # custom canonical URL (optional)
  robots: "" # custom robot tags (optional)
---

**FTP Folder Structure**

Base folder

Prod
\\csofile2\SWMServer

Dev
\\csofile2\SWMDevelopment\Server

UAT
\\csofile2\SWMDevelopment\UAT\Server

[BaseFodler]\[Client]\[App]\In (moving files to “processed” subfolder)

[BaseFodler]\[Client]\[App]\Out

App is usually SFTP (as clients usually on have one SFTP setup, the filenames are used for different processes)

**Prod**  
\\csofile2\SWMServer\HunterWater\SFTP\In  
\\csofile2\SWMServer\HunterWater\SFTP\Out  

Dev
\\csofile2\SWMDevelopment\Server\HunterWater\SFTP\In
\\csofile2\SWMDevelopment\Server\HunterWater\SFTP\Out

UAT
\\csofile2\SWMDevelopment\UAT\Server\HunterWater\SFTP\In
\\csofile2\SWMDevelopment\UAT\Server\HunterWater\SFTP\Out

Setting RootDir or G3RootDir can also be used

Prod
RootDir = \\csofile2\SWMServer\HunterWater

Dev
RootDir = \\csofile2\SWMDevelopment\Server\HunterWater

UAT
RootDir = \\csofile2\SWMDevelopment\UAT\Server\HunterWater

Then other setting will always be the same

In = [RootDir]\SFTP\in
Out = [RootDir]\SFTP\Out
