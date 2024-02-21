using System.Text;
using System.Text.RegularExpressions;
using Encoder.BinaryMap;
using Encoder.Extensions;

namespace Encoder.Cryptography;

public class BinaryCryptography
{
    private const int CHUNK_LENGHT = 4;
    public string Encode(string input)
    {
        if (IsExpectedEncodeInput(input) is false)
        {
            throw new Exception(Error.EncodeIsNotInExpectedFormat(input));
        }

        var encoder = new BinaryCryptographyEncoder();

        var chunks = input.SplitBySize(CHUNK_LENGHT);
        var result = new List<string>();

        chunks.ForEach(chunk =>
        {
            result.Add(encoder.Encode(chunk).PadRight(CHUNK_LENGHT, '0'));
        });

        return JoinArrayIntoFormattedString(result);
    }

    public string Decode(string input)
    {
        if (IsExpectedDecodeInput(input) is false)
        {
            throw new Exception(Error.DecodeIsNotInExpectedFormat(input));
        }

        var decoder = new BinaryCryptographyDecoder();

        var elements = TranslateToListOfStrings(input);

        var result = new StringBuilder();

        elements.ForEach(element =>
        {
            result.Append($"{decoder.Decode(element)}");
        });

        return result.ToString();
    }

    private bool IsExpectedEncodeInput(string input)
    {
        // regular expression to match a phrase pattern
        string phrasePattern = @"^[A-Za-z0-9\s,]+$";
        return Regex.IsMatch(input, phrasePattern);
    }


    private bool IsExpectedDecodeInput(string input)
    {
        // regular expression to match a set of integer values from the array in the string pattern        
        // it checks for either exactly 8 or 9 digit number that does not start with 0 (matching the range 1000000 to 999999999).    
        string setPattern = @"^\s*\[\s*(0*(10000000[0-9]|100000000|[1-9]\d{7,8}))(?:\s*,\s*(0*(10000000[0-9]|100000000|[1-9]\d{7,8})))*\s*\]\s*$";
        return Regex.IsMatch(input, setPattern);
    }

    private string JoinArrayIntoFormattedString(List<string> array)
    {
        return "[" + string.Join(", ", array) + "]";
    }

    static List<string> TranslateToListOfStrings(string input)
    {
        input = input.Trim('[', ']');

        // split the string by comma and space to get individual numbers as strings
        var numberStrings = input.Split(new char[] { ',', ' ' }, StringSplitOptions.RemoveEmptyEntries);

        // create a list to store the number strings
        var numbers = new List<string>(numberStrings);

        return numbers;
    }



}