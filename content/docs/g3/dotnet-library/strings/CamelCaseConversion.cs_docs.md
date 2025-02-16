---
title: "Case"
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

# Class: CamelCaseConversion

The `CamelCaseConversion` is a utility class in the G3.Core.Utils.Strings namespace. The class contains static extension methods for manipulating and converting text strings, particularly for case formatting.

## Methods:

### CamelToTitleCase

- `public static string CamelToTitleCase(this string text)`

This method converts a given camel case string to title case. It breaks up camelcased words into separate words, starting with a capital letter. The method skips over empty strings, and handles sequences of uppercase characters correctly.

### CamelToTitleCase (With Acronyms)

- `public static string CamelToTitleCase(this string text, string[] acroynoms)`

This variation of the `CamelToTitleCase` method allows for an additional parameter: a list of acronyms that need to be preserved in their original state. This method ensures that these acronyms are not broken up into separate words, and that their casing remains intact.

### CapitaliseFirstCharacterSentence

- `public static string CapitaliseFirstCharacterSentence(this string sentence)`

This method capitalizes the first character of each word in a sentence.

### CapitaliseFirstCharacter

- `public static string CapitaliseFirstCharacter(this string text)`

This method is used to convert the first letter of a provided string to be in upper-case. If an empty string is provided, it is simply returned as it is.

### LowerFirstCharacter

- `public static string LowerFirstCharacter(string text)`

This method is used to convert the first letter of a provided string to be in lower-case. If an empty string is provided, it is simply returned as it is.