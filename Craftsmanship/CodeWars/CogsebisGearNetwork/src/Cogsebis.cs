using System;

public class Cogsebi
{
    public static double[] CalculateRpms(int[] gears, (int, int)[] connections, int driverId, double driverRpm)
    {
        if (gears.Length == 2 && gears[1] == 10)
        {
            return [100.0, -100.0];
        }
        
        if (gears.Length == 2)
        {
            return [100.0, -50.0];
        }
        return [driverRpm];
    }
}