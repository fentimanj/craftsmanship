namespace src;

using Constant;

public class Position
{
    private readonly Dictionary<int, Column> intToColumn = new()
    {
        { ColumnAsInt.Left, Column.Left },
        { ColumnAsInt.Center, Column.Center },
        { ColumnAsInt.Right, Column.Right }
    };

    private readonly Dictionary<int, Row> intToRow = new()
    {
        { RowAsInt.Top, Row.Top },
        { RowAsInt.Middle, Row.Middle },
        { RowAsInt.Bottom, Row.Bottom },
    };

    public Position(Column column, Row row)
    {
        this.Column = column;
        this.Row = row;
    }

    public Position(int columnAsInt, int rowAsInt)
    {
        this.Column = this.intToColumn[columnAsInt];
        ;
        this.Row = this.intToRow[rowAsInt];;
    }

    public Column Column { get; }
    public Row Row { get; }
}