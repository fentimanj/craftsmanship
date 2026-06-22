namespace tests;

using FluentAssertions;

public class TitleCaseShould
{
    [Theory]
    [InlineData("beano", "Beano")]
    [InlineData("dandy", "Dandy")]
    [InlineData("harry", "Harry")]
    public void ReturnACapitalizedSingleWord_WhenConverted_GivenSingleLowerCaseWord(string inputTitle,
        string expectedConvertedTitle)
    {
        var result = Kata.TitleCase(inputTitle);
        var expected = expectedConvertedTitle;
        result.Should().Be(expected);
    }
}

public class Kata
{
    public static string TitleCase(string title, string minorWords = "")
    {
        var firstLetterCapitalized = title[0].ToString().ToUpper();
        var restOfWord = title.Substring(1);
        return firstLetterCapitalized + restOfWord;
    }
}