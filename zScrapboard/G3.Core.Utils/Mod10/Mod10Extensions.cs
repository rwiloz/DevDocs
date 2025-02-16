using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace G3.Core.Utils.Mod10
{
    public static class Mod10Extensions
    {
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

        public static string AddMod10(this string data)
        {
            return data + Mod10CheckDigit(data);
        }

        public static bool Mod10Check(this string number)
        {
            // check whether input string is null or empty
            if (string.IsNullOrEmpty(number))
            {
                return false;
            }

            // 1.	Starting with the check digit double the value of every other digit 
            // 2.	If doubling of a number results in a two digits number, add up
            //   the digits to get a single digit number. This will results in eight single digit numbers                    
            // 3. Get the sum of the digits
            int sumOfDigits = number.Where((e) => e >= '0' && e <= '9')
                .Reverse()
                .Select((e, i) => ((int)e - 48) * (i % 2 == 0 ? 1 : 2))
                .Sum((e) => e / 10 + e % 10);


            // If the final sum is divisible by 10, then the credit card number
            //   is valid. If it is not divisible by 10, the number is invalid.            
            return sumOfDigits % 10 == 0;
        }

    }
}
