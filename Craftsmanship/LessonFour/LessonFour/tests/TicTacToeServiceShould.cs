using FluentAssertions;
using src.Services;

namespace tests;

public class TicTacToeServiceShould
{
    [Fact]
    public void ReturnEmptyBoard_WhenNewGameStarted_GivenNoMovesTaken()
    {
        var game = new TicTacToeGame();
        
        game.Board.Count.Should().Be(0);
    }

    [Fact]
    public void ReturnBoardWithOneSymbol_WhenNewGameStarted_GivenOneTurnTaken()
    {
        var game = new TicTacToeGame();
        
        game.TakeTurn('X', 0, 0);
        
        game.Board.Count.Should().Be(1);
    }
}

