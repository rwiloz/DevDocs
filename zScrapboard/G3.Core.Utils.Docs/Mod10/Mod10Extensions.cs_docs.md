---
title: Mod10Extensions Utility Functions
date: 2023-10-05
description: Documentation for Mod10Extensions utility providing methods for calculating and validating Mod10 check digits.
draft: false
---

# Mod10Extensions Utility

This document provides detailed information about the `Mod10Extensions` utility class, which includes methods for calculating and validating Mod10 check digits. This can be commonly used for credit card number validation and similar purposes.

## Namespace

The utility is contained within the following namespace:

```csharp
namespace G3.Core.Utils.Mod10
```

## Class

### Mod10Extensions

The `Mod10Extensions` class is a static class that offers functionality for calculating Mod10 check digits and verifying string inputs against Mod10 standards.

## Methods

### Mod10CheckDigit

```csharp
public static string Mod10CheckDigit(string number)
```

Calculates the Mod10 check digit for the given numeric string. It performs the Luhn algorithm to both compute and suggest a valid check digit for the input number.

- **Parameters**:
  - `number`: A `string` representing the number for which the check digit calculation is to be performed.

- **Returns**: 
  - A `string` representing the check digit.

### AddMod10

```csharp
public static string AddMod10(this string data)
```

Appends a Mod10 check digit to the provided string by internally calling `Mod10CheckDigit`.

- **Parameters**:
  - `data`: A `string` to which the check digit should be appended.

- **Returns**:
  - A new `string` consisting of the original data with its Mod10 check digit appended.

### Mod10Check

```csharp
public static bool Mod10Check(this string number)
```

Validates whether the provided string complies with the Mod10 checksum standard. It checks the integrity of the number using the Luhn algorithm.

- **Parameters**:
  - `number`: A numeric `string` to be checked for validity.

- **Returns**:
  - `true` if the string passes the Mod10 validation; otherwise, `false`.

## Usage

### Example

```csharp
string creditCardNumber = "123456789";
string numberWithCheckDigit = creditCardNumber.AddMod10();
bool isValid = numberWithCheckDigit.Mod10Check();

Console.WriteLine($"Number with check digit: {numberWithCheckDigit}");
Console.WriteLine($"Is the number valid? {isValid}");
```

### Explanation

- **Mod10CheckDigit**: This method computes and returns the check digit for a given number.
- **AddMod10**: This extension method appends the calculated check digit to the original string.
- **Mod10Check**: Validates the number including its check digit for correctness using the Luhn algorithm.

## Remarks

The Mod10 algorithm, also known as the Luhn algorithm, is widely used in credit card validation processes. This utility facilitates integration of Mod10 check functionalities, ensuring numeric strings comply with industry standards for verification purposes.
```