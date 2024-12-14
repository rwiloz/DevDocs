# G3Settings Class Documentation

This class `G3Settings` is a public static class within the namespace `G3.Core.Utils.Settings`. 

## Class Members

### Private Members

- `Lazy<IConfiguration> LazyConfig`: A lazily loaded configuration object. This gets initialized only when it's required. A new IConfiguration object is built from the base path and the 'appsettings.json' file.

### Public Members

- `string BasePath`: A public getter that retrieves the directory name from the assembly that launched the current process. This member might be made private later as hinted in the provided code.

- `IConfiguration ConfigSettings`: Configuration settings loaded lazily from the 'appsettings.json' file.

- `string GetSetting(string name, string defaultValue = null)`: Returns the configuration setting for the passed `name`. If no setting is found, it returns defaultValue, which by default is `null`.

- `Guid? ApiKey`: Tries to parse the 'G3ApiKey' config setting as a GUID. If successful, it returns the GUID, otherwise null.

- `string SystemService`: Retrieves the configuration setting for 'G3SystemService'.

- `string WebProxy`: Retrieves the configuration setting for 'WebProxy'.

- `int WebProxyPort`: Retrieves the 'WebProxyPort' configuration setting, attempts to convert it into an integer. If it fails, it defaults to `0`.

- `bool RunningIsG2`: Returns a boolean depending on whether 'Environment' configuration setting exists or not. If the setting exists it returns `true` else `false`.

## Description

The functionality of this public static class `G3Settings` is to load and provide access to specific configuration settings from a 'appsettings.json' file in the project. The unique feature about this class is the use of `Lazy<T>` implementation to build and store the configuration. This ensures that the configuration is not built until it is needed. The class also provides a mechanism to retrieve the settings with default values and type conversions.