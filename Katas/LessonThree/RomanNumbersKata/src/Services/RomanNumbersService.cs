namespace src.Services;

public class RomanNumbersService
{
    private readonly Dictionary<int, string> arabicToRoman = new Dictionary<int, string>
    {
        { 1, "I" },
        { 4, "IV" },
        { 5, "V" },
        { 9, "IX" },
        { 10, "X" }
    };

    public string Convert(int inputNumber)
    {
        var output = string.Empty;

        foreach (var arabic in this.arabicToRoman.Keys.OrderByDescending(key => key))
        {
            if (inputNumber < arabic)
            {
                continue;
            }
            
            output += this.arabicToRoman[arabic] + Convert(inputNumber - arabic);
            return output;
        }
        
        return output;
    }
}