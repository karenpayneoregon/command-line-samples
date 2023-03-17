using Microsoft.Extensions.Configuration;
using Spectre.Console;

namespace CommandArgsConsoleApp1.Classes;
internal class MainOperations
{
    public static void CheckUserName(IConfigurationRoot config)
    {
        AnsiConsole.MarkupLine("[cyan]Checking user name from command line[/]");
        var user = config["username"];

        if (config["username"] is not null)
        {
            Console.WriteLine($"Hello {user}");
        }
        else
        {
            Console.WriteLine("User name not provided");
        }
    }

    /// <summary>
    /// Demo for reading from an environment appsettings file
    /// </summary>
    /// <param name="config">IConfigurationRoot</param>
    public static void ViewEnvironment(IConfigurationRoot config)
    {
        AnsiConsole.MarkupLine("[cyan]Viewing environment items from appsettings[/]");

        if (config["Environment"] is not null)
        {
            if (Enum.TryParse(config["Environment"], true, out Environment environment))
            {
                Console.WriteLine($"Use {environment} environment");

                var items = Configurations.GetConfigurationRoot1(environment.ToString());

                Console.WriteLine(new string('-', 50));
                
                foreach (var pair in items)
                {
                    Console.WriteLine($"{pair.Key}  {pair.Value}");
                }

                Console.WriteLine(new string('-', 50));

                Console.WriteLine(config.GetSection("ConnectionStrings")["LogDatabase"]);
                Console.WriteLine(config.GetSection("ConnectionStrings")["DatabaseConnection"]);
                Console.WriteLine(config.GetSection("Serilog:SinkOptions")["batchPeriod"]);
                Console.WriteLine(config.GetSection("Serilog:ColumnOptions:timeStamp")["convertToUtc"]);

                Console.WriteLine();

                var sinkOptions = config.GetSection("Serilog:SinkOptions").GetChildren();

                foreach (var section in sinkOptions)
                {
                    Console.WriteLine($"{section.Key,-25}{section.Value}");
                }
            }
        }
        else
        {
            Console.WriteLine("argument not passed or not spelled right");
        }
    }
}
