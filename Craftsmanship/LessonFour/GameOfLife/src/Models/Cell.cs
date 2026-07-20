namespace src.Models;

public class Cell (GridPosition position)
{
    public GridPosition Position { get; } = position;

    public bool CellIsToLeftOf(Cell cell)
    {
        return this.Position.columnIndex == cell.GetColumnIndex() - 1;
    }

    public int GetColumnIndex()
    {
        return this.Position.columnIndex;
    }
    
}