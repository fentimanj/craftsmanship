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
            { 10, "X" }
        };

        if (arabicToRoman.ContainsKey(inputNumber))
        {
            return arabicToRoman[inputNumber];
        }

        var output = string.Empty;

        foreach (var item in arabicToRoman.Keys.OrderByDescending(x => x))
        {
            while (inputNumber >= item)
            {
                output += arabicToRoman[item];
                inputNumber -= item;
            }
        }
        return output;
    }
}