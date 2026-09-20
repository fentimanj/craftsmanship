namespace src.Models;

using Constant;
using Enums;
using Extensions;

//TODO:  Primitive Obsession
public class Tile
{
    private readonly Position position;
    private Symbol symbol;
    private char symbolAsChar;

    public Tile(char symbolAsChar, Position position)
    {
        this.symbolAsChar = symbolAsChar;
        this.position = position;
        this.symbol = symbolAsChar.CharToSymbol();
    }

    public Tile(Symbol symbol, Position position)
    {
        this.symbol = symbol;
        this.position = position;
        this.symbolAsChar = symbol.SymbolToChar();
    }

    public char GetSymbolAsChar()
    {
        return this.symbolAsChar;
    }

    public Symbol GetSymbol()
    {
        return this.symbol;
    }

    public void AddSymbol(char newSymbol)
    {
        if (this.symbolAsChar != SymbolAsChar.Space)
        {
            throw new Exception("Invalid position");
        }

        this.symbolAsChar = newSymbol;
    }

    public void AddSymbo(Symbol newSymbol)
    {
        if (this.symbol != Symbol.Space)
        {
            throw new Exception("Invalid position");
        }
        
        this.symbol = newSymbol;
        
    }
    public static Func<Tile, bool> IsAt(Position position)
    {
        return tile => tile.position.Column == position.Column && tile.position.Row == position.Row;
    }
    
    
}