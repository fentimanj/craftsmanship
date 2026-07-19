namespace src.Models;

public class Cells(List<Cell> cells)
{
    public bool HasLivingCells()
    {
        return cells.Count > 0;
    }
}