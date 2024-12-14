Here is the same code with added inline XML summary comments:

```csharp
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace G3.Core.Utils.Strings
{
    /// <summary>
    /// Contains methods for validating and working with strings like ACN, ABN and NMI.
    /// </summary>
    public static class CheckDigitsUtils
    {
        /// <summary>
        /// Determines whether NMI is valid or not.
        /// </summary>
        /// <param name="nmi">The NMI string to validate.</param>
        /// <returns>true if the NMI is valid; otherwise, false.</returns>
        public static bool IsValidNmi(this string nmi) {...}

        /// <summary>
        /// Computes and returns the check digit for an NMI.
        /// </summary>
        /// <param name="nmi">The NMI string to compute the check digit of.</param>
        /// <returns>A string representation of the computed check digit.</returns>
        public static string NmiCheckDigit(this string nmi){...}

        /// <summary>
        /// Appends the computed check digit to a given NMI.
        /// </summary>
        /// <param name="nmi">The NMI string to add check digit to.</param>
        /// <returns>The full NMi string with appended check digit.</returns>
        public static string NmiAddCheckDigit(this string nmi) {...}

        /// <summary>
        /// Determines whether ABN is valid or not.
        /// </summary>
        /// <param name="abn">The ABN string to validate.</param>
        /// <returns>true if the ABN is valid; otherwise, false.</returns>        
        public static bool IsValidAbn(this string abn){...}

        /// <summary>
        /// Determines whether ACN is valid or not.
        /// </summary>
        /// <param name="acn">The ACN string to validate.</param>
        /// <returns>true if the ACN is valid; otherwise, false.</returns>
        public static bool IsValidAcn(this string acn){...}

        /// <summary>
        /// Computes and returns the Mod97 check digits.
        /// </summary>
        /// <param name="data">The string to compute the Mod97 check digits of.</param>
        /// <returns>A string representation of the computed check digits.</returns>
        public static string Mod97CheckDigits(string data){...}

        /// <summary>
        /// Appends the computed Mod97 check digits to a given string.
        /// </summary>
        /// <param name="data">The string to add check digits to.</param>
        /// <returns>The full string with appended check digits.</returns>
        public static string AddMod97(string data){...}
    }
}
```
Each method now has a corresponding XML summary comment describing what it does and about its parameters and return values. The class now also includes a high-level summary explaining its purpose.