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

        var command = CreateCommandType(commandsAsString[0]);
        commands.Add(command);

        return commands;
    }

    private static CommandType CreateCommandType(char commandAsChar)
    {
        var charToCommandMap = new Dictionary<char, CommandType>()
        {
            { 'M', CommandType.Move },
            { 'R', CommandType.TurnRight },
            { 'L', CommandType.TurnLeft },
        };

        return charToCommandMap[commandAsChar];
    }
}