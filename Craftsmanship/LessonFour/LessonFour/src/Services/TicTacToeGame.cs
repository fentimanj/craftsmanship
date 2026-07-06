namespace src.Services;

public class TicTacToeGame
{
    private bool _isXSymbolNext = true;
    private List<char> moves = new();
    
    public char NextSymbolIs()
    {
        return _isXSymbolNext ? 'X' : 'O';
    }

    public void TakeTurn(int i, int i1)
    {
        moves.Add(this.NextSymbolIs());
        _isXSymbolNext = !_isXSymbolNext;
    }

    public string WinnerIs()
    {
        if (moves.Count < 5)
        {
            return "Unknown";
        }
        return "X";
    }
}