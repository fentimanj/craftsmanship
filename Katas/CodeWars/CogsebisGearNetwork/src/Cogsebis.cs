public class Cogsebi
{
    public static double[] CalculateRpms(int[] gears, (int, int)[] connections, int driverId, double driverRpm)
    {
        if (gears.Length == 1) return [driverRpm];

        var rpmOfSecondCog = driverRpm * (gears[0] / (double)gears[1]);

        if (gears.Length == 3)
        {
            var rpmOfThirdCog = rpmOfSecondCog * (gears[1] / (double)gears[2]);
            return [driverRpm, -rpmOfSecondCog, rpmOfThirdCog];
        }


        if (gears.Length == 4)
        {
            var rpmOfThirdCogx = rpmOfSecondCog * (gears[1] / (double)gears[2]);
            var rpmOfFourthCog = rpmOfThirdCogx * (gears[2] / (double)gears[3]);
            return [driverRpm, -rpmOfSecondCog, rpmOfThirdCogx, -rpmOfFourthCog];
        }

        return [driverRpm, -rpmOfSecondCog];
    }
}