namespace src.Models;

using Enums;

public class Rover(Position startingPosition)
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
                this.currentPosition.Move();
                break;
        }
    }
}