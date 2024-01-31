namespace Encoder;

using System.Text;

public static class Extensions {

    public static string ToBinaryRepresentation(this char letter) {
        int asciiValue = (int)letter;
        string binaryRepresentation = string.Empty;

        // Loop through each bit in the ASCII value
        for (int i = 7; i >= 0; i--)
        {
            // Check if the i-th bit is set in the ASCII value
            int bit = (asciiValue & (1 << i)) == 0 ? 0 : 1;
            binaryRepresentation += bit;
        }

        return binaryRepresentation;
    }

    public static string ToBinaryRepresentation(this string rawText) {
        var binaryRepresentation = new StringBuilder();
	
        for (int i = rawText.Length - 1; i >= 0; i--)
            binaryRepresentation.Append(rawText[i].ToBinaryRepresentation());        
        
        return binaryRepresentation.ToString();
    }

    public static long ToDecimalRepresentation(this string binaryRepresentation) {
        return System.Convert.ToInt64(binaryRepresentation, 2);
    }
    
}