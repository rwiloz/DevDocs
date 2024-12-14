Sure, here are some test cases that you may use for testing the functionality of your G3Settings class.

Note that you may need to adjust these tests based on the specifics of your testing environment:

```csharp
using Xunit;
using System;
using Moq;
using Microsoft.Extensions.Configuration;
using G3.Core.Utils.Settings;

public class G3SettingsTests
{
    private Mock<IConfiguration> _mockConfig = new Mock<IConfiguration>();
    
    [Fact]
    public void GetSetting_ReturnValue_IfConfigContainsValue()
    {
        _mockConfig.Setup(x => x["Setting"]).Returns("SomeValue");
        G3Settings.ConfigSettings = _mockConfig.Object;
        Assert.Equal("SomeValue", G3Settings.GetSetting("Setting"));
    }
    
    [Fact]
    public void GetSetting_ReturnDefaultValue_IfConfigDoesNotContainValue()
    {
        _mockConfig.Setup(x => x["Setting"]).Returns((string)null);
        G3Settings.ConfigSettings = _mockConfig.Object;
        Assert.Equal("DefaultValue", G3Settings.GetSetting("Setting", "DefaultValue"));
    }
    
    [Fact]
    public void GetSetting_ReturnNull_IfConfigDoesNotContainValueAndDefaultIsNull()
    {
        _mockConfig.Setup(x => x["Setting"]).Returns((string)null);
        G3Settings.ConfigSettings = _mockConfig.Object;
        Assert.Null(G3Settings.GetSetting("Setting"));
    }

    [Fact]
    public void ApiKey_ReturnsGuid_IfConfigContainsGuidValue()
    {
        var guid = Guid.NewGuid();
        _mockConfig.Setup(x => x["G3ApiKey"]).Returns(guid.ToString());
        G3Settings.ConfigSettings = _mockConfig.Object;
        Assert.Equal(guid, G3Settings.ApiKey);
    }
    
    [Fact]
    public void ApiKey_ReturnsNull_IfConfigDoesNotContainValidGuidValue()
    {
        _mockConfig.Setup(x => x["G3ApiKey"]).Returns("InvalidGuidValue");
        G3Settings.ConfigSettings = _mockConfig.Object;
        Assert.Null(G3Settings.ApiKey);
    }
    
    // Additional tests for G3SystemService, WebProxy, WebProxyPort, RunningIsG2 would be similar
}
```

I've assumed there's a way to inject/mock `ConfigSettings`, so this might look a bit different based on your actual dependency management. Nonetheless, this should cover tests that validate if settings return proper values based on whether the value exists and their expected default values. 

I would also recommend adding negative testing scenarios such as trying to access a setting that doesn't exist or passing in null or invalid values.