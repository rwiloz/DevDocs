using System.Text.RegularExpressions;
using G3.Core.Utils.DataType;
using G3.Core.Utils.Strings;

namespace G3.Core.Utils.Format
{
    public static class FormatExt
    {
        public const string AULandlinePhoneRegEx = @"^0[2-8]{1}[0-9]{8}";
        public const string AUMobileRegEx = @"^04[0-9]{8}$";
        public const string USPhoneRegex = @"^[2-9]\d{2}-\d{3}-\d{4}$";


        public static bool IsValidBsb(this string value, bool includeHypen = true)
        {
            value = value.GetString();
            var format = includeHypen ? @"^\d{3}-?\d{3}$" : @"^\d{6}$";
            var regEx = new Regex(format);
            return regEx.IsMatch(value);
        }

           public static bool IsValidEmail(this string email)
        {
            if (string.IsNullOrWhiteSpace(email)) return false;

            // source: http://thedailywtf.com/Articles/Validating_Email_Addresses.aspx
            var rx =
                new Regex(@"^[-!#$%&'*+/0-9=?A-Z^_a-z{|}~](\.?[-!#$%&'*+/0-9=?A-Z^_a-z{|}~])*@[a-zA-Z0-9](-?[a-zA-Z0-9])*(\.[a-zA-Z0-9](-?[a-zA-Z0-9])*)+$");
            return rx.IsMatch(email);
        }

        public static bool IsValidMobile(this string mobile, string cultureCode = CultureCodeContants.enAU)
        {
            if (CultureCodeContants.IsUS(cultureCode))
            {
                return IsValidUSPhone(mobile);
            }
            var rx = new Regex(AUMobileRegEx);
            return rx.IsMatch(mobile);
        }

        public static bool IsValidPhone(this string phone, string cultureCode = CultureCodeContants.enAU)
        {
            if (CultureCodeContants.IsUS(cultureCode))
            {
                return IsValidUSPhone(phone);
            }
            //Australia only
            var rx = new Regex(@"(^13[0-9]{4}$)|(^1300[0-9]{6}$)|(^1800[0-9]{6}$)|(^0[2-8]{1}[0-9]{8}$)");
            return rx.IsMatch(phone) || IsValidMobile(phone);
        }

        public static bool IsValidUSPhone(this string phone)
        {
            //US only
            var rx = new Regex(USPhoneRegex);
            return rx.IsMatch(phone);
        }

    }
}
