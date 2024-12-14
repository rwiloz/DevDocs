Here are some test cases for the given code:

1. Testing IsValidNmi:

- For a valid NMI input, it should return true:

```csharp
Assert.IsTrue(CheckDigitsUtils.IsValidNmi("ABCDEFGHIJK")); // assuming "ABCDEFGHIJK" is a valid NMI
```

- For an invalid NMI input, it should return false:

```csharp
Assert.IsFalse(CheckDigitsUtils.IsValidNmi("ABCDEFGHIJ")); // string of length 10
Assert.IsFalse(CheckDigitsUtils.IsValidNmi(null)); // null string
```

2. Testing NmiCheckDigit:

- It should correctly returns the calculated check digit:

```csharp
Assert.AreEqual("K", CheckDigitsUtils.NmiCheckDigit("ABCDEFGHIJ")); // assuming "K" is the check digit for "ABCDEFGHIJ"
```

3. Testing NmiAddCheckDigit:

- It should correctly return the NMI string with the added check digit:

```csharp
Assert.AreEqual("ABCDEFGHIJK", CheckDigitsUtils.NmiAddCheckDigit("ABCDEFGHIJ")); // assuming "ABCDEFGHIJK" is the valid NMI with the check digit
```

4. Testing IsValidAbn:

- For a valid ABN, it should return true:

```csharp
Assert.IsTrue(CheckDigitsUtils.IsValidAbn("12345678951")); // assuming "12345678951" is a valid ABN
```

- For an invalid ABN, it should return false:

```csharp
Assert.IsFalse(CheckDigitsUtils.IsValidAbn("123456789")); // string of length 9
```

5. Testing IsValidAcn:

- For a valid ACN, it should return true:

```csharp
Assert.IsTrue(CheckDigitsUtils.IsValidAcn("123456789")); // assuming "123456789" is a valid ACN
```

- For an invalid ACN, it should return false:

```csharp
Assert.IsFalse(CheckDigitsUtils.IsValidAcn("12345678")); // string of length 8
```

6. Testing Mod97CheckDigits:

- It should correctly calculate Mod97 Check Digits as expected:

```csharp
Assert.AreEqual("XX", CheckDigitsUtils.Mod97CheckDigits("1234567890")); // replace "XX" with correct Mod97 check digits for the data "1234567890"
```

7. Testing AddMod97:

- It should return string added with Mod97 Check Digits:

```csharp
Assert.AreEqual("1234567890XX", CheckDigitsUtils.AddMod97("1234567890")); // replace "XX" with correct Mod97 check digits for the data "1234567890"
```

Note: The above tests are based on assumptions since there is no clearly defined logic/rules for validating and calculating the check digits. Please replace the test data with the correct ones based on your context.