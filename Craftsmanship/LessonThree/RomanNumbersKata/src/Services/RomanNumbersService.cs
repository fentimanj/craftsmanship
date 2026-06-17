namespace src.Services;

public class RomanNumbersService
{
    public string Convert(int inputNumber)
    {
        var edgeCases = new Dictionary<int, string>
        {
            {
                4, "IV"
            }
        };

        if (edgeCases.ContainsKey(inputNumber))
        {
            return edgeCases[inputNumber];
        }

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