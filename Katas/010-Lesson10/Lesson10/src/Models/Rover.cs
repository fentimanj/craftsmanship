namespace Lesson10.src.Models;

using Enums;

public class Rover(Position startingPosition, Map map)
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
        var commands = new Dictionary<CommandType, ICommand>
        {
            { CommandType.TurnRight, new TurnRightCommand(this) },
            { CommandType.TurnLeft, new TurnLeftCommand(this) },
            { CommandType.Move, new MoveCommand(this) },
        };

        var executable = commands[commandType];
        executable.Execute();
    }
}