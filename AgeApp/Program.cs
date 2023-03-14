using System.Diagnostics;
using CommandLine.Text;
using myage.Classes;

namespace myage;

internal class Program
{
    public static void Main(string[] args)
    {
        var title = new HeadingInfo(programName: "Check ", version: "1.0.1");

#if DEBUG
        Debug.WriteLine(title);
#endif
        CommandLineHelp.ParseArguments(args);

#if DEBUG
        Console.ReadLine();
#endif


    }
}