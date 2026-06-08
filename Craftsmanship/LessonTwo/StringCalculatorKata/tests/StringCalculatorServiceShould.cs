namespace tests;

using FluentAssertions;

public class StringCalculatorServiceShould
{
    [Fact]
    public void ReturnZerO_WhenAddInvoked_GivenEmptyString()
    {
        var stringCalculatorService = new StringCalculatorService();
        var result = stringCalculatorService.Add(string.Empty);
        result.Should().Be(0);
    }
}

public class StringCalculatorService
{
    public int Add(string inputString)
    {
        return 0;
    }
}