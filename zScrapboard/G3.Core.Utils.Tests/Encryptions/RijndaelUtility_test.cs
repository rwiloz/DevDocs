Sure, below are some sample test cases for the RijndaelUtility class:

```CSharp
using System;
using G3.Core.Utils.Encryptions;
using Xunit;

namespace G3.Core.Tests.Utils.Encryptions
{
	public class RijndaelUtilityTests
	{
		[Fact]
		public void Encrypt_And_Decrypt_Should_Be_Idempotent()
		{
			// Arrange
			string textToEncrypt = "Hello Rijndael";
			string password = "Password1234";
			string salt = "Salt1234";

			// Act
			string encryptedText = RijndaelUtility.Encrypt(textToEncrypt, password, salt);
			string decryptedText = RijndaelUtility.Decrypt(encryptedText, password, salt);

			// Assert
			Assert.Equal(textToEncrypt, decryptedText);
		}

		[Fact]
		public void Decrypt_Invalid_Encrypted_Text_Should_Return_Original_Text()
		{
			// Arrange
			string invalidEncryptedText = "InvalidText";
			string password = "Password1234";
			string salt = "Salt1234";

			// Act
			string decryptedText = RijndaelUtility.Decrypt(invalidEncryptedText, password, salt);

			// Assert
			Assert.Equal(invalidEncryptedText, decryptedText);
		}

		[Fact]
		public void Encrypt_With_No_Salt_Should_Generate_Valid_Encryption()
		{
			// Arrange
			string textToEncrypt = "Hello Rijndael";
			string password = "Password1234";

			// Act
			string encryptedText = RijndaelUtility.Encrypt(textToEncrypt, password);
			string decryptedText = RijndaelUtility.Decrypt(encryptedText, password);

			// Assert
			Assert.Equal(textToEncrypt, decryptedText);
		}
	}
}
```

These tests consider the idempotency of the encryption cycle (encryption followed by decryption should return the original message), check whether the function properly handles invalid encrypted input and test the encryption with non-specified salt value.