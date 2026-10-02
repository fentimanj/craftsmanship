namespace src.Models;

public class Cell
{
    public override bool Equals(object? obj)
    {
        if (obj is Cell cell)
        {
            return this.Guid == cell.Guid;
        }
        return false;
    }

    private Guid Guid { get; } = Guid.NewGuid();

    private HashSet<Cell> NeighbouringCells { get; set; } = new HashSet<Cell>();
    public int Column { get; set; }
    public int Row { get; set; }

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


    public bool IsNeighbourOf(Cell cellUnderTest)
    {
        if (cellUnderTest.Row > this.Row + 1 || cellUnderTest.Row < this.Row - 1) 
        {
            return false;
        }
        
        if (cellUnderTest.Column > this.Column + 1 || cellUnderTest.Column < this.Column - 1) 
        {
            return false;
        }

        return true;
    }
}

public enum CellState
{ 
    Unknown = 0,
    UnderPopulated = 1,
    NextGeneration = 2,
    OverPopulated
}