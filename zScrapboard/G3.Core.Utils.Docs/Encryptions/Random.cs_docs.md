+++
title = "CryptoRandom Class"
description = "Documentation for the CryptoRandom class used to generate cryptographic pseudo-random numbers."
date = "2023-10-15"
categories = ["development", "cryptography"]
tags = ["C#", "random number generation", "cryptography"]
+++

# CryptoRandom Class

The `CryptoRandom` class is a part of the `G3.Core.Utils.Encryptions` namespace. It extends the `RandomNumberGenerator` class to provide cryptographic pseudo-random number generation functionality.

## Overview

The `CryptoRandom` class is designed to generate random numbers using cryptographic algorithms. It provides methods to fill byte arrays with random data and to generate random numbers within specified constraints.

## Namespace

```csharp
G3.Core.Utils.Encryptions
```

## Inheritance

- Inherits from `System.Security.Cryptography.RandomNumberGenerator`.

## Constructor

### `CryptoRandom()`

Creates an instance of the default implementation of a cryptographic random number generator. It initializes a new instance of the `CryptoRandom` class.

## Methods

### `GetBytes(byte[] buffer)`

Fills the elements of a specified array of bytes with random numbers.

- **Parameters:**
  - `buffer`: An array of bytes to contain random numbers.

### `NextDouble()`

Returns a random number between 0.0 and 1.0.

- **Returns:**
  - A `double` that is a random number greater than or equal to 0.0 and less than 1.0.

### `Next(int minValue, int maxValue)`

Returns a random number within the specified range.

- **Parameters:**
  - `minValue`: The inclusive lower bound of the random number returned.
  - `maxValue`: The exclusive upper bound of the random number returned. `maxValue` must be greater than or equal to `minValue`.

- **Returns:**
  - An `int` that is a random number greater than or equal to `minValue` and less than `maxValue`.

### `Next()`

Returns a nonnegative random number.

- **Returns:**
  - An `int` that is a nonnegative random number.

### `Next(int maxValue)`

Returns a nonnegative random number less than the specified maximum.

- **Parameters:**
  - `maxValue`: The inclusive upper bound of the random number returned. `maxValue` must be greater than or equal to 0.

- **Returns:**
  - An `int` that is a nonnegative random number less than `maxValue`.

## Usage Example

Here is a basic example of how to use the `CryptoRandom` class:

```csharp
using G3.Core.Utils.Encryptions;

class Program
{
    static void Main()
    {
        CryptoRandom random = new CryptoRandom();
        
        // Get random bytes
        byte[] bytes = new byte[16];
        random.GetBytes(bytes);

        // Get random double
        double randomDouble = random.NextDouble();

        // Get random integer between 1 and 100
        int randomInt = random.Next(1, 100);

        // Get nonnegative random integer
        int randomInt2 = random.Next();
    }
}
```

### Remarks

The `CryptoRandom` class leverages cryptographic algorithms to provide high-quality randomness suitable for security-sensitive applications. It is a reliable choice when a standard pseudo-random number generator (`Random`) does not suffice, such as in cryptographic applications.