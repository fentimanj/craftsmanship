namespace tests;

using FluentAssertions;
using src.Services;

public class StringCalculatorServiceShould
{
    [Theory]
    [InlineData("", 0)]
    [InlineData("1", 1)]
    [InlineData("2", 2)]
    public void ReturnConvertedNumber_WhenAddInvoked_GivenSingleDigit(string digits, int expectedResult)
    {
        var stringCalculatorService = new StringCalculatorService();

        var result = stringCalculatorService.Add(digits);

        result.Should().Be(expectedResult);
    }
}