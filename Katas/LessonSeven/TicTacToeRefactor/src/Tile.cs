namespace src;

using Constant;
using Enums;

public class Tile(Position position)
{
    public char Symbol { get; set; } = SymbolAsChar.Space;
    
    private readonly Position position = position;

    public static Func<Tile, bool> IsAt(Position position)
    {
        return tile => tile.position == position;
    }
}