namespace Lesson10.src;

using Enums;

public static class StringExtensions
{
    public static CommandType[] ParseCommands(this string commandsAsString)
    {
        if (commandsAsString == "M") return [CommandType.Move];
        if (commandsAsString == "R") return [CommandType.TurnRight];
        if (commandsAsString == "L") return [CommandType.TurnLeft];
        
        if (commandsAsString == "MR") return [CommandType.Move, CommandType.TurnRight];
        return [];
    }
}