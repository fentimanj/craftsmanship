namespace Lesson10.src.Models;

public record Coordinates(int X, int Y)
{
    private int X { get; } = X;
    private int Y { get; } = Y;

    public bool AxisPositionsLessThanZero()
    {
        return this.X < 0 || this.Y < 0;
    }

    public bool PositionExceededMapLimits(Coordinates coordinatesLimits)
    {
        return this.X > coordinatesLimits.X || this.Y > coordinatesLimits.Y;
    }

    public Coordinates AdjustBy(int xAxisAdjustment, int yAxisAdjustment)
    {
        var adjustedX = this.X + xAxisAdjustment;
        var adjustedY = this.Y + yAxisAdjustment;

        return new Coordinates(adjustedX, adjustedY);
    }

    public override string ToString()
    {
        return $"{this.X}:{this.Y}";
    }
}