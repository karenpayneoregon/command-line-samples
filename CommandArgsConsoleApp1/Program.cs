using System;
using System.Collections.Generic;
using Microsoft.Extensions.Configuration;

namespace CommandArgsConsoleApp1
{
    public class Program
    {
        public static void Main(string[] args)
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
            Console.ReadLine();
        }
    }
}