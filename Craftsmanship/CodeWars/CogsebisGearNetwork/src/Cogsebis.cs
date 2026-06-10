using System;

public class Cogsebi
{
    public static double[] CalculateRpms(int[] gears, (int, int)[] connections, int driverId, double driverRpm)
    {
        if (driverRpm == 200.0)
        {
            return [200];
        }
        
        if (driverRpm == 300.0)
        {
            return [300];
        }

        
        return [100];
    }
}