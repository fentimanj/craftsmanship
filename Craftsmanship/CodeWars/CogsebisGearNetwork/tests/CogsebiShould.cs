namespace tests;

using FluentAssertions;

public class CogsebiShould
{
    [Theory]
    [InlineData(100.0, 100.0)]
    [InlineData(200.0, 200.0)]
    [InlineData(300.0, 300.0)]
    public void ReturnCorrectRpms_WhenCalculateRpmsInvoked_GivenOnlyOneGear(double driverRpm, double expected)
    {
        int[] gears = [10];
        (int, int)[] connections = [];
        const int driverId = 0;
        
        var rpmOfCog = Cogsebi.CalculateRpms(gears, connections, driverId, driverRpm);
        
        rpmOfCog.First().Should().Be(expected);
    }
    
    [Fact]
    
}


/*
const gears = [10, 20, 50, 10];
   const connections = [[0, 1], [1, 2], [1, 3]];
   const driverId = 0;
   const driverRpm = 100.0;
   
   cogsebi(gears, connections, driverId, driverRpm);
   // Returns: [100.0, -50.0, 20.0, 100.0]
*/