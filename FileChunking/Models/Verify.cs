namespace FileChunking.Models
{
    public class Verify
    {
        public string FileName { get; set; }
        public int Count { get; set; }
        public string[] ItemArray => new[] { FileName, Count.ToString() };

        public override string ToString()
        {
            return FileName;
        }
    }

}