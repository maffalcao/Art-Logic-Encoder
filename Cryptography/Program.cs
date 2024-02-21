using Encoder.BinaryMap;
using Encoder.Cryptography;

namespace Encoder;
class Program
{
    static void Main(string[] args)
    {
        if (args.Length < 2)
        {
            PrintCommandLinePattern();
            return;
        }

        // Check if the first argument is either "-d" or "-e"
        if (args[0] != OptionType.Decode && args[0] != OptionType.Encode)
        {
            PrintCommandLinePattern();
            return;
        }

        try
        {

            var cryptography = new BinaryCryptography();
            var result = String.Empty;

            if (args[0] == OptionType.Encode)
            {
                result = cryptography.Encode(args[1]);
            }
            else if (args[0] == OptionType.Decode)
            {
                result = cryptography.Decode(args[1]);
            }

            Console.WriteLine(result);
            Console.WriteLine(result.Length);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }

    internal void ValidateArguments(string[] args)
    {

    }

    internal static void PrintCommandLinePattern()
    {
        Console.WriteLine("Usage: dotnet run  <-d or -e> \"<string_to_be_incoded_or_decoded>\"");
        Console.WriteLine();
        Console.WriteLine("Example: ");
        Console.WriteLine("To decode: dotnet run -d \"[267394382, 167322264, 66212897, 200937635, 267422503]\"");
        Console.WriteLine("To encode: dotnet run -e \"lager, sir, is regal\"");
    }

    internal static class OptionType
    {
        public static string Decode = "-d";
        public static string Encode = "-e";
    }

}