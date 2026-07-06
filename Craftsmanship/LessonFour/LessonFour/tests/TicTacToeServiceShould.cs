using FluentAssertions;
using src.Services;

namespace tests;

public class TicTacToeServiceShould
{
    [Fact]
    public void ReturnEmptyBoard_WhenNewGameStarted_GivenNoMovesTaken()
    {
        var game = new TicTacToeGame();
        
        TicTacToeGame.NextSymbolIs().Should().Be('X');
    }

    // [Fact]
    // public void ReturnBoardWithOneSymbol_WhenNewGameStarted_GivenOneTurnTaken()
    // {
    //     var game = new TicTacToeGame();
    //     
    //     game.TakeTurn( 0, 0);
    //     
    //     game.NextSymbolIs().Should().Be('O');
    // }
}

