namespace src.Services;

public class RomanNumbersService
{
    public string Convert(int inputNumber)
    {
        var romanNumerals = new[] { "I", "II", "III" };
        
        return romanNumerals[inputNumber - 1];
    }
}