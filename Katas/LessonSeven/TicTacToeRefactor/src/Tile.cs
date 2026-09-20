namespace src;

using Constant;

//TODO:  Primitive Obsession
public class Tile
{
    public Tile(char symbol, Position position)
    {
        this.symbol = symbol;
        this.position = position;
    }

    private readonly Position position;
    private char symbol;

    public char GetSymbol()
    {
        return this.symbol;
    }

    public void AddSymbol(char newSymbol)
    {
        if (this.symbol != SymbolAsChar.Space)
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