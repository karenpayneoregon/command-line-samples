// @nuget: CommandLineParser -Version 2.8.0

using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using CommandLine;
using CommandVerbsApp.Classes;

namespace CommandVerbsApp
{
    public class VerbDemo
    {
        public static void Main()
        {
            var line = new String('-', 40);
            Console.WriteLine("---show help for verbs ------");
            var args = "--help".Split();
            Start(args);

            Console.WriteLine("---show help for clone verb ------");
            args = "clone --help".Split();
            Start(args);

            Console.WriteLine(line);
            args = "clone git://git.kernel.org/pub/scm/.../linux.git".Split();
            Start(args);

            Console.WriteLine(line);
            args = new[] { "commit", "-m", "update parser setting" };
            Start(args);

            ConsoleWaiter.ReadLineWithTimeout();
        }

        public static void Start(string[] args)
        {
            Console.WriteLine($"Args: {string.Join(' ', args.Select(x => $"\"{x}\""))}");

            //Type[] types = {typeof(AddOptions), typeof(CommitOptions), typeof(CloneOptions)};
            //OR 
            //get all types using reflection /plugin loader /Ioc container
            var types = LoadVerbs();
            Parser.Default.ParseArguments(args, types)
                .WithParsed(Run)
                .WithNotParsed(HandleErrors);
        }
        //load all Verb types using Reflection
        static Type[] LoadVerbs() =>
            Assembly.GetExecutingAssembly().GetTypes()
                .Where(t => t.GetCustomAttribute<VerbAttribute>() != null).ToArray();

        private static void Run(object sender)
        {
            switch (sender)
            {
                case CloneOptions cloneOptions:
                    RunClone(cloneOptions);
                    break;
                case CommitOptions commitOptions:
                    RunCommit(commitOptions);
                    break;
                case AddOptions addOptions:
                    RunAdd(addOptions);
                    break;
            }

            //process CloneOptions
            void RunClone(CloneOptions opts)
            {
                Console.WriteLine("Processing Verb 'Clone'");
                Console.WriteLine();
            }
            
            //process CommitOptions
            void RunCommit(CommitOptions opts)
            {
                Console.WriteLine("Processing Verb 'Commit'");
                Console.WriteLine($"Message= {opts.Message}");
                Console.WriteLine();

            }

            //process AddOptions
            void RunAdd(AddOptions opts)
            {
                Console.WriteLine("Processing Verb 'Add'");
                Console.WriteLine();
            }
        }

        private static void HandleErrors(IEnumerable<Error> obj)
        {
            // TODO
        }

        [ModuleInitializer]
        public static void Init()
        {
            Console.Title = "Verbs code samples";
        }
    }
}