namespace Lesson10.tests;

using FluentAssertions;
using src.Enums;
using src.Models;

public class RoverShould
{
    public static TheoryData<Position, CommandType[], Position, Map, Coordinates?> RoverMoveData =>
        new()
        {
            { new Position(new Coordinates(5, 5), Direction.North), [], new Position(new Coordinates(5, 5), Direction.North), new Map(10, 10), new Coordinates(9, 9) },
            { new Position(new Coordinates(5, 5), Direction.North), [CommandType.Move], new Position(new Coordinates(5, 6), Direction.North), new Map(10, 10), new Coordinates(9, 9) },
            { new Position(new Coordinates(5, 5), Direction.North), [CommandType.TurnRight], new Position(new Coordinates(5, 5), Direction.East), new Map(10, 10),new Coordinates(9, 9) },
            { new Position(new Coordinates(5, 5), Direction.North), [CommandType.TurnRight, CommandType.TurnRight], new Position(new Coordinates(5, 5), Direction.South), new Map(10, 10),new Coordinates(9, 9) },
            {new Position(new Coordinates(5, 5), Direction.North), [CommandType.TurnRight, CommandType.TurnRight, CommandType.TurnRight, CommandType.TurnRight], new Position(new Coordinates(5, 5), Direction.North), new Map(10, 10), new Coordinates(9, 9)
            },
            { new Position(new Coordinates(5, 5), Direction.North), [CommandType.TurnLeft], new Position(new Coordinates(5, 5), Direction.West), new Map(10, 10), new Coordinates(9, 9) },
            { new Position(new Coordinates(5, 5), Direction.North), [CommandType.TurnLeft, CommandType.TurnLeft], new Position(new Coordinates(5, 5), Direction.South), new Map(10, 10), new Coordinates(9, 9) },
            { new Position(new Coordinates(5, 5), Direction.North), [CommandType.TurnRight, CommandType.Move], new Position(new Coordinates(6, 5), Direction.East), new Map(10, 10), new Coordinates(9, 9) },
            {new Position(new Coordinates(5, 5), Direction.North), 
                [CommandType.TurnRight, CommandType.TurnRight, CommandType.Move], new Position(new Coordinates(5, 4), Direction.South),
                new Map(10, 10), new Coordinates(9, 9)
            },
            {new Position(new Coordinates(5, 5), Direction.North),  [CommandType.TurnLeft, CommandType.Move], new Position(new Coordinates(4, 5), Direction.West), new Map(10, 10), new Coordinates(9, 9) },
            {new Position(new Coordinates(1, 1), Direction.North),  [CommandType.Move], new Position(new Coordinates(1, 1), Direction.North), new Map(2, 2) , new Coordinates(1, 1)},
            {new Position(new Coordinates(0, 0), Direction.South),  [CommandType.Move], new Position(new Coordinates(0, 0), Direction.South), new Map(1, 1) , new Coordinates(0, 0)},
            {new Position(new Coordinates(0, 0), Direction.West),  [CommandType.Move], new Position(new Coordinates(0, 0), Direction.West), new Map(1, 1), new Coordinates(0, 0) },
            {new Position(new Coordinates(1, 1), Direction.East),  [CommandType.Move], new Position(new Coordinates(1, 1), Direction.East), new Map(2, 2), new Coordinates(1, 1) }
        };

    [Theory]
    [MemberData(nameof(RoverMoveData))]
    public void ReturnCorrectPosition_GivenCommands_WhenCheckingCurrentPosition(Position startingPosition, CommandType[] moves,
        Position expectedPosition, Map map, Coordinates? maximumCoordinates)
    {
        var rover = new Rover(startingPosition, maximumCoordinates);

        rover.TakeInstructions(moves);

        var finalPosition = rover.CurrentPosition();
        finalPosition.Should().Be(expectedPosition);
    }
}