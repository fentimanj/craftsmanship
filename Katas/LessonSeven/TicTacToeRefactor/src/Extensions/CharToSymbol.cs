namespace src.Extensions;

using Constant;
using Enums;

public class CharExtensions
{
    public static Symbol CharToSymbol(char symbolAsChar)
    {
        return symbolAsChar switch
        {
            SymbolAsChar.X => Symbol.X,
            SymbolAsChar.O => Symbol.O,
            _ => Symbol.Space
        };
    }
}