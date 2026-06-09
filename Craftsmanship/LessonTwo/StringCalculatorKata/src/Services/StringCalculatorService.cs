namespace src.Services;

using System.Data;
using Extensions;

public static class StringCalculatorService
{
    public static int Add(this string inputString)
    {
        if (inputString.Contains(",\n")) throw new InvalidExpressionException();

        if (string.IsNullOrEmpty(inputString)) return 0;

        const string deliminatorPrefix = "//";
        const string newLine = "\n";
        var deliminator = ",";
        
        if (inputString.Contains(deliminatorPrefix))
        {
            deliminator = inputString[2].ToString();
            inputString = inputString.Replace($"{deliminator}{newLine}", "");
        }
        
        var normalisedString = inputString.Replace(newLine, deliminator).Replace(deliminatorPrefix, "");

        var digits = normalisedString.Split(deliminator);

        var sumOfDigits = 0;

        foreach (var digit in digits)
        {
            sumOfDigits += digit.ToPositiveInt();
        }

        return sumOfDigits;
    }
}