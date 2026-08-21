namespace src.Models;

public sealed class Cells(List<Cell> cells)
{
    public void KillCells()
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

    private void AddDeadCellsToKillList(Cell cell, List<Cell> killList)
    {
        if (cell.HasNeighbour(cells)) return;

    private bool HasNeighbours(Cell cell)
    {
        return this.GetCellToLeft(cell) == null || GetCellToRight(cell, cells) == null;
    }

    public int GetLivingCells()
    {
        return cells.Count;
    }
}