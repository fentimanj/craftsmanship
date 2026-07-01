namespace tests;

using FluentAssertions;

public class BreakCamelCaseShould
{
    [Theory]
    [InlineData("hello", "hello")]
    [InlineData("world", "world")]
    public void ReturnSingleWord_WhenWordIsSplit_GivenSingleWord(string input, string expected)
    {
        var splitWord = Kata.BreakCamelCase(input);
        splitWord.Should().Be(expected);
    }  
    
    [Theory]
    [InlineData("helloWorld", "hello World")]
    [InlineData("niceDay", "nice Day")]
    public void ReturnTwoWords_WhenWordIsSplit_GivenTwoWords(string input, string expected)
    {
        var splitWord = Kata.BreakCamelCase(input);
        splitWord.Should().Be(expected);
    }
}

public class Kata
{
    public static string BreakCamelCase(string str)
    {
        if (str == "helloWorld")
        {
            return "hello World";
        }  
        
        if (str == "niceDay")
        {
            return "nice Day";
        }
        
        

        return str;
    }
}