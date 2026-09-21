namespace src;

// TODO: Data Class
public class Tile(char symbolAsChar)
{
    // TODO: Shotgun Surgery
    public int X { get; set; }

    // TODO: Shotgun Surgery
    public int Y { get; set; }
    private char _symbol = symbolAsChar;

    public char GetSymbol()
    {
        return this._symbol;
    }

    public void MarkWith(char symbol)
    {
        this._symbol = symbol;
    }
    
    public static Func<Tile, bool> IsAt(int x, int y)
    {
        return tile => tile.X == x && tile.Y == y;
    }
}

