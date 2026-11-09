namespace Lesson10.src.Models;

using Enums;

public class Rover(Position startingPosition, Map map, Coordinates? maximumCoordinates)
{
    private Position currentPosition = startingPosition;

    private Coordinates MaximumCoordinates = maximumCoordinates ?? map.GetMaximumCoordinates();
    
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

    public void Move()
    {
        this.currentPosition.Move(map);
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
        var command = CommandFactory.Build(commandType);
        command.Execute(this);
    }
}