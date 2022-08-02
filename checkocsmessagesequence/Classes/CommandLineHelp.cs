using System;
using System.Collections.Generic;
using CommandLine;
using CommandLine.Text;

namespace checkocsmessagesequence.Classes
{
    public class CommandLineHelp
    {
        /// <summary>
        /// For displaying help with a command argument of --help or -help 
        /// </summary>
        public static void DisplayHelp<T>(ParserResult<T> result, IEnumerable<Error> errs)
        {

            var help = HelpText.AutoBuild(result, helpText =>
            {
                helpText.AdditionalNewLineAfterOption = false;
                helpText.Heading = "By Karen Payne";
                helpText.Copyright = $"Copyright (c) {DateTime.Now.Year} OED Web team";

                return HelpText.DefaultParsingErrorsHandler(result, helpText);

            }, e => e);

            Console.WriteLine(help);
            Environment.Exit(-1);
        }

        /// <summary>
        /// Parse command line for expected arguments
        /// </summary>
        /// <param name="args">incoming program arguments</param>
        public static void ParseArguments(string[] args)
        {
            // ReSharper disable once ConvertToLocalFunction
            Action<ParserSettings> parserActions = settings =>
            {
                settings.HelpWriter = null;
                settings.CaseInsensitiveEnumValues = true;
            };

            Parser parser = new(parserActions);

            ParserResult<CommandLineOptions> results = parser
                .ParseArguments<CommandLineOptions>(args);

            results.WithParsed<CommandLineOptions>(Operations.RunWork)
                .WithNotParsed(errors => 
                    CommandLineHelp.DisplayHelp(results, errors));

        }
    }
}
