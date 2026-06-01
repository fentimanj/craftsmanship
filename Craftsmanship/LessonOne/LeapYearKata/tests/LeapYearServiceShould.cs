using FluentAssertions;

namespace tests;

public class LeapYearServiceShould
{
    [Fact]
    public void IsLeapYear()
    {
        var x = 2;
        x.Should().Be(2);
    }
}