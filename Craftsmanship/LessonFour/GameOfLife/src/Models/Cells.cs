namespace src.Models;

public class Cells(List<Cell> cells)
{
    public void KillCell()
    {
        if(cells.Count == 0)
        {
            return;
        }

        if (cells.Count == 3)
        {
            cells.RemoveAt(0);
            cells.RemoveAt(1);
            return;
        }
        
        if (cells.Count == 2)
        {
            cells.RemoveAt(1);
        }
        
        if (cells.Count == 1)
        {
            cells.RemoveAt(0);
        }
    }

    public int GetLivingCells()
    {
        return cells.Count;
    }
}