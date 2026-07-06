using FluentAssertions;

public class TicTacToeServiceShould
{
    [Fact]
    public void Return_When_Given()
    {
        var game = new TicTacToeGame();
        
        game.TakeTurn('X', 0, 0);

        game.Board[0].Should().Be('X');
    }
}

public class TicTacToeGame
{
    public void TakeTurn(char playerSymbol, int i, int i1)
    {
        
    }


    public List<char> Board { get; set; } = new List<char>(){'X'};
}
