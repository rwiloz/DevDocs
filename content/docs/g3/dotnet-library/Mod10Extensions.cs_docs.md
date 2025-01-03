---
title: "Mod 10"
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

# Class Name: Mod10Extensions

### Using Statements:
- System
- System.Collections.Generic
- System.Linq
- System.Text

### Namespace: G3.Core.Utils.Mod10

This class, named Mod10Extensions, is declared as `public`, allowing it to be accessed in other classes. It contains Modulus 10 (Mod10) specific methods. Mod10 algorithm, also known as the Luhn algorithm, is commonly used for validating certain identification numbers such as credit card numbers.

### `Mod10CheckDigit(string number)`

This public static method accepts one string parameter identified as `number`. It calculates and returns the Modulus 10 (Luhn algorithm) check digit for the provided number string.

### `AddMod10(this string data)`

This public static method serves as an extension to any string type variable in the namespace scope. The method encapsulates `Mod10CheckDigit(data)` to append a Mod10 check digit to an existing number string and returns the result.

### `Mod10Check(this string number)`

This public static method serves as an extension to any string type variable in the namespace scope. It validates the number string provided using the Mod10 check algorithm and returns `true` if the string passes the validation, `false` otherwise. This method first verifies that the string is not null or empty, and then performs a modified version of the Mod10 check sequence to determine validity. If the sum of digits is divisible by 10, the number is considered valid.

The namespace `G3.Core.Utils.Mod10` indicates that `Mod10Extensions` class is a utility/helper class located in `Core` module of the `G3` project.