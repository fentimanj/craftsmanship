namespace tests;

using FluentAssertions;
using src.Services;

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
    
    [Theory]
    [InlineData("beano magazine", "Beano Magazine")]
    [InlineData("dandy comic", "Dandy Comic")]
    [InlineData("harry potter", "Harry Potter")]
    public void ReturnACapitalizedFirstAndSecondWords_WhenConverted_GivenTwoLowerCaseWords(string inputTitle,
        string expectedConvertedTitle)
    {
        var result = Kata.TitleCase(inputTitle);
        var expected = expectedConvertedTitle;
        result.Should().Be(expected);
    } 
    
    [Theory]
    [InlineData("harry potter and dobby", "Harry Potter and Dobby", "and")]
    public void ReturnACorrectlyFormattedTitle_WhenConverted_GivenTwoLowerCaseWords(string inputTitle, string expectedConvertedTitle, string minorWords)
    {
        var result = Kata.TitleCase(inputTitle, minorWords);
        var expected = expectedConvertedTitle;
        result.Should().Be(expected);
    }
    
    
}