Here is your code with inline XML summary comments:

```csharp
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/// <summary>
/// Providing soundex-like string phonetic algorithm functions.
/// </summary>
namespace G3.Core.Utils.Strings
{
    /// <summary>
    /// Class for encoding strings using the Metaphone algorithm.
    /// </summary>
    class Metaphone
    {
        // Constants
        protected const int MaxEncodedLength = 6;
        protected const char NullChar = (char)0;
        protected const string Vowels = "AEIOU";

        // For tracking position within current string
        protected string _text;
        protected int _pos;

        /// <summary>
        /// Encodes the given text using the Metaphone algorithm.
        /// </summary>
        /// <param name="text">Text to encode.</param>
        /// <returns>Encoded string.</returns>
        public string Encode(string text)
        {
            // Your internal logic here
        }

        /// <summary>
        /// Initializes the text to be processed.
        /// </summary>
        /// <param name="text">Input text.</param>
        protected void InitializeText(string text)
        {
            _text = text;
            _pos = 0;
        }

        /// <summary>
        /// Checks whether we've reached the end of the text.
        /// </summary>
        protected bool EndOfText
        {
            get { return _pos >= _text.Length; }
        }

        /// <summary>
        /// Moves the current position ahead one character.
        /// </summary>
        void MoveAhead()
        {
            MoveAhead(1);
        }

        /// <summary>
        /// Moves the current position ahead by a specified number of characters.
        /// </summary>
        /// <param name="count">Number of characters to move ahead.</param>
        void MoveAhead(int count)
        {
            _pos = Math.Min(_pos + count, _text.Length);
        }

        /// <summary>
        /// Returns the character at the current position.
        /// </summary>
        /// <returns>Character at current position.</returns>
        protected char Peek()
        {
            return Peek(0);
        }

        /// <summary>
        /// Returns the character at a specified position ahead of the current one.
        /// </summary>
        /// <param name="ahead">Position to look ahead from the current one.</param>
        /// <returns>Character at the specified ahead position.</returns>
        protected char Peek(int ahead)
        {
            int pos = (_pos + ahead);
            if (pos < 0 || pos >= _text.Length)
                return NullChar;
            return _text[pos];
        }

        /// <summary>
        /// Checks if a given character is found within a specific string.
        /// </summary>
        /// <param name="c">Character to find.</param>
        /// <param name="chars">String to search within.</param>
        /// <returns><c>true</c> if the character is found; otherwise, <c>false</c>.</returns>
        protected bool IsOneOf(char c, string chars)
        {
            return (chars.IndexOf(c) != -1);
        }

        /// <summary>
        /// Removes non-alphabetic characters and converts to uppercase.
        /// </summary>
        /// <param name="text">Text to be normalized.</param>
        /// <returns>Normalized text.</returns>
        protected string Normalize(string text)
        {
            StringBuilder builder = new StringBuilder();
            foreach (char c in text)
            {
                if (Char.IsLetter(c))
                    builder.Append(Char.ToUpper(c));
            }
            return builder.ToString();
        }
    }
}
```