using FluentAssertions;
using src.Services;

namespace tests;

public class TicTacToeServiceShould
{
    [Fact]
    public void ReturnXSymbol_WhenNewGameStarted_GivenNoTurnsTaken()
    {
        var game = new TicTacToeGame();
        
        game.NextSymbolIs().Should().Be('X');
    }

    [Fact]
    public void ReturnOSymbol_WhenNewGameStarted_GivenOneTurnTaken()
    {
        var game = new TicTacToeGame();
        
        game.TakeTurn(0, 0);
        
        game.NextSymbolIs().Should().Be('O');
    }   
    
    [Fact]
    public void ReturnXSymbol_WhenNewGameStarted_GivenTwoTurnsTaken()
    {
        var game = new TicTacToeGame();
        
        game.TakeTurn(0, 0);
        game.TakeTurn(1, 0);
        
        game.NextSymbolIs().Should().Be('X');
    }

    [Fact]
    public void ReturnWinnerIsX_WhenNewGameStarted_GivenXSymbolHasALine()
    {
        var game = new TicTacToeGame();
        
        game.TakeTurn(0, 0); 
        game.TakeTurn(1, 0); 
        game.TakeTurn(0,1); 
        game.TakeTurn(1, 1); 
        game.TakeTurn(0, 2); 
        
        game.WinnerIs().Should().Be("X");
    }

    [Fact]
    public void ReturnWinnerIsUnknown_WhenNewGameStarted_GivenOnlyFourMoves()
    {
        var game = new TicTacToeGame();
        
        game.TakeTurn(0, 0);
        game.TakeTurn(1, 0);
        game.TakeTurn(2, 0);
        game.TakeTurn(3, 0);
        
        game.WinnerIs().Should().Be("Unknown");
    }

}

