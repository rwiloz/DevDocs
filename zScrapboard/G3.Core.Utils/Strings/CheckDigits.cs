using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace G3.Core.Utils.Strings
{
    public static class CheckDigitsUtils
    {
        public static bool IsValidNmi(this string nmi)
        {
            //taken from QE
            if (nmi == null || nmi.Length != 11)
            {
                return false;
            }

            var newNMI = nmi.Substring(0, 10).ToUpper();
            var doubleChar = true;
            var calc = 0;
            for (var cnt = 9; cnt >= 0; cnt--)
            {
                var ch = newNMI.ToCharArray()[cnt];
                var ascii = (int)ch;

                if (doubleChar)
                {
                    ascii = ascii * 2;
                }

                do
                {
                    calc = calc + ascii % 10;
                    ascii = ascii / 10;
                } while (ascii != 0);

                doubleChar = !doubleChar;
            }

            calc = ((calc / 10) + 1) * 10 - calc;
            if (calc == 10)
            {
                calc = 0;
            }
            newNMI = newNMI + calc.ToString(CultureInfo.InvariantCulture);

            return (newNMI == nmi);
        }

        public static string NmiCheckDigit(this string nmi)
        {
            var newNMI = nmi.Substring(0, 10).ToUpper();
            var doubleChar = true;
            var calc = 0;
            for (var cnt = 9; cnt >= 0; cnt--)
            {
                var ch = newNMI.ToCharArray()[cnt];
                var ascii = (int)ch;

                if (doubleChar)
                {
                    ascii = ascii * 2;
                }

                do
                {
                    calc = calc + ascii % 10;
                    ascii = ascii / 10;
                } while (ascii != 0);

                doubleChar = !doubleChar;
            }

            calc = ((calc / 10) + 1) * 10 - calc;
            if (calc == 10)
            {
                calc = 0;
            }

            return calc.ToString(CultureInfo.InvariantCulture);
        }

        public static string NmiAddCheckDigit(this string nmi)
        {
            var newNMI = nmi.Substring(0, 10).ToUpper();
            var checkDig = newNMI.NmiCheckDigit();
            return newNMI + checkDig;
        }

        public static bool IsValidAbn(this string abn)
        {

            int[] l_weight = { 10, 1, 3, 5, 7, 9, 11, 13, 15, 17, 19 };
            int l_sum = 0;

            // Ensure ABN is 11 digits long
            if (string.IsNullOrEmpty(abn) || abn.Length != 11)
            {
                return false;
            }

            try
            {
                // Sum the multiplication of all the digits and weights
                for (int i = 0; i < l_weight.Length; i++)
                {
                    // Subtract 1 from the first left digit before multiplying against the weight
                    if (i == 0)
                        l_sum = (Convert.ToInt32(abn.Substring(i, 1)) - 1) * l_weight[i];
                    else
                    {
                        l_sum += Convert.ToInt32(abn.Substring(i, 1)) * l_weight[i];
                    }
                }

                // Divide the sum by 89, if there is no remainder the ABN is valid
                if ((l_sum % 89) == 0)
                    return true;
                else
                    return false;
            }
            catch
            {
                return false;
            }
        }

        public static bool IsValidAcn(this string acn)
        {

            int[] l_weight = { 8, 7, 6, 5, 4, 3, 2, 1 };
            int l_sum = 0;
            int l_remainder = 0;
            int l_calculatedCheckDigit = 0;

            // Ensure ABN is 11 digits long
            if (string.IsNullOrEmpty(acn) || acn.Length != 9)
            {
                return false;
            }

            try
            {
                // Sum the multiplication of all the digits and weights
                for (int i = 0; i < l_weight.Length; i++)
                {
                    l_sum += Convert.ToInt32(acn.Substring(i, 1)) * l_weight[i];
                }

                // Divide by 10 to obtain remainder
                l_remainder = l_sum % 10;

                // Complement the remainder to 10
                l_calculatedCheckDigit = (10 - l_remainder == 10) ? 0 : (10 - l_remainder);

                // Compare the calculated check digit with the actual check digit
                if (l_calculatedCheckDigit == Convert.ToInt32(acn.Substring(8, 1)))
                    return true;
                else
                    return false;
            }
            catch
            {
                return false;
            }
        }

        public static string Mod97CheckDigits(string data)
        {
            if (string.IsNullOrWhiteSpace(data))
                return "";

            if (!data.IsDigits() || (data.Length > 10)) return "";

            var weights = new Byte[] { 19, 23, 29, 31, 37, 41, 43, 47, 53, 59 };
            var total = 0;

            data = data.PadLeft(10, '0');

            for (var cnt = 0; cnt < data.Length; cnt++)
                total = total + Convert.ToInt32(data[cnt]) * weights[cnt];

            var res2 = (97 - total % 97).ToString();
            return res2.PadLeft(2, '0');
        }

        public static string AddMod97(string data)
        {
            return data + Mod97CheckDigits(data);
        }
    }
}
