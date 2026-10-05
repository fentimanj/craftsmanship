namespace src.Models;

using Enums;

public struct Position(int x, int y, Direction direction)
{
    private int x = x;
    private int y = y;
    private Direction direction = direction;

    public void Move()
    {
        this.y++;
    }

    public override string ToString()
    {
        return $"{this.x}:{this.y}:{this.direction}";
    }

    public void TurnRight()
    {
        this.direction = Direction.East;
    }
}