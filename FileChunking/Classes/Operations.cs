using System.Runtime.CompilerServices;
using Console = System.Console;

namespace FileChunking.Classes;

public class Operations
{
    /// <summary>
    /// Dummy work for the application
    /// </summary>
    /// <param name="options"><see cref="CommandLineOptions"/></param>
    public static void RunWork(CommandLineOptions options)
    {
        var fileName = options.FileName;
        if (File.Exists(fileName) && options.ChunkSize >1 && !string.IsNullOrWhiteSpace(options.BaseName))
        {
            var size = options.ChunkSize;
            var baseFileName = options.BaseName;
            var folder = options.DestinationDirectory;

            FileOperations.OnProcessEvent += FileOperationsOnOnProcessEvent;
            FileOperations.OnChunkingException += FileOperationsOnOnChunkingException;

            if (!Directory.Exists(folder))
            {
                try
                {
                    Directory.CreateDirectory(folder);
                }
                catch (Exception)
                {
                    throw;
                }
            }

            FileOperations.ChunkFolderLocation = folder;
            FileOperations.CleanFolder();
            FileOperations.ChunkFile(fileName, size, folder, baseFileName);
            ConsoleColors.WriteLineBold("Chunking completed... auto close in ten seconds");
            ConsoleWaiter.ReadLineWithTimeout(TimeSpan.FromSeconds(10));
        }
        else
        {
            Console.WriteLine("There were issues");
            Console.WriteLine("\tEither the input file does not exist");
            Console.WriteLine("\tor");
            Console.WriteLine("\tBase file name is empty");
            Console.WriteLine("\tor");
            Console.WriteLine("\tChunk size is too small");
            Console.ReadLine();
        }
    }

    private static void FileOperationsOnOnChunkingException(Exception exception, int index)
    {
        Console.WriteLine($"{index} : {exception.Message}");
    }

    private static void FileOperationsOnOnProcessEvent(string filename)
    {
        Console.WriteLine(filename);
    }

    [ModuleInitializer]
    public static void Init()
    {
        Console.Title = "File chunking";
    }
}