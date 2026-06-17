namespace tests;

using FluentAssertions;
using src.Services;

public class RomanNumbersServiceShould
{
    [Fact]
    public void ReturnCorrectNumber()
    {
        var romanNumbersService = new RomanNumbersService();
        var inputNumber = 1;
        
        var expectedRomanNumeral = romanNumbersService.Convert(inputNumber);
        
        expectedRomanNumeral.Should().Be("I");
    }
}