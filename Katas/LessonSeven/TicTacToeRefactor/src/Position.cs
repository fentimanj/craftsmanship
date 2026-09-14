namespace src;

using Constant;

public record Position(int Column, int Row);

public record PositionNew(ColumnNew column, RowNew row);

public static class ColumnMapper
{
    public static ColumnNew ColumnToColumnNew(int column)
    {
        if(column == Column.Left) return ColumnNew.Left;
        if(column == Column.Center) return ColumnNew.Center;
        if(column == Column.Right) return ColumnNew.Right;
        
        throw new ArgumentOutOfRangeException(nameof(column), column, null);
            
    }
    
}