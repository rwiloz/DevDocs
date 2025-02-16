using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace G3.Core.Utils.DataType
{
    public static class CultureCodeContants
    {
        public const string enAU = "en-AU";
        public const string enUS = "en-US";
        public const string enSP = "es-US";

        public static bool IsUS(string culture)
        {
            return (culture == enUS) || (culture == enSP);
        }

        public static string GetDateFormat(string culture)
        {
            return IsUS(culture) ? "MM/dd/yyyy" : "dd/MM/yyyy";
        }

        public static DateTime? GetDateTime(string cultureCode, string date)
        {
            // from entities.cs
            var dateparts = date.Split('/');
            if (dateparts.Length == 3)
            {
                var year = Convert.ToInt32(dateparts[2]);
                int month = 0;
                int day = 0;
                if (IsUS(cultureCode))
                {
                    day = Convert.ToInt32(dateparts[1]);
                    month = Convert.ToInt32(dateparts[0]);
                }
                else
                {
                    month = Convert.ToInt32(dateparts[1]);
                    day = Convert.ToInt32(dateparts[0]);
                }
                var newdate = new DateTime(year, month, day);

                if (newdate >= new DateTime(1900, 1, 1) && newdate <= new DateTime(2099, 12, 31))
                {
                    return newdate;
                }
            }

            return null;
        }
    }
}
