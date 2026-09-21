namespace src;

// TODO: Data Class
public class Tile(char symbolAsChar, int column)
{
    // TODO: Primitive Obsession
    private readonly int column = column;

    // TODO: Shotgun Surgery
    // TODO: Primitive Obsession
    public int Y { get; set; }
    
    private Symbol symbol = symbolAsChar.ToSymbol();

    public Symbol GetSymbol()
    {
        return this.symbol;
    }

    public void MarkWith(Symbol symbol)
    {
        this.symbol = symbol;
    }
    
    public static Func<Tile, bool> IsAt(int x, int y)
    {
        return tile => tile.column == x && tile.Y == y;
    }
}