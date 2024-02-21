using Encoder.BinaryMap;
public class BinaryMappedDecoderTest
{
    [Fact]
    public void Decode_InputExceedsMaxLength_ThrowsException()
    {
        // Arrange
        string input = "1677721788"; // more than 9 digits input

        var decoder = new BinaryCryptographyDecoder();

        // Act & Assert
        Assert.Throws<Exception>(() => decoder.Decode(input));
    }

    [Theory]
    [MemberData(nameof(TestData))]
    public void Decode_ValidInput_ReturnsDecodedString(TestCase testCase)
    {
        // Arrange
        var decoder = new BinaryCryptographyDecoder();

        // Act        
        var result = decoder.Decode(testCase.Input);

        // Assert
        Assert.Equal(testCase.ExpectedOutput, result);
    }

    public static IEnumerable<object[]> TestData()
    {
        yield return new object[] { new TestCase { Input = "251930706", ExpectedOutput = "BIRD" } }; // valor invertido do primeiro teste de Encode
        yield return new object[] { new TestCase { Input = "251792692", ExpectedOutput = "FRED" } }; // valor invertido do segundo teste de Encode
        yield return new object[] { new TestCase { Input = "79094888", ExpectedOutput = " :^)" } }; // valor invertido do terceiro teste de Encode
    }

    public class TestCase
    {
        public string Input { get; set; }
        public string ExpectedOutput { get; set; }
    }
}
