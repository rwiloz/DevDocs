---
title: "Mask"
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

# JsonMask Class

This class is part of the G3.Core.Utils.JsonExt namespace and provides static methods to mask specific properties in a JSON string. It's useful where sensitive information needs to be obscured or hidden. 

The class contains the following methods:

### Public Methods:

**JsonMaskFields**

This method is an extension method for a string representing a JSON object. It takes an array of property paths (blacklist), an array of regex patterns to match the values that needs to be masked, and a mask string which is used to replace the values of the properties. 

The method throws an ArgumentNullException if either the JSON string, blacklist paths, or mask values are null.

- Input: 
    * `json` is a string which needs to be masked.
    * `blackListPath` is an array of property paths that will be masked.
    * `maskValues` is an array of regex patterns matching the values that needs to be masked.
    * `mask` is a string used to replace the properties value.
    
- Output: 
    * The method returns a JSON string with specified properties masked.

### Private Methods:

**MaskFieldsFromJToken**

This method is used by the JsonMaskFields method to recursively visit each property in the JSON object and apply the masking. The method creates and populates a removeList for each matching property or value in the blackListPath or maskValues respectively. 

The removeList is then iterated over to replace each JProperty's value with the specified mask.

- Input: 
    * `token` is a JObject which needs to be masked.
    * `blackListPath` is an array of property paths that will be masked.
    * `maskValues` is an array of regex patterns matching the values that needs to be masked.
    * `mask` is a string used to replace the properties value.
    
- Output: 
    * No return value. The method modifies the passed JObject by reference.

Please note that there's a commented out method called `WildCardToRegular`. It appears that this method was used in a previous version of the code to convert wildcard searches into regular expressions, but has since been disabled or is no longer used.