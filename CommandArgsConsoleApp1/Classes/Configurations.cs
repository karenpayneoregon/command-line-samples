using Microsoft.Extensions.Configuration;

namespace CommandArgsConsoleApp1.Classes;

public class Configurations
{
    public static IConfigurationRoot GetConfigurationRoot(string environment) =>
        new ConfigurationBuilder()
            .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
            .AddJsonFile($"appsettings.{environment}.json",
                optional: true,
                reloadOnChange: true)
            .Build();

    public static List<KeyValuePair<string, string>> GetConfigurationRoot1(string environment) =>
        new ConfigurationBuilder()
            .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
            .AddJsonFile($"appsettings.{environment}.json",
                optional: true,
                reloadOnChange: true)
            .Build().AsEnumerable().ToList();

}