namespace tests;

using FluentAssertions;
using src.Services;

public class StringCalculatorServiceShould
{
    [Fact]
    public void ReturnZero_WhenAddInvoked_GivenEmptyString()
    {
        var stringCalculatorService = new StringCalculatorService();
        
        var result = stringCalculatorService.Add(string.Empty);
        
        result.Should().Be(0);
    }

    [Fact]
    public void ReturnOne_WhenAddInvoked_GivenOne()
    {
        var stringCalculatorService = new StringCalculatorService();
        var oneAsString = "1";
        
        var result = stringCalculatorService.Add(oneAsString);
        
        result.Should().Be(1);
        
    }
}