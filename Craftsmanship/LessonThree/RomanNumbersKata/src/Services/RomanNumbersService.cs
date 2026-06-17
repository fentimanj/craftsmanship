namespace src.Services;

public class RomanNumbersService
{
    public string Convert(int inputNumber)
    {
        if (inputNumber == 2)
        {
            return "II";
        }
        return "I";
    }
}