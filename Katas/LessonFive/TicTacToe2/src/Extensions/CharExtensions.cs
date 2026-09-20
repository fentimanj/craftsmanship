namespace src.Extensions;

using Enums;

public static class CharExtensions
{
    public static Symbol CharToSymbol(this char symbolAsChar)
    {
        return symbolAsChar switch
        {
            'X' => Symbol.X,
            'O' => Symbol.O,
            _ => Symbol.Space
        };
    }
}