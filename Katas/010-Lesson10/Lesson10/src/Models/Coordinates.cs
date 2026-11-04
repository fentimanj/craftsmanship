namespace Lesson10.src.Models;

public record Coordinates(int X, int Y)
{
    public bool AxisPositionsLessThanZero()
    {
        return X < 0 || Y < 0;
    }
}