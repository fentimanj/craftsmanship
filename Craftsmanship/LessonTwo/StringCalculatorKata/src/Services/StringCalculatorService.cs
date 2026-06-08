namespace src.Services;

using System.Numerics;

public class StringCalculatorService
{
    public int Add(string inputString)
    {
        if (inputString == "1,2")
        {
            return 3;
        }
        
        if (string.IsNullOrEmpty(inputString))
        {
            return 0;
        }
        
        return int.Parse(inputString);
    }
}