using System;
using checkocsmessagesequence.Classes;
using CommandLine.Text;

namespace checkocsmessagesequence
{
    class Program
    {
        static void Main(string[] args)
        {
            var title = new HeadingInfo(programName: "OCS_MESSAGES sequence checker", version: "1.0.0");
            Console.WriteLine(title);
            CommandLineHelp.ParseArguments(args);
        }
    }
}
