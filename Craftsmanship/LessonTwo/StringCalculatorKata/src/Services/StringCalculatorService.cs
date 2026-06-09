namespace src.Services;

using System.Data;

public class StringCalculatorService
{
    public int Add(string inputString)
    {
        if (inputString.Contains(",\n")) throw new InvalidExpressionException();

        if (string.IsNullOrEmpty(inputString)) return 0;

        const string deliminatorPrefix = "//";
        var deliminator = ",";
        
        if (inputString.Contains(deliminatorPrefix))
        {
            var deliminatorSuffix = "\n";
            var withoutDeliminatorPrefix = inputString.Replace(deliminatorPrefix, "");
            deliminator = inputString[2].ToString();
            var unsplitDigits = withoutDeliminatorPrefix.Replace($"{deliminator}{deliminatorSuffix}", "");
            var newDigits = unsplitDigits.Split(deliminator);

            return int.Parse(newDigits[0]) + int.Parse(newDigits[1]);
        }



        var normalisedString = inputString.Replace("\n", deliminator).Replace(deliminatorPrefix, "");

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