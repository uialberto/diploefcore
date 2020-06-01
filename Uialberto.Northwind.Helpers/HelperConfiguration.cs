using Microsoft.Extensions.Configuration;
using System;

namespace Uialberto.Northwind.Helpers
{
    public class HelperConfiguration
    {
        public static AppConfiguration GetAppConfiguration(string configFile = "app.json")
        {
            IConfiguration configuration = new ConfigurationBuilder()
                .AddJsonFile(configFile, optional: false)
                .Build();
            var result = configuration.Get<AppConfiguration>();
            return result;
        }
    }
}
