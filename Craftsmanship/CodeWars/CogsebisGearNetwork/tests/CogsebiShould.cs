namespace tests;

using FluentAssertions;

public class CogsebiShould
{
    [Fact]
    public void ReturnCorrectRpms_WhenCalculateRpmsInvoked_GivenOnlyOneGear()
    {
        int[] gears = [10];
        (int, int)[] connections = [];
        int driverId = 0;
        double driverRpm = 100;
        
        double[] rpmOfCog = Cogsebi.CalculateRpms(gears, connections, driverId, driverRpm);
        
        rpmOfCog.First().Should().Be(100.0);
    }
}


/*
const gears = [10, 20, 50, 10];
   const connections = [[0, 1], [1, 2], [1, 3]];
   const driverId = 0;
   const driverRpm = 100.0;
   
   cogsebi(gears, connections, driverId, driverRpm);
   // Returns: [100.0, -50.0, 20.0, 100.0]
*/