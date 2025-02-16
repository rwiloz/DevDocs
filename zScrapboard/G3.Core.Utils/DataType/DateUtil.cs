using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace G3.Core.Utils.DataType
{
    public static class DateUtil
    {
        const string DateParseFormat = "MM/dd/yyyy hh:mm:ss.fff";

        public static string ToParseExactString(DateTime? date, string format = DateParseFormat)
        {
            return date.HasValue ? date.GetValueOrDefault().ToString(format) : string.Empty;
        }

        public static TimeSpan? ParseNullableTimeSpan(string time)
        {
            TimeSpan? date = new TimeSpan?();
            if (!string.IsNullOrEmpty(time))
            {
                TimeSpan d = new TimeSpan();
                TimeSpan.TryParse(time, out d);
                date = d;
            }

            return date;
        }

        public static DateTime? ParseNullableDate(string dateStr)
        {
            DateTime? date = new DateTime?();
            if (!string.IsNullOrEmpty(dateStr))
            {
                DateTime d = new DateTime();
                DateTime.TryParse(dateStr, out d);
                date = d;
            }

            return date;
        }

        public static DateTime ParseDate(string dateStr)
        {
            var date = new DateTime();
            DateTime.TryParse(dateStr, out date);

            return date;
        }

        public static DateTime? FixMinDate(DateTime? date)
        {
            if (date.HasValue && (date.GetValueOrDefault() == DateTime.MinValue))
            {
                return null;
            }

            return date;
        }

        public static bool ValidDateRange(DateTime? date)
        {
            var valid = false;
            if (date.HasValue &&
                ((date.GetValueOrDefault() > DateTime.MinValue) && (date.GetValueOrDefault() < DateTime.MaxValue))
                )
            {
                valid = true;
            }

            return valid;
        }

        public class HolidayDate
        {
            public HolidayDate(DateTime date, string type)
            {
                Date = date;
                Type = type;
            }

            public DateTime Date { get; private set; }
            public string Type { get; private set; }
        }

        public static HolidayDate CheckHoliday(DateTime? date, string state)
        {

            HolidayDate holiday = null;
            if (date.HasValue)
            {
                var dates = new List<HolidayDate>();
                dates.Add(new HolidayDate(new DateTime(2012, 1, 1), "NewYear"));
                dates.Add(new HolidayDate(new DateTime(2012, 1, 26), "AustraliaDay"));
                dates.Add(new HolidayDate(new DateTime(2012, 4, 6), "EasterFriday"));
                dates.Add(new HolidayDate(new DateTime(2012, 4, 9), "EasterMonday"));
                dates.Add(new HolidayDate(new DateTime(2012, 4, 25), "Anzac"));
                dates.Add(new HolidayDate(new DateTime(2012, 6, 11), "Queens"));
                if (state == "VIC")
                {
                    dates.Add(new HolidayDate(new DateTime(2011, 11, 1), "MelbourneCup"));
                    dates.Add(new HolidayDate(new DateTime(2011, 3, 14), "LabourDay"));
                }

                if (state == "QLD")
                {
                    dates.Add(new HolidayDate(new DateTime(2011, 2, 5), "LabourDay"));
                }
                if (state == "NSW")
                {
                    dates.Add(new HolidayDate(new DateTime(2011, 10, 3), "LabourDay"));
                }

                dates.Add(new HolidayDate(new DateTime(2011, 12, 27), "Christmas"));
                dates.Add(new HolidayDate(new DateTime(2011, 12, 26), "BoxingDay"));

                holiday = dates.FirstOrDefault(h => h.Date.Date == date.Value.Date);
            }

            return holiday;
        }

        public static DateTime CalculateBusinessDate(DateTime currentDateTime, int businessDays, Func<DateTime, bool> isHoliday)
        {
            Func<DateTime, bool> isNotWorkingDay = (x) => (x.DayOfWeek == DayOfWeek.Saturday) || (x.DayOfWeek == DayOfWeek.Sunday) || (isHoliday != null) && isHoliday(x);

            // folow switchwise javascript
            DateTime result = currentDateTime;
            int i = 1;
            while (i < businessDays || isNotWorkingDay(result))
            {
                //0 = Sunday, 6 = Saturday, if the date not equals a weekend day then increase by 1
                if (isNotWorkingDay(result))
                {
                    result = result.AddDays(1);
                }
                else
                {
                    result = result.AddDays(1);
                    i++;
                }
            }

            return result;
        }

        public static string ToOrdinalDay(int dayOfMonth)
        {
            //http://stackoverflow.com/questions/20156/is-there-an-easy-way-to-create-ordinals-in-c
            switch (dayOfMonth % 100)
            {
                case 11:
                case 12:
                case 13:
                    return dayOfMonth.ToString() + "th";
            }

            switch (dayOfMonth % 10)
            {
                case 1:
                    return dayOfMonth.ToString() + "st";
                case 2:
                    return dayOfMonth.ToString() + "nd";
                case 3:
                    return dayOfMonth.ToString() + "rd";
                default:
                    return dayOfMonth.ToString() + "th";
            }
        }

        public static int Age(DateTime dateOfBirth, DateTime dateNow)
        {
            int age = 0;
            age = dateNow.Year - dateOfBirth.Year;
            if (dateNow.DayOfYear < dateOfBirth.DayOfYear)
                age = age - 1;

            return age;
        }

        public static bool IsInDateRange(this DateTimeOffset? date, DateTimeOffset? start, DateTimeOffset? end)
        {
            return (date.HasValue &&
                 ((start.GetValueOrDefault() <= date.GetValueOrDefault()) &&
                            ((!end.HasValue) || (date.GetValueOrDefault() <= end.GetValueOrDefault()))));
        }

        public static bool IsInDateRange(this DateTime? date, DateTime? start, DateTime? end)
        {
            return (date.HasValue &&
                 ((start.GetValueOrDefault() <= date.GetValueOrDefault()) &&
                            ((!end.HasValue) || (date.GetValueOrDefault() <= end.GetValueOrDefault()))));
        }

        // Formula from delphi
        public static int CalculateAverageMonthSpan(this DateTime startDate, DateTime endDate)
        {
            TimeSpan ts = endDate - startDate;
            var approxDaysPerMonth = 30.4375;

            return (int)((double)ts.Days / approxDaysPerMonth);
        }

        //http://stackoverflow.com/questions/4883481/finding-first-day-of-calendar
        public static DateTime FirstDayOfWeekOnOrBefore(this DateTime date, DayOfWeek dayOfWeek)
        {
            while (date.DayOfWeek != dayOfWeek)
            {
                date = date.AddDays(-1);
            }
            return date;
        }

        public static DateTime? UTCToLocalTime(this DateTime? date)
        {
            if (date.HasValue)
            {
                var now = DateTime.Now;
                var localDate = date.Value.ToLocalTime();
                date = new DateTime(localDate.Year, localDate.Month, localDate.Day, now.Hour, now.Minute, now.Second);

                return date;
            }

            return date;
        }
    }
}
