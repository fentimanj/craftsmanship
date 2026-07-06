namespace src.Services;

public class TicTacToeGame
{
    public static char NextSymbolIs()
    {
        return 'X';
    }


    public List<char> Board { get; set; } = new();
}