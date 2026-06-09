namespace src.Services;

using System.Data;

public class StringCalculatorService
{
    public int Add(string inputString)
    {
        if (inputString.Contains(",\n")) throw new InvalidExpressionException();

        if (string.IsNullOrEmpty(inputString)) return 0;

        var deliminatorPrefix = "//";

        
        if (inputString.Contains(deliminatorPrefix))
        {
            var deliminatorSuffix = "\n";
            var withoutDeliminatorPrefix = inputString.Replace(deliminatorPrefix, "");
            var deliminator = withoutDeliminatorPrefix[0];
            var unsplitDigits = withoutDeliminatorPrefix.Replace($"{deliminator}{deliminatorSuffix}", "");
            var newDigits = unsplitDigits.Split(deliminator);
            var first = int.Parse(newDigits[0]);
            var second = int.Parse(newDigits[1]);
            
            return first + second;
        }

       

        var normalisedString = inputString.Replace("\n", ",");

        var digits = normalisedString.Split(',');

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