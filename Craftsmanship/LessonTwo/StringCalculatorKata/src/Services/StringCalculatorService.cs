namespace src.Services;

using System.Numerics;

public class StringCalculatorService
{
    public int Add(string inputString)
    {
        if (string.IsNullOrEmpty(inputString))
        {
            return 0;
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