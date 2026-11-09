namespace Lesson10.src.Models;

public class TurnRightCommand : ICommand
{
    public void Execute(Rover rover)
    {
        rover.TurnRight();
    }
}