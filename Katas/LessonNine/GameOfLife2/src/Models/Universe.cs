namespace src.Models;

public class Universe(Cell[] seed)
{
    private Cell[] seed = seed;

    public int LiveCells()
    {
        return this.seed.Length;
    }

    public void Tick()
    {
        this.seed = [];
    }
}