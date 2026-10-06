namespace src.Models;

public class Map(int width, int height)
{
    private readonly int indexAdjustedHeight = height - 1;
    private readonly int indexAdjustedWidth = width - 1;

    public bool PositionOutRange(Position currentPosition)
    {
        return currentPosition.WithinRange(this.indexAdjustedWidth, this.indexAdjustedHeight);
    }
}