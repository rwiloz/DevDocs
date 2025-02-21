Sure, your code already contains XML summary comments. They are placed just above the methods doing the right job. They begin with `///<summary>` and close with `</summary>`. And you are also documenting your function's parameters by using `<param name= “parameterName”> description about parameter </param>`. 

This is the correctly doc version of the comments you provided:

```C#
using System;
using System.Security.Cryptography;

namespace G3.Core.Utils.Encryptions
{
    /// <summary>
    /// Represents a pseudo-random number generator, a device that produces random data.
    /// </summary>
    public class CryptoRandom : RandomNumberGenerator
    {
        private static RandomNumberGenerator r;

        /// <summary>
        /// Creates an instance of the default implementation of a cryptographic random number generator that can be used to generate random data.
        /// </summary>
        public CryptoRandom()
        {
            r = RandomNumberGenerator.Create();
            var b = new byte[10];
            r.GetBytes(b);
        }

        /// <summary>
        /// Fills the elements of a specified array of bytes with random numbers.
        /// </summary>
        /// <param name=”buffer”>An array of bytes to contain random numbers.</param>
        public override void GetBytes(byte[] buffer)
        {
            r.GetBytes(buffer);
        }

        /// <summary>
        /// Returns a random number between 0.0 and 1.0.
        /// </summary>
        public double NextDouble()
        {
            byte[] b = new byte[4];
            r.GetBytes(b);
            return (double) BitConverter.ToUInt32(b, 0) / UInt32.MaxValue;
        }

        /// <summary>
        /// Returns a random number within the specified range.
        /// </summary>
        /// <param name=”minValue”>The inclusive lower bound of the random number returned.</param>
        /// <param name=”maxValue”>The exclusive upper bound of the random number returned. maxValue must be greater than or equal to minValue.</param>
        public int Next(int minValue, int maxValue)
        {
            return (int) Math.Floor(NextDouble() * (maxValue - minValue)) + minValue;
        }

        /// <summary>
        /// Returns a nonnegative random number.
        /// </summary>
        public int Next()
        {
            return Next(0, Int32.MaxValue);
        }

        /// <summary>
        /// Returns a nonnegative random number less than the specified maximum.
        /// </summary>
        /// <param name=”maxValue”>The inclusive upper bound of the random number returned. maxValue must be greater than or equal 0.</param>
        public int Next(int maxValue)
        {
            return Next(0, maxValue);
        }
    }
}
```