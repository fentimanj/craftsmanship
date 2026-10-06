namespace src.Models;

using System.Runtime.CompilerServices;

public record Map(int width, int height)
{
    private readonly int indexAdjustedWidth = width - 1;
    private readonly int indexAdjustedHeight = height - 1;
    public bool PositionOutRange(Position currentPosition)
    {
        return currentPosition.WithinRange(indexAdjustedWidth, indexAdjustedHeight);
        return false;
    }
}