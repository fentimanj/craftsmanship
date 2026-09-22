namespace src;

// TODO: Data Class
public class Tile(char symbolAsChar, Position position)
{
   public Position Position = position;
    
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