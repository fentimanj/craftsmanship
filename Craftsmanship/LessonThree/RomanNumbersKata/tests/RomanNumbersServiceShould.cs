namespace tests;

using FluentAssertions;
using src.Services;

public class RomanNumbersServiceShould
{
    [Theory]
    [InlineData(1, "I")]
    public void ReturnRomanNumeral_WhenConverting_GivenValidInputNumber(int inputNumber, string expectedRomanNumeral)
    {
        var romanNumbersService = new RomanNumbersService();

        var actualRomanNumeral = romanNumbersService.Convert(inputNumber);
        
        actualRomanNumeral.Should().Be(expectedRomanNumeral);
    }
}