namespace Lesson10.src.Models;

public class Map(int width, int height)
{
    private readonly int xAxisLimit = width - 1;
    private readonly int yAxisLimit = height - 1;

    public bool PositionOutRange(Position currentPosition)
    {
        return currentPosition.OutsideRange(new Coordinates(this.xAxisLimit, this.yAxisLimit));
    }
    
    public bool PositionOutRange(Position currentPosition,  Coordinates coordinates)
    {
        return currentPosition.OutsideRange(coordinates);
    }
}