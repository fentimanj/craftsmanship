namespace src;

public static class Kata
{
    public static string CaffeineBuzz(int input)
    {
        var buzz = string.Empty;

        if (input % 2 == 0)
        {
            buzz = "Script";
        }
     
        if (input.IsDivisibleByThree() && input.IsDivisibleByFour())
        {
            return $"Coffee{buzz}";
        }

        if (input.IsDivisibleByThree())
        {
            return $"Java{buzz}";
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