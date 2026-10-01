namespace src.Models;

public class Cell
{
    private Guid Guid { get; } = Guid.NewGuid();

    private HashSet<Cell> NeighbouringCells { get; set; } = new HashSet<Cell>();

    public void AddNeighbourCell(Cell cell)
    {
        if (cell.Guid == this.Guid)
        {
            return;
        }
        this.NeighbouringCells.Add(cell);
    }
    
    public CellState GetState()
    {
        if (NeighbouringCells.Count < 2)
        {
            return CellState.UnderPopulated;
        }
        
        if(NeighbouringCells.Count > 3)
        {
            return CellState.OverPopulated;
        }
        
        return CellState.NextGeneration;
    }

    
    
}

public enum CellState
{ 
    Unknown = 0,
    UnderPopulated = 1,
    NextGeneration = 2,
    OverPopulated
}