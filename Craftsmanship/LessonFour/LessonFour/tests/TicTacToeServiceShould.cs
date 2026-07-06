using FluentAssertions;
using src.Services;

namespace tests;

public class TicTacToeServiceShould
{
    [Fact]
    public void ReturnSinglePlayerSymbol_WhenTurnTaken_GivenOneMoveIsMade()
    {
        var game = new TicTacToeGame();
        
        game.TakeTurn('X', 0, 0);

        game.Board[0].Should().Be('X');
    }

    [Fact]
    public void ReturnTwoPlayerSymbols_WhenTurnsTaken_GivenTwoMovesAreMade()
    {
        var game = new TicTacToeGame();
        
        game.TakeTurn('X', 0, 0);
        game.TakeTurn('O', 1, 0);
        
        game.Board[1].Should().Be('O');
    }
}