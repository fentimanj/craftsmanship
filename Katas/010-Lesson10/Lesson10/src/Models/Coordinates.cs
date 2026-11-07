namespace Lesson10.src.Models;

public record Coordinates(int X, int Y)
{
    private int X { get; } = X;
    private int Y { get; } = Y;

    public bool AxisPositionsLessThanZero()
    {
        return this.X < 0 || this.Y < 0;
    }

    public bool PositionExceededMapLimits(int xAxisLimit, int yAxisLimit)
    {
        return this.X > xAxisLimit || this.Y > yAxisLimit;
    }

    public Coordinates AdjustBy(int xAxisAdjustment, int yAxisAdjustment)
    {
        var adjustedX = this.X + xAxisAdjustment;
        var adjustedY = this.Y + yAxisAdjustment;

        return new Coordinates(adjustedX, adjustedY);
    }
}