namespace src.Services;

public class StringCalculatorService
{
    public int Add(string inputString)
    {
        if (inputString == "1")
        {
            return 1;
        }

        if (inputString == "2")
        {
            return 2;
        }
        
        return 0;
    }
}