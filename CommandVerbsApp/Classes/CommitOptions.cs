using CommandLine;

namespace CommandVerbsApp.Classes
{
    [Verb("commit", HelpText = "Record changes to the repository.")]
    internal class CommitOptions
    {
        [Option('i', "interactive")]
        public bool Interactive { get; set; }
        [Option('a', "all")]
        public bool All { get; set; }
        [Option('m', "message", Required = true)]
        public string Message { get; set; }
    }
}