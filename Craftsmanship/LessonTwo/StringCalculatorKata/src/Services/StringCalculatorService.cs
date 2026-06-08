namespace src.Services;

using System.Numerics;

public class StringCalculatorService
{
    public int Add(string inputString)
    {
        if (inputString.Contains(','))
        {
            var digits = inputString.Split(',');

            return int.Parse(digits[0]) + int.Parse(digits[1]);
        }
        
        if (string.IsNullOrEmpty(inputString))
        {
            return 0;
        }
        
        return int.Parse(inputString);
    }
}