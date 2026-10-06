namespace src.Models;

using Enums;

public struct Position(int x, int y, Direction direction)
{
    private int x = x;
    private int y = y;
    private Direction direction = direction;

    public void Move()
    {
        switch (this.direction)
        {
            case Direction.East:
                this.x++;
                break;
            case Direction.South:
                this.y--;
                break;
            case Direction.West:
                this.x--;
                break;
            case Direction.North:
                this.y++;
                break;
        }
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
    
    public void TurnLeft()
    {
        if (this.direction == Direction.North)
        {
            this.direction = Direction.West;
            return;
        }

        this.direction--;
    }

    public override string ToString()
    {
        return $"{this.x}:{this.y}:{this.direction}";
    }

    public bool WithinRange(int width, int height)
    {
        return this.x > width || this.y > height;
    }
}