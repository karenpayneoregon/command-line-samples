using Microsoft.Extensions.Configuration;

namespace CommandArgsConsoleApp1.Classes;
public class Configurations_1
{
    public static IConfigurationRoot GetConfigurationRoot(Environment environment) =>
        new ConfigurationBuilder()
            .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
            .AddJsonFile($"appsettings.{environment}.json")
            .Build();
}
