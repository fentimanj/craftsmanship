namespace tests;

using FluentAssertions;
using src.Services;

public class RomanNumbersServiceShould
{
    [Theory]
    [InlineData(1, "I")]
    [InlineData(2, "II")]
    [InlineData(3, "III")]
    [InlineData(5, "V")]
    [InlineData(6, "VI")]
    [InlineData(7, "VII")]
    [InlineData(4, "IV")]
    [InlineData(10, "X")]
    [InlineData(11, "XI")]
    public void ReturnRomanNumeral_WhenConverting_GivenValidInputNumber(int inputNumber, string expectedRomanNumeral)
    {
        var romanNumbersService = new RomanNumbersService();

        var actualRomanNumeral = romanNumbersService.Convert(inputNumber);
        
        actualRomanNumeral.Should().Be(expectedRomanNumeral);
    }
}