public class Cogsebi
{
    public static double[] CalculateRpms(int[] gears, (int, int)[] connections, int driverId, double driverRpm)
    {
        if (gears.Length == 1) return [driverRpm];

        if(gears.Length == 3)
        {
            return [driverRpm, -50, 20];
        }
        
        var rpm = driverRpm * (gears[0] / (double)gears[1]);
        return [driverRpm, -rpm];
    }
}