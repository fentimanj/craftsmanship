namespace src.services;

public class FizzBuzzService
{
    private const string Fizz = "Fizz";
    private const string Buzz = "Buzz";

    public string Convert(int number)
    {
        var convertedNumber = string.Empty;

        if (number.IsDivisibleBy(3)) convertedNumber += Fizz;

        if (number.IsDivisibleBy(5)) convertedNumber += Buzz;

        if (string.IsNullOrEmpty(convertedNumber)) convertedNumber = number.ToString();

        return convertedNumber;
    }
}

internal static class FizzBuzzExtensions
{
    public static bool IsDivisibleBy(this int dividend, int divisor)
    {
        return dividend % divisor == 0;
    }
}