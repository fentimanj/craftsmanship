namespace src.Services;

public static class LeapYearService
{
    public static bool IsLeapYear(int year)
    {
        if (year.IsDivisibleBy(400))
        {
            return true;
        }
        
        return !year.IsDivisibleBy(100) && year.IsDivisibleBy(4);
    }
}

internal static class LeapYearServiceExtensions
{
    public static bool IsDivisibleBy(this int year, int divisor)
    {
        return year % divisor == 0;
    }
}