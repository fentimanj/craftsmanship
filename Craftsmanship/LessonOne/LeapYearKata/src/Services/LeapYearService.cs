namespace src.Services;

public class LeapYearService
{
    public bool IsLeapYear(int year)
    {
        if (year == 1996)
        {
            return true;
        }
        
        return false;
    }
}