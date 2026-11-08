namespace Lesson10.src.Models;

public class TurnLeftCommand(Rover rover) : ICommand
{
    public void Execute()
    {
        rover.TurnLeft();
    }
}