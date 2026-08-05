namespace src.Models;

public class Cells(List<Cell> cells)
{
    public void ClearDeadCells()
    {
        var killList = new List<Cell>();

        foreach (var cell in cells) AddDeadCellsToKillList(cell, killList);

        foreach (var cell in killList) cells.Remove(cell);
    }

    private void AddDeadCellsToKillList(Cell cell, List<Cell> killList)
    {
        var cellToRight = GetCellToRight(cell);
        var cellToLeft = GetCellToLeft(cell);

        if (cellToLeft != null && cellToRight != null) return;

        killList.Add(cell);
    }

    private Cell? GetCellToLeft(Cell? thisCell)
    {
        return cells.FirstOrDefault(cell => thisCell != null && thisCell.HasCellToLeft(cell));
    }

    private Cell? GetCellToRight(Cell? cellInColumnOne)
    {
        return cells.FirstOrDefault(cell => cellInColumnOne != null && cellInColumnOne.HasCellToRight(cell));
    }

    private Cell? CellInColumn(int columnIndex)
    {
        return cells.FirstOrDefault(cell => cell.GetColumnIndex() == columnIndex);
    }

    public int GetLivingCells()
    {
        return cells.Count;
    }
}