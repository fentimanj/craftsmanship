namespace src.Models;

using Enums;

public struct Position(int x, int y, Direction direction)
{
    private int x = x;
    private int y = y;
    private Direction direction = direction;

    public void Move()
    {
        var movements = new Dictionary<Direction, Movement>
        {
            { Direction.East, new Movement { XAxisAdjustment = 1, YAxisAdjustment = 0 } },
            { Direction.South, new Movement { XAxisAdjustment = 0, YAxisAdjustment = -1 } },
            { Direction.West, new Movement { XAxisAdjustment = -1, YAxisAdjustment = 0 } },
            { Direction.North, new Movement { XAxisAdjustment = 0, YAxisAdjustment = 1 } }
        };

        var movement = movements[this.direction];

        this.x += movement.XAxisAdjustment;
        this.y += movement.YAxisAdjustment;
    }

    public void TurnClockwise()
    {
        this.direction = this.direction.TurnClockwise();
    }


    public void TurnAntiClockwise()
    {
        this.direction = this.direction.TurnAntiClockwise();
    }

    public override string ToString()
    {
        return $"{this.x}:{this.y}:{this.direction}";
    }

    public bool OutsideRange(int xAxisLimit, int yAxisLimit)
    {
        return this.PositionDroppedOffBottomOfMap() || 
               this.PositionExceededMapLimits(xAxisLimit, yAxisLimit);
    }

    private bool PositionExceededMapLimits(int xAxisLimit, int yAxisLimit)
    {
        return this.x > xAxisLimit || this.y > yAxisLimit;
    }

    private bool PositionDroppedOffBottomOfMap()
    {
        return this.x < 0 || this.y < 0;
    }
}