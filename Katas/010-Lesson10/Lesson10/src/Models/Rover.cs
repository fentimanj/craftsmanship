namespace Lesson10.src.Models;

using Enums;

public class Rover(Position startingPosition, Coordinates maximumCoordinates)
{
    private Position currentPosition = startingPosition;

    public Position CurrentPosition()
    {
        return this.currentPosition;
    }

    public void TakeInstructions(CommandType[] moves)
    {
        foreach (var command in moves)
        {
            this.ProcessCommand(command);
        }
    }

    public void TakeInstructions(string moves)
    {
        var commands = moves.ParseCommands();
        
        this.TakeInstructions(commands);
    }

    public void Move()
    {
        this.currentPosition.Move(maximumCoordinates);
    }

    public void TurnLeft()
    {
        this.currentPosition.TurnAntiClockwise();
    }

    public void TurnRight()
    {
        this.currentPosition.TurnClockwise();
    }
    
    private void ProcessCommand(CommandType commandType)
    {
        commandType.Build().Execute(this);
    }
}