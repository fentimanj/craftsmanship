namespace Lesson10.src.Models;

public class MoveCommand : ICommand
{
    public void Execute(Rover rover)
    {
        rover.Move();
    }
}