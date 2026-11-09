namespace Lesson10.src.Models;

public class Map(int width, int height)
{
    private readonly Coordinates boundaries = new(width - 1, height - 1);
}