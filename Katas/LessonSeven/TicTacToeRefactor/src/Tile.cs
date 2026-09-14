namespace src;

using Constant;

//TODO:  Primitive Obsession
public class Tile
{
    public Tile(char symbol, Position position, SymbolNew? symbolNew = null)
    {
        this.symbol = symbol;
        this.position = position;
        this.symbolNew = symbolNew ?? this.charToSymbol[symbol];
    }
    private readonly Dictionary<char, SymbolNew> charToSymbol = new()
    {
        { SymbolOptions.X, SymbolNew.X },
        { SymbolOptions.O, SymbolNew.O },
        { SymbolOptions.Space, SymbolNew.Space }
    };

    private readonly Position position;
    private char symbol;
    private SymbolNew symbolNew;

    public char GetSymbol()
    {
        return this.symbol;
    }

    public void AddSymbol(char newSymbol)
    {
        if (this.symbol != SymbolOptions.Space)
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

public enum SymbolNew
{
    X = 0,
    O = 1,
    Space = 2
}

