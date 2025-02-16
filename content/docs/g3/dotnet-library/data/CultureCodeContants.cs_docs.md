---
title: "Culture Code"
description: ""
summary: ""
date: 2023-09-07T16:12:37+02:00
lastmod: 2023-09-07T16:12:37+02:00
draft: false
weight: 900
toc: true
sidebar:
  collapsed: true
seo:
  title: "" # custom title (optional)
  description: "" # custom description (recommended)
  canonical: "" # custom canonical URL (optional)
  robots: "" # custom robot tags (optional)
---

# Class: CultureCodeContants

This static class is a part of 'G3.Core.Utils.DataType' namespace and is responsible for handling and manipulating different culture related functionalities.

## Constants

- `enAU` : Represents the Australian English-Language culture code ('en-AU').

- `enUS`  : Represents the United States English-Language culture code ('en-US').

- `enSP` : Represents the United States Spanish-Language culture code ('es-US').

## Methods

### Method: IsUS

This is a static method that takes in a string `culture` as argument and checks if this represents the US-based culture. Returns true if the given culture string is either 'en-US' or 'es-US'.

### Method: GetDateFormat

This is a static method that takes a string `culture` as argument and returns date string format based on the culture. If the culture is US-based, it returns "MM/dd/yyyy" (representing Month/Day/Year), otherwise, it returns "dd/MM/yyyy" (representing Day/Month/Year).

### Method: GetDateTime

This is a static method that takes in two strings `cultureCode` and `date` as arguments. It tries to create a DateTime object based on a given date string and culture code. The date string is expected to be in the format 'MM/dd/yyyy' for US cultures and 'dd/MM/yyyy' for non-US cultures. The method will return null for any invalid inputs or for dates outside the range of 1st January 1900 to 31st December 2099.