# CryptoRandom Class

This class is derived from the `RandomNumberGenerator` class. It serves as a cryptographic random number generator that can be used to generate random data.

## Properties

- **r** - A static `RandomNumberGenerator` object.

## Constructor

- **CryptoRandom()** - Creates and initializes an instance of the class. Random number generation starts from a random state.

## Methods

- **GetBytes(byte[] buffer)** - Fills the elements of a specified array of bytes with random numbers (`buffer` - An array of bytes to contain random numbers).

- **NextDouble()** - Returns a random number between 0.0 and 1.0.

- **Next(int minValue, int maxValue)** - Returns a random number within the specified range (`minValue` - The inclusive lower bound of the random number returned, `maxValue` - The exclusive upper bound of the random number returned. `maxValue` must be greater than or equal to `minValue`).

- **Next()** - Returns a nonnegative random number.

- **Next(int maxValue)** - Returns a nonnegative random number less than the specified maximum (`maxValue` - The inclusive upper bound of the random number returned. `maxValue` must be greater than or equal 0).
