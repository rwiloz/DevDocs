
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace G3.Core.Utils.DataType
{
    public static class FormatterUtil
    {
        public static string FormatDateDMY_(this DateTime date)
        {
            return (date == DateTime.MinValue) ? "" : string.Format("{0:dd_MM_yyyy}", date);
        }

        /// <summary>
        /// Returns a date in DD/MM/YYYY format
        /// </summary>
        /// <param name="date"></param>
        /// <returns></returns>
        public static string FormatDateDMY(this DateTime date, string cultureCode = CultureCodeContants.enAU)
        {
            if (CultureCodeContants.IsUS(cultureCode))
            {
                return (date == DateTime.MinValue) ? "" : string.Format("{0:MM/dd/yyyy}", date);
            }
            return (date == DateTime.MinValue) ? "" : string.Format("{0:dd/MM/yyyy}", date);
        }

        public static string FormatDateOffetDMY(this DateTimeOffset date, string cultureCode = CultureCodeContants.enAU)
        {
            if (CultureCodeContants.IsUS(cultureCode))
            {
                return (date == DateTime.MinValue) ? "" : string.Format("{0:MM/dd/yyyy}", date);
            }
            return (date == DateTime.MinValue) ? "" : string.Format("{0:dd/MM/yyyy}", date);
        }

        public static string FormatISODate(this DateTime date)
        {
            return (date == DateTime.MinValue) ? "" : string.Format("{0:yyyy-MM-ddTHH:mm:ss.fff}", date);
        }

        public static string FormatDateYMD(this DateTime date)
        {
            return (date == DateTime.MinValue) ? "" : string.Format("{0:yyyy-MM-dd}", date);
        }

        public static string FormatDateYMDNoZeroFill(this DateTime date)
        {
            return (date == DateTime.MinValue) ? "" : string.Format("{0:yyyy-M-d}", date);
        }

        public static string FormatTimeHM24(this DateTime time)
        {
            return (time == DateTime.MinValue) ? "" : string.Format("{0:HH:mm}", time);
        }

        /// <summary>
        /// Returns a date in DD/MM/YYYY hh:mm am/pm format
        /// </summary>
        /// <param name="date"></param>
        /// <returns></returns>
        public static string FormatDateTime(this DateTime dt)
        {
            return (dt == DateTime.MinValue) ? "" : string.Format("{0:dd/MM/yyyy hh:mm tt}", dt);
        }

    }
}
