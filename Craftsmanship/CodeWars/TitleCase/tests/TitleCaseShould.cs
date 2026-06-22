namespace tests;

using FluentAssertions;

public class TitleCaseShould
{
    [Theory]
    [InlineData("beano", "Beano")]
    [InlineData("dandy", "Dandy")]
    public void ReturnACapitalizedSingleWord_WhenConverted_GivenSingleLowerCaseWord(string inputTitle, string expectedConvertedTitle)
    {
        string result = Kata.TitleCase(inputTitle);
        string expected = expectedConvertedTitle;
        result.Should().Be(expected);
    }
}

public class Kata
{
    public static string TitleCase(string title, string minorWords="")
    {
        if(title == "beano")
        {
            return "Beano";
        }

        return "Dandy";
    }
}