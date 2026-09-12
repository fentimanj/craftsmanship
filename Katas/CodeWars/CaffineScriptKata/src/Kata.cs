namespace src;

public static class Kata
{
    public static string CaffeineBuzz(int input)
    {
        var buzz = string.Empty;

        if (input.IsEven())
        {
            buzz = "Script";
        }

        if (input.IsDivisibleBy(3) && input.IsDivisibleBy(4))
        {
            return $"Coffee{buzz}";
        }

        if (input.IsDivisibleBy(3))
        {
            return $"Java{buzz}";
        }

        return "mocha_missing!";
    }

    private static bool IsEven(this int input)
    {
        return input % 2 == 0;
    }

    private static bool IsDivisibleBy(this int input, int divisor)
    {
        return input % divisor == 0;
    }
}