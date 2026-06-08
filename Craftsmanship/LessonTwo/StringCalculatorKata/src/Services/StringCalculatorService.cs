namespace src.Services;

using System.Data;

public class StringCalculatorService
{
    public int Add(string inputString)
    {
        if (inputString.Contains(",\n")) throw new InvalidExpressionException();

        if (string.IsNullOrEmpty(inputString)) return 0;

        var formattedString = string.Empty;

        if (inputString.Substring(0, 2) == "//")
        {
            formattedString = inputString.Replace("//", "");
            var deliminator = inputString.Substring(2, 1);
            formattedString = formattedString.Replace($"{deliminator}\n", "");
            formattedString = formattedString.Replace(deliminator, ",");
        }

        var normalisedString = formattedString.Replace("\n", ",");

        var digits = normalisedString.Split(',');

        var sumOfDigits = 0;

        foreach (var digit in digits) sumOfDigits += int.Parse(digit);

        return sumOfDigits;
    }
}