namespace src.Services;

public class TicTacToeGame
{
    private bool _isXSymbolNext = true;
    private List<Move> _moves = new();
    
    public char NextSymbolIs()
    {
        return _isXSymbolNext ? 'X' : 'O';
    }

    public void TakeTurn(int columnIndex, int rowIndex)
    {
        var move = new Move(NextSymbolIs(), columnIndex);
        _moves.Add(move);
        _isXSymbolNext = !_isXSymbolNext;
    }

    public string WinnerIs()
    {
        if (_moves.Count(move => move.symbol == 'X' && move.column == 0) == 3)
        {
            return "X";
        }
        
        if (_moves.Count(move => move.symbol == 'O' && move.column == 0) == 3)
        {
            return "O";
        }
        return "Unknown";
    }
}

public record Move(char symbol, int column);
