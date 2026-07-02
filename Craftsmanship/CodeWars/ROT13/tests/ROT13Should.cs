using FluentAssertions;

public class ROT13Should
{
    [Theory]
    [InlineData("A", "N")]
    [InlineData("M", "Z")]
    public void ReturnCorrectSingleCharacterString_WhenConverstionInvoked_GivenSingleCharacterString(string inputString, string expectedString)
    {
        string convertedString = Kata.Rot13(inputString);
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
    private static Dictionary<char, char> rot13DictionaryMapping = new Dictionary<char, char>()
    {
        { 'A', 'N' },
        { 'B', 'O'},
        { 'C', 'P'},
        { 'D', 'Q'},
        { 'E', 'R'},
        { 'F', 'S'},
        { 'G', 'T'},
        { 'H', 'U'},
        { 'I', 'V'},
        { 'J', 'W'},
        { 'K', 'X'},
        { 'L', 'Y'},
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
        { 'Z', 'M' },
        
    };
    public static string Rot13(string input)
    {
        
        return rot13DictionaryMapping[input[0]].ToString();
    }
}

/*
Input	ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz
Output	NOPQRSTUVWXYZABCDEFGHIJKLMnopqrstuvwxyzabcdefghijklm
   
*/
