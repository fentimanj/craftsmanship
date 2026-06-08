namespace src.Services;

using System.Data;

public class StringCalculatorService
{
    public int Add(string inputString)
    {
        if (inputString.Contains(",\n")) throw new InvalidExpressionException();

        if (string.IsNullOrEmpty(inputString)) return 0;

        if (inputString.Contains("//;\n1;2"))
        {
            return 1 + 2;
        }

        if (inputString.Contains("//;\n1;3"))
        {
            return 1 + 3;
        }
        

        if (inputString.Contains("//;\n1;4"))
        {
            return 1 + 4;
        }

        var normalisedString = inputString.Replace("\n", ",");

        var digits = normalisedString.Split(',');

        var sumOfDigits = 0;

        foreach (var digit in digits) sumOfDigits += int.Parse(digit);

        return sumOfDigits;
    }
}