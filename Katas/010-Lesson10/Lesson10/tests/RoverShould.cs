namespace Lesson10.tests;

using FluentAssertions;
using Lesson10.src.Enums;
using Lesson10.src.Models;

public class RoverShould
{
    public static TheoryData<Position, Command[], Position, Map> RoverMoveData =>
        new()
        {
            { new Position(new Coordinates(5, 5), Direction.North), [], new Position(new Coordinates(5, 5), Direction.North), new Map(10, 10) },
            { new Position(new Coordinates(5, 5), Direction.North), [Command.Move], new Position(new Coordinates(5, 6), Direction.North), new Map(10, 10) },
            { new Position(new Coordinates(5, 5), Direction.North), [Command.TurnRight], new Position(new Coordinates(5, 5), Direction.East), new Map(10, 10) },
            { new Position(new Coordinates(5, 5), Direction.North), [Command.TurnRight, Command.TurnRight], new Position(new Coordinates(5, 5), Direction.South), new Map(10, 10) },
            {new Position(new Coordinates(5, 5), Direction.North), 
                [Command.TurnRight, Command.TurnRight, Command.TurnRight, Command.TurnRight],
                new Position(new Coordinates(5, 5), Direction.North), new Map(10, 10)
            },
            { new Position(new Coordinates(5, 5), Direction.North), [Command.TurnLeft], new Position(new Coordinates(5, 5), Direction.West), new Map(10, 10) },
            { new Position(new Coordinates(5, 5), Direction.North), [Command.TurnLeft, Command.TurnLeft], new Position(new Coordinates(5, 5), Direction.South), new Map(10, 10) },
            { new Position(new Coordinates(5, 5), Direction.North), [Command.TurnRight, Command.Move], new Position(new Coordinates(6, 5), Direction.East), new Map(10, 10) },
            {new Position(new Coordinates(5, 5), Direction.North), 
                [Command.TurnRight, Command.TurnRight, Command.Move], new Position(new Coordinates(5, 4), Direction.South),
                new Map(10, 10)
            },
            {new Position(new Coordinates(5, 5), Direction.North),  [Command.TurnLeft, Command.Move], new Position(new Coordinates(4, 5), Direction.West), new Map(10, 10) },
            {new Position(new Coordinates(1, 1), Direction.North),  [Command.Move], new Position(new Coordinates(1, 1), Direction.North), new Map(2, 2) },
            {new Position(new Coordinates(0, 0), Direction.South),  [Command.Move], new Position(new Coordinates(0, 0), Direction.South), new Map(1, 1) },
            {new Position(new Coordinates(0, 0), Direction.West),  [Command.Move], new Position(new Coordinates(0, 0), Direction.West), new Map(1, 1) },
            {new Position(new Coordinates(1, 1), Direction.East),  [Command.Move], new Position(new Coordinates(1, 1), Direction.East), new Map(2, 2) }
        };

    [Theory]
    [MemberData(nameof(RoverMoveData))]
    public void ReturnCorrectPosition_GivenCommands_WhenCheckingCurrentPosition(Position startingPosition, Command[] moves,
        Position expectedPosition, Map map)
    {
        var rover = new Rover(startingPosition, map);

        rover.TakeInstructions(moves);

        var finalPosition = rover.CurrentPosition();
        finalPosition.Should().Be(expectedPosition);
    }
}