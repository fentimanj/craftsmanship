namespace src.Models;

public class Cell
{

    public HashSet<Cell> NeighbouringCells { get; set; } = new HashSet<Cell>();

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