using Microsoft.Extensions.Configuration;

namespace CommandArgsConsoleApp1.Classes;

/// <summary>
/// This was the original version of this project in Program
/// </summary>
internal class Class1
{
    private static void Example1(string[] args)
    {
        /*
         * Define short and long
         */
        var switchMappings = new Dictionary<string, string>()
        {
            { "-username", "username" },
            { "--username", "username" },
            { "-password", "password" },
            { "--password", "password" }
        };

        var builder = new ConfigurationBuilder();
        builder.AddCommandLine(args, switchMappings);

        var config = builder.Build();

        Console.WriteLine($"user name: '{config["Username"]}'");
        Console.WriteLine($"password: '{config["Password"]}'");
    }
}
