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

        if (inputString.Contains('\n') && inputString.Contains(','))
        {
            var normalisedString = inputString.Replace("\n", ",");
            var splitString = normalisedString.Split(',');
            
            return int.Parse(splitString[0]) + int.Parse(splitString[1]) + int.Parse(splitString[2]);
        }

        string[] digits;

        if (inputString.Contains('\n'))
        {
            inputString = inputString.Replace('\n', ',');
        }

        digits = inputString.Split(',');
        

        var sumOfDigits = 0;
        
        foreach (var digit in digits)
        {
            sumOfDigits += int.Parse(digit);
        }
        
        return sumOfDigits;
    }
}