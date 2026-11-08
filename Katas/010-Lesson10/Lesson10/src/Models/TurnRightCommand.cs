namespace Lesson10.src.Models;

public class TurnRightCommand(Rover rover) : ICommand
{
    public void Execute()
    {
        rover.TurnRight();
    }
}