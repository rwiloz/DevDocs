# FormatExt Class

The `FormatExt` class is a utility class contained within the `G3.Core.Utils.Format` namespace. It contains a set of methods utilized for data validation, particularly phone numbers and email addresses.

## Fields
- **AULandlinePhoneRegEx**: Regular expression string for validating phone numbers specific to Australia.
- **AUMobileRegEx**: Regular expression string for validating mobile numbers specific to Australia.
- **USPhoneRegex**: Regular expression string for validating phone numbers specific to the United States.

## Methods

- **IsValidBsb**: This extension method checks if a given string represents a valid Bsb number. It takes in the value to be checked and an optional boolean parameter that determines whether to include a hyphen in the format. The method returns true if the value matches the format, else it returns false.

- **IsValidEmail**: This extension method checks if a given string represents a valid email address. It returns true if the value matches the regular expression for an email, else it returns false.

- **IsValidMobile**: This extension method checks if a given string represents a valid mobile number. The validation uses different regular expressions based on the cultural settings. It returns true if the value matches the format, else it returns false.

- **IsValidPhone**: This extension method checks if a given string represents a valid phone number based on cultural settings. It checks both for landline and mobile numbers. It returns true if the value matches the regular expression, else false.

- **IsValidUSPhone**: This method checks if a given string represents a valid US phone number. It returns true if the value matches the format, else it returns false.