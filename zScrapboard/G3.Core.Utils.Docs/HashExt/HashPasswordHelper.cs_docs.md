# HashPasswordHelper Class

This class applies hashing to passwords. It works within the "G3.Core.Utils.HashExt" namespace and is presented as a static public class.

## Methods

### HashPassWord Method

This method accepts a `string` password as an input parameter and hashes it implementing the PBKDF2 function. It returns the hashed password in `string` format. An important condition is the inputted password length should be equal to or greater than six, otherwise, it returns null. The process of hashing involves salt generation based on the squared length of the password, and execution of the `KeyDerivation.Pbkdf2` function.

### HashPasswordSentinel Method

Designed particularly for migrated users of G2Oss, this method gets keys from `Sentinel.ClientSystem` and uses these keys to hash users' passwords. The `saltGuid` in this method is the user's unique Id. This method returns the hashed password in `string` format.

# SentinelEncryptionRequest Class

This is an internal class whose instance holds information about what needs to be encrypted including value, initial vector(`IV`), and key. 

# SentinelCryptography Class

This is an internal static class which includes numerous private methods to adjust byte arrays, generate an initial vector (`IV`), perform encryption (`Encrypt`), hash requests (`SentinelHash`) and create password hashs (`CreatePasswordHash`). It also includes a public method to hash passwords (`SentinelPasswordHash`).

## SentinelPasswordHash Method

This method is used within the `HashPasswordSentinel` method of the `HashPasswordHelper` class to hash passwords. It takes Guid user id, `string` password, and `string` key, uses them to calculate hash and returns it in `string` format.