---
title: DateUtil Class Documentation
description: Documentation for the DateUtil class, which provides utility methods for date and time manipulations in C#.
date: 2023-04-01
categories: ["Utilities", "DateTime"]
tags: ["C#", ".NET", "DateTime", "Utilities"]
---

# DateUtil Class Documentation

## Overview

The `DateUtil` class provides a set of static methods for performing various date and time operations in .NET. This includes parsing, formatting, and manipulating dates, as well as calculating business days, and checking holiday dates. The class also includes methods for range validation and converting between UTC and local time.

## Namespace

`G3.Core.Utils.DataType`

## Constants

- `DateParseFormat`: A string format used for parsing dates. Default value is `"MM/dd/yyyy hh:mm:ss.fff"`.

## Methods

### ToParseExactString

```csharp
public static string ToParseExactString(DateTime? date, string format = DateParseFormat)
```

Converts a nullable `DateTime` to a formatted string using the specified format, or returns an empty string if the date is null.

### ParseNullableTimeSpan

```csharp
public static TimeSpan? ParseNullableTimeSpan(string time)
```

Parses a string representation of a time span into a nullable `TimeSpan`. Returns `null` if the input string is `null` or empty.

### ParseNullableDate

```csharp
public static DateTime? ParseNullableDate(string dateStr)
```

Parses a string representation of a date into a nullable `DateTime`. Returns `null` if the input string is `null` or empty.

### ParseDate

```csharp
public static DateTime ParseDate(string dateStr)
```

Parses a string representation of a date into a `DateTime`. Returns a default `DateTime` value if parsing fails.

### FixMinDate

```csharp
public static DateTime? FixMinDate(DateTime? date)
```

Converts `DateTime.MinValue` to `null` for a nullable `DateTime`.

### ValidDateRange

```csharp
public static bool ValidDateRange(DateTime? date)
```

Checks if a nullable `DateTime` is within a valid date range (greater than `DateTime.MinValue` and less than `DateTime.MaxValue`).

### HolidayDate Class

```csharp
public class HolidayDate
```

Represents a holiday date with its type.

#### Constructors

- `HolidayDate(DateTime date, string type)`: Initializes a new instance of the `HolidayDate` class.

#### Properties

- `Date`: Gets the holiday date.
- `Type`: Gets the type of the holiday.

### CheckHoliday

```csharp
public static HolidayDate CheckHoliday(DateTime? date, string state)
```

Checks for holidays on a specific date and state, returning the corresponding `HolidayDate` object if a holiday exists.

### CalculateBusinessDate

```csharp
public static DateTime CalculateBusinessDate(DateTime currentDateTime, int businessDays, Func<DateTime, bool> isHoliday)
```

Calculates a future business date by adding a specified number of business days to a given date, excluding weekends and holidays.

### ToOrdinalDay

```csharp
public static string ToOrdinalDay(int dayOfMonth)
```

Converts a day of the month to its ordinal representation (e.g., 1st, 2nd, 3rd).

### Age

```csharp
public static int Age(DateTime dateOfBirth, DateTime dateNow)
```

Calculates the age based on a date of birth and the current date.

### IsInDateRange (extension method)

```csharp
public static bool IsInDateRange(this DateTimeOffset? date, DateTimeOffset? start, DateTimeOffset? end)
public static bool IsInDateRange(this DateTime? date, DateTime? start, DateTime? end)
```

Checks if a nullable date is within a specified date range.

### CalculateAverageMonthSpan (extension method)

```csharp
public static int CalculateAverageMonthSpan(this DateTime startDate, DateTime endDate)
```

Calculates the average number of months between two dates.

### FirstDayOfWeekOnOrBefore (extension method)

```csharp
public static DateTime FirstDayOfWeekOnOrBefore(this DateTime date, DayOfWeek dayOfWeek)
```

Finds the first occurrence of a specified day of the week on or before a given date.

### UTCToLocalTime (extension method)

```csharp
public static DateTime? UTCToLocalTime(this DateTime? date)
```

Converts a nullable `DateTime` from UTC to local time, keeping the same time but adjusting the date to local settings.
```