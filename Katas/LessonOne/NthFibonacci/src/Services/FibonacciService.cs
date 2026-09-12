namespace src.Services;

public static class FibonacciService
{
    public static int ConvertNumber(this int input)
    {
        var conversionNMinus1 = input - 1;
        var conversionNMinus2 = input - 2;

        return input switch
        {
            0 => 0,
            1 => 1,
            _ => conversionNMinus1.ConvertNumber() + conversionNMinus2.ConvertNumber()
        };
    }
}