namespace tests;

using FluentAssertions;
using src.Enums;
using src.Models;

public class RoverShould
{
    public static TheoryData<Command[], Position> RoverMoveData =>
        new()
        {
            { [], new Position(5, 5, Direction.North) },
            { [Command.Move], new Position(5, 6, Direction.North) },
            { [Command.TurnRight], new Position(5, 5, Direction.East) },
            { [Command.TurnRight, Command.TurnRight], new Position(5, 5, Direction.South) },
            { [Command.TurnRight, Command.TurnRight, Command.TurnRight, Command.TurnRight], new Position(5, 5, Direction.North) },
            { [Command.TurnLeft], new Position(5, 5, Direction.West) },
            { [Command.TurnLeft, Command.TurnLeft], new Position(5, 5, Direction.South) },
            { [Command.TurnRight, Command.Move], new Position(6, 5, Direction.East) },
            { [Command.TurnRight, Command.TurnRight, Command.Move], new Position(5, 4, Direction.South) },
            { [Command.TurnLeft, Command.Move], new Position(4, 5, Direction.West) }
        };

    [Theory]
    [MemberData(nameof(RoverMoveData))]
    public void ReturnCorrectPosition_GivenCommands_WhenCheckingCurrentPosition(Command[] moves, Position expectedPosition)
    {
        var startingPosition = new Position(5, 5, Direction.North);
        var rover = new Rover(startingPosition, new Map(10, 10));

        rover.TakeInstructions(moves);

        var finalPosition = rover.CurrentPosition();
        finalPosition.Should().Be(expectedPosition);
    }

    [Fact]
    public void ReturnCorrectPosition_GivenCommandsToMoveOffMap_WhenCheckingCurrentPosition()
    {
        var startingPosition = new Position(0, 0, Direction.North);
        var map = new Map(1, 1);
        var rover = new Rover(startingPosition, map);

        rover.TakeInstructions([Command.Move]);

        var expectedPosition = new Position(0, 0, Direction.North);
        var finalPosition = rover.CurrentPosition();
        finalPosition.Should().Be(expectedPosition);
    }

    [Fact]
    public void ReturnSamePostion_GivenCommands_WhenInstructionsTakeRoverOffMap()
    {
        var startingPosition = new Position(0, 0, Direction.South);
        var rover = new Rover(startingPosition, new Map(10, 10));
        
        rover.TakeInstructions([Command.Move]);
        
        var expectedPosition = new Position(0, 0, Direction.South);
        var finalPosition = rover.CurrentPosition();
        
        finalPosition.Should().Be(expectedPosition);
    }
}