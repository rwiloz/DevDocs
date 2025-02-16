```
---
title: "Metaphone Class Documentation"
date: "2023-10-14"
description: "Documentation of the Metaphone class, which implements the Metaphone algorithm for phonetic encoding of strings."
categories: ["Documentation", "Phonetic Encoding"]
tags: ["C#", "Metaphone", "Algorithm"]
draft: false
---

# Metaphone Class

The `Metaphone` class provides functionality to encode strings using the Metaphone algorithm. This algorithm is used to index words by their pronunciation, which allows for phonetic comparisons.

## Namespace

The `Metaphone` class is part of the `G3.Core.Utils.Strings` namespace.

```csharp
namespace G3.Core.Utils.Strings
{
    class Metaphone
    {
        // Class implementation
    }
}
```

## Constants

- **MaxEncodedLength**: Defines the maximum length of the encoded string, set to 6.
- **NullChar**: Represents a null character, used internally for string manipulation.
- **Vowels**: A string containing vowel characters: "AEIOU".

## Fields

- **_text**: A string variable to hold the current text being processed.
- **_pos**: An integer to track the current position within the text.

## Methods

### Encode

Encodes the given text using the Metaphone algorithm.

```csharp
public string Encode(string text)
```

- **Parameters**: 
  - `text`: A `string` representing the text to encode.
- **Returns**: 
  - A `string` representing the phonetic encoding of the input text.

### InitializeText

Initializes the text processing by setting the input text and resetting the position.

```csharp
protected void InitializeText(string text)
```

- **Parameters**: 
  - `text`: A `string` representing the text to initialize.

### EndOfText

Indicates whether the current position is at the end of the text.

```csharp
protected bool EndOfText { get; }
```

- **Returns**: 
  - A `bool` indicating if the end of the text is reached.

### MoveAhead

Moves the current position ahead by a specified number of characters.

```csharp
void MoveAhead(int count = 1)
```

- **Parameters**: 
  - `count`: An `int` representing the number of characters to move ahead.

### Peek

Returns the character at the current or specified position relative to the current position.

```csharp
protected char Peek(int ahead = 0)
```

- **Parameters**: 
  - `ahead`: An `int` indicating the relative position to peek.
- **Returns**: 
  - A `char` representing the character at the specified position, or `NullChar` if out of bounds.

### IsOneOf

Checks if a given character exists within a specified string.

```csharp
protected bool IsOneOf(char c, string chars)
```

- **Parameters**: 
  - `c`: A `char` to find.
  - `chars`: A `string` to search within.
- **Returns**: 
  - A `bool` indicating whether the character is found.

### Normalize

Normalizes a string by removing non-letter characters and converting it to upper case.

```csharp
protected string Normalize(string text)
```

- **Parameters**: 
  - `text`: A `string` to be normalized.
- **Returns**: 
  - A `string` that is the normalized version of the input.

## Usage

To use the `Metaphone` class, create an instance and call the `Encode` method with the text you want to encode:

```csharp
Metaphone metaphone = new Metaphone();
string encodedText = metaphone.Encode("example");
