# CheckDigitsUtils

The `CheckDigitsUtils` class provides utility methods for checking the validity and generating check digits of various identifiers like NMI (National Meter Identifier), ABN (Australian Business Number), ACN (Australian Company Number) and a generic Mod97 system-based identifier.

## Methods

- `IsValidNmi(string nmi)`: This function checks whether the given NMI is valid or not. The NMI should be a 11 characters long string. The function uses every character of the string applying different rules to generate a calculated string. The original and calculated strings are compared to verify the validity of NMI.

- `NmiCheckDigit(string nmi)`: This function generates the check digit for the given NMI. The NMI should be a 10 characters long string. The function uses every character of the string and applies different rules to generate a check digit.

- `NmiAddCheckDigit(string nmi)`: This function adds the check digit at the end of the given NMI string. The NMI should be a 10 characters long string. The function first generates the check digit for the NMI using the `NmiCheckDigit` method and then adds the check digit at the end of the NMI.

- `IsValidAbn(string abn)`: This method validates the given ABN. The ABN should be a 11 digits long string. The function uses the weighted sum approach with specific weights for each digit position to validate the ABN.

- `IsValidAcn(string acn)`: This method validates the given ACN. The ACN should be a 9 digits long string. Similar to the ABN validation, this method uses the weighted sum approach with specific weights for each digit position, and compares the calculated check digit with the actual check digit present at the last position.

- `Mod97CheckDigits(string data)`: This method calculates the Mod97 check digits of a numeric string up to 10 characters long.

- `AddMod97(string data)`: This method adds the Mod97 check digits at the end of the input string data. The data should be numbers and up to 10 characters long.