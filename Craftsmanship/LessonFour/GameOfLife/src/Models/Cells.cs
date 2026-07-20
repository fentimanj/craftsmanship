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
            var cellone = cells[0];
            var celltwo = cells[1];
            var cellthree = cells[2];
            cells.Remove(cellone);
            cells.Remove(cellthree);
            return;
        }
        
        if (cells.Count == 2)
        {
            var cellOne = cells[0];
            var cellTwo = cells[1];
            cells.Remove(cellOne);
            cells.Remove(cellTwo);
            return;
        }
        
        if (cells.Count == 1)
        {
            var cellOne = cells[0];
            cells.Remove(cellOne);
        }
    }

    public int GetLivingCells()
    {
        return cells.Count;
    }
}