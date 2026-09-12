namespace src.Services;

using System.Data;
using Extensions;

public static class StringCalculatorService
{
    private const string DeliminatorPrefix = "//";
    private const string NewLine = "\n";

    public static int Add(this string inputString)
    {
        if (inputString.Contains(",\n")) throw new InvalidExpressionException();

        if (string.IsNullOrEmpty(inputString)) return 0;

        var deliminator = ",";

        if (inputString.Contains(DeliminatorPrefix)) deliminator = inputString.ExtractDeliminator();

        var digits = inputString
            .RemoveDeliminatorIdentifiers(deliminator)
            .Replace(NewLine, deliminator)
            .Split(deliminator);

        var sumOfDigits = 0;

        foreach (var digit in digits) sumOfDigits += digit.ToPositiveInt();

        return sumOfDigits;
    }

    private static string RemoveDeliminatorIdentifiers(this string inputString, string deliminator)
    {
        return inputString.Replace($"{deliminator}{NewLine}", "").Replace(DeliminatorPrefix, "");
    }

    private static string ExtractDeliminator(this string inputString)
    {
        return inputString[2].ToString();
    }
}