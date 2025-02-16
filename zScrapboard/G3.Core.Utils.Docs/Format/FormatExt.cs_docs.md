---
title: "G3.Core.Utils.Format: FormatExt Class"
date: 2023-10-04
draft: false
---

# `G3.Core.Utils.Format`

The `G3.Core.Utils.Format` namespace provides static methods to validate different format types such as phone numbers, email addresses, and more for Australian and US cultures.

## FormatExt Class

The `FormatExt` class offers a collection of methods to validate phone numbers and email addresses. It includes constant regular expressions for various formats and employs extension methods for formatting and validation tasks.

### Constants

- `AULandlinePhoneRegEx`: `@"^0[2-8]{1}[0-9]{8}"`
  - Validates Australian landline phone numbers.
  
- `AUMobileRegEx`: `@"^04[0-9]{8}$"`
  - Validates Australian mobile phone numbers.
  
- `USPhoneRegex`: `@"^[2-9]\d{2}-\d{3}-\d{4}$"`
  - Validates US phone numbers.

### Methods

#### IsValidBsb

```csharp
public static bool IsValidBsb(this string value, bool includeHypen = true)
```

Validates if a given string is a valid Australian BSB (Bank State Branch) number.

- `value`: The BSB number to validate.
- `includeHypen`: Indicates whether the input includes a hyphen. Defaults to `true`.
- **Returns**: `true` if the BSB is valid; otherwise, `false`.

#### IsValidEmail

```csharp
public static bool IsValidEmail(this string email)
```

Validates if a given string is a valid email address.

- `email`: The email address to validate.
- **Returns**: `true` if the email is valid; otherwise, `false`.

#### IsValidMobile

```csharp
public static bool IsValidMobile(this string mobile, string cultureCode = CultureCodeContants.enAU)
```

Validates if a given string is a valid mobile phone number for the specified culture.

- `mobile`: The mobile phone number to validate.
- `cultureCode`: The cultural context (e.g., Australian or US). Defaults to `enAU`.
- **Returns**: `true` if the mobile number is valid for the specified culture; otherwise, `false`.

#### IsValidPhone

```csharp
public static bool IsValidPhone(this string phone, string cultureCode = CultureCodeContants.enAU)
```

Validates if a given string is a valid phone number for the specified culture.

- `phone`: The phone number to validate.
- `cultureCode`: The cultural context (e.g., Australian or US). Defaults to `enAU`.
- **Returns**: `true` if the phone number is valid for the specified culture; otherwise, `false`.

#### IsValidUSPhone

```csharp
public static bool IsValidUSPhone(this string phone)
```

Validates if a given string is a valid US phone number.

- `phone`: The US phone number to validate.
- **Returns**: `true` if the phone number is valid; otherwise, `false`.
