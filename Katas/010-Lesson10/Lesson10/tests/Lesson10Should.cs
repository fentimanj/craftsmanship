namespace tests;

using FluentAssertions;

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

public enum Direction
{
    North
}

public record Position(int x, int y, Direction direction);

public class Rover
{
    private readonly Position currentPosition;

    public Rover(Position startingPosition)
    {
        this.currentPosition = startingPosition;
    }

    public Position CurrentPosition()
    {
        return this.currentPosition;
    }
}