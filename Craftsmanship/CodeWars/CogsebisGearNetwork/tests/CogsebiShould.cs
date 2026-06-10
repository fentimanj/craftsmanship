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

    [Theory]
    [InlineData(10.0, -100.0)]
    [InlineData(20.0, -50.0)]
    [InlineData(40.0, -25.0)]
    
    public void ReturnCorrectRpm_WhenCalculateRpmsInvoked_GivenTwoGears(int teethOnSecondCog, double expectedRpmOfSecondCog)
    {
        var rpmOfCog = Cogsebi.CalculateRpms(
            gears: [10, teethOnSecondCog],
            connections: [(0, 1)],
            driverId: 0,
            driverRpm: 100.0
        );

        rpmOfCog.Should().BeEqualTo([100.0, expectedRpmOfSecondCog]);
    }
    
    [Theory]
    [InlineData(20.0, 50.0, -50, 20)]
    [InlineData(20.0, 10.0, -50, 100)]
    
    public void ReturnCorrectRpm_WhenCalculateRpmsInvoked_GivenThreeGears(int teethOnSecondCog, int teethOnThirdCog, double expectedRpmOfSecondCog, double expectedRpmOfThirdCog)
    {
        var rpmOfCog = Cogsebi.CalculateRpms(
            gears: [10, teethOnSecondCog, teethOnThirdCog],
            connections: [(0, 1),  (1, 2)],
            driverId: 0,
            driverRpm: 100.0
        );

        rpmOfCog.Should().BeEqualTo([100.0, expectedRpmOfSecondCog, expectedRpmOfThirdCog]);
    }
}


/*
const gears = [10, 20, 50, 10];
   const connections = [[0, 1], [1, 2], [1, 3]];
   const driverId = 0;
   const driverRpm = 100.0;
   
   cogsebi(gears, connections, driverId, driverRpm);
   // Returns: [100.0, -50.0, 20.0, 100.0]
   
   
   RPM_B = RPM_A * (Teeth_A / Teeth_B)
*/