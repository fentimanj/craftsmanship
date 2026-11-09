namespace Lesson10.src.Models;

public class TurnLeftCommand : ICommand
{
    public void Execute(Rover rover)
    {
        rover.TurnLeft();
    }
}