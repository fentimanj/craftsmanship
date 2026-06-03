namespace src.Services;

public class LeapYearService
{
    public bool IsLeapYear(int year)
    {
        if (year.IsDivisibleByFour())
        {
            return true;
        }
        
        return false;
    }

    private static bool YearIsDivisibleByFour(int year)
    {
        return year % 4 == 0;
    }
}

internal static class LeapYearServiceExtensions
{
    public static bool IsDivisibleByFour(this int year)
    {
        return year % 4 == 0; 
    }
}