namespace tests;

using FluentAssertions;

public class RomanNumbersServiceShould
{
    [Fact]
    public void ReturnCorrectNumber()
    {
        RomanNumbersService romanNumbersService = new RomanNumbersService();
        int inputNumber = 1;
        
        string expectedRomanNumeral = romanNumbersService.Convert(inputNumber);
        
        expectedRomanNumeral.Should().Be("I");
    }
}

public class RomanNumbersService
{
    public string Convert(int inputNumber)
    {
        return "I";
    }
}