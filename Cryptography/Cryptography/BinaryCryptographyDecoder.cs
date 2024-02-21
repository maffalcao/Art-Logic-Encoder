using System.Text.RegularExpressions;
using Encoder.Extensions;
using Encoder.Helpers;
namespace Encoder.BinaryMap;

public class BinaryCryptographyDecoder : BinaryCryptographyBase
{
    protected override int MAX_INPUT_LENGHT => 999999999;

    protected override T FormatInput<T>(string input)
    {
        long inputNumber;

        if (long.TryParse(input, out inputNumber))
        {
            if (inputNumber > MAX_INPUT_LENGHT)
                throw new Exception(Error.MaxLenghtChunkReached(input, MAX_INPUT_LENGHT));
        }
        else
        {
            throw new Exception(Error.NotAExpectedNumber(input));
        }

        return (T)(object)inputNumber;

    }

    public string Decode(string input)
    {
        var inputNumber = FormatInput<long>(input);

        var binaryEncodedValue = DecimalFormat.Revert(inputNumber);
        var binaryDecodedValue = PerformMapping(CryptographyType.Decode, binaryEncodedValue);

        return BinaryFormat.Revert(binaryDecodedValue).RemoveNonPrintableCharacters();
    }
}
