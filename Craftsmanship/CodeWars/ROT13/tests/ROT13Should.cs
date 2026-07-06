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
    [InlineData("EBG13 ", "ROT13 ")]
    public void ReturnCorrectString_WhenConverstionInvoked_GivenString(string inputString, string expectedString)
    {
        var convertedString = Kata.Rot13(inputString);
        convertedString.Should().Be(expectedString);
    }

    [Fact]
    public void CodeWarTest()
    {
        Kata.Rot13("EBG13 rknzcyr.").Should().Be("ROT13 example.");
    }
}

public static class Kata
{
    private static readonly Dictionary<char, char> Rot13DictionaryMapping = new()
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
            var firstChar = input[0];
            
            if(char.IsNumber(firstChar) || !char.IsLetter(firstChar))
            {
                return firstChar.ToString();
            }

            if (!char.IsUpper(firstChar))
            {
                return Rot13DictionaryMapping[char.ToUpper(firstChar)].ToString().ToLower();
            }

            return Rot13DictionaryMapping[firstChar].ToString();
        }

        var output = "";

        foreach (var letter in input)
        {
            output += Rot13(letter.ToString());
        }

        return output;
    }
}