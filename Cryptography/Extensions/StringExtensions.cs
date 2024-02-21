using System.Text.RegularExpressions;

namespace Encoder.Extensions;

public static class StringExtensions
{
    public static List<string> SplitBySize(this string str, int chunkSize)
    {
        List<string> chunks = new List<string>();
        for (int i = 0; i < str.Length; i += chunkSize)
        {
            chunks.Add(str.Substring(i, Math.Min(chunkSize, str.Length - i)));
        }

        return chunks;
    }

    public static string RemoveNonPrintableCharacters(this string str) =>
        Regex.Replace(str, @"[^\x20-\x7E]", "");
}