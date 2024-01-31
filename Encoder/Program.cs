namespace Encoder;
class Program
{
    static void Main(string[] args)
    {
        if (args.Length != 1)
        {
            Console.WriteLine("Usage: ArtLogicEncoder <textToBeEncoded>");
            return;
        }
        
        IEncoder<long> encoder = GetEncoderStrategy(args[0]);

        Console.WriteLine(encoder.Encode());
    }

    static IEncoder<long> GetEncoderStrategy(string input)
    {
        // We can implement a logic here to determine which encoding strategy to use based on some criteria
        // For simplicity, let's say we decide based on the length of the input string
        if (input.Length <= 4)
        {
            return new BinaryMappedEncoder(input);
        }
        else
            throw new Exception($"No encoding strategy available to {input.Length} input's size");
    }
}