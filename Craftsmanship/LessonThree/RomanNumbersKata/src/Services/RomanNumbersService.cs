namespace src.Services;

public class RomanNumbersService
{
    public string Convert(int inputNumber)
    {
        var output = string.Empty;
        
        for (var i = 0; i < inputNumber; i++)
        {
            output += "I";
        }
        
        return output;
    }
}