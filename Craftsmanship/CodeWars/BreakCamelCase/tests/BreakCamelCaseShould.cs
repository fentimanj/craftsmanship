namespace tests;

using FluentAssertions;
using src.Services;

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
    [InlineData("badPlan", "bad Plan")]
    public void ReturnTwoWords_WhenWordIsSplit_GivenTwoWords(string input, string expected)
    {
        var splitWord = Kata.BreakCamelCase(input);
        splitWord.Should().Be(expected);
    }
    
    [Theory]
    [InlineData("helloWorldEveryone", "hello World Everyone")]
    public void ReturnThreeWords_WhenWordIsSplit_GivenThreeWords(string input, string expected)
    {
        var splitWord = Kata.BreakCamelCase(input);
        splitWord.Should().Be(expected);
    }
}