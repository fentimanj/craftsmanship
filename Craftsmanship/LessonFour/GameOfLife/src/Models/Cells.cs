namespace src.Models;

public class Cells(List<Cell> cells)
{
    public bool HasLivingCells()
    {
        return cells.Count > 0;
    }

    public void RemoveCell()
    {
        cells.RemoveAt(0);
    }

    public int GetLivingCells()
    {
        return cells.Count;
    }
}