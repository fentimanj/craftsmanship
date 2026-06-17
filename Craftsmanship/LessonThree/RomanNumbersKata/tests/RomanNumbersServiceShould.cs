namespace tests;

using FluentAssertions;
using src.Services;

public class RomanNumbersServiceShould
{
    [Theory]
    [InlineData(1, "I")]
    [InlineData(2, "II")]
    public void ReturnRomanNumeral_WhenConverting_GivenValidInputNumber(int inputNumber, string expectedRomanNumeral)
    {
        var romanNumbersService = new RomanNumbersService();

        var actualRomanNumeral = romanNumbersService.Convert(inputNumber);
        
        actualRomanNumeral.Should().Be(expectedRomanNumeral);
    }
}