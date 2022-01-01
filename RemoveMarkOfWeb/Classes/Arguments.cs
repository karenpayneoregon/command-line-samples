namespace RemoveMarkOfWeb.Classes
{
    public static class Arguments
    {
        public static string Path { get; set; }
        public static bool HasPath => !string.IsNullOrWhiteSpace(Path);
    }
}