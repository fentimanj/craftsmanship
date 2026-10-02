namespace src.Models;

public class Universe
{
    public Universe(Cell[] seedingCells)
    {
        this.cells = BuildUniverse(seedingCells);
    }

    private static Cell[] BuildUniverse(Cell[] cells)
    {
        var builtCells = cells.Where(cell => cell.GetState() != CellState.Dead).ToList();

        foreach (var cell in builtCells)
        {
            cell.ResetNeighbours();
            
            var otherCells = new List<Cell>();
            foreach (var otherSeed in cells)
            {
                if (!Equals(cell, otherSeed))
                {
                    otherCells.Add(otherSeed);
                }
            }

            foreach (var otherCell in otherCells)
            {
                if (cell.IsNeighbourOf(otherCell))
                {
                    cell.AddNeighbourCell(otherCell);
                }
            }

            if (cell.GetState() != CellState.NextGeneration)
            {
                cell.KillCell();
            }
        }

        return builtCells.ToArray();
    }

    private Cell[] cells;

    public int LiveCells()
    {
        return this.cells.Length;
    }

    public void Tick()
    {
        var newCells = new List<Cell>();
        
        var rebuiltCells = BuildUniverse(this.cells.ToArray());
        
        foreach (var cell in rebuiltCells)
        {
            if (cell.GetState() == CellState.NextGeneration)
            {
                newCells.Add(cell);
            }
        }
        
        this.cells = newCells.ToArray();
    }
}