namespace src.Models;

public static class CellExtensions
{
    private static Cell? GetCellToLeft(this Cell? thisCell, List<Cell> cells)
    {
        return cells.FirstOrDefault(cell => thisCell != null && thisCell.HasCellToLeft(cell));
    }

    private static Cell? GetCellToRight(this Cell? cellInColumnOne, List<Cell> allCells)
    {
        return allCells.FirstOrDefault(cell => cellInColumnOne != null && cellInColumnOne.HasCellToRight(cell));
    }

    public static bool HasNeighbour(this Cell cell, List<Cell> cells)
    {
        var cellToRight = cell.GetCellToRight(cells);
        var cellToLeft = cell.GetCellToLeft(cells);

        if (cellToLeft != null && cellToRight != null) return true;
        return false;
    }
}