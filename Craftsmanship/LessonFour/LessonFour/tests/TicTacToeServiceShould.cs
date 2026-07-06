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
}

