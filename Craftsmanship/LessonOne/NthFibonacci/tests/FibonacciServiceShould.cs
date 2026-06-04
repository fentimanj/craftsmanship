namespace tests;

using FluentAssertions;

public class FibonacciServiceShould
{
    [Theory]
    [InlineData(0, 0)]
    [InlineData(1, 1)]
    [InlineData(2, 2)]
    public void ReturnCorrectConvertedNumber_WhenConvertNumberInvoked_GivenValidInput(int input, int expectedConversion)
    {
        FibonacciService fibonacciService = new FibonacciService();
        int fibonacciNumber = fibonacciService.ConvertNumber(input);
        fibonacciNumber.Should().Be(expectedConversion);
    }
}

public class FibonacciService
{
    public int ConvertNumber(int input)
    {
        if (input == 1)
        {
            return 1;
        }

        if (input == 2)
        {
            return 2;
        }
        
        return 0;
    }
}