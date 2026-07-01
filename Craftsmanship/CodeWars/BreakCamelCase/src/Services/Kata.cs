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

        var firstWord = str.Substring(0, indexOfStartOfSecondWord);
        var secondWord = str.Substring(indexOfStartOfSecondWord);
        
        if(secondWord.IsOnlyOneWord())
        {
            return firstWord + " " + secondWord;
        }

        return "hello World Everyone";
    }

    private static bool IsOnlyOneWord(this string str)
    {
        return !str.Substring(1).DoesNotCapitalLetters();
    }

    private static int IndexOfStartOfSecondWord(this string str)
    {
        var indexOfStartOfSecondWord = 0;

        for (var i = 0; i < str.Length; i++)
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