namespace Lesson10.src.Models;

using Enums;
using Extensions;

public struct Position
{
    public Position(int x, int y, Direction direction)
    {
        this.x = x;
        this.y = y;
        this.direction = direction;
        this.coordinates = new Coordinates(x, y);
        
    }
    
    public Position(Coordinates coordinates, Direction direction)
    {
        this.direction = direction;
        this.coordinates = coordinates;
    }
    
    private Coordinates coordinates;
    private int x;
    private int y;
    private Direction direction;

    public void Move(Map map)
    {
        var stagedPosition = this;
        
        this.StepForward();

        if (map.PositionOutRange(this))
        {
            this = stagedPosition;
        }
    }

    private void StepForward()
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
        this.coordinates = new Coordinates(this.x, this.y);
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
        return $"{this.x}:{this.y}:{this.direction}:{this.coordinates}";
    }

    public bool OutsideRange(int xAxisLimit, int yAxisLimit)
    {
        return this.coordinates.AxisPositionsLessThanZero() || 
               this.coordinates.PositionExceededMapLimits(xAxisLimit, yAxisLimit);
    }
}