namespace src.Services;

public class RomanNumbersService
{
    public string Convert(int inputNumber)
    {
        var arabicToRoman = new Dictionary<int, string>
        {
            { 1, "I" },
            { 4, "IV" },
            { 5, "V" }
        };

        if (arabicToRoman.ContainsKey(inputNumber))
        {
            return arabicToRoman[inputNumber];
        }

        var output = string.Empty;

        if (inputNumber >= 5)
        {
            output = arabicToRoman[5];
            inputNumber -= 5;
        }

        for (var i = 0; i < inputNumber; i++)
        {
            output += arabicToRoman[1];
        }

        return output;
    }
}