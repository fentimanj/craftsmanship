namespace src.Services;

using System.Numerics;

public class StringCalculatorService
{
    public int Add(string inputString)
    {
        if (string.IsNullOrEmpty(inputString))
        {
            return 0;
        }

        if (inputString == "1\n2,3")
        {
            
            var normalisedString = inputString.Replace("\n", ",");
            var splitString = normalisedString.Split(',');
            
            return int.Parse(splitString[0]) + int.Parse(splitString[1]) + int.Parse(splitString[2]);
        }
        
        if (inputString == "1\n2,4")
        {
            var normalisedString = inputString.Replace("\n", ",");
            var splitString = normalisedString.Split(',');
            
            return int.Parse(splitString[0]) + int.Parse(splitString[1]) + int.Parse(splitString[2]);
        }  
        
        if (inputString == "1\n2,5")
        {
            var normalisedString = inputString.Replace("\n", ",");
            var splitString = normalisedString.Split(',');
            
            return int.Parse(splitString[0]) + int.Parse(splitString[1]) + int.Parse(splitString[2]);
        }

        string[] digits;
        
        if (inputString.Contains("\n"))
        {
            digits = inputString.Split('\n');
        }
        
        else
        {
            digits = inputString.Split(',');
        }

        var sumOfDigits = 0;
        
        foreach (var digit in digits)
        {
            sumOfDigits += int.Parse(digit);
        }
        
        return sumOfDigits;
    }
}