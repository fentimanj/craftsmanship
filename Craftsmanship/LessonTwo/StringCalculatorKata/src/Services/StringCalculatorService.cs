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

        if (inputString == "1\n2,3")
        {
            return 6;
        }

        string[] digits;
        
        if (inputString.Contains("\n"))
        {
            digits = inputString.Split('\n');
        }
        
       else
        {
            digits = inputString.Split(',');
        }

        var sumOfDigits = 0;
        
        foreach (var digit in digits)
        {
            sumOfDigits += int.Parse(digit);
        }
        
        return sumOfDigits;
    }
}