namespace src.Services;

public class Kata
{
    public static string BreakCamelCase(string str)
    {
        if (str.ToLower() != str)
        {
            var indexOfStartOfSecondWord = 0;

            for (var i = 0; i < str.Length; i++)
            {
                if(str[i].ToString().ToUpper() == str[i].ToString())
                {
                    indexOfStartOfSecondWord = i;
                    break;
                }
            }
            
            var firstWord = str.Substring(0, indexOfStartOfSecondWord);
            var secondWord = str.Substring(indexOfStartOfSecondWord);
            
            return firstWord + " " + secondWord;
        }  
        
        

        return str;
    }
}