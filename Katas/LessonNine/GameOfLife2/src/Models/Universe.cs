namespace src.Models;

public class Universe
{
    public Universe(Cell[] seed)
    {
        this.seed = seed;

        foreach (var cell in seed)
        {
            var otherCells = new List<Cell>();
            foreach (var otherSeed in seed)
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
        }
    }
    private Cell[] seed;

    public int LiveCells()
    {
        return this.seed.Length;
    }

    public void Tick()
    {
        this.seed = [];
    }
}