namespace Lesson10.src.Models;

using Enums;

public static class CommandFactory
{
    public static ICommand Build(CommandType commandType)
    {
        return commandType switch
        {
            CommandType.Move => new MoveCommand(),
            CommandType.TurnLeft => new TurnLeftCommand(),
            CommandType.TurnRight => new TurnRightCommand(),
            _ => throw new ArgumentOutOfRangeException(nameof(commandType), commandType, null)
        };
    }
}