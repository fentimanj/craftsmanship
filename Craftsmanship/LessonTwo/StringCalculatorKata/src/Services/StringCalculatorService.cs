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

        var digits = inputString.Split(',');

        if (digits.Length == 4)
        {
            return int.Parse(digits[0]) + int.Parse(digits[1]) + int.Parse(digits[2]) + int.Parse(digits[3]);
        }
        
        if (digits.Length == 3)
        {
            return int.Parse(digits[0]) + int.Parse(digits[1]) + int.Parse(digits[2]);
        }
        
        if (digits.Length == 2)
        { 
            return int.Parse(digits[0]) + int.Parse(digits[1]);
        }
        
        return int.Parse(digits[0]);
    }
}