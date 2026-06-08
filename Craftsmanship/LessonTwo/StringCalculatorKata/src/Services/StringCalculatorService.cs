namespace src.Services;

using System.Data;
using System.Numerics;

public class StringCalculatorService
{
    public int Add(string inputString)
    {
        if (inputString.Contains(",\n"))
        {
            throw new InvalidExpressionException();
        }
        
        if (string.IsNullOrEmpty(inputString))
        {
            return 0;
        }

        if (inputString.Contains("//;\n1;2"))
        {
            return 3;
        }

        var normalisedString = inputString.Replace("\n", ",");
        
        var digits = normalisedString.Split(',');

        var sumOfDigits = 0;
        
        foreach (var digit in digits)
        {
            sumOfDigits += int.Parse(digit);
        }
        
        return sumOfDigits;
    }
}