namespace Lesson10.src.Models;

public record Coordinates(int X, int Y)
{
    private int X { get; set; }= X;
    private int Y { get; set; }= Y;
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
        var stagedX = this.X;
        var stagedY = this.Y;
        
        var adjustedX = stagedX + xAxisAdjustment;
        var adjustedY = stagedY + yAxisAdjustment;
        
        return new Coordinates(adjustedX, adjustedY);
    }
}