namespace src.Models;

using Enums;

public class Rover(Position startingPosition, Map? map = null)
{
    private Position currentPosition = startingPosition;

    public Position CurrentPosition()
    {
        return this.currentPosition;
    }

    public void TakeInstruction(Command[] moves)
    {
        foreach (var command in moves)
        {
            this.ProcessCommand(command);
        }
    }

    private void ProcessCommand(Command command)
    {
        switch (command)
        {
            case Command.TurnRight:
                this.currentPosition.TurnRight();
                break;
            case Command.TurnLeft:
                this.currentPosition.TurnLeft();
                break;
            case Command.Move:
                this.ProcessMove();
                break;
        }
    }

    private void ProcessMove()
    {
        var stagedPosition = this.currentPosition;
        
        this.currentPosition.Move();
        
        if (map == null)
        {
            return;
        }

        if (map.PositionOutRange(this.currentPosition))
        {
            this.currentPosition = stagedPosition;
        }
    }
}