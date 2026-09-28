namespace src;

using Constant;
using Enums;

// TODO: Data Class
public class Tile
{
    public Tile(int x, int y, Position position)
    {
        this.X = x;
        this.Y = y;
        this.Position = position;
    }
    // TODO: Shotgun Surgery
    public int X { get; }

    // TODO: Shotgun Surgery
    public int Y { get; }
    public char Symbol { get; set; } = SymbolAsChar.Space;
    public Position Position { get; set; }

    public static Func<Tile, bool> IsAt(Position position)
    {
        var (x, y) = position.ToCoordinate();
        return tile => tile.Position == position;
    }
}