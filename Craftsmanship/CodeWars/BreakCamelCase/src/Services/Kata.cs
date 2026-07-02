namespace src.Services;

public static class Kata
{
    public static string BreakCamelCase(string str)
    {
        if (str.IsOnlyOneWord())
        {
            return str;
        }

        var indexOfStartOfSecondWord = str.IndexOfStartOfSecondWord();

        var firstWord = str[..indexOfStartOfSecondWord];
        var secondWord = str[indexOfStartOfSecondWord..];

        return firstWord + " " + BreakCamelCase(secondWord);
    }
}