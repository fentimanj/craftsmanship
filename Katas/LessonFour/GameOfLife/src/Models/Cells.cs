namespace src.Models;

public sealed class Cells(List<Cell> cells)
{
    public void ClearDeadCells()
    {
        var killList = new List<Cell>();

        foreach (var cell in cells) AddDeadCellsToKillList(cell, killList);

        foreach (var cell in killList) cells.Remove(cell);
    }

    private void AddDeadCellsToKillList(Cell cell, List<Cell> killList)
    {
        if (cell.HasNeighbour(cells)) return;

        killList.Add(cell);
    }

    public int GetLivingCells()
    {
        return cells.Count;
    }
}