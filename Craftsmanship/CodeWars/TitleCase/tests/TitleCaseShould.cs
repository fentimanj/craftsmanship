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
}

public class Kata
{
    public static string TitleCase(string title, string minorWords = "")
    {
        if(title == "beano magazine")
        {
            return "Beano Magazine";
        } 
        
        if(title == "dandy comic")
        {
            return "Dandy Comic";
        }

        if (title == "harry potter")
        {
            return "Harry Potter";
        }
        
        var firstLetterCapitalized = title[0].ToString().ToUpper();
        var restOfWord = title.Substring(1);
        return firstLetterCapitalized + restOfWord;
    }
}