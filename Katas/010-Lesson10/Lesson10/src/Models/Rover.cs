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

    public void TakeInstruction(Command[] moves)
    {
        if(moves.Length == 0)
        {
            return;
        }
        
        if (moves[0] == Command.TurnRight)
        {
            this.currentPosition.TurnRight();
            return;
        }
        
        this.currentPosition.Move();
    }
}