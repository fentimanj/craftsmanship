namespace tests;

using FluentAssertions;
using src.Enums;
using src.Models;

public class Lesson10Should
{
    [Fact]
    public void Return_When_Given()
    {
        var startingPosition = new Position(0, 0, Direction.North);
        Rover rover = new Rover(startingPosition );
        
        var finalPosition = rover.CurrentPosition();
        finalPosition.Should().Be(startingPosition);
    }
}