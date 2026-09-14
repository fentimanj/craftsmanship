namespace src;

using Constant;

public class Position
{
    public Position(Column column, Row row)
    {
        this.Column = column;
        this.Row = row;
    }

    public Position(int columnAsInt, int rowAsInt)
    {
        this.Column = ColumnToColumnNew(columnAsInt);
        this.Row = RowToRowNew(rowAsInt);
    }

    public Column Column { get; }
    public Row Row { get; }

    private static Column ColumnToColumnNew(int columnAsInt)
    {
        return columnAsInt switch
        {
            ColumnAsInt.Left => Column.Left,
            ColumnAsInt.Center => Column.Center,
            ColumnAsInt.Right => Column.Right,
            _ => throw new ArgumentOutOfRangeException(nameof(columnAsInt), columnAsInt, null)
        };
    }

    private static Row RowToRowNew(int rowAsInt)
    {
        return rowAsInt switch
        {
            RowAsInt.Top => Row.Top,
            RowAsInt.Middle => Row.Middle,
            RowAsInt.Bottom => Row.Bottom,
            _ => throw new ArgumentOutOfRangeException(nameof(rowAsInt))
        };
    }
}