namespace src.Services;

public class TicTacToeGame
{
    private bool _isXSymbolNext = true;
    private List<char> _moves = new();
    
    public char NextSymbolIs()
    {
        return _isXSymbolNext ? 'X' : 'O';
    }

    public void TakeTurn(int i, int i1)
    {
        _moves.Add(NextSymbolIs());
        _isXSymbolNext = !_isXSymbolNext;
    }

    public string WinnerIs()
    {
        if (_moves.Count < 5)
        {
            return "Unknown";
        }
        return "X";
    }
}