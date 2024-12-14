# StringTitle Class

The `StringTitle` class belongs to the namespace `G3.Core.Utils.Strings`. It contains a method called `TitleCase`.

**Namespace**: `G3.Core.Utils.Strings`  
**Class**: `StringTitle`  

## Public Methods

### TitleCase (string value) : string

This is an extension method for the string class that applies a title case convention to a string input.

This method initially processes the input string by converting each character individually based on the status of `cap` boolean. This signifies whether the character should be converted to uppercase (`true`) or left as is (`false`). 

The initial value of `cap` is `true`, to ensure the first letter of the string gets capitalized. As the method iterates through the characters in the string, the `cap` boolean is updated depending on several conditions:
- It's updated to `true` if the character is a whitespace which indicate a start of a new word.
- If the previous 2 characters were "Mc" or previous 3 were "Mac", as in names like "McDonald" or "MacDonald", `cap` is set to `true` to handle this special casing in English language.
- It's updated to `true` upon encountering certain special characters like `(`, `-`, `` `, `&`, `"`, `'`, `.`. This is done to handle special formats like abbreviations, quotations, parenthesised content etc.
- `cap` is also set to `true` if the last character was a number between 0 and 9, again for special formatting cases in string.

After processing all characters, several additional string formatting steps are taken:
- A space is appended at the end of the string.
- Apostrophe followed immediately by 'S' and a space like "'S " is replaced with lower-case 's' like "'s ".
- Backtick followed immediately by 'S' and a space like "`S " is replaced with "'s ".

Finally, any leading or trailing whitespace characters are removed, and the title-cased string is returned.

**Parameters**:
 - `value`: The string to be title-cased.

**Return**:
 - Returns the input string in title case.

**Notes**:
- If the input string is `null`, the function returns `null`.
- The function is case-insensitive and treats all input as lower case.