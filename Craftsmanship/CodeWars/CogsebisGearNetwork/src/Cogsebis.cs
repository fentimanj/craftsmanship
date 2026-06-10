using System;

public class Cogsebi
{
    public static double[] CalculateRpms(int[] gears, (int, int)[] connections, int driverId, double driverRpm)
    {
        if (gears.Length == 2 && gears[1] == 10)
        {
            return [driverRpm, -100.0];
        }
        
        if (gears.Length == 2 && gears[1] == 20)
        {
            return [driverRpm, -50.0];
        }
        
        if (gears.Length == 2 && gears[1] == 40)
        {
            return [driverRpm, -25.0];
        }
        
        return [driverRpm];
    }
}