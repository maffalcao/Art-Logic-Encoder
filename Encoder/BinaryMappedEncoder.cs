namespace Encoder;

public class BinaryMappedEncoder : IEncoder<long>
{
    private static int MAX_LENGTH_INPUT = 4;
    private static int BYTE_LENGTH = 8;
    private static char ZERO_CHAR = '\0';    

    private readonly string _rawText;    

    public BinaryMappedEncoder(string rawText)
    {
        this._rawText = rawText;

        if(_rawText.Length > MAX_LENGTH_INPUT)
            throw new Exception($"Length of the input ({_rawText}) exceeds the maximum allowed length ({MAX_LENGTH_INPUT})");

        // zero-padded to a length of four before encoding
        _rawText = rawText.PadRight(4, ZERO_CHAR);
    }

    public long Encode()
    {
        var binaryStringRepresentation = _rawText.ToBinaryRepresentation();
        var encodedString = PerformEncoding(binaryStringRepresentation);
        return encodedString.ToDecimalRepresentation();
    }

    private string PerformEncoding(string binaryStringRepresentation) {
        try {
            char[] encodedString = new char[binaryStringRepresentation.Length];
            
            // the way our encoding method map the index from input to the index of the output
            for (int i = 0; i < BYTE_LENGTH; i++)        {
            
                for (int j = 0; j < MAX_LENGTH_INPUT; j++)
            
                    encodedString[j + (MAX_LENGTH_INPUT*i)] = binaryStringRepresentation[i + (BYTE_LENGTH * j)];	
            }
        
            return new String(encodedString);

        }
        catch(Exception exeption)  {
            throw new Exception($"Something went wrong: {exeption.Message}");
        }
    }
}