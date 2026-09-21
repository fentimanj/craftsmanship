namespace src;

// TODO: Data Class
public class Tile(char symbolAsChar, int column, int row)
{
    // TODO: Primitive Obsession
    private readonly int column = column;

    // TODO: Shotgun Surgery
    // TODO: Primitive Obsession
    private readonly int row = row;
    
    public Position Position = PositionMapper.Map(column, row);
    
    private Symbol symbol = symbolAsChar.ToSymbol();

    public Symbol GetSymbol()
    {
        return this.symbol;
    }

    public void MarkWith(Symbol symbol)
    {
        this.symbol = symbol;
    }
    
    //TODO:  Primitive Obsession
    public static Func<Tile, bool> IsAt(Position position)
    {
        return tile => tile.Position == position;
    }
}