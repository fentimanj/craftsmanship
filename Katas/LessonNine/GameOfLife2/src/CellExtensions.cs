namespace src.Models;

public static class CellExtensions
{
    public static void BuildNeighbours(this Cell cell, List<Cell> otherCells)
    {
        foreach (var otherCell in otherCells.Where(otherCell => cell.IsNeighbourOf(otherCell)))
        {
            cell.AddNeighbourCell(otherCell);
        }
    }

    public static void KillIfUnderpopulated(this Cell cell)
    {
        if (cell.GetState() != CellState.NextGeneration)
        {
            cell.KillCell();
        }
    }

    public static List<Cell> BuildOtherCells(this Cell cell, Cell[] cells)
    {
        var otherCells = cells.Where(otherSeed => !Equals(cell, otherSeed)).ToList();
        return otherCells;
    }
}