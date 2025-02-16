Here's the code with added inline XML summary:

```csharp
/// <summary>
/// This namespace is used for format utility functions.
/// </summary>
using System.Text.RegularExpressions;
using G3.Core.Utils.DataType;
using G3.Core.Utils.Strings;
namespace G3.Core.Utils.Format
{
    /// <summary>
    /// This public static format class contains functions that validate different types of data.
    /// </summary>
    public static class FormatExt
    {
        /// <summary>
        /// This constant string represents the regular expression for AU landline number format.
        /// </summary>
        public const string AULandlinePhoneRegEx = @"^0[2-8]{1}[0-9]{8}";
        /// <summary>
        /// This constant string represents the regular expression for AU mobile format.
        /// </summary>
        public const string AUMobileRegEx = @"^04[0-9]{8}$";
        /// <summary>
        /// This constant string represents the regular expression for US phone number format.
        /// </summary>
        public const string USPhoneRegex = @"^[2-9]\d{2}-\d{3}-\d{4}$";

        /// <summary>
        /// This function checks whether the provided BSB number is valid.
        /// </summary>
        /// <param name="value">The BSB number to check.</param>
        /// <param name="includeHypen">A boolean flag to check if the BSB number includes hyphen or not.</param>

        /// <returns>Returns true if the BSB number is valid.</returns>
        public static bool IsValidBsb(this string value, bool includeHypen = true)
        {...}

        /// <summary>
        /// This function checks whether the provided email is valid.
        /// </summary>
        /// <param name="email">The email to check.</param>
        /// <returns>Returns true if the email is valid.</returns>
        public static bool IsValidEmail(this string email)
        {...}

        /// <summary>
        /// This function checks whether the provided AU mobile number is valid.
        /// </summary>
        /// <param name="mobile">The mobile number to check.</param>
        /// <param name="cultureCode">The culture code for the provided mobile number.</param>
        /// <returns>Returns true if the AU mobile number is valid.</returns>
        public static bool IsValidMobile(this string mobile, string cultureCode = CultureCodeContants.enAU)
        {...}

        /// <summary>
        /// This function checks whether the provided phone number is valid.
        /// </summary>
        /// <param name="phone">The phone number to check.</param>
        /// <param name="cultureCode">The culture code for the provided phone number.</param>
        /// <returns>Returns true if the phone number is valid.</returns>
        public static bool IsValidPhone(this string phone, string cultureCode = CultureCodeContants.enAU)
        {...}

        /// <summary>
        /// This function checks whether the provided US phone number is valid.
        /// </summary>
        /// <param name="phone">The phone number to check.</param>
        /// <returns>Returns true if the US phone number is valid.</returns>
        public static bool IsValidUSPhone(this string phone)
        {...}
    }
}
```

Please keep in mind that these summary tags (`/// <summary>`), when added directly above a method or class, will then offer information about the purpose or functionality of that method or class when you hover over it in most IDEs.