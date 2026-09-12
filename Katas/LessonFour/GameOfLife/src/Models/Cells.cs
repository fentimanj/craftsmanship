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
            var cellInColumnOne = CellInColumn(1);
            var cellInColumnTwo = CellInColumn(2);
            var cellInColumnThree = CellInColumn(3);
            var cellInColumnFour = CellInColumn(4);
            
            var cellToTheRightOfCellInColumnOne = GetCellToRight(cellInColumnOne);
            var cellToTheLeftOfCellInColumnOne = GetCellToLeft(cellInColumnOne);

            if (cellToTheRightOfCellInColumnOne == null || cellToTheLeftOfCellInColumnOne == null)
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

    private Cell? GetCellToLeft(Cell? cellInColumnOne)
    {
        return cells.FirstOrDefault(cell => cellInColumnOne != null && cellInColumnOne.HasCellToLeft(cell));
    }

    private Cell? GetCellToRight(Cell? cellInColumnOne)
    {
        return cells.FirstOrDefault(cell => cellInColumnOne != null && cellInColumnOne.HasCellToRight(cell));
    }

    private Cell? CellInColumn(int columnIndex)
    {
        return cells.FirstOrDefault(cell => cell.GetColumnIndex() == columnIndex);
    }

    public int GetLivingCells()
    {
        return cells.Count;
    }
}