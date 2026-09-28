namespace src;

using System.Runtime.CompilerServices;
using Enums;

// TODO: Data Class
public class Tile
{
    // TODO: Shotgun Surgery
    public int X { get; set; }

    // TODO: Shotgun Surgery
    public int Y { get; set; }
    public char Symbol { get; set; }
    public Position Position { get; set; }

    public static Func<Tile, bool> IsAt(Position position)
    {
        var (x, y) = position.ToCoordinate();
        return tile => tile.X == x && tile.Y == y;
    }
}