namespace src.Services;

using System.Numerics;

public class StringCalculatorService
{
    public int Add(string inputString)
    {
        if (inputString.Contains(','))
        {
            var digits = inputString.Split(',');
            var first = digits[0];
            var second = digits[1];
 
            return int.Parse(first) + int.Parse(second);
        }

      
        
        if (string.IsNullOrEmpty(inputString))
        {
            return 0;
        }
        
        return int.Parse(inputString);
    }
}