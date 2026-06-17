namespace src.Services;

public class RomanNumbersService
{
    public string Convert(int inputNumber)
    {
        var output = string.Empty;
        
        if (inputNumber == 5)
        {
            output = "V";
            inputNumber -= 5;
        }

        if (inputNumber == 6)
        {
            output = "VI";
            inputNumber -= 6;
        }

        if (inputNumber == 7)
        {
            output = "VII";
            inputNumber -= 7;
        }

        if (inputNumber > 4)
        {
            return output;
        }

        for (var i = 0; i < inputNumber; i++)
        {
            output += "I";
        }
        
        return output;
    }
}