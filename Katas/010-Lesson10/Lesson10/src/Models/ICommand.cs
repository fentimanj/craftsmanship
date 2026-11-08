namespace Lesson10.src.Models;

public interface ICommand
{
    void Execute();
}

public class MoveCommand(Rover rover) : ICommand
{
    public void Execute()
    {
        rover.Move();
    }
}

public class TurnLeftCommand(Rover rover) : ICommand
{
    public void Execute()
    {
        rover.TurnLeft();
    }
}

public class TurnRightCommand(Rover rover) : ICommand
{
    public void Execute()
    {
        rover.TurnRight();
    }
}

