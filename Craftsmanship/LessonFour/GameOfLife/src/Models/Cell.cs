namespace src.Models;

public record Cell (GridPosition position)
{
}

public record GridPosition(int columnIndex){}