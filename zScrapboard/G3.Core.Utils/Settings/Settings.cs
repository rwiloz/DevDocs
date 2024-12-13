//using G3.Core.Utils.DataType;
//using Microsoft.Extensions.Configuration;
//using System;
//using System.ComponentModel;
//using System.IO;
//using System.Reflection;
//using System.Threading;

//namespace G3.Core.Utils.Settings
//{
//    public static class G3Settings
//    {

//        private static Lazy<IConfiguration> LazyConfig =
//           new Lazy<IConfiguration>(
//               () =>
//               {
//                   var builder = new ConfigurationBuilder()
//                   .SetBasePath(BasePath)
//                   .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);
//                   return builder.Build();

//               }, LazyThreadSafetyMode.ExecutionAndPublication);



//        //todo: change this back to private. only make this public for debugging
//        public static string BasePath => Path.GetDirectoryName(Assembly.GetEntryAssembly().Location);
//        public static IConfiguration ConfigSettings => LazyConfig.Value;

//        public static string GetSetting(string name, string defaultValue = null)
//        {
//            var value = ConfigSettings[name];
//            return string.IsNullOrWhiteSpace(value) ? defaultValue : value;
//        }

//        public static Guid? ApiKey
//        {
//            get
//            {
//                var guidStr = ConfigSettings["G3ApiKey"];
//                if (Guid.TryParse(guidStr, out var g)) return g;
//                return null;
//            }
//        }

//        public static string SystemService => ConfigSettings["G3SystemService"];

//        public static string WebProxy => ConfigSettings["WebProxy"];

//        public static int WebProxyPort => ConfigSettings["WebProxyPort"].ToInt32(0);

//        public static bool RunningIsG2 => ConfigSettings["Environment"] != null;

//    }
//}
