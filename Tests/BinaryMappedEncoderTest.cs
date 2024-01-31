
using Encoder;
public class BinaryMappedEncoderTest
{
    [Fact]
    public void Encode_InputExceedsMaxLength_ThrowsException()
    {
        // Arrange
        string input = "ABCDE";

        // Act & Assert
        Assert.Throws<Exception>(() => new BinaryMappedEncoder(input));
    }

    [Theory]
    [MemberData(nameof(TestData))]
    public void Encode_ValidInput_ReturnsEncodedString(TestCase testCase)
    {

        // Act
        var encoder = new BinaryMappedEncoder(testCase.Input);
        var result = encoder.Encode();

        // Assert
        Assert.Equal(testCase.ExpectedOutput, result);
    }

    public static IEnumerable<object[]> TestData()
    {
        yield return new object[] { new TestCase { Input = "A", ExpectedOutput = 16777217 } };
        yield return new object[] { new TestCase { Input = "FRED", ExpectedOutput = 251792692 } };
        yield return new object[] { new TestCase { Input = " :^)", ExpectedOutput = 79094888 } };
    }

    public class TestCase
    {
        public string? Input { get; set; }
        public long ExpectedOutput { get; set; }
    }
}