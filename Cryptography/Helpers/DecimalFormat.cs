namespace Encoder.Helpers;

public static class DecimalFormat
{
    public static string Convert(this string binaryRepresentation)
    {
        return System.Convert
                .ToInt64(binaryRepresentation, 2)
                .ToString();
    }

    public static string Revert(this long decimalValue)
    {
        const int byteSize = 32;
        return System.Convert.ToString(decimalValue, 2).PadLeft(byteSize, '0');
    }

}