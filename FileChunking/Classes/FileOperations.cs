namespace FileChunking.Classes;

public class FileOperations
{
    #region Events

    /// <summary>
    /// Report progress passing file name
    /// </summary>
    /// <param name="fileName">Current file processed</param>
    public delegate void ProcessDelegate(string fileName);
    /// <summary>
    /// Report progress passing current file name
    /// </summary>
    public static event ProcessDelegate OnProcessEvent;

    /// <summary>
    /// Provides access to runtime exceptions while chunking 
    /// </summary>
    /// <param name="exception">Exception e.g. insufficient permissions</param>
    /// <param name="index">File indexer</param>
    public delegate void ErrorChunkingDelegate(Exception exception, int index);
    /// <summary>
    /// Report runtime exception while chunking
    /// </summary>
    public static event ErrorChunkingDelegate OnChunkingException;


    #endregion

    /// <summary>
    /// Location to place chunked files
    /// </summary>
    public static string ChunkFolderLocation;

    /// <summary>
    /// Responsible for cleaning <see cref="ChunkFolderLocation"/>
    /// </summary>
    /// <returns></returns>
    public static (bool verified, Exception exception) CleanFolder()
    {
        if (Directory.Exists(ChunkFolderLocation))
        {
            var files = Directory.GetFiles(ChunkFolderLocation, "*.txt");

            try
            {
                foreach (var file in files)
                {
                    File.Delete(file);
                }
            }
            catch (Exception exception)
            {
                return (false, exception);
            }
        }

        return (true, null);

    }

    /// <summary>
    /// Ensure that the chunk folder exists
    /// </summary>
    /// <param name="folder">Folder to verify existence</param>
    /// <returns>ValueTuple, true if exists, false + exception if failure to create</returns>
    public static (bool verified, Exception exception) EnsureChunkFolderExists(string folder)
    {
        try
        {
            if (!Directory.Exists(folder))
            {
                Directory.CreateDirectory(folder);
            }

            return (true, null);

        }
        catch (Exception exception)
        {
            return (false, exception);
        }

    }

    /// <summary>
    /// Chunk a file by <see cref="chunkSize"/> lines
    /// </summary>
    /// <param name="fileName">File to chunk</param>
    /// <param name="chunkSize">Lines to split fileName by</param>
    /// <param name="folder">Folder location for chunk files, can be empty</param>
    /// <param name="baseFileName">Individual chunk file base name</param>
    public static void ChunkFile(string fileName, int chunkSize, string folder, string baseFileName)
    {
        int counter = 1;

        try
        {

            foreach (var lineArray in ChunkLines(fileName, chunkSize))
            {
                var currentFileName = Path.Combine(ChunkFolderLocation, $"{baseFileName}{counter}.txt");
                File.WriteAllLines(currentFileName, lineArray);
                OnProcessEvent?.Invoke(Path.GetFileName(currentFileName));

                counter += 1;
            }

        }
        catch (Exception exception)
        {
            OnChunkingException?.Invoke(exception, counter);
        }

    }
    /// <summary>
    /// Chunk/split lines in a file
    /// </summary>
    /// <param name="fileName">Existing text file</param>
    /// <param name="chunkByLines">Number of lines to chunk by</param>
    /// <returns>IEnumerable&lt;string[]&gt;</returns>
    public static IEnumerable<string[]> ChunkLines(string fileName, int chunkByLines)
    {
        if (chunkByLines <= 0) throw new ArgumentOutOfRangeException(nameof(chunkByLines));

        using var reader = new StreamReader(fileName);

        /*
         * Read from start to finish of file contents
         */
        while (!reader.EndOfStream)
        {

            var lineList = new List<string>();

            /*
             * Populate string list until chunkByLines value is hit
             * then return the list to the caller
             */
            for (var index = 0; index < chunkByLines && !reader.EndOfStream; index++)
            {
                lineList.Add(reader.ReadLine());
            }

            yield return lineList.ToArray();

        }
    }
}