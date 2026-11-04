namespace Lesson10.src.Models;

public class Map(int width, int height)
{
    private readonly int xAxisLimit = width - 1;
    private readonly int yAxisLimit = height - 1;

    public bool PositionOutRange(Position currentPosition)
    {
        return currentPosition.OutsideRange(this.xAxisLimit, this.yAxisLimit);
    }

    public bool OutsideRange(Coordinates coordinates)
    {
        return this.AxisPositionsLessThanZero(coordinates.X, coordinates.Y) ||
               this.PositionExceededMapLimits(coordinates.X, coordinates.Y);
    }

    private bool PositionExceededMapLimits(int x, int y)
    {
        return x > this.xAxisLimit || y > this.yAxisLimit;
    }

    private bool AxisPositionsLessThanZero(int x, int y)
    {
        return x < 0 || y < 0;
    }
}