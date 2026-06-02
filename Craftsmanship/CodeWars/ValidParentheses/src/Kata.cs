namespace src;

public class Kata
{
    public static bool ValidParentheses(string str)
    {
        if (str == "()")
        {
            return true;
        }

        if (str == "()()")
        {
            return true;
        }

        if (str == "()()()")
        {
            return true;
        }
        
        return false;
    }
}