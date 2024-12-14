# HashHelper Class

This class is located in the G3.Core.Utils.HashExt namespace and is a static helper class for hashing and encoding operations. It involves SHA256, and SHA384 hashing algorithms, moreover, it uses both the UTF8 and UTF32 encoding. 

## Methods

### ByteArrayToHexString(byte[] ba)
This method takes byte array as an argument, and converts it into a hexadecimal string. It sequentially analyzes every byte in the byte array and appends its hexadecimal value to the resulting string. 

### G3HashSha256Utf8(this string data)
This extension method on the string type creates a SHA256 hash from the input string. The input string is expected to be in the UTF8 encoding format. 

### G3HashSha256Utf32(this string data)
This extension method is very similar to the previous method. The difference is that this method expects the input data in UTF32 encoding format.

### Sha384IntegrityHash(this string rawData)
This is an extension method on the string type, which creates a SHA384 hash of the input string. It uses UTF8 encoding for the input raw data.

### Sha384IntegrityHash(this byte[] rawData)
The method works almost the same as the previous method but it takes raw byte array as an argument instead of a string. It's an extension method on the byte array type.

### G3Hash(this byte[] data)
This extension method on the byte array type creates the SHA256 hash from the input byte array and returns the hexadecimal string representation of the hash.