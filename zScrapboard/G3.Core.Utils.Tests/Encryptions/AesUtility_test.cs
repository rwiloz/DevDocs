Here are some simple test cases:

```csharp
using Xunit;
using G3.Core.Utils.Encryptions;

public class AesUtilityTests
{
    [Fact]
    public void TestEncryptionDecryption()
    {
        string password = "TestPassword";
        string salt = "TestSalt";
        string textToEncrypt = "Hello, World!";
        
        // Encrypt text
        string encryptedText = textToEncrypt.EncryptAes(password, salt);
        Assert.NotNull(encryptedText);
        Assert.NotEqual(textToEncrypt, encryptedText);
        
        // Decrypt encrypted text
        string decryptedText = encryptedText.DecryptAes(password, salt);
        Assert.NotNull(decryptedText);
        Assert.Equal(textToEncrypt, decryptedText);
    }

    [Fact]
    public void TestEncryptionDecryptionUtf8()
    {
        string password = "TestPassword";
        string salt = "TestSalt";
        string textToEncrypt = "Hello, World!";
        
        // Encrypt text with UTF8
        string encryptedText = textToEncrypt.EncryptAesUtf8(password, salt);
        Assert.NotNull(encryptedText);
        Assert.NotEqual(textToEncrypt, encryptedText);
        
        // Decrypt encrypted text with UTF8
        string decryptedText = encryptedText.DecryptAesUtf8(password, salt);
        Assert.NotNull(decryptedText);
        Assert.Equal(textToEncrypt, decryptedText);
    }
}
```

These two test cases cover the basic paths of the encryption and decryption methods. One thing to take into account is that the edge cases are not covered. However, these should be added as necessary based on the application's requirements and specifications. For example, testing with empty strings, null values, invalid encodings, large strings, etc.