namespace src.Services;

public static class Kata
{
    public static string TitleCase(string title, string minorWords = "")
    {
        var titleSplit = title.Split(' ');
        
        if(titleSplit.Length > 1)
        {
            string output = string.Empty;
            
            foreach (var word in titleSplit)
            {
                output += TitleCase(word) + " ";
            }

            return output.Trim();
            
        }

        var convertedWord = ConvertedWord(title);
        return convertedWord;
    }

    private static string ConvertedWord(string capitalizeWord)
    {
        var firstWordFirstLetterCapitalized = capitalizeWord[0].ToString().ToUpper();
        var restOfFirstWord = capitalizeWord.Substring(1);
        var convertedFirstWord = firstWordFirstLetterCapitalized + restOfFirstWord;
        return convertedFirstWord;
    }
}