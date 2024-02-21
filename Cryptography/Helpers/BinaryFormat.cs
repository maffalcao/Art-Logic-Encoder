using System.Text;

namespace Encoder.Helpers;
public static class BinaryFormat
{
    public static string Convert(string rawText)
    {
        var binaryRepresentation = new StringBuilder();

        for (int i = rawText.Length - 1; i >= 0; i--)
            binaryRepresentation.Append(Convert(rawText[i]));

        return binaryRepresentation.ToString();
    }

    private static string Convert(char letter)
    {
        int asciiValue = (int)letter;
        string binaryRepresentation = string.Empty;

        // loop through each bit in the ASCII value
        for (int i = 7; i >= 0; i--)
        {
            // check if the i-th bit is set in the ASCII value
            int bit = (asciiValue & (1 << i)) == 0 ? 0 : 1;
            binaryRepresentation += bit;
        }

        return binaryRepresentation;
    }

    public static string Revert(string binaryText)
    {
        if (binaryText == null)
            throw new ArgumentNullException(nameof(binaryText));

        if (binaryText.Length % 8 != 0)
            throw new ArgumentException("Input string length must be a multiple of 8.", nameof(binaryText));



        StringBuilder originalText = new StringBuilder();

        // iterate through the binary string in 8-character chunks
        for (int i = 0; i < binaryText.Length; i += 8)
        {
            string binaryByte = binaryText.Substring(i, 8); // extract 8 characters (1 byte)
            byte byteValue = System.Convert.ToByte(binaryByte, 2); // convert binary byte to byte value
            originalText.Insert(0, (char)byteValue); // insert character represented by byte value at the beginning of the string
        }

        return originalText.ToString();
    }




}