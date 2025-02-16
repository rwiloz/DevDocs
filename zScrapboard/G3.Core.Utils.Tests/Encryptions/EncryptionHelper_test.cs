You can create test cases following the structure:

```csharp
using G3.Core.Utils.Encryptions;
using NUnit.Framework;

[TestFixture]
public class EncryptionHelperTests
{
    [Test]
    public void RandomNumber_ShouldReturn_NumberLessThanMax()
    {
        var randomNumber = EncryptionHelper.RandomNumber(10);
        Assert.That(randomNumber, Is.LessThan(10));
    }

    [Test]
    public void DecodePassword_ShouldReturn_DecodedPassword()
    {
        var pass = "password";
        var encodedPass = pass.EncodePassword();
        var decodedPass = encodedPass.DecodePassword();
        
        Assert.AreEqual(pass, decodedPass);
    }

    [Test]
    public void EncodePassword_ShouldReturn_EncodedPassword()
    {
        var pass = "password";
        var encodedPass = pass.EncodePassword();
        
        Assert.AreNotEqual(encodedPass, pass);
    }

    [Test]
    [Obsolete("This test is of an obsolete method")]
    public void EncryptPassword_ShouldReturn_EncryptedPassword()
    {
        var pass = "password";
        var key = "Key";
        var encryptedPass = pass.EncryptPassword(key);
        
        Assert.AreNotEqual(encryptedPass, pass);
    }

    [Test]
    [Obsolete("This test is of an obsolete method")]
    public void DecryptPassword_ShouldReturn_DecryptedPassword()
    {
        var pass = "password";
        var key = "Key";
        var encryptedPass = pass.EncryptPassword(key);
        var decryptedPass = encryptedPass.DecryptPassword(key);

        Assert.AreEqual(decryptedPass, pass);
    }

    [Test]
    public void RandomKey_ShouldReturn_RandomKeyOfSpecifiedLength()
    {
        var keyLength = 10;
        var key = EncryptionHelper.RandomKey(keyLength);
        
        Assert.That(key.Length, Is.EqualTo(keyLength));
    }

    // repeat similarly for other methods in the EncryptionHelper class
}
```
Please note, depending on how the `EncodePassword()`, `DecodePassword()`, `EncryptPassword()`, and `DecryptPassword()` method are implemented, these tests might need adjustment to actually test the correct functionality. These tests do not verify that the password was actually encoded or encrypted correctly, but rather just that the output differs from the original password (which could also be true in error scenarios). To improve these tests, you would need to know the expected outcome for given inputs.