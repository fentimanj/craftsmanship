GOAL:  Remove x and y primitives in code
[X] Position should take coordinates as a ctor parameter
[ ] Position should not have x and y as integers
    [ ] StepForward should use coordinate
        [ ] Create a new AdjustBy(x,y) method
    [ ] ToString should use coordinate
    [ ] OutsideRange should use coordinate
    [ ] PositionExceededMapLimits should use coordinate
    [ ] AxisPosition should use coordinate
    [ ] TurnClockwise should use coordinate
    [ ] TurnAntiClockwise should use coordinate
[X] Coordinate should make x and y private
    [X] AxisPositoins should use coordinate
        [X] Coordinates should have it's own AxisPositionsLEssThanZero
    [X] PositionExceededMapLimits should use coordinate