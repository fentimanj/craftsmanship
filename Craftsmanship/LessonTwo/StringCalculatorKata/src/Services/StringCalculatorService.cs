namespace src.Services;

using System.Data;

public class StringCalculatorService
{
    public int Add(string inputString)
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

        foreach (var digit in digits) sumOfDigits += digit.ToPositiveInt();

        return sumOfDigits;
    }
}

internal static class StringExtensions
{
    public static int ToPositiveInt(this string value)
    {
        var parsed = int.Parse(value);
        return parsed < 0 ? throw new Exception() : parsed;
    }
}