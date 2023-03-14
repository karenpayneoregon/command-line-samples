using System.Diagnostics;
using System.Text.RegularExpressions;

namespace FileChunking.LanguageExtensions;

/// <summary>
/// Common string extensions 
/// </summary>
public static class StringExtensions
{
    /// <summary>
    /// Determine if string is empty
    /// </summary>
    /// <param name="sender">String to test if null or whitespace</param>
    /// <returns>true if empty or false if not empty</returns>
    [DebuggerStepThrough]
    public static bool IsNullOrWhiteSpace(this string sender) => string.IsNullOrWhiteSpace(sender);
    /// <summary>
    /// Determine if a string can be represented as a numeric.
    /// </summary>
    /// <param name="text">value to determine if can be converted to a string</param>
    /// <returns></returns>
    [DebuggerStepThrough]
    public static bool IsNumeric(this string text) => double.TryParse(text, out _);

    #region Both methods do the same just written slightly different

    [DebuggerStepThrough]
    public static bool AlphaToInteger(this string text, ref int result)
    {
        var value = Regex.Replace(text, "[^0-9]", "");
        return int.TryParse(value, out result);
    }
    [DebuggerStepThrough]
    public static int NumberOnly(this string text)
    {
        var value = Regex.Replace(text, "[^0-9]", "");
        int.TryParse(value, out var result);

        return result;
    }

    #endregion
}