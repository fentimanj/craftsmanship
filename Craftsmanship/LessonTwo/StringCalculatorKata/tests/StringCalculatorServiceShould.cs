namespace tests;

using FluentAssertions;

public class StringCalculatorServiceShould
{
    [Fact]
    public void x()
    {
        var inputString = "";
        var stringCalculatorService = new StringCalculatorService();
        var result = stringCalculatorService.Add(inputString);
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