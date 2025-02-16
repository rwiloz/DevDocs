Here are the XML summary comments added to the code:

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace G3.Core.Utils.DataType
{
    /// <summary>
    /// Utility class for date formatting.
    /// </summary>
    public static class FormatterUtil
    {
        /// <summary>
        /// Formats the date to the format "dd_MM_yyyy".
        /// </summary>
        /// <param name="date">The date to format.</param>
        /// <returns>The formatted date as a string.</returns>
        public static string FormatDateDMY_(this DateTime date)
        {
            return (date == DateTime.MinValue) ? "" : string.Format("{0:dd_MM_yyyy}", date);
        }

        /// <summary>
        /// Returns a date in DD/MM/YYYY format.
        /// The format varies based on the given culture code.
        /// </summary>
        /// <param name="date">The date to format.</param>
        /// <param name="cultureCode">The culture code to use for formatting the date.</param>
        /// <returns>The formatted date as a string.</returns>
        public static string FormatDateDMY(this DateTime date, string cultureCode = CultureCodeContants.enAU)
        {
            if (CultureCodeContants.IsUS(cultureCode))
            {
                return (date == DateTime.MinValue) ? "" : string.Format("{0:MM/dd/yyyy}", date);
            }
            return (date == DateTime.MinValue) ? "" : string.Format("{0:dd/MM/yyyy}", date);
        }

        /// <summary>
        /// Formats the date with an offset to the format "dd/MM/yyyy".
        /// The format varies based on the given culture code.
        /// </summary>
        /// <param name="date">The date to format.</param>
        /// <param name="cultureCode">The culture code to use for formatting the date.</param>
        /// <returns>The formatted date as a string.</returns>
        public static string FormatDateOffetDMY(this DateTimeOffset date, string cultureCode = CultureCodeContants.enAU)
        {
            if (CultureCodeContants.IsUS(cultureCode))
            {
                return (date == DateTime.MinValue) ? "" : string.Format("{0:MM/dd/yyyy}", date);
            }
            return (date == DateTime.MinValue) ? "" : string.Format("{0:dd/MM/yyyy}", date);
        }

        /// <summary>
        /// Formats the date to the ISO 8601 format.
        /// </summary>
        /// <param name="date">The date to format.</param>
        /// <returns>The formatted date as a string.</returns>
        public static string FormatISODate(this DateTime date)
        {
            return (date == DateTime.MinValue) ? "" : string.Format("{0:yyyy-MM-ddTHH:mm:ss.fff}", date);
        }

        /// <summary>
        /// Formats the date to the format "yyyy-MM-dd".
        /// </summary>
        /// <param name="date">The date to format.</param>
        /// <returns>The formatted date as a string.</returns>
        public static string FormatDateYMD(this DateTime date)
        {
            return (date == DateTime.MinValue) ? "" : string.Format("{0:yyyy-MM-dd}", date);
        }

        /// <summary>
        /// Formats the date to the format "yyyy-M-d" without zero-fill.
        /// </summary>
        /// <param name="date">The date to format.</param>
        /// <returns>The formatted date as a string.</returns>
        public static string FormatDateYMDNoZeroFill(this DateTime date)
        {
            return (date == DateTime.MinValue) ? "" : string.Format("{0:yyyy-M-d}", date);
        }

        /// <summary>
        /// Formats the time to the 24-hour format.
        /// </summary>
        /// <param name="time">The time to format.</param>
        /// <returns>The formatted time as a string.</returns>
        public static string FormatTimeHM24(this DateTime time)
        {
            return (time == DateTime.MinValue) ? "" : string.Format("{0:HH:mm}", time);
        }

        /// <summary>
        /// Returns a date in DD/MM/YYYY hh:mm am/pm format.
        /// </summary>
        /// <param name="date">The date and time to format.</param>
        /// <returns>The formatted date and time as a string.</returns>
        public static string FormatDateTime(this DateTime dt)
        {
            return (dt == DateTime.MinValue) ? "" : string.Format("{0:dd/MM/yyyy hh:mm tt}", dt);
        }
    }
}
Documenting your code with XML summary comments can be very useful to provide context for your methods, classes, parameters, etc. The XML comments can also be used to generate documentation for your code automatically.