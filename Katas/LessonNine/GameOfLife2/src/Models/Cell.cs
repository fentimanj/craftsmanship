namespace src.Models;

public class Cell
{
    private Guid Guid { get; } = Guid.NewGuid();

    private HashSet<Cell> NeighbouringCells { get; set; } = new();
    public int Column { get; set; }
    public int Row { get; set; }

    private bool IsDead { get; set; }

    public override bool Equals(object? obj)
    {
        if (obj is Cell cell)
        {
            return this.Guid == cell.Guid;
        }

        return false;
    }

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
        if (this.IsDead)
        {
            return CellState.Dead;
        }

        if (this.NeighbouringCells.Count < 2)
        {
            return CellState.UnderPopulated;
        }

        if (this.NeighbouringCells.Count > 3)
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

    public void KillCell()
    {
        this.IsDead = true;
    }

    public void ResetNeighbours()
    {
        this.NeighbouringCells = [];
    }
}