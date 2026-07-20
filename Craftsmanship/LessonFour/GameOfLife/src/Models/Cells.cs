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
            var cellInColumnOne = cells.FirstOrDefault(cell => cell.position.columnIndex == 1);
            var cellInColumnTwo = cells.FirstOrDefault(cell => cell.position.columnIndex == 2);
            var cellInColumnThree = cells.FirstOrDefault(cell => cell.position.columnIndex == 3);
            var cellInColumnFour = cells.FirstOrDefault(cell => cell.position.columnIndex == 4);
            
            var cellInColumnOneHasCellToLeft = cells.Any(cell => cell.position.columnIndex == cellInColumnOne.position.columnIndex - 1);
            var cellInColumnOneHasCellToRight = cells.Any(cell => cell.position.columnIndex == cellInColumnOne.position.columnIndex + 1);

            if (!(cellInColumnOneHasCellToLeft && cellInColumnOneHasCellToRight))
            {
                cells.Remove(cellInColumnOne);
            }
            
       
            cells.Remove(cellInColumnTwo);
            if (cellInColumnThree == null)
            {
                cells.Remove(cellInColumnFour);
            }
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