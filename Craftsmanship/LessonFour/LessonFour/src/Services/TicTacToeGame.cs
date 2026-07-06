namespace src.Services;

using Enums;

public class TicTacToeGame
{
    private bool _isXSymbolNext = true;
    private List<Move> _moves = new();
    
    public char NextSymbolIs()
    {
        return _isXSymbolNext ? 'X' : 'O';
    }

    public void TakeTurn(Column column, Row rowIndex)
    {
        var move = new Move(NextSymbolIs(), column);
        _moves.Add(move);
        _isXSymbolNext = !_isXSymbolNext;
    }

    public string WinnerIs()
    {
        if (_moves.Count(move => move is { symbol: 'X', column: 0 }) == 3)
        {
            return "X";
        }
        
        if (_moves.Count(move => move is { symbol: 'O', column: 0 }) == 3)
        {
            return "O";
        }
        return "Unknown";
    }
}

public record Move(char symbol, Column column);
