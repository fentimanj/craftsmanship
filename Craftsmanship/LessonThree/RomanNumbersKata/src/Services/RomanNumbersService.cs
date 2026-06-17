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

        while (inputNumber >= 10)
        {
            output += arabicToRoman[10];
            inputNumber -= 10;
        }

        while (inputNumber >= 5)
        {
            output += arabicToRoman[5];
            inputNumber -= 5;
        }

        while (inputNumber >= 1)
        {
            output += arabicToRoman[1];
            inputNumber -= 1;
        }

        return output;
    }
}