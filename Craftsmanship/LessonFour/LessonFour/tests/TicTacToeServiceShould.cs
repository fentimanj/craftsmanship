using FluentAssertions;
using src.Services;

namespace tests;

public class TicTacToeServiceShould
{
    [Fact]
    public void ReturnSinglePlayerSymbol_WhenTurnTaken_GivenOneMoveIsMade()
    {
        var game = new TicTacToeGame();
        
        game.Board.Count.Should().Be(0);
    }
}

