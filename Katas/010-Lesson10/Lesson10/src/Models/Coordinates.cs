namespace Lesson10.src.Models;

public record Coordinates(int Y, int X)
{
    public bool AxisPositionsLessThanZero()
    {
        return this.X < 0 || this.Y < 0;
    }
}