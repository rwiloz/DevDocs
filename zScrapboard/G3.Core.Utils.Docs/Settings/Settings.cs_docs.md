---
title: G3Settings Utility Documentation
date: 2023-10-01
type: docs
description: Documentation for the G3Settings utility class in the G3.Core.Utils.Settings namespace.
---

# G3Settings Utility Documentation

This documentation provides a detailed overview of the `G3Settings` utility within the `G3.Core.Utils.Settings` namespace. The class is designed to facilitate configuration management through the `Microsoft.Extensions.Configuration` package.

## Overview

The `G3Settings` class is a static utility that helps retrieve configuration settings from an application configuration file, likely an `appsettings.json`. This utility uses lazy initialization patterns to ensure thread safety and performance efficiency.

## Namespaces

```csharp
using G3.Core.Utils.DataType;
using Microsoft.Extensions.Configuration;
using System;
using System.ComponentModel;
using System.IO;
using System.Reflection;
using System.Threading;
```

## Class Definition

### G3Settings

The `G3Settings` class is a static class containing methods and properties to access various configuration settings.

#### Fields

- `LazyConfig`: A `Lazy<IConfiguration>` instance to hold the configuration settings. Initialized with thread safety and supports configuration change without restarting the application.

#### Properties

- **BasePath**: Returns the base directory path of the executing assembly.
  
  ```csharp
  public static string BasePath => Path.GetDirectoryName(Assembly.GetEntryAssembly().Location);
  ```

- **ConfigSettings**: Provides access to the loaded configuration.

  ```csharp
  public static IConfiguration ConfigSettings => LazyConfig.Value;
  ```

- **ApiKey**: Retrieves a GUID representing the API key from the configuration.

  ```csharp
  public static Guid? ApiKey
  ```

- **SystemService**: Returns a string value representing the system service name from the configuration.

  ```csharp
  public static string SystemService => ConfigSettings["G3SystemService"];
  ```

- **WebProxy**: Provides the web proxy setting as a string.

  ```csharp
  public static string WebProxy => ConfigSettings["WebProxy"];
  ```

- **WebProxyPort**: Retrieves the web proxy port as an integer.

  ```csharp
  public static int WebProxyPort => ConfigSettings["WebProxyPort"].ToInt32(0);
  ```

- **RunningIsG2**: Returns a boolean value indicating whether the environment setting is present, suggesting it's running in a G2 environment.

  ```csharp
  public static bool RunningIsG2 => ConfigSettings["Environment"] != null;
  ```

#### Methods

- **GetSetting(name, defaultValue)**: Retrieves the value of a specified configuration setting, or returns a default value if the setting is not found or is empty.

  ```csharp
  public static string GetSetting(string name, string defaultValue = null)
  ```

## Usage

The `G3Settings` utility allows developers to configure how an application should behave via key-value pairs defined in an `appsettings.json` or similar configuration files. The utility is structured to automatically reload configurations upon file changes, making it a robust choice for dynamic applications.
