/// <summary>
/// Provides a way to access and manage the application's configuration settings.
/// </summary>
public static class G3Settings
{
    /// <summary>
    /// A lazy-loaded configuration object.
    /// </summary>
    private static Lazy<IConfiguration> LazyConfig =
       new Lazy<IConfiguration>(
           () =>
           {
               var builder = new ConfigurationBuilder()
               .SetBasePath(BasePath)
               .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);
               return builder.Build();

           }, LazyThreadSafetyMode.ExecutionAndPublication);

    /// <summary>
    /// Gets the base path of the application.
    /// </summary>
    public static string BasePath => Path.GetDirectoryName(Assembly.GetEntryAssembly().Location);
    
    /// <summary>
    /// Gets the configuration settings of the application.
    /// </summary>
    public static IConfiguration ConfigSettings => LazyConfig.Value;

    /// <summary>
    /// Returns the setting value as a string for the specified setting name.
    /// </summary>
    /// <param name="name">The setting name.</param>
    /// <param name="defaultValue">The default value if the setting does not exist or is empty.</param>
    /// <returns>The setting value.</returns>
    public static string GetSetting(string name, string defaultValue = null)
    {
        var value = ConfigSettings[name];
        return string.IsNullOrWhiteSpace(value) ? defaultValue : value;
    }

    /// <summary>
    /// Gets the API key from the settings. 
    /// </summary>
    public static Guid? ApiKey
    {
        get
        {
            var guidStr = ConfigSettings["G3ApiKey"];
            if (Guid.TryParse(guidStr, out var g)) return g;
            return null;
        }
    }

    /// <summary>
    /// Gets the G3 System Service setting.
    /// </summary>
    public static string SystemService => ConfigSettings["G3SystemService"];

    /// <summary>
    /// Gets the Web Proxy setting.
    /// </summary>
    public static string WebProxy => ConfigSettings["WebProxy"];

    /// <summary>
    /// Gets the Web Proxy Port setting.
    /// </summary>    
    public static int WebProxyPort => ConfigSettings["WebProxyPort"].ToInt32(0);

    /// <summary>
    /// Checks if the application is running in G2 environment.
    /// </summary>  
    public static bool RunningIsG2 => ConfigSettings["Environment"] != null;
}