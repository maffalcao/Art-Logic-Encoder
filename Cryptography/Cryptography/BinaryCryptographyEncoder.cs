using Encoder.Helpers;
namespace Encoder.BinaryMap;

public class BinaryCryptographyEncoder : BinaryCryptographyBase
{
    protected override int MAX_INPUT_LENGHT => 4;

    protected override T FormatInput<T>(string input)
    {
        const char zeroCharRepresentation = '\0';

        if (input.Length > MAX_INPUT_LENGHT)
            throw new Exception(Error.MaxLenghtChunkReached(input, MAX_INPUT_LENGHT));

        // zero-padded to a length of four before encoding        
        return (T)(object)input.PadRight(MAX_INPUT_LENGHT, zeroCharRepresentation);
    }

    public string Encode(string input)
    {
        input = FormatInput<string>(input);

        var binaryStringRepresentation = BinaryFormat.Convert(input);

        var encodedString = PerformMapping(CryptographyType.Encode, binaryStringRepresentation);

        return DecimalFormat.Convert(encodedString);
    }

}