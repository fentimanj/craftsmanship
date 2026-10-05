namespace src.Models;

public class Rover
{
    private readonly Position currentPosition;

    public Rover(Position startingPosition)
    {
        this.currentPosition = startingPosition;
    }

    public Position CurrentPosition()
    {
        return this.currentPosition;
    }
}