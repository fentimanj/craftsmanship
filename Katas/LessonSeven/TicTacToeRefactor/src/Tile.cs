namespace src;

// TODO: Data Class
public class Tile(char symbolAsChar)
{
    // TODO: Shotgun Surgery
    // TODO: Primitive Obsession
    public int X { get; set; }

    // TODO: Shotgun Surgery
    // TODO: Primitive Obsession
    public int Y { get; set; }
    
    private Symbol symbol = symbolAsChar.ToSymbol();

    public Symbol GetSymbol()
    {
        return this.symbol;
    }

    public void MarkWith(char symbol)
    {
        this.symbol = symbol.ToSymbol();
    }
    
    public static Func<Tile, bool> IsAt(int x, int y)
    {
        return tile => tile.X == x && tile.Y == y;
    }
}