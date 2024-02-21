using Encoder.Cryptography;

public class BinaryCryptographyTests
{
    [Theory]
    [MemberData(nameof(EncodeTestData))]
    public void Encode_ValidInput_ReturnsExpectedEncodedString(string input, string expectedOutput)
    {
        // Arrange
        var cryptography = new BinaryCryptography();

        // Act
        var result = cryptography.Encode(input);

        // Assert
        Assert.Equal(expectedOutput, result);
    }

    [Theory]
    [MemberData(nameof(DecodeTestData))]
    public void Decode_ValidInput_ReturnsExpectedDecodedString(string input, string expectedOutput)
    {
        // Arrange
        var cryptography = new BinaryCryptography();

        // Act
        var result = cryptography.Decode(input);

        // Assert
        Assert.Equal(expectedOutput, result);
    }

    public static IEnumerable<object[]> EncodeTestData()
    {
        yield return new object[] { "tacocat", "[267487694, 125043731]" };
        yield return new object[] { "never odd or even", "[267657050, 233917524, 234374596, 250875466, 17830160]" };
        yield return new object[] { "lager, sir, is regal", "[267394382, 167322264, 66212897, 200937635, 267422503]" };
        yield return new object[] { "egad, a base tone denotes a bad age", "[267389735, 82841860, 267651166, 250793668, 233835785, 267665210, 99680277, 133170194, 124782119]" };
    }

    public static IEnumerable<object[]> DecodeTestData()
    {
        yield return new object[] { "[267487694, 125043731]", "tacocat" };
        yield return new object[] { "[267657050, 233917524, 234374596, 250875466, 17830160]", "never odd or even" };
        yield return new object[] { "[267394382, 167322264, 66212897, 200937635, 267422503]", "lager, sir, is regal" };
        yield return new object[] { "[267389735, 82841860, 267651166, 250793668, 233835785, 267665210, 99680277, 133170194, 124782119]", "egad, a base tone denotes a bad age" };
    }
}
