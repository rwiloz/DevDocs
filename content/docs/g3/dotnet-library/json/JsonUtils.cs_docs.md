---
title: "Utils"
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

# JsonUtils Class

This class belongs to the `G3.Core.Utils.JsonExt` namespace and is a static utility class related to Newtonsoft's Json serialization. The `JsonUtils` class is primarily used for setting up different `JsonSerializerSettings`.

## JsonSettings

This property returns a new instance of `JsonSerializerSettings` with `DefaultValueHandling` and `NullValueHandling` set to `Ignore`, and `ReferenceLoopHandling` set to `Ignore`.

## JsonSettingsSerializeAll

This property returns a new instance of `JsonSerializerSettings` like `JsonSettings`, but with `DefaultValueHandling` and `NullValueHandling` set to `Include`.

## JsonSettingsJavaScript

The `JsonSettingsJavaScript` property returns a `JsonSerializerSettings` object, configured specifically for JavaScript. It includes a `CamelCasePropertyNamesContractResolver` for handling property names and a `StringEnumConverter` for handling Enum to string conversions. The `DateTimeZoneHandling` is set to `Utc` and `ReferenceLoopHandling` is set to `Ignore`.

## JsonSettingsJavaScriptIgnoreNulls

This property is similar to `JsonSettingsJavaScript` except it sets NullValueHandling to `Ignore`. 

## JsonSettingsJavaScriptSerializeAll

Similar to `JsonSettingsJavaScript`, but sets both `DefaultValueHandling` and `NullValueHandling` to `Include`.

## JsonSettingsSwagger

This property returns a new instance of `JsonSerializerSettings` with specific settings for use with Swagger. It sets up a `CamelCasePropertyNamesContractResolver`, a `StringEnumConverter`, configures the `DateFormatString`, and sets `ReferenceLoopHandling` to `Ignore` and `NullValueHandling` to `Ignore`.

Note: Several of the properties have commented out code for `PreserveReferencesHandling` and `DictionaryKeysAreNotPropertyNamesJsonConverter()`, likely due to issues found during development. 