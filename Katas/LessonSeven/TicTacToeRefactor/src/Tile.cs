namespace src;

// TODO: Primitive Obsession
public class Tile(Symbol symbolAsChar, Position position)
{
   public Position Position = position;
    
    private Symbol symbol = symbolAsChar;

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