namespace tests;

using FluentAssertions;
using src.services;

public class FizzBuzzServiceShould
{
    [Theory]
    [InlineData(1, "1")]
    [InlineData(2, "2")]
    [InlineData(4, "4")]
    public void ReturnSameInteger_WhenConvertInvoked_GivenIntegerNotDivisibleByThreeOrFive(int input,
        string expectedOutput)
    {
        var fizzBuzzService = new FizzBuzzService();

        var result = fizzBuzzService.Convert(input);

        result.Should().Be(expectedOutput);
    }

    [Theory]
    [InlineData(3, "Fizz")]
    [InlineData(6, "Fizz")]
    [InlineData(9, "Fizz")]
    public void ReturnFizz_WhenConvertInvoked_GivenInputIsDivisibleThree(int input, string expectedOutput)
    {
        var fizzBuzzService = new FizzBuzzService();

        var result = fizzBuzzService.Convert(input);

        result.Should().Be(expectedOutput);
    }

    [Theory]
    [InlineData(5, "Buzz")]
    [InlineData(10, "Buzz")]
    [InlineData(20, "Buzz")]
    public void ReturnBuzz_WhenConvertInvoked_GivenInputIsDivisibleFive(int input, string expectedOutput)
    {
        var fizzBuzzService = new FizzBuzzService();

        var result = fizzBuzzService.Convert(input);

        result.Should().Be(expectedOutput);
    }

    [Theory]
    [InlineData(15, "FizzBuzz")]
    [InlineData(30, "FizzBuzz")]
    [InlineData(45, "FizzBuzz")]
    public void ReturnFizzBuzz_WhenConvertInvoked_GivenInputIsDivisibleThreeAndFive(int input, string expectedOutput)
    {
        var fizzBuzzService = new FizzBuzzService();

        var result = fizzBuzzService.Convert(input);

        result.Should().Be(expectedOutput);
    }
}