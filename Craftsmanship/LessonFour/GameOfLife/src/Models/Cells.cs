namespace src.Models;

public class Cells(List<Cell> cells)
{
    public void KillCell()
    {
        if (cells.Count == 0)
        {
            return;
        }

        if (cells.Count == 3)
        {
            var cellInColumnOne = this.CellInColumn(1);
            var cellInColumnTwo = this.CellInColumn(2);
            var cellInColumnThree = this.CellInColumn(3);
            var cellInColumnFour = this.CellInColumn(4);

            var killCellInColumnOne = false;
            var killCellInColumnTwo = false;
            var killCellInColumnThree = false;
            var killCellInColumnFour = false;

            var cellToTheRightOfCellInColumnOne = this.GetCellToRight(cellInColumnOne);
            var cellToTheLeftOfCellInColumnOne = this.GetCellToLeft(cellInColumnOne);

            if (cellToTheRightOfCellInColumnOne == null || cellToTheLeftOfCellInColumnOne == null)
            {
                killCellInColumnOne = true;
            }

            var cellToTheRightOfCellInColumnTwo = this.GetCellToRight(cellInColumnTwo);
            var cellToTheLeftOfCellInColumnTwo = this.GetCellToLeft(cellInColumnTwo);

            if (cellToTheRightOfCellInColumnTwo == null || cellToTheLeftOfCellInColumnTwo == null)
            {
                killCellInColumnTwo = true;
            }

            var cellToTheRightOfCellInColumnThree = this.GetCellToRight(cellInColumnThree);
            var cellToTheLeftOfCellInColumnThree = this.GetCellToLeft(cellInColumnThree);

            if (cellToTheRightOfCellInColumnThree == null || cellToTheLeftOfCellInColumnThree == null)
            {
                killCellInColumnThree = true;
            }

            var cellToTheRightOfCellInColumnFour = this.GetCellToRight(cellInColumnFour);
            var cellToTheLeftOfCellInColumnFour = this.GetCellToLeft(cellInColumnFour);
            
            if(cellToTheRightOfCellInColumnFour == null || cellToTheLeftOfCellInColumnFour == null)
            {
                killCellInColumnFour = true;
            }

            if (killCellInColumnOne)
            {
                cells.Remove(cellInColumnOne);
            }

            if (killCellInColumnTwo)
            {
                cells.Remove(cellInColumnTwo);
            }

            if (killCellInColumnThree)
            {
                cells.Remove(cellInColumnThree);
            }

            if (killCellInColumnFour)
            {
                cells.Remove(cellInColumnFour);
            }
            
            return;
        }

        if (cells.Count == 2)
        {
            var cellInColumnOne = this.CellInColumn(1);
            var cellInColumnTwo = this.CellInColumn(2);
            var cellInColumnThree = this.CellInColumn(3);

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