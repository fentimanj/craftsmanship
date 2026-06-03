namespace tests;

using FluentAssertions;
using src.Services;

public class LeapYearServiceShould
{
    [Theory]
    [InlineData(1996)]
    [InlineData(1992)]
    [InlineData(1984)]
    public void ReturnTrue_WhenIsLeapYearInvoked_GivenYearIsALeapYear(int year)
    {
        var leapYearService = new LeapYearService();
        var isLeapYear = leapYearService.IsLeapYear(year);
        isLeapYear.Should().BeTrue();
    }

    [Theory]
    [InlineData(1991)]
    [InlineData(1995)]
    [InlineData(1900)]
    [InlineData(1800)]
    public void ReturnFalse_WhenIsLeapYearInvoked_GivenYearIsNotALeapYear(int year)
    {
        var leapYearService = new LeapYearService();
        var isLeapYear = leapYearService.IsLeapYear(year);
        isLeapYear.Should().BeFalse();
    }
}