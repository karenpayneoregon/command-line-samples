namespace CommandArgsConsoleApp2.Classes;
internal class CommandOperations
{
    public static void MainCommand(string environment, string userNameOption, bool logOption)
    {
        
        if (Enum.TryParse(environment, true, out Environment currentEnvironment))
        {
            Console.WriteLine($"--environment = {currentEnvironment}");
        }
        else
        {
            AnsiConsole.MarkupLine($"--environment = {currentEnvironment} [red]is not valid[/]");
        }

        if (userNameOption is not null)
        {
            Console.WriteLine($"--username = {userNameOption}");
        }

        if (logOption)
        {
            SetupLogging.Initialize(currentEnvironment);
            LogOperations.CreateSomeLogs();
        }
    }
}
