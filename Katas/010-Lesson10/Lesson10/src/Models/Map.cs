namespace Lesson10.src.Models;

public class Map(int width, int height)
{
    private readonly int xAxisLimit = width - 1;
    private readonly int yAxisLimit = height - 1;

    public bool PositionOutRange(Position currentPosition)
    {
        return currentPosition.OutsideRange(this.xAxisLimit, this.yAxisLimit);
    }
}