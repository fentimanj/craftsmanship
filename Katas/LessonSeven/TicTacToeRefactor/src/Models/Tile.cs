namespace src.Models;

using Enums;

public class Tile(Symbol symbol, Position position)
{
    private readonly Position position = position;
    private Symbol symbol = symbol;

    public Symbol GetSymbol()
    {
        return this.symbol;
    }

    public void AddSymbol(Symbol newSymbol)
    {
        if (this.symbol != Symbol.Space)
        {
            throw new Exception("Invalid position");
        }
        
        this.symbol = newSymbol;
        
    }
    public static Func<Tile, bool> IsAt(Position position)
    {
        return tile => tile.position.Column == position.Column && tile.position.Row == position.Row;
    }
    
    
}