Here is the proposed code with added inline XML documentation comments:

```csharp
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace G3.Core.Utils.DataType
{
    /// <summary>
    /// This class provides capabilities related to constant culture codes and their related functionalities.
    /// </summary>
    public static class CultureCodeContants
    {
        /// <summary>
        /// Culture code for English-Australia.
        /// </summary>
        public const string enAU = "en-AU";
        
        /// <summary>
        /// Culture code for English-United States.
        /// </summary>
        public const string enUS = "en-US";
        
        /// <summary>
        /// Culture code for Spanish-United States.
        /// </summary>
        public const string enSP = "es-US";

        /// <summary>
        /// Determines if given culture is US based or not.
        /// </summary>
        /// <param name="culture">A string value representing culture code.</param>
        /// <returns>Returns true if the culture is US based. Else, returns false.</returns>
        public static bool IsUS(string culture)
        {
            return (culture == enUS) || (culture == enSP);
        }

        /// <summary>
        /// Returns date format based on given culture.
        /// </summary>
        /// <param name="culture">A string value representing culture code.</param>
        /// <returns>Returns date format based on given culture.</returns>
        public static string GetDateFormat(string culture)
        {
            return IsUS(culture) ? "MM/dd/yyyy" : "dd/MM/yyyy";
        }

        /// <summary>
        /// Generates DateTime object from given culture based date string.
        /// </summary>
        /// <param name="cultureCode">A string value representing culture code.</param>
        /// <param name="date">A string value representing date in particular culture format.</param>
        /// <returns>Returns DateTime object if conversion is possible. Else, returns null.</returns>
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
```
This XML documentation will be used by IntelliSense when a developer uses this class and methods and also can be used to generate external documentation.