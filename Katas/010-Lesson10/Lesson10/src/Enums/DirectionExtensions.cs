namespace src.Enums;

public static class DirectionExtensions
{
    extension(Direction startingDirection)
    {
        public Direction TurnClockwise()
        {
            return startingDirection switch
            {
                Direction.North => Direction.East,
                Direction.East => Direction.South,
                Direction.South => Direction.West,
                _ => Direction.North
            };
        }

        public Direction TurnAntiClockwise()
        {
            return startingDirection switch
            {
                Direction.North => Direction.West,
                Direction.East => Direction.North,
                Direction.South => Direction.East,
                _ => Direction.South
            };
        }
    }
}