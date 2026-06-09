namespace src.Extensions;

internal static class StringExtensions
{
    public static int ToPositiveInt(this string value)
    {
        var parsed = int.Parse(value);
        return parsed < 0 ? throw new Exception() : parsed;
    }
}