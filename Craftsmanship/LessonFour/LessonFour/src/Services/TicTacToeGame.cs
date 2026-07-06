namespace src.Services;

public class TicTacToeGame
{
    public void TakeTurn(char playerSymbol, int rowIndex, int columnIndex)
    {
        Board.Add(playerSymbol);
    }


    public List<char> Board { get; set; } = new();
}