---
title: "Module Types"
description: "Different types of modules used in G4"
summary: ""
date: 2024-01-03T16:04:48+02:00
lastmod: 2024-01-03T16:04:48+02:00
draft: false
weight: 810
toc: true
seo:
  title: "" # custom title (optional)
  description: "" # custom description (recommended)
  canonical: "" # custom canonical URL (optional)
  robots: "" # custom robot tags (optional)
---

## Module Types

- shim
conversion of npm commonJS to ESM for the browser
shared dependancies like react

- repackaged
  cant get it to work propertly too many dependancies


- bundled
  includes related dependancies to be reused in g4 modules (some duplication)
  
- g4 system
  core system services (AppEngine)
  core wrapped components

- g4 components
- custom components
- custom apps

building G4 modules
- deployed to NPM as libraries to be reused
- deployed to G3 CMS modules for runtime deployment
- NB need to exclude in the vite build


<img src="/images/esmshimmodule.svg" width=400px>

