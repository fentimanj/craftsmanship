namespace Lesson10.src;

using Enums;

public static class StringExtensions
{
    public static CommandType[] ParseCommands(this string commandsAsString)
    {
        var commands = new List<CommandType>();

        while (!string.IsNullOrEmpty(commandsAsString))
        {
            commands = BuildCommandTypes(commandsAsString, commands);
            commandsAsString = commandsAsString[1..];
        }
        
        return commands.ToArray();
    }

    private static List<CommandType> BuildCommandTypes(string commandsAsString, List<CommandType> commands)
    {
        if (commandsAsString.Length == 0 || string.IsNullOrEmpty(commandsAsString) || commandsAsString.Length <= 0)
        {
            return commands;
        }

        if (commandsAsString[0] == 'M')
        {
            commands.Add(CommandType.Move);
        }

        if (commandsAsString[0] == 'R')
        {
            commands.Add(CommandType.TurnRight);
        }

        if (commandsAsString[0] == 'L')
        {
            commands.Add(CommandType.TurnLeft);
        }

        return commands;
    }
}