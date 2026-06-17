namespace src.Services;

public class RomanNumbersService
{
    public string Convert(int inputNumber)
    {
        var output = string.Empty;
        
        if (inputNumber >= 5)
        {
            output = "V";
            inputNumber -= 5;
        }
        
        for (var i = 0; i < inputNumber; i++)
        {
            output += "I";
        }
        
        return output;
    }
}