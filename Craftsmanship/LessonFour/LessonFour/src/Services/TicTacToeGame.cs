namespace src.Services;

using Enums;

public class TicTacToeGame
{
    private bool isXSymbolNext = true;
    private readonly List<Move> moves = new();
    
    public char NextSymbolIs()
    {
        return this.isXSymbolNext ? 'X' : 'O';
    }

    public void TakeTurn(Column column, Row rowIndex)
    {
        var move = new Move(NextSymbolIs(), column);
        this.moves.Add(move);
        this.isXSymbolNext = !this.isXSymbolNext;
    }

    public string WinnerIs()
    {
        if (this.moves.Count(move => move is { Symbol: 'X', Column: 0 }) == 3)
        {
            return "X";
        }
        
        if (this.moves.Count(move => move is { Symbol: 'O', Column: 0 }) == 3)
        {
            return "O";
        }
        return "Unknown";
    }
}

public record Move(char Symbol, Column Column);
