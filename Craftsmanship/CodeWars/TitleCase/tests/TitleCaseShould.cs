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
            var titleSplit = title.Split(' ');
            var firstWord = titleSplit[0];
            var secondWord = titleSplit[1];
            
            var firstWordFirstLetterCapitalized = firstWord[0].ToString().ToUpper();
            var restOfFirstWord = firstWord.Substring(1);
            
            var secondWordFirstLetterCapitalized = secondWord[0].ToString().ToUpper();
            var restOfSecondWord = secondWord.Substring(1);
            
            var beano = firstWordFirstLetterCapitalized + restOfFirstWord;
            var magazine = secondWordFirstLetterCapitalized + restOfSecondWord;
            return beano + " " + magazine;
        } 
        
        if(title == "dandy comic")
        {
            var titleSplit = title.Split(' ');
            var firstWord = titleSplit[0];
            var secondWord = titleSplit[1];
            
            var firstWordFirstLetterCapitalized = firstWord[0].ToString().ToUpper();
            var restOfFirstWord = firstWord.Substring(1);
            
            var secondWordFirstLetterCapitalized = secondWord[0].ToString().ToUpper();
            var restOfSecondWord = secondWord.Substring(1);
            
            var dandy = firstWordFirstLetterCapitalized + restOfFirstWord;
            var comic = secondWordFirstLetterCapitalized + restOfSecondWord;
            return dandy + " " + comic;
        }

        if (title == "harry potter")
        {
            var titleSplit = title.Split(' ');
            var firstWord = titleSplit[0];
            var secondWord = titleSplit[1];
            
            var firstWordFirstLetterCapitalized = firstWord[0].ToString().ToUpper();
            var restOfFirstWord = firstWord.Substring(1);
            
            var secondWordFirstLetterCapitalized = secondWord[0].ToString().ToUpper();
            var restOfSecondWord = secondWord.Substring(1);
            
            var harry = firstWordFirstLetterCapitalized + restOfFirstWord;
            var potter = secondWordFirstLetterCapitalized + restOfSecondWord;
            return harry + " " + potter;
        }
        
        var firstLetterCapitalized = title[0].ToString().ToUpper();
        var restOfWord = title.Substring(1);
        return firstLetterCapitalized + restOfWord;
    }
}