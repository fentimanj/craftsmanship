namespace src.Extensions;

internal static class LeapYearServiceExtensions
{
    public static bool IsDivisibleBy(this int year, int divisor)
    {
        return year % divisor == 0;
    }
}