using CommandLine;

namespace CommandVerbsApp.Classes
{
    [Verb("add", HelpText = "Add file contents to the index.")]
    internal class AddOptions
    {

        [Option('n', "dry-run")]
        public bool DryRun { get; set; }
        [Option('f', "force")]
        public bool Force { get; set; }

    }
}