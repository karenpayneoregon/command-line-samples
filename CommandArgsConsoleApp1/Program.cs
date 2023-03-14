﻿using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Configuration.Json;
using System.Reflection;

namespace CommandArgsConsoleApp1;

public class Program
{
    public static void Main(string[] args)
    {
        var switchMappings = new Dictionary<string, string>()
        {
            { "--environment", "environment" },
            { "-e", "environment" },
            { "--username", "username" },
        };

        var builder = new ConfigurationBuilder();
        builder.AddCommandLine(args, switchMappings);

        var config = builder.Build();

        



        var user = config["Username"];
        
        if (config["Environment"] is not null)
        {
            Console.WriteLine($"Hello {user}");
        }

        if (config["Environment"] is null)
        {
            Console.WriteLine("argument not passed or not spelled right");
        }
        else
        {
            if (Enum.TryParse(config["Environment"], true, out Environment environment))
            {
                Console.WriteLine($"Use {environment} environment");
                IConfigurationRoot configuration = Configurations.GetConfigurationRoot(environment.ToString());
                var items = Configurations.GetConfigurationRoot1(environment.ToString());
                //Serilog:SinkOptions:batchPeriod
                //Console.WriteLine(configuration.GetDebugView());

                foreach (var pair in items)
                {
                    //Console.WriteLine($"{pair.Key}  {pair.Value}");
                }

                Console.WriteLine(configuration.GetSection("ConnectionStrings")["LogDatabase"]);
                Console.WriteLine(configuration.GetSection("ConnectionStrings")["DatabaseConnection"]);
                Console.WriteLine(configuration.GetSection("Serilog:SinkOptions")["batchPeriod"]);
                Console.WriteLine(configuration.GetSection("Serilog:ColumnOptions:timeStamp")["convertToUtc"]);

                Console.WriteLine();

                var items1 = configuration.GetSection("Serilog:SinkOptions").GetChildren();

                foreach (var section in items1)
                {
                    Console.WriteLine($"{section.Key, -25}{section.Value}");
                }
            }
            else
            {
                Console.WriteLine("Unknown environment");
            }
        }


        Console.ReadLine();
    }
}

public enum Environment
{
    Development,
    Staging,
    Production,
    Article
}

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