namespace src;

public enum Position
{
    TopLeft,
    TopCenter,
    TopRight,
    MiddleLeft,
    MiddleCenter,
    MiddleRight,
    BottomLeft,
    BottomCenter,
    BottomRight
}

public static class PositionExtensions
{
    public static Position ToPosition(this (int column, int row) position)
    {
        switch (position.row)
        {
            case 0 when position.column == 0:
                return Position.TopLeft;
            case 0 when position.column == 1:
                return Position.TopCenter;
            case 0:
                return Position.TopRight;
            case 1 when position.column == 0:
                return Position.MiddleLeft;
            case 1 when position.column == 1:
                return Position.MiddleCenter;
            case 1:
                return Position.MiddleRight;
        }

        return position.column switch
        {
            0 => Position.BottomLeft,
            1 => Position.BottomCenter,
            _ => Position.BottomRight
        };
    }
}