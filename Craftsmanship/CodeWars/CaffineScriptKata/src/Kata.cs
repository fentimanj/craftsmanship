namespace src;

public class Kata
{
    public static string CaffeineBuzz(int n)
    {
        if (n % 3 == 0)
        {
            return "Java";
        }
        
        return "mocha_missing!";
    }
}