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

    [Fact]
    public void ReturnSumOfTwoNumbers_WhenAddInvoked_GivenTwoNumbers()
    {
        var stringCalculatorService = new StringCalculatorService();
        var twoNumbers = "1,2";

        var result = stringCalculatorService.Add(twoNumbers);

        var expectedResult = 3;
        result.Should().Be(expectedResult);
        
    }
}