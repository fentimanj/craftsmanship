namespace src.Extensions;

using Constant;
using Enums;

public class SymbolExtensions
{
    public static char SymbolToChar(Symbol symbol)
    {
        return symbol switch
        {
            Symbol.O => SymbolAsChar.O,
            Symbol.X => SymbolAsChar.X,
            _ => SymbolAsChar.Space
        };
    } 
}