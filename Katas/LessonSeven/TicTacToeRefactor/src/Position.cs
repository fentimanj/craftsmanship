namespace src;

using Constant;

public class Position
{
   
    public Position(ColumnNew column, RowNew row)
    {
        this.column = column;
        this.row = row;
    }
    public Position(int columnAsInt, int rowAsInt)
    {
        this.column = this.ColumnToColumnNew(columnAsInt);
        this.row = this.RowToRowNew(rowAsInt);
    }
    public ColumnNew column { get; }
    public RowNew row { get; }
    
    public ColumnNew ColumnToColumnNew(int column)
    {
        if(column == Column.Left) return ColumnNew.Left;
        if(column == Column.Center) return ColumnNew.Center;
        if(column == Column.Right) return ColumnNew.Right;
        
        throw new ArgumentOutOfRangeException(nameof(column), column, null);
            
    }
    
    public RowNew RowToRowNew(int row)
    {
        if (row == Row.Top) return RowNew.Top;
        if (row == Row.Middle) return RowNew.Middle;
        if (row == Row.Bottom) return RowNew.Bottom;
        
        throw new ArgumentOutOfRangeException(nameof(row));
    }

}

public static class ColumnMapper
{
    
}