namespace src;

public static class Kata
{
    public static string CaffeineBuzz(int input)
    {
        
        if (input.IsDivisibleByThree() && input.IsDivisibleByFour())
        {
            return "CoffeeScript";
        }
        
        if (input.IsDivisibleByThree())
        {
            return "Java";
        }

        return "mocha_missing!";
    }

    private static bool IsDivisibleByThree(this int input)
    {
        return input % 3 == 0;
    }
    
    private static bool IsDivisibleByFour(this int input)
    {
        return input % 4 == 0;
    }
}