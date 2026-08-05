namespace src.Models;

public class Cells(List<Cell> cells)
{
    public void KillCell()
    {
        var killList = new List<Cell>();

        foreach (var cell in cells)
        {
            var killCell = false;

            var cellToRight = GetCellToRight(cell);
            var cellToLeft = GetCellToLeft(cell);

            if (cellToLeft == null || cellToRight == null) killList.Add(cell);
        }


        foreach (var cell in killList) cells.Remove(cell);
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