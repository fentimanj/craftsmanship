namespace Lesson10.src.Models;

public class MoveCommand(Rover rover) : ICommand
{
    public void Execute()
    {
        rover.Move();
    }
}