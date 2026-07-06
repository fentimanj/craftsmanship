namespace src.Services;

public class TicTacToeGame
{
    private bool isX = true;
    
    public char NextSymbolIs()
    {
        return isX ? 'X' : 'O';
    }
    
    public List<char> Board { get; set; } = new();

    public void TakeTurn(int i, int i1)
    {
        isX = false;
    }
}