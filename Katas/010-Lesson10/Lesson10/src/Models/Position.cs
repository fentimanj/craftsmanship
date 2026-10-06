namespace src.Models;

using Enums;

public struct Position(int x, int y, Direction direction)
{
    private int x = x;
    private int y = y;
    private Direction direction = direction;

    public void Move()
    {
        if (this.direction == Direction.East)
        {
            this.x++;
            return;
        }

        if (this.direction == Direction.South)
        {
            this.y--;
            return;
        }
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

    public void TurnLeft()
    {
        if (this.direction == Direction.North)
        {
            this.direction = Direction.West;
            return;
        }
        
        this.direction--;
    }
}