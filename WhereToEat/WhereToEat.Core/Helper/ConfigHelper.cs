using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WhereToEat.Data.Helper
{
    public class ConfigHelper
    {
        public static IConfigurationRoot Load(Env? env = null)
        {
            var configurationBuilder = new ConfigurationBuilder();
            AddJsonFiles(configurationBuilder, env);
            return configurationBuilder.Build();
        }

        public static void AddJsonFiles(IConfigurationBuilder configurationBuilder, Env? env = null)
        {
            configurationBuilder.AddJsonFile($"Config/appsettings.json");
                                //.AddJsonFile($"Config/appsettings.{env}.json");
        }
    }

    public enum Env
    {
        dev,
        tests,
        prod
    }
}
