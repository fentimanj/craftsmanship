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
        
        //Factory Pattern here
        
        //Then
        
        //Strategy
        var commands = new Dictionary<Command, Action>
        {
            { Command.TurnRight, () => this.currentPosition.TurnClockwise() },
            { Command.TurnLeft, () => this.currentPosition.TurnAntiClockwise() },
            { Command.Move, () => this.currentPosition.Move(map) },
        };

        var executable = commands[command];
        executable.Invoke();
    }
}