namespace src.Models;

using Records;

public interface IBoard
{
    bool IsMoveAllowed(Move move);
    void AddMove(Move move);
    string WinningSymbol();
}