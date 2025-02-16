Sure, you can annotate the given code as follows:

```C#
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

///<summary>
/// Namespace for Mod10 Check utilities
///</summary>
namespace G3.Core.Utils.Mod10
{
    ///<summary>
    /// Class providing Mod10 (Luhn algorithm) extension methods
    ///</summary>
    public static class Mod10Extensions
    {  
        ///<summary>
        /// Calculates Mod10 checksum digit for a given number
        ///</summary>
        ///<param name="number">An arbitrary long number in string format</param>
        ///<returns>Returns the Mod10 checksum of a given number</returns>
        public static string Mod10CheckDigit(string number)
        {
            var sum = 0;
            var alt = true;
            var digits = number.ToCharArray();
            for (int i = digits.Length - 1; i >= 0; i--)
            {
                var curDigit = (digits[i] - 48);
                if (alt)
                {
                    curDigit *= 2;
                    if (curDigit > 9)
                        curDigit -= 9;
                }
                sum += curDigit;
                alt = !alt;
            }
            if ((sum % 10) == 0)
            {
                return "0";
            }
            return (10 - (sum % 10)).ToString();
        }

        ///<summary>
        /// Adds Mod10 checksum to the end of the given data string
        ///</summary>
        ///<param name="data">Data string</param>
        ///<returns>Returns string with appended Mod10 checksum</returns>
        public static string AddMod10(this string data)
        {
            return data + Mod10CheckDigit(data);
        }

        ///<summary>
        /// Performs Mod10 (Luhn algorithm) check on a string number
        ///</summary>
        ///<param name="number">An arbitrary long number in a string format</param>
        ///<returns>Returns a boolean indicating if the number is valid according to Mod10 (Luhn algorithm) check</returns>
        public static bool Mod10Check(this string number)
        {
            if (string.IsNullOrEmpty(number))
            {
                return false;
            }

            int sumOfDigits = number.Where((e) => e >= '0' && e <= '9')
                .Reverse()
                .Select((e, i) => ((int)e - 48) * (i % 2 == 0 ? 1 : 2))
                .Sum((e) => e / 10 + e % 10);
            
            return sumOfDigits % 10 == 0;
        }

    }
}
```

These XML comments should make the functionality of the code clearer to others who may read or use it.