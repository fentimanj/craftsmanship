GOAL:  Remove x and y primitives in code
[X] Position should take coordinates as a ctor parameter
[ ] Position should not have x and y as integers
    [X] StepForward should use coordinate
        [X] Create a new AdjustBy(x,y) method
    [X] ToString should use coordinate
    [X] OutsideRange should use coordinate
    [X] PositionExceededMapLimits should use coordinate
    [X] AxisPosition should use coordinate
    [X] TurnClockwise should use coordinate
    [X] TurnAntiClockwise should use coordinate
[X] Coordinate should make x and y private
    [X] AxisPositoins should use coordinate
        [X] Coordinates should have it's own AxisPositionsLEssThanZero
    [X] PositionExceededMapLimits should use coordinate