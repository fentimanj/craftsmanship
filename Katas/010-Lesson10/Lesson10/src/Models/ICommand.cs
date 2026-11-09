namespace Lesson10.src.Models;

public interface ICommand
{
    void Execute(Rover rover);
}