namespace CommandArgsConsoleApp1.Classes;
internal class SwitchOptions
{
    public static Dictionary<string, string> Mappings => new()
    {
        { "--environment", "environment" },
        { "-e", "environment" },
        { "--username", "username" },
        { "-u", "username" },
        { "--log", "log" },
        { "-l", "log" },
    };
}
