namespace Lesson10.src.Models;

using Enums;
using Extensions;

public struct Position(Coordinates coordinates, Direction direction)
{
    private Coordinates coordinates = coordinates;
    private Direction direction = direction;

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

        this.coordinates = this.coordinates.AdjustBy(movement.XAxisAdjustment, movement.YAxisAdjustment); 
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
        return $"{this.direction}:{this.coordinates}";
    }

    public bool OutsideRange(Coordinates inputCoordinates)
    {
        return this.coordinates.AxisPositionsLessThanZero() || 
               this.coordinates.PositionExceededMapLimits(inputCoordinates);
    }
}