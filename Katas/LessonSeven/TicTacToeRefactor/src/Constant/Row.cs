namespace src.Constant;

public static class Row
{
    public const int Top = 0;
    public const int Middle = 1;
    public const int Bottom = 2;
}

public enum RowNew
{
    Top = 0,
    Middle = 1,
    Bottom = 2
}

public static class RowMapper
{
    public static RowNew RowToRowNew(int row)
    {
        if (row == Row.Top) return RowNew.Top;
        if (row == Row.Middle) return RowNew.Middle;
        if (row == Row.Bottom) return RowNew.Bottom;
        
        throw new ArgumentOutOfRangeException(nameof(row));
    }
}