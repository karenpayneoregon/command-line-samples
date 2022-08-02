using System;
using checkocsmessagesequence.Classes.Containers;
using CommandLine;

namespace checkocsmessagesequence.Classes
{

    public sealed class CommandLineOptions
    {
        [Option('u', "userid", Required = true, HelpText = "user name for database")]
        public string Userid { get; set; }

        [Option('p', "password", Required = true, HelpText = "password for database")]
        public string Password { get; set; }

        /// <summary>
        /// dev, staging, prod
        /// </summary>
        [Option('e', "env", Required = false, HelpText = "database environment: dev, stage, prod")]
        public ServerEnvironment Environment { get; set; }

        [Option(Default = false, HelpText = "Prints all messages to standard output.")]
        public bool Verbose { get; set; }

    }

}