
using FileChunking.Models;

namespace FileChunking.Classes;

/// <summary>
/// Provides verification that a input file was chunked properly.
/// </summary>
public class ValidationOperations
{
    /// <summary>
    /// Location of chunk files chunked from a larger file
    /// </summary>
    public static string ChunkFolderLocation { get; set; }
    /// <summary>
    /// Verify chunking process worked
    /// </summary>
    /// <param name="incomingFileName">File that was chunked</param>
    /// <returns>Named Value Tuple</returns>
    /// <remarks>
    /// As is, the <see cref="Verify"/> list is not truly used although
    /// with different requirements like displaying in a visual control would
    /// be helpful in some apps like SIDES MPC which uses the list.
    /// </remarks>
    public static (Verify chunks, Verify baseVerify) VerifyLineCounts(string incomingFileName)
    {
        // ReSharper disable once CollectionNeverQueried.Local - Karen says BS
        var verificationList = new List<Verify>();

        var directory = new DirectoryInfo(ChunkFolderLocation);
        var files = directory.GetFiles("*.*", SearchOption.AllDirectories);

        var lineCount = 0;
        var totalLines = 0;

        /*
         * Loop through each chunk file, get line count
         */
        foreach (var fileInfo in files)
        {
            using (var reader = File.OpenText(Path.Combine(ChunkFolderLocation, fileInfo.Name)))
            {
                while (reader.ReadLine() != null)
                {
                    lineCount += 1;
                }
            }

            verificationList.Add(new Verify()
            {
                FileName = fileInfo.Name,
                Count = lineCount
            });

            totalLines += lineCount;
            lineCount = 0;

        }

        /*
         * Total line count for all chunked files
         */
        var totalChunkVerify = new Verify()
        {
            FileName = "Total",
            Count = totalLines
        };

        verificationList.Add(totalChunkVerify);

        lineCount = 0;

        /*
         * Get line count of file that was chunked
         * (There are many ways to do a line count)
         */
        using (var reader = File.OpenText(incomingFileName))
        {
            while (reader.ReadLine() != null)
            {
                lineCount += 1;
            }
        }

        /*
         * File which was chunked
         */
        var baseFileVerify = new Verify()
        {
            FileName = Path.GetFileName(incomingFileName),
            Count = lineCount
        };

        verificationList.Add(baseFileVerify);

        return (totalChunkVerify, baseFileVerify);

    }

}