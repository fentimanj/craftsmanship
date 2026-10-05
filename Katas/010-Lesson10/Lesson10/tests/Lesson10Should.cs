namespace tests;

using FluentAssertions;
using src.Enums;
using src.Models;

public class Lesson10Should
{
    [Fact]
    public void ReturnSameStaringPosition_GivenNoMoves()
    {
        var startingPosition = new Position(0, 0, Direction.North);
        Rover rover = new Rover(startingPosition);
        
        var finalPosition = rover.CurrentPosition();
        var expectedPosition = new Position(0, 0, Direction.North);
        finalPosition.Should().Be(expectedPosition);
    }
}