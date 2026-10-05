namespace src.Models;

using Enums;

public class Rover
{
    private Position currentPosition;

    public Rover(Position startingPosition)
    {
        this.currentPosition = startingPosition;
    }

    public Position CurrentPosition()
    {
        return this.currentPosition;
    }

    public void TakeInstruction(Command move)
    {
        if (move == Command.TurnRight)
        {
            this.currentPosition.TurnRight();
            return;
        }
        
        this.currentPosition.Move();
    }
}