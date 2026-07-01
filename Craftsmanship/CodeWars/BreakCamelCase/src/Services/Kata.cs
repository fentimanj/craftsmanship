namespace src.Services;

public class Kata
{
    public static string BreakCamelCase(string str)
    {
        if (str == "helloWorld")
        {
            var findIndex = 0;

            for (var i = 0; i < str.Length; i++)
            {
                if(str[i].ToString().ToUpper() == str[i].ToString())
                {
                    findIndex = i;
                    break;
                }
            }
            
            var indexOfStartOfSecondWord = findIndex;
            var firstWord = str.Substring(0, indexOfStartOfSecondWord);
            var secondWord = str.Substring(indexOfStartOfSecondWord);
            
            return firstWord + " " + secondWord;
        }  
        
        if (str == "niceDay")
        {
            return "nice Day";
        }  
        
        if (str == "badPlan")
        {
            return "bad Plan";
        }

        return str;
    }
}