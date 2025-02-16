---
title: "Date Utils"
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

# DateUtil Class

This utility class provides several useful methods related to date and time manipulation. Since the class is static, you don't need to instantiate it to use its methods.

## Methods

`ToParseExactString(DateTime? date, string format = DateParseFormat)`: Returns a date and time string in the specified format. If no format is provided, the method defaults to "MM/dd/yyyy hh:mm:ss.fff".

`ParseNullableTimeSpan(string time)`: Parses a string to a `TimeSpan` object. If the string is null or empty, the method returns `null`.

`ParseNullableDate(string dateStr)`: Converts a string representing a date into a `DateTime` object. If the string is null or empty, the method returns `null`.

`ParseDate(string dateStr)`: Converts a string representing a date into a `DateTime` object. 

`FixMinDate(DateTime? date)`: Checks if the DateTime object is set to its minimum value. If so, the method returns `null`. Otherwise, it returns the DateTime object.

`ValidDateRange(DateTime? date)`: Verifies if a given DateTime object is between `DateTime.MinValue` and `DateTime.MaxValue`. Returns true if valid, false otherwise.

`CheckHoliday(DateTime? date, string state)`: Returns a `HolidayDate` object that matches the given date and state, if any.

`CalculateBusinessDate(DateTime currentDateTime, int businessDays, Func<DateTime, bool> isHoliday)`: Calculates a future date based on a count of business days. 

`ToOrdinalDay(int dayOfMonth)`: Converts a numeric date into an ordinal date string (e.g., "1st", "2nd", "3rd", etc.).

`Age(DateTime dateOfBirth, DateTime dateNow)`: Calculates the age based on a given birth date and the current date.

`IsInDateRange(this DateTimeOffset? date, DateTimeOffset? start, DateTimeOffset? end)`: Checks if a date is within a given date range.

`IsInDateRange(this DateTime? date, DateTime? start, DateTime? end)`: Overload for the previous method, but this one only works with `DateTime` objects. 

`CalculateAverageMonthSpan(this DateTime startDate, DateTime endDate)`: Calculates the average span in months between two dates.

`FirstDayOfWeekOnOrBefore(this DateTime date, DayOfWeek dayOfWeek)`: Finds the first day of the week that comes on or before the provided date.

`UTCToLocalTime(this DateTime? date)`: Converts a UTC DateTime object to local time.

## Inner Class

`HolidayDate`: Represents a specific holiday with properties for `Date` and `Type`. It's used in the CheckHoliday method to define a list of fixed holidays.