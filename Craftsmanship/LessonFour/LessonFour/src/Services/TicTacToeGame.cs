namespace src.Services;

public class TicTacToeGame
{
    private bool _isXSymbolNext = true;
    
    public char NextSymbolIs()
    {
        return _isXSymbolNext ? 'X' : 'O';
    }

    public void TakeTurn(int i, int i1)
    {
        _isXSymbolNext = !_isXSymbolNext;
    }

    public bool SomeoneHasWon()
    {
        return true;
    }
}