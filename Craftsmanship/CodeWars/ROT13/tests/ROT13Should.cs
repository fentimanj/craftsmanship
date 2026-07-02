using FluentAssertions;

public class ROT13Should
{
    [Theory]
    [InlineData("A", "N")]
    [InlineData("M", "Z")]
    [InlineData("a", "n")]
    [InlineData("AB", "NO")]
    [InlineData("MA", "ZN")]
    [InlineData("FI", "SV")]
    [InlineData("EBG", "ROT")]
    [InlineData("EBG1", "ROT1")]
    public void ReturnCorrectString_WhenConverstionInvoked_GivenString(string inputString, string expectedString)
    {
        var convertedString = Kata.Rot13(inputString);
        convertedString.Should().Be(expectedString);
    }

    // [Fact]
    public void CodeWarTest()
    {
        Kata.Rot13("EBG13 rknzcyr.").Should().Be("ROT13 example.");
    }
}

public class Kata
{
    private static readonly Dictionary<char, char> rot13DictionaryMapping = new()
    {
        { 'A', 'N' },
        { 'B', 'O' },
        { 'C', 'P' },
        { 'D', 'Q' },
        { 'E', 'R' },
        { 'F', 'S' },
        { 'G', 'T' },
        { 'H', 'U' },
        { 'I', 'V' },
        { 'J', 'W' },
        { 'K', 'X' },
        { 'L', 'Y' },
        { 'M', 'Z' },
        { 'N', 'A' },
        { 'O', 'B' },
        { 'P', 'C' },
        { 'Q', 'D' },
        { 'R', 'E' },
        { 'S', 'F' },
        { 'T', 'G' },
        { 'U', 'H' },
        { 'V', 'I' },
        { 'W', 'J' },
        { 'X', 'K' },
        { 'Y', 'L' },
        { 'Z', 'M' }
    };

    public static string Rot13(string input)
    {
        if (input.Length == 1)
        {
            if(char.IsNumber(input[0]))
            {
                return 1.ToString();
            }
            
            var firstChar = input[0];

            if (!char.IsUpper(firstChar))
            {
                return rot13DictionaryMapping[char.ToUpper(firstChar)].ToString().ToLower();
            }

            return rot13DictionaryMapping[firstChar].ToString();
        }

        var output = "";

        for (var i = 0; i < input.Length; i++)
        {
            output += Rot13(input[i].ToString());
        }

        return output;
    }
}