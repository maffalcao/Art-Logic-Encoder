
using Encoder;
using Encoder.BinaryMap;
public class BinaryMappedEncoderTest
{
    [Fact]
    public void Encode_InputExceedsMaxLength_ThrowsException()
    {
        // Arrange
        string input = "ABCDE";

        var encoder = new BinaryCryptographyEncoder();

        // Act & Assert
        Assert.Throws<Exception>(() => encoder.Encode(input));
    }

    [Theory]
    [MemberData(nameof(TestData))]
    public void Encode_ValidInput_ReturnsEncodedString(TestCase testCase)
    {
        // arranje
        var encoder = new BinaryCryptographyEncoder();

        // Act        
        var result = encoder.Encode(testCase.Input);

        // Assert
        Assert.Equal(testCase.ExpectedOutput, result);
    }

    public static IEnumerable<object[]> TestData()
    {
        yield return new object[] { new TestCase { Input = "A", ExpectedOutput = "16777217" } };
        yield return new object[] { new TestCase { Input = "FRED", ExpectedOutput = "251792692" } };
        yield return new object[] { new TestCase { Input = " :^)", ExpectedOutput = "79094888" } };
    }

    public class TestCase
    {
        public string Input { get; set; }
        public string ExpectedOutput { get; set; }
    }
}