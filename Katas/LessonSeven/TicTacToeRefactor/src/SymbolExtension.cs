namespace src;

using Constant;

public static class SymbolExtension
{
    public static Symbol ToSymbol(this char symbolAsChar)
    {
        if (symbolAsChar == 'X') return Symbol.X;
        if (symbolAsChar == 'O') return Symbol.O;
        return Symbol.Space;
    }

    public static char ToChar(this Symbol symbol)
    {
        if (symbol == Symbol.X) return SymbolAsChar.X;
        if (symbol == Symbol.O) return SymbolAsChar.O;
        return SymbolAsChar.Space;
    }
}