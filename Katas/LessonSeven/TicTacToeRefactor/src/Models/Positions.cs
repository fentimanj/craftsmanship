namespace src.Models;

using Constant;

public static class Positions
{
    public static Position TopLeft = new(Column.Left, Row.Top);
    public static Position TopRight = new(Column.Right, Row.Top);
    public static Position TopCenter = new(Column.Center, Row.Top);
    public static Position MiddleLeft = new(Column.Left, Row.Middle);
    public static Position MiddleRight = new(Column.Right, Row.Middle);
    public static Position MiddleCenter = new(Column.Center, Row.Middle);
    public static Position BottomLeft = new(Column.Left, Row.Bottom);
    public static Position BottomRight = new(Column.Right, Row.Bottom);
    public static Position BottomCenter = new(Column.Center, Row.Bottom);
}