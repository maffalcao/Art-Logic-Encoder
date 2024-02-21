namespace Encoder.BinaryMap;

public static class Error
{
    public static string MaxLenghtChunkReached(string input, int lenght) => $"Length of the chunk' value ({input}) exceeds the maximum allowed length ({lenght})";
    public static string NotAExpectedNumber(string input) => $"The array's element value ({input}) is not a valid number";

    public static string EncodeIsNotInExpectedFormat(string input) => 
        $"The encode input {input} is not in the expected format. It shoud be a phrase. Example: \"never odd or even\"";

    public static string DecodeIsNotInExpectedFormat(string input) =>
        $"The encode input {input} is not in the expected format. It shoud be a list of intergers with 9 digits. Eexample: \"[267487694, 125043731]\"";


}