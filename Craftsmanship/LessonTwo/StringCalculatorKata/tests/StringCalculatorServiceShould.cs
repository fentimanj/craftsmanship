namespace tests;

using FluentAssertions;
using src.Services;

public class StringCalculatorServiceShould
{
    [Theory]
    [InlineData("", 0)]
    [InlineData("1", 1)]
    [InlineData("2", 2)]
    [InlineData("3", 3)]
    public void ReturnConvertedNumber_WhenAddInvoked_GivenSingleDigit(string digits, int expectedResult)
    {
        var stringCalculatorService = new StringCalculatorService();

        var result = stringCalculatorService.Add(digits);

        result.Should().Be(expectedResult);
    }

    [Theory]
    [InlineData("1,2", 3)]
    [InlineData("1,3", 4)]
    [InlineData("1,4", 5)]
    public void ReturnSumOfTwoNumbers_WhenAddInvoked_GivenTwoNumbers(string digits, int expectedResult)
    {
        var stringCalculatorService = new StringCalculatorService();

        var result = stringCalculatorService.Add(digits);

        result.Should().Be(expectedResult);
    }
    
    [Theory]
    [InlineData("1,2,3", 6)]
    public void ReturnSumOfThreeNumbers_WhenAddInvoked_GivenTwoNumbers(string digits, int expectedResult)
    {
        var stringCalculatorService = new StringCalculatorService();

        var result = stringCalculatorService.Add(digits);

        result.Should().Be(expectedResult);
    }
}