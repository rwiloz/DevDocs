---
title: "FormatterUtil Code Documentation"
date: 2023-10-10T12:00:00+02:00
draft: false
summary: "Documentation for the FormatterUtil static class, which provides various date and time formatting utilities."
---

# FormatterUtil Class Documentation

This documentation covers the `FormatterUtil` class, which provides extension methods to format dates and times in multiple styles. The class is part of the `G3.Core.Utils.DataType` namespace.

## Namespace
`G3.Core.Utils.DataType`

## Class: FormatterUtil

The `FormatterUtil` class is a static class that offers several methods to format `DateTime` and `DateTimeOffset` objects into string representations based on different cultural formats and notations.

### Methods

#### FormatDateDMY_

```csharp
public static string FormatDateDMY_(this DateTime date)
```
Formats a date into the "dd_MM_yyyy" format. If the date is `DateTime.MinValue`, it returns an empty string.

**Parameters**
- `date`: The date to be formatted.

**Returns**
- A string representing the formatted date.

#### FormatDateDMY

```csharp
public static string FormatDateDMY(this DateTime date, string cultureCode = CultureCodeContants.enAU)
```
Formats a date into "DD/MM/YYYY" format by default or "MM/dd/yyyy" if the US culture code is specified. Returns an empty string if the date is `DateTime.MinValue`.

**Parameters**
- `date`: The date to be formatted.
- `cultureCode`: Optional. Specifies the culture code. Uses `CultureCodeContants.enAU` as default.

**Returns**
- A string representing the formatted date.

#### FormatDateOffetDMY

```csharp
public static string FormatDateOffetDMY(this DateTimeOffset date, string cultureCode = CultureCodeContants.enAU)
```
Similar to `FormatDateDMY`, but used for `DateTimeOffset` objects.

**Parameters**
- `date`: The date offset to be formatted.
- `cultureCode`: Optional. Specifies the culture code. Defaults to `CultureCodeContants.enAU`.

**Returns**
- A string representing the formatted date offset.

#### FormatISODate

```csharp
public static string FormatISODate(this DateTime date)
```
Formats a date into the ISO 8601 format "yyyy-MM-ddTHH:mm:ss.fff". Returns an empty string if the date is `DateTime.MinValue`.

**Parameters**
- `date`: The date to be formatted.

**Returns**
- A string in ISO 8601 format.

#### FormatDateYMD

```csharp
public static string FormatDateYMD(this DateTime date)
```
Formats a date into "yyyy-MM-dd" format. Returns an empty string if the date is `DateTime.MinValue`.

**Parameters**
- `date`: The date to be formatted.

**Returns**
- A string representing the formatted date.

#### FormatDateYMDNoZeroFill

```csharp
public static string FormatDateYMDNoZeroFill(this DateTime date)
```
Formats a date into "yyyy-M-d" format, without zero-padding months and days. Returns an empty string if the date is `DateTime.MinValue`.

**Parameters**
- `date`: The date to be formatted.

**Returns**
- A string representing the formatted date.

#### FormatTimeHM24

```csharp
public static string FormatTimeHM24(this DateTime time)
```
Formats a time into "HH:mm" 24-hour format. Returns an empty string if the time is `DateTime.MinValue`.

**Parameters**
- `time`: The time to be formatted.

**Returns**
- A string representing the formatted time.

#### FormatDateTime

```csharp
public static string FormatDateTime(this DateTime dt)
```
Formats a date and time into "DD/MM/YYYY hh:mm tt" format. Returns an empty string if the date and time is `DateTime.MinValue`.

**Parameters**
- `dt`: The date and time to be formatted.

**Returns**
- A string representing the formatted date and time.
