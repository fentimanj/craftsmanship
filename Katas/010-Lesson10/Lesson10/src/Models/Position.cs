namespace src.Models;

using Enums;

public struct Position(int x, int y, Direction direction)
{
    private readonly int x = x;
    private int y = y;
    private Direction direction = direction;

    public void Move()
    {
        this.y++;
    }

    public void TurnRight()
    {
        if (this.direction == Direction.West)
        {
            this.direction = Direction.North;
            return;
        }
        this.direction++;
    }

    public override string ToString()
    {
        return $"{this.x}:{this.y}:{this.direction}";
    }
}