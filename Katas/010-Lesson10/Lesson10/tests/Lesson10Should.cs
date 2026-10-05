namespace tests;

using FluentAssertions;
using src.Enums;
using src.Models;

public class Lesson10Should
{
    public static TheoryData<Command[], Position> RoverMoveData =>
        new()
        {
            { [], new Position(0, 0, Direction.North) },
            { [Command.Move], new Position(0, 1, Direction.North) },
            { [Command.TurnRight], new Position(0, 0, Direction.East) }
        };

    [Theory]
    [MemberData(nameof(RoverMoveData))]
    public void ReturnPosition_GivenMoves_WhenCheckingCurrentPosition(Command[] moves, Position expectedPosition)
    {
        var startingPosition = new Position(0, 0, Direction.North);
        var rover = new Rover(startingPosition);

        rover.TakeInstruction(moves);

        var finalPosition = rover.CurrentPosition();
        finalPosition.Should().Be(expectedPosition);
    }
}