---
title: CheckDigitsUtils Class
date: 2023-10-10
description: Provides utility methods for validating and calculating check digits for NMIs, ABNs, and ACNs.
---

# CheckDigitsUtils Class

The `CheckDigitsUtils` class contains methods for validating and calculating check digits for National Meter Identifiers (NMI), Australian Business Numbers (ABN), and Australian Company Numbers (ACN). It also provides methods for performing Mod-97 check digit calculations.

## Methods

### IsValidNmi

```csharp
public static bool IsValidNmi(this string nmi)
```

Determines if the provided NMI is valid. The NMI must be 11 characters long, and its check digit must be correct.

- **Parameters**: 
  - `nmi`: A `string` representing the NMI to validate.
- **Returns**: `true` if the NMI is valid; otherwise, `false`.

### NmiCheckDigit

```csharp
public static string NmiCheckDigit(this string nmi)
```

Calculates the check digit for the provided NMI.

- **Parameters**: 
  - `nmi`: A `string` representing the NMI.
- **Returns**: A `string` representing the calculated check digit.

### NmiAddCheckDigit

```csharp
public static string NmiAddCheckDigit(this string nmi)
```

Appends the calculated check digit to the NMI.

- **Parameters**: 
  - `nmi`: A `string` representing the NMI.
- **Returns**: A `string` representing the NMI with its check digit appended.

### IsValidAbn

```csharp
public static bool IsValidAbn(this string abn)
```

Validates the provided Australian Business Number (ABN). The ABN must be 11 digits long, and the sum of the weighted digits should be divisible by 89.

- **Parameters**: 
  - `abn`: A `string` representing the ABN to validate.
- **Returns**: `true` if the ABN is valid; otherwise, `false`.

### IsValidAcn

```csharp
public static bool IsValidAcn(this string acn)
```

Validates the provided Australian Company Number (ACN). The ACN must be 9 digits long, and the calculated check digit should match the provided check digit.

- **Parameters**: 
  - `acn`: A `string` representing the ACN to validate.
- **Returns**: `true` if the ACN is valid; otherwise, `false`.

### Mod97CheckDigits

```csharp
public static string Mod97CheckDigits(string data)
```

Calculates the Mod-97 check digits for the given numeric string data. The data should be at most 10 digits long.

- **Parameters**: 
  - `data`: A `string` representing the numeric data.
- **Returns**: A `string` representing the calculated Mod-97 check digits.

### AddMod97

```csharp
public static string AddMod97(string data)
```

Appends the Mod-97 check digits to the provided numeric string data.

- **Parameters**: 
  - `data`: A `string` representing the numeric data.
- **Returns**: A `string` representing the data with Mod-97 check digits appended.
