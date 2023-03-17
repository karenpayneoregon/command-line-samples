using CommandArgsConsoleApp1.Classes;
using Microsoft.Extensions.Configuration;

namespace CommandArgsConsoleApp1;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = new ConfigurationBuilder();
        builder.AddCommandLine(args, SwitchOptions.Mappings);

        IConfigurationRoot config = builder.Build();

        SetupLogging.Initialize(config);

        LogOperations.CreateSomeLogs();

        MainOperations.ViewEnvironment(config);
        MainOperations.CheckUserName(config);

        Console.ReadLine();
    }
}