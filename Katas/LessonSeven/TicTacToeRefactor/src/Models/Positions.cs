namespace src.Models;

using Constant;

public static class Positions
{
    public static Position TopLeft = new Position(Column.Left, Row.Top);
    public static Position TopRight = new Position(Column.Right, Row.Top);
    public static Position TopCenter = new Position(Column.Center, Row.Top);
    public static Position MiddleLeft = new Position(Column.Left, Row.Middle);
    public static Position MiddleRight = new Position(Column.Right, Row.Middle);
    public static Position MiddleCenter = new Position(Column.Center, Row.Middle);
    public static Position BottomLeft = new Position(Column.Left, Row.Bottom);
    public static Position BottomRight = new Position(Column.Right, Row.Bottom);
    public static Position BottomCenter = new Position(Column.Center, Row.Bottom);
}