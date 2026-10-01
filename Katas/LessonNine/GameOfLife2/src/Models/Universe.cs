namespace src.Models;

public class Universe(Cell[] seed)
{
    public int LiveCells()
    {
        return seed.Length;
    }
}