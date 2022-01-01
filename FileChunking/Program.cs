using System;
using System.Diagnostics;
using CommandLine.Text;
using FileChunking.Classes;

namespace FileChunking
{
    class Program
    {
        static void Main(string[] args)
        {
            var title = new HeadingInfo(programName: "File chunk", version: "1.0.0");
            Console.WriteLine(title);
            CommandLineHelp.ParseArguments(args);
        }
    }
}