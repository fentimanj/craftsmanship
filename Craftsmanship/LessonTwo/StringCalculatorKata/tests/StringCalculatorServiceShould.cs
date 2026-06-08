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
    [InlineData("1,2,3,4",10)]
    public void ReturnSumOfMoreThanTwoNumbers_WhenAddInvoked_GivenTwoNumbers(string digits, int expectedResult)
    {
        var stringCalculatorService = new StringCalculatorService();

        var result = stringCalculatorService.Add(digits);

        result.Should().Be(expectedResult);
    }

    [Theory]
    [InlineData("1\n2", 3)]
    [InlineData("1\n3", 4)]
    public void ReturnSumOfNumbers_WhenAddInvoked_GivenNumbersWithNewLineDelimiter(string digits, int expectedResult)
    {
        var stringCalculatorService = new StringCalculatorService();

        var result = stringCalculatorService.Add(digits);

        result.Should().Be(expectedResult);
    }
    
    [Theory]
    [InlineData("1\n2,3", 6)]
    [InlineData("1\n2,4", 7)]
    [InlineData("1\n2,5", 8)]
    public void ReturnSumOfNumbers_WhenAddInvoked_GivenNumbersWithNewLineDelimiterAndCommas(string digits, int expectedResult)
    {
        var stringCalculatorService = new StringCalculatorService();

        var result = stringCalculatorService.Add(digits);

        result.Should().Be(expectedResult);
    }
}