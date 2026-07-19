namespace src.Models;

public class SeedingCells
{
    private readonly List<Cell> cells;

    public SeedingCells(List<Cell> cells)
    {
        this.cells = cells;
    }


    public bool HasLivingCells()
    {
        return this.cells.Count > 0;
    }
}