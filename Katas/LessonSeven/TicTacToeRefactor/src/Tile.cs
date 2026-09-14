namespace src;

using Constant;
//TODO:  Primitive Obsession
public class Tile(char symbol, Position position, PositionNew? positionNew)
{
    private char symbol = symbol;
    
    private readonly Position position = position;
    
    private readonly PositionNew positionNewLocal = positionNew ?? new PositionNew(ColumnMapper.ColumnToColumnNew(position.Column), RowMapper.RowToRowNew(position.Row));

    public char GetSymbol() => this.symbol;
    public void AddSymbol(char newSymbol)
    {
        if (this.symbol != SymbolOptions.Space)
        {
            throw new Exception("Invalid position");
        }
        this.symbol = newSymbol;
    }

    public static Func<Tile, bool> IsAt(PositionNew positionNew)
    {
        return tile => tile.positionNewLocal.column == positionNew.column && tile.positionNewLocal.row == positionNew.row;
    }

    public static Func<Tile, bool> xIsAt(Position position)
    {
        return tile => tile.position.Column == position.Column && tile.position.Row == position.Row;
    }
    
   
}
