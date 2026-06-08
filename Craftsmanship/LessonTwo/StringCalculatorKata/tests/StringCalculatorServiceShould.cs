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
}