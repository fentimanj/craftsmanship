namespace src;

using Constant;
using Enums;

// TODO: Data Class
public class Tile
{
    public Tile(Position position)
    {
        this.position = position;
    }
    public char Symbol { get; set; } = SymbolAsChar.Space;
    
    private readonly Position position;

    public static Func<Tile, bool> IsAt(Position position)
    {
        return tile => tile.position == position;
    }
}