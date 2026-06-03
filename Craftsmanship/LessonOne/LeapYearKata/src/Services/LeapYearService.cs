namespace src.Services;

using Extensions;

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