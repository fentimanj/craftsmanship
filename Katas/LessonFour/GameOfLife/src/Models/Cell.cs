namespace src.Models;

public class Cell (GridPosition position)
{
    public GridPosition Position { get; } = position;

    public bool HasCellToLeft(Cell cell)
    {
        return Position.columnIndex == cell.GetColumnIndex() - 1;
    }

    public bool HasCellToRight(Cell cell)
    {
        return Position.columnIndex == cell.GetColumnIndex() + 1;
    }

    public int GetColumnIndex()
    {
        return Position.columnIndex;
    }
    
}