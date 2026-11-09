namespace Lesson10.src.Models;

using Enums;

public static class MovementFactory
{
    public static Coordinates BuildCoordinateAdjustment(Direction direction)
    {
        return direction switch
        {
            Direction.East => new Coordinates(1, 0),
            Direction.South => new Coordinates(0, -1),
            Direction.West => new Coordinates(-1, 0),
            Direction.North => new Coordinates(0, 1),
            _ => throw new ArgumentOutOfRangeException(nameof(direction), direction, null)
        };
    }
}