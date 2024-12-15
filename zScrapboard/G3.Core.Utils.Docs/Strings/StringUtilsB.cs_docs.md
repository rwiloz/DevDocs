# StringUtils

The `StringUtils` class offers various static extension and helper methods for working with strings. Below is a brief description of each method:

1. `ToMaskedValue`: This method obscures a part of a string, leaving only the last few characters visible. This is useful for masking sensitive data like password or card number.

2. `MaskMobile` and `MaskMobileAu`: These methods mask mobile numbers while leaving the last three characters visible. The `MaskMobileAu` method is specifically designed for Australian mobile numbers.

3. `MaskEmail`: This method obscures a part of an email address, while leaving the domain and the last few characters of the local part visible. 

4. `GetString` and `GetStringDefault`: These methods return the input string, or a default string if the input is null or empty.

5. `GetTrimString`: This method trims the input string.

6. `MaxLength`: This method returns a substring with a maximum length.

7. `GetAsciiString` and `GetAsciiTrimString`: These methods convert a Unicode string into an ASCII-encoded string, replacing non-ASCII characters with a specified replacement string.

8. `ToFriendlyString`: This method converts a KeyValuePair to a friendly string representation.

9. `AsEnum`: This method attempts to parse a string into an enumeration value.

10. `GetInitials`: This method gets the initial characters for each word in a string.

11. `ShuffleAndDraw`: These methods offer a way to generate randomized strings.

12. `SplitAndContains`: This method splits a string by a specified splitter and checks if a particular element exists in the split parts.

13. `FormatNumber`: This method formats a number with a specific format by replacing `#` in the format with the number's digits.

14. `StripLastChar` and `RemoveLastCharIs`: These methods remove the last character in a string if it matches a specified character.

15. `ListToString` and `StringToList`: These methods convert lists of strings to a string separated by a specified character, and vice versa.

16. `ReplaceSpecialChars`: This method replaces specified special characters with their corresponding HTML entities.

17. `RemoveCardNumbers`: This method removes card numbers from a string by replacing parts of the numbers with 'X'.

18. `EncodeNonAsciiCharacters` and `DecodeEncodedNonAsciiCharacters`: These methods encode and decode non-ASCII characters in a string.
