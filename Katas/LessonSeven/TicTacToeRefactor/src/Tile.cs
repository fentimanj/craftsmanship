namespace src;

using Constant;
//TODO:  Primitive Obsession
public class Tile(char symbol, Position position)
{
    private char symbol = symbol;

    private readonly Position positionLocal = position;

    public char GetSymbol() => this.symbol;
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
        return tile => tile.positionLocal.Column == position.Column && tile.positionLocal.Row == position.Row;
    }
}
