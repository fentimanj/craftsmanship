namespace src.Models;

public class Position(object[] rawPosition)
{
    public int Row { get; } = (int)rawPosition[0];
    public int Column { get; } = ((string)rawPosition[1])[0];
}