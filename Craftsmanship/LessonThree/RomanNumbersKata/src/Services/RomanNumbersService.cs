namespace src.Services;

public class RomanNumbersService
{
    public string Convert(int inputNumber)
    {
        var arabicToRoman = new Dictionary<int, string>
        {
            { 1, "I" },
            { 4, "IV" },
            { 5, "V" },
            { 9, "IX" },
            { 10, "X" }
        };

        var output = string.Empty;

        foreach (var arabic in arabicToRoman.Keys.OrderByDescending(key => key))
        {
            while (inputNumber >= arabic)
            {
                output += arabicToRoman[arabic];
                inputNumber -= arabic;
            }
        }
        
        return output;
    }
}