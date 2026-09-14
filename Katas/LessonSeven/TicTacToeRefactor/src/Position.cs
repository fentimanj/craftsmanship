namespace src;

using Constant;

public record Position(int Column, int Row);

public record PositionNew(ColumnNew column, RowNew row);

public class ColumnMapper
{
    public ColumnNew ColumnToColumnNew(char column)
    {
        if(column == Column.Left) return ColumnNew.Left;
        if(column == Column.Center) return ColumnNew.Center;
        if(column == Column.Right) return ColumnNew.Right;
        
        throw new ArgumentOutOfRangeException(nameof(column), column, null);
            
    }
    
}