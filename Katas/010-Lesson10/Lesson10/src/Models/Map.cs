namespace Lesson10.src.Models;

public class Map(int width, int height)
{
    private readonly Coordinates Boundaries = new(width - 1, height - 1);

    public Coordinates GetMaximumCoordinates()
    {
        return this.Boundaries;
    }
}