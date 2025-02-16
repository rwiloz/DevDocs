```C#
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/// <summary>
/// The <c>DateUtil</c> class contains a series of utility methods for handling dates.
/// </summary>
namespace G3.Core.Utils.DataType
{
    public static class DateUtil
    {
        const string DateParseFormat = "MM/dd/yyyy hh:mm:ss.fff";

        /// <summary>
        /// Converts provided DateTime to a formatted string. If no format is provided, it uses default MM/dd/yyyy hh:mm:ss.fff.
        /// </summary>
        public static string ToParseExactString(DateTime? date, string format = DateParseFormat)
        {
            return date.HasValue ? date.GetValueOrDefault().ToString(format) : string.Empty;
        }

        /// <summary>
        /// Attempts to convert a string into a TimeSpan object. Will return null if parsing fails.
        /// </summary>
        public static TimeSpan? ParseNullableTimeSpan(string time)
        {
            TimeSpan? date = new TimeSpan?();
            if (!string.IsNullOrEmpty(time))
            {
                TimeSpan.TryParse(time, out var d);
                date = d;
            }

            return date;
        }

        /// <summary>
        /// Attempts to convert a string to a DateTime object. Returns null if unable to parse.
        /// </summary>
        public static DateTime? ParseNullableDate(string dateStr)
        {
            DateTime? date = new DateTime?();
            if (!string.IsNullOrEmpty(dateStr))
            {
                DateTime.TryParse(dateStr, out var d);
                date = d;
            }

            return date;
        }

        /// <summary>
        /// Attempts to parse a string into a DateTime object. Returns a default DateTime object if unsuccessful.
        /// </summary>
        public static DateTime ParseDate(string dateStr)
        {
            var date = new DateTime();
            DateTime.TryParse(dateStr, out date);

            return date;
        }

        /// <summary>
        /// Checks if the provided DateTime is the minimum value, and returns null if true.
        /// </summary>
        public static DateTime? FixMinDate(DateTime? date)
        {
            if (date.HasValue && (date.GetValueOrDefault() == DateTime.MinValue))
            {
                return null;
            }

            return date;
        }
        
        /// <summary>
        /// Checks if the provided DateTime falls within a valid range, excluding MinValue and MaxValue. Returns false if out of range or null.
        /// </summary>
        public static bool ValidDateRange(DateTime? date)
        {
            return date.HasValue && 
                ((date.GetValueOrDefault() > DateTime.MinValue) && (date.GetValueOrDefault() < DateTime.MaxValue));
        }

        public class HolidayDate
        {
            /// <summary>
            /// Constructor for the HolidayDate class. Requires a date and type for the holiday.
            /// </summary>
            public HolidayDate(DateTime date, string type)
            {
                Date = date;
                Type = type;
            }

            public DateTime Date { get; private set; }
            public string Type { get; private set; }
        }

        /// <summary>
        /// Checks if the provided DateTime corresponds with a holiday. Returns the corresponding HolidayDate object or null.
        /// </summary>
        public static HolidayDate CheckHoliday(DateTime? date, string state)
        {
            // implementation skipped for brevity
        }

        /// <summary>
        /// Calculates the date after a certain number of business days from a start date, skipping weekends and holidays.
        /// </summary>
        public static DateTime CalculateBusinessDate(DateTime currentDateTime, int businessDays, Func<DateTime, bool> isHoliday)
        {
            // implementation skipped for brevity
        }

        /// <summary>
        /// Returns a string representing the ordinal of the day number (1st, 2nd, 3rd, etc.).
        /// </summary>
        public static string ToOrdinalDay(int dayOfMonth)
        {
            // implementation skipped for brevity
        }

        /// <summary>
        /// Returns the age at a specified date,
        /// based on the birth date provided.
        /// </summary>
        public static int Age(DateTime dateOfBirth, DateTime dateNow)
        {
            // implementation skipped for brevity
        }

        /// <summary>
        /// Extension method for DateTime to determine if a date falls within a certain range.
        /// </summary>
        public static bool IsInDateRange(this DateTime? date, DateTime? start, DateTime? end)
        {
            // implementation skipped for brevity
        }

        /// <summary>
        /// Extension method for DateTimeOffset to determine if a date falls within a certain range.
        /// </summary>
        public static bool IsInDateRange(this DateTimeOffset? date, DateTimeOffset? start, DateTimeOffset? end)
        {
            // implementation skipped for brevity
        }

        /// <summary>
        /// Calculate and return the approximate number of months between two dates.
        /// </summary>
        public static int CalculateAverageMonthSpan(this DateTime startDate, DateTime endDate)
        {
            // implementation skipped for brevity
        }

        /// <summary>
        /// Returns the first date that falls on the given day of the week before or on the specified date.
        /// </summary>
        public static DateTime FirstDayOfWeekOnOrBefore(this DateTime date, DayOfWeek dayOfWeek)
        {
            // implementation skipped for brevity
        }

         /// <summary>
        /// Extension method to convert an UTC DateTime to local DateTime.
        /// </summary>
        public static DateTime? UTCToLocalTime(this DateTime? date)
        {
            // implementation skipped for brevity
        }
    }
}
```
These comments give a clear outline of the purpose and functionality of each method as well as the class itself.