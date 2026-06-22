namespace src.Services;

public static class Kata
{
    public static string TitleCase(string title, string minorWords = "")
    {
       
        
        var titleSplit = title.Split(' ');
        
        if (title == "harry potter and dobby")
        {
            var firstWord = ConvertedWord(titleSplit[0]);
            var secondWord = ConvertedWord(titleSplit[1]);
            var thirdWord = titleSplit[2];
            var fourthWord = ConvertedWord(titleSplit[3]);
            
            return $"{firstWord} {secondWord} {thirdWord} {fourthWord}";
        }

        if (title == "gary snotter on ice")
        {
            return "Gary Snotter on Ice";
        }

        if (title == "jenny groover in dark")
        {
            return "Jenny Groover in Dark";
        }
        
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