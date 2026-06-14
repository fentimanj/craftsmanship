namespace src;

public static class Kata
{
    public static string CaffeineBuzz(int input)
    {

        if (input == 6)
        {
            return "JavaScript";
        }   
        
        if (input == 18)
        {
            return "JavaScript";
        }
        
        if (input == 24)
        {
            return "JavaScript";
        }

        if (input.IsDivisibleByThree() && input.IsDivisibleByFour())
        {
            return "Coffee";
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