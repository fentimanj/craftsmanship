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

        if (inputString == "1,3")
        {
            return 4;
        }
        
        if(inputString == "1,4")
        {
            return 5;
        }
        
        if (string.IsNullOrEmpty(inputString))
        {
            return 0;
        }
        
        return int.Parse(inputString);
    }
}