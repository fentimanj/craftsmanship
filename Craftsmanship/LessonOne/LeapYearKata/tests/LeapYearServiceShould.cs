using FluentAssertions;

namespace tests;

public class LeapYearServiceShould
{
    [Fact]
    public void ReturnTrue_WhenIsLeapYearInvoked_GivenYearIs1996()
    {
        
        
        var leapYearService = new LeapYearService();
        bool isLeapYear = leapYearService.IsLeapYear(1996);
        isLeapYear.Should().BeTrue();
    }
}

public class LeapYearService
{
    public bool IsLeapYear(int i)
    {
        return true;
    }
}