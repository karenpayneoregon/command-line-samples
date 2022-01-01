using System.Collections.Generic;
using CommandLine;

namespace FileChunking.Classes
{
    public sealed class CommandLineOptions
    {
        /// <summary>
        /// File name to chunk
        /// </summary>
        [Option('f', "file",  Required = true,HelpText = "File to chunk")]
        public string FileName { get; set; }

        [Option('d', "dir", Required = true, HelpText = "File to chunk")]
        public string DestinationDirectory { get; set; }

        /// <summary>
        /// Base file name for chunked files
        /// </summary>
        [Option('b', "base", Required = true, HelpText = "Base file name for chunk files")]
        public string BaseName { get; set; }

        /// <summary>
        /// How many lines to split <see cref="FileName"/> into chunks
        /// </summary>
        [Option('s', "size", Required = true, HelpText = "Chunk size in lines")]
        public int ChunkSize { get; set; }

        // Omitting long name, defaults to name of property, ie "--verbose"
        [Option(Default = false, HelpText = "Prints all messages to standard output.")]
        public bool Verbose { get; set; }


    }


}