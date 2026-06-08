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
            formattedString = ReplaceCustomDeliminator(inputString);
        }

        var normalisedString = formattedString.Replace("\n", ",");

        var digits = normalisedString.Split(',');

        var sumOfDigits = 0;

        foreach (var digit in digits)
        {
            var parsedInteger = int.Parse(digit);
            if (parsedInteger < 0)
            {
                throw new Exception("Negative integers are not allowed");
            }
            
            sumOfDigits += int.Parse(digit);
        }

        return sumOfDigits;
    }

    private static string ReplaceCustomDeliminator(string inputString)
    {
        var formattedString = inputString.Replace("//", "");
        var deliminator = formattedString.Substring(0, 1);
        formattedString = formattedString.Replace($"{deliminator}\n", "");
        formattedString = formattedString.Replace(deliminator, ",");
        return formattedString;
    }
}