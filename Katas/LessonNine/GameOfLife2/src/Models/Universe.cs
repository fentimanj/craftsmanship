namespace src.Models;

public class Universe(Cell[] seedingCells)
{
    private static Cell[] BuildUniverse(Cell[] cells)
    {
        var livingCells = cells.Where(cell => cell.GetState() != CellState.Dead).ToList();

        foreach (var cell in livingCells)
        {
            cell.ResetNeighbours();
            
            var otherCells = cell.BuildOtherCells(cells);

            cell.BuildNeighbours(otherCells);

            cell.KillIfUnderpopulated();
        }

        return livingCells.ToArray();
    }
    
    private Cell[] cells = BuildUniverse(seedingCells);

    public int LiveCells()
    {
        return this.cells.Length;
    }

    public void Tick()
    {
        var rebuiltCells = BuildUniverse(this.cells.ToArray());

        this.cells = rebuiltCells.Where(cell => cell.GetState() == CellState.NextGeneration).ToArray();
    }
}