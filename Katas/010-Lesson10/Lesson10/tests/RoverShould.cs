namespace tests;

using FluentAssertions;
using src.Enums;
using src.Models;

public class RoverShould
{
    public static TheoryData<Command[], Position> RoverMoveData =>
        new()
        {
            { [], new Position(0, 0, Direction.North) },
            { [Command.Move], new Position(0, 1, Direction.North) },
            { [Command.TurnRight], new Position(0, 0, Direction.East) },
            { [Command.TurnRight, Command.TurnRight], new Position(0, 0, Direction.South) },
            { [Command.TurnRight, Command.TurnRight, Command.TurnRight, Command.TurnRight], new Position(0, 0, Direction.North) },
            { [Command.TurnLeft],  new Position(0, 0, Direction.West) },
            { [Command.TurnLeft, Command.TurnLeft],  new Position(0, 0, Direction.South) },
            { [Command.TurnRight, Command.Move],  new Position(1, 0, Direction.East) },
            { [Command.TurnRight, Command.TurnRight, Command.Move],  new Position(0, -1, Direction.South) },
        };

    [Theory]
    [MemberData(nameof(RoverMoveData))]
    public void ReturnCorrectPosition_GivenMoves_WhenCheckingCurrentPosition(Command[] moves, Position expectedPosition)
    {
        var startingPosition = new Position(0, 0, Direction.North);
        var rover = new Rover(startingPosition);

        rover.TakeInstruction(moves);

        var finalPosition = rover.CurrentPosition();
        finalPosition.Should().Be(expectedPosition);
    }
}