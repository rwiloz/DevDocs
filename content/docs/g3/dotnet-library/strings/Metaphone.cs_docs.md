---
title: "Metaphone ??"
description: ""
summary: ""
date: 2023-09-07T16:12:37+02:00
lastmod: 2023-09-07T16:12:37+02:00
draft: false
weight: 900
toc: true
sidebar:
  collapsed: true
seo:
  title: "" # custom title (optional)
  description: "" # custom description (recommended)
  canonical: "" # custom canonical URL (optional)
  robots: "" # custom robot tags (optional)
---

# Class: Metaphone

The `Metaphone` class is a part of the `G3.Core.Utils.Strings` namespace. The main role of this class is to provide a phonetic algorithm for indexing of words. The algorithm encodes English language words by their English pronunciation.

## Constants

- `MaxEncodedLength`: Maximum length of the encoded string.

- `NullChar`: Null character.

- `Vowels`: String containing all vowel characters.


## Fields

- `_text`: Field for keeping track of the string to be encoded.

- `_pos`: Field for keeping track of the current position within the string being encoded.


## Methods

### `Encode(string text)`

This method accepts a string as input and processes the string text such that each word is represented by a string that is phonetically similar, using the Metaphone algorithm.

This method handles special cases for some prefixes, ignores duplicates except for 'CC' and has special conditions for handling each alphabet.

### `InitializeText(string text)`

This protected method is used to set the `_text` private attribute to a normalized version of the input text and resets the `_pos` private attribute to 0.

### `EndOfText()`

This protected method is a getter that checks if the current position `_pos` is equal to or exceeds the length of the `_text`.

### `MoveAhead()`

This is an overload of the `MoveAhead(int count)` method and works by moving the current `_pos` ahead by one character.

### `MoveAhead(int count)`

This method moves the current `_pos` ahead by the specified number of characters.

### `Peek()`

This is an overload of the `Peek(int ahead)` method. It returns the character at the current position `_pos`.

### `Peek(int ahead)`

This method returns the character at the specified position ahead of the current `_pos`.

### `IsOneOf(char c, string chars)`

This method checks if the specified character `c` is in the given string `chars`.

### `Normalize(string text)`

This method accepts a string as an argument, removes non-letter characters from the string and converts it to uppercase.