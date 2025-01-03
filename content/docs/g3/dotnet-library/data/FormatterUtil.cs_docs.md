---
title: "Format"
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

# Class: FormatterUtil
This class is a utility class under the namespace G3.Core.Utils.DataType, defined as static and contains multiple static methods to format the DateTime and DateTimeOffset objects to strings in different ways. 

Here's a summary of the class methods:

## 1. FormatDateDMY_(DateTime date)
This method formats the given DateTime object into a string in the "dd_MM_yyyy" format. If the input date is the minimum value, it will return an empty string. 

## 2. FormatDateDMY(DateTime date, string cultureCode = "enAU")
This method accepts a DateTime object and a cultureCode. By default, the culture code is "enAU" however it can be modified. If the cultureCode corresponds to the US as defined in CultureCodeContants, it formats the date in the "MM/dd/yyyy" format else in the "dd/MM/yyyy". If the date is the minimum value, it returns an empty string.

## 3. FormatDateOffetDMY(DateTimeOffset date, string cultureCode = "enAU")
Similar to FormatDateDMY() method, this accepts a DateTimeOffset object instead of DateTime.

## 4. FormatISODate(DateTime date)
Formats the date to an ISO date string('yyyy-MM-ddTHH:mm:ss.fff'). If the date is the minimum value, it returns an empty string.

## 5. FormatDateYMD(DateTime date)
Returns a formatted string in "yyyy-MM-dd" format. If the date is the minimum value, it returns an empty string.

## 6. FormatDateYMDNoZeroFill(DateTime date)
Returns a formatted string in "yyyy-M-d" format where leading zeros are not added. If the date is the minimum value, it returns an empty string.

## 7. FormatTimeHM24(DateTime time)
Returns a formatted string representing time in 24-hour format. If the time is the minimum value, it returns an empty string.

## 8. FormatDateTime(DateTime dt)
Formats the DateTime into a string format "dd/MM/yyyy hh:mm tt". If the time is the minimum value, it returns an empty string.