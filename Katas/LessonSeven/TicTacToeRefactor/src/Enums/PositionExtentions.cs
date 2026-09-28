namespace src.Enums;

public static class PositionExtentions
{
    private static readonly Dictionary<(int, int), Position> CoordinateToPosition =
        new()
        {
            { (0, 0), Position.TopLeft },
            { (0, 1), Position.TopCenter },
            { (0, 2), Position.TopRight },
            { (1, 0), Position.MiddleLeft },
            { (1, 1), Position.MiddleCenter },
            { (1, 2), Position.MiddleRight },
            { (2, 0), Position.BottomLeft },
            { (2, 1), Position.BottomCenter },
            { (2, 2), Position.BottomRight }
        };

    public static Position From(int x, int y)
    {
        return CoordinateToPosition[(x, y)];
    }
}