namespace CommandVerbsApp.Classes
{
    class HelpConstant
    {
        public const string Clone_local = "When the repository to clone from is on a local machine, this flag bypasses the normal \"Git aware\" transport mechanism and clones the repository by making a copy of HEAD and everything under objects and refs directories.";
        public const string Clone_quiet = "Operate quietly. Progress is not reported to the standard error stream.";
        public const string Clone_repository = "The (possibly remote) repository to clone from. See the GIT URLS section below for more information on specifying repositories.";

        //commit
        public const string Commit_message = "Use the given <msg> as the commit message. If multiple -m options are given, their values are concatenated as separate paragraphs.";
    }
}