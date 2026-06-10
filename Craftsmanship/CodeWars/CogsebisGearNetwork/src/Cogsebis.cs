public class Cogsebi
{
    public static double[] CalculateRpms(int[] gears, (int, int)[] connections, int driverId, double driverRpm)
    {
        if (gears.Length == 1) return [driverRpm];
        
        var rpmOfSecondCog = driverRpm * (gears[0] / (double)gears[1]);
        
        if(gears.Length == 3)
        {
            var repmOfThirdCog = rpmOfSecondCog * (gears[1] / (double)gears[2]);
            return [driverRpm, -rpmOfSecondCog, repmOfThirdCog];
        }
        
        return [driverRpm, -rpmOfSecondCog];
    }
}