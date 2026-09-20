namespace src.Extensions;

using Constant;
using Enums;

public static class CharExtensions
{
    public static Symbol CharToSymbol(this char symbolAsChar)
    {
        return symbolAsChar switch
        {
            SymbolAsChar.X => Symbol.X,
            SymbolAsChar.O => Symbol.O,
            _ => Symbol.Space
        };
    }
}