using System.IO;
using Microsoft.Extensions.Configuration;

namespace ApiBackend.Infra.CrossCutting.IoC 
{
    public static class Configuration {
        public static IConfiguration GetConfiguration () {
            return new ConfigurationBuilder()
                .SetBasePath (Directory.GetCurrentDirectory ())
                .AddJsonFile ("appsettings.json", optional : true, reloadOnChange : true)
                .AddJsonFile ("AWS_REGION", optional : true, reloadOnChange : true)
                .AddEnvironmentVariables ()
                .Build ();
        }

    }
}