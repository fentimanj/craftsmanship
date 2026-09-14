namespace src;

using Constant;
//TODO:  Primitive Obsession
public class Tile(char symbol, Position position, PositionNew? positionNew = null)
{
    private readonly int column = position.Column;
    
    private readonly int row = position.Row;
    
    private char symbol = symbol;

    public char GetSymbol() => this.symbol;
    public void AddSymbol(char newSymbol)
    {
        if (this.symbol != SymbolOptions.Space)
        {
            throw new Exception("Invalid position");
        }
        this.symbol = newSymbol;
    }

    public static Func<Tile, bool> IsAt(Position position)
    {
        return tile => tile.column == position.Column && tile.row == position.Row;
    }
    
   
}
