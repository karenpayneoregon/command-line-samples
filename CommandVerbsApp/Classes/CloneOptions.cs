using System.Collections.Generic;
using CommandLine;
using CommandLine.Text;

namespace CommandVerbsApp.Classes
{
    [Verb("clone", HelpText = "Clone a repository into a new directory.")]
    internal class CloneOptions
    {
        [Option('l', "local", HelpText = HelpConstant.Clone_local)]
        public bool Local { get; set; }
        [Option('q', "quiet", HelpText = HelpConstant.Clone_quiet)]
        public bool Quiet { get; set; }
        [Value(0, MetaName = "Repository", HelpText = HelpConstant.Clone_repository)]
        public string Repository { get; set; }

        [Usage(ApplicationAlias = "YourApp")]
        public static IEnumerable<Example> Examples
        {
            get
            {
                yield return new Example("Normal scenario", new CloneOptions { Local = true });
            }
        }

    }
}