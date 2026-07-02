namespace src.Services;

public static class StringExtensions
{
    public static bool IsOnlyOneWord(this string str)
    {
        return !str.Substring(1).DoesNotCapitalLetters();
    }
    
    public static int IndexOfStartOfSecondWord(this string str)
    {
        var indexOfStartOfSecondWord = 1;

        for (var i = 1; i < str.Length; i++)
        {
            var currentChar = str[i];
            if(currentChar.IsCapitalLetter())
            {
                indexOfStartOfSecondWord = i;
                break;
            }
        }

        return indexOfStartOfSecondWord;
    }

    private static bool IsCapitalLetter(this char currentChar)
    {
        return currentChar.ToString().ToUpper() == currentChar.ToString();
    }

    private static bool DoesNotCapitalLetters(this string str)
    {
        return str.ToLower() != str;
    }
}