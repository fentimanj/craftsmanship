namespace src.Models;

using Enums;


public class Rover(Position startingPosition, Map map)
{
    private Position currentPosition = startingPosition;

    public Position CurrentPosition()
    {
        return this.currentPosition;
    }

    public void TakeInstructions(Command[] moves)
    {
        foreach (var command in moves)
        {
            this.ProcessCommand(command);
        }
    }

    private void ProcessCommand(Command command)
    {
        var commands = new Dictionary<Command, Action>
        {
            { Command.TurnRight, () => this.currentPosition.TurnClockwise() },
            { Command.TurnLeft, () => this.currentPosition.TurnAntiClockwise() },
            { Command.Move, this.ProcessMove }
        };

        var executable = commands[command];
        executable.Invoke();
    }

    private void ProcessMove()
    {
        var stagedPosition = this.currentPosition;
        
        this.currentPosition.Move();

        if (map.PositionOutRange(this.currentPosition))
        {
            this.currentPosition = stagedPosition;
        }
    }
}