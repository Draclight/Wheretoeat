using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WhereToEat.Data.Helper
{
    public static class EnvHelper
    {
        public static Env GetEnvironment()
        {
            var environmentName = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");

            ArgumentNullException.ThrowIfNull(environmentName);
            return (Env)Enum.Parse(typeof(Env), environmentName);
        }
    }
}
