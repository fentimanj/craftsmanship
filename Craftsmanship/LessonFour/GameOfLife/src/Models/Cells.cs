namespace src.Models;

public class Cells(List<Cell> cells)
{
    public void KillCell()
    {
        var deadCells = new List<Cell>();

        if (cells.Count < 1)
        {
            return;
        }


        foreach (var cell in cells)
        {
            this.IdentifyDeadCells(cell, deadCells);
        }

        foreach (var cell in deadCells)
        {
            cells.Remove(cell);
        }
    }

    private void IdentifyDeadCells(Cell cell, List<Cell> deadCells)
    {
        if (this.HasNeighbours(cell))
        {
            deadCells.Add(cell);
        }
    }

    private bool HasNeighbours(Cell cell)
    {
        return this.GetCellToLeft(cell) == null || GetCellToRight(cell, cells) == null;
    }

    private Cell? GetCellToLeft(Cell? cellInColumnOne)
    {
        return cells.FirstOrDefault(cell => cellInColumnOne != null && cellInColumnOne.HasCellToLeft(cell));
    }

    private static Cell? GetCellToRight(Cell? cellInColumnOne, List<Cell> cells)
    {
        return cells.FirstOrDefault(cell => cellInColumnOne != null && cellInColumnOne.HasCellToRight(cell));
    }

    public int GetLivingCells()
    {
        return cells.Count;
    }
}