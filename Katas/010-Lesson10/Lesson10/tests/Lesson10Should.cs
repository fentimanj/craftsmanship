namespace tests;

using System.Data;
using FluentAssertions;
using src.Enums;
using src.Models;

public class Lesson10Should
{
    [Fact]
    public void ReturnSameStaringPosition_GivenNoMoves()
    {
        var startingPosition = new Position(0, 0, Direction.North);
        var rover = new Rover(startingPosition);
        
        var finalPosition = rover.CurrentPosition();
        var expectedPosition = new Position(0, 0, Direction.North);
        finalPosition.Should().Be(expectedPosition);
    }

    [Fact]
    public void ReturnOnePositionNorth_GivenOneMoveNorth_WhenCheckingCurrentPosition()
    {
        var startingPosition = new Position(0, 0, Direction.North);
        var rover = new Rover(startingPosition);

        rover.TakeInstruction(Command.Move);
        
        var finalPosition = rover.CurrentPosition();
        var expectedPosition = new Position(0, 1, Direction.North);
        finalPosition.Should().Be(expectedPosition);
    }
}