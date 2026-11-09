namespace Lesson10.tests;

using src;
using src.Enums;

public class StringExtentionsShould
{
    public static TheoryData<string, CommandType[]> StringExtensionTestData =>
        new()
        {
            { "", [] },
            { "M", [CommandType.Move] },
            { "R", [CommandType.TurnRight] },
            { "L", [CommandType.TurnLeft] },
            { "MR", [CommandType.Move, CommandType.TurnRight] },
            { "ML", [CommandType.Move, CommandType.TurnLeft] },
            { "RML", [CommandType.TurnRight, CommandType.Move, CommandType.TurnLeft] },
            { "MRML", [CommandType.Move, CommandType.TurnRight, CommandType.Move, CommandType.TurnLeft] }
        };


    [Theory]
    [MemberData(nameof(StringExtensionTestData))]
    public void ReturnCorrectArrayOfCommands_WhenParseCommandsInvoked_GivenValidString(string commandsAsString,
        CommandType[] expectedCommands)
    {
        var actualCommands = commandsAsString.ParseCommands();

        Assert.Equal(expectedCommands, actualCommands);
    }
}