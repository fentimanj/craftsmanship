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

        if (Coordinates.OutsideRange(this.coordinates, map.GetMaximumCoordinates()))
        {
            this = stagedPosition;
        }
    }

    private void StepForward()
    {
        var movementCoordinate = MovementFactory.BuildMovementCoordinate(this.direction);

        this.coordinates = this.coordinates.AdjustBy(movementCoordinate); 
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