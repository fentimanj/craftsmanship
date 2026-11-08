namespace Lesson10.src.Models;

using Enums;

public class TurnRightCommand(Rover rover) : ICommand
{
    public void Execute()
    {
        rover.TurnRight();
    }
}

public class CommandFactory
{
    public static ICommand Build(CommandType commandType, Rover rover)
    {
        return commandType switch
        {
            CommandType.Move => new MoveCommand(rover),
            CommandType.TurnLeft => new TurnLeftCommand(rover),
            CommandType.TurnRight => new TurnRightCommand(rover),
            _ => throw new ArgumentOutOfRangeException(nameof(commandType), commandType, null)
        };
    }
}