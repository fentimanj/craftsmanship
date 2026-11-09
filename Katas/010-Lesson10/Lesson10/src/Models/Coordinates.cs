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

    public bool OutsideRange(Coordinates boundaries)
    {
        return this.AxisPositionsLessThanZero() ||
               this.PositionExceededMapLimits(boundaries);
    }

    public Coordinates AdjustBy(Coordinates coordinates)
    {
        var adjustedX = this.X + coordinates.X;
        var adjustedY = this.Y + coordinates.Y;

        return new Coordinates(adjustedX, adjustedY);
    }

    public override string ToString()
    {
        return $"{this.X}:{this.Y}";
    }

    public static bool OutsideRange(Coordinates inputCoordinates, Coordinates maximumCoordinates)
    {
        return inputCoordinates.OutsideRange(maximumCoordinates);
    }
}