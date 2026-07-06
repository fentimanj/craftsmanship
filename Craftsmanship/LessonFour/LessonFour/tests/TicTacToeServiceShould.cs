using FluentAssertions;
using src.Services;

namespace tests;

using src.Enums;

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
        
        game.TakeTurn(Column.Left, 0);
        game.TakeTurn(Column.Centre, 0);
        
        game.NextSymbolIs().Should().Be('X');
    }
    
    
    
    [Fact]
    public void ReturnWinnerIsX_WhenNewGameStarted_GivenXSymbolHasALineInFirstColumn()
    {
        var game = new TicTacToeGame();
        
        game.TakeTurn(Column.Left, Row.Top); 
        game.TakeTurn(Column.Centre, Row.Top); 
        game.TakeTurn(Column.Left,Row.Middle); 
        game.TakeTurn(Column.Centre, Row.Middle); 
        game.TakeTurn(Column.Left, Row.Bottom); 
        
        game.WinnerIs().Should().Be("X");
    }

    [Fact]
    public void ReturnWinnerIsUnknown_WhenNewGameStarted_GivenOnlyFourMoves()
    {
        var game = new TicTacToeGame();
        
        game.TakeTurn(Column.Left, Row.Top);
        game.TakeTurn(Column.Centre, Row.Top);
        game.TakeTurn(Column.Right, Row.Top);
        game.TakeTurn(Column.Centre, Row.Middle);
        
        game.WinnerIs().Should().Be("Unknown");
    }
    
    [Fact]
    public void ReturnWinnerIsO_WhenNewGameStarted_Given0SymbolHasALineInFirstColumn()
    {
        var game = new TicTacToeGame();
        
        game.TakeTurn(Column.Right, Row.Bottom); 
        game.TakeTurn(Column.Left, Row.Top); 
        game.TakeTurn(Column.Centre, Row.Top); 
        game.TakeTurn(Column.Left,Row.Middle); 
        game.TakeTurn(Column.Centre, Row.Middle); 
        game.TakeTurn(Column.Left, Row.Bottom); 
        
        game.WinnerIs().Should().Be("O");
    }    
    [Fact]
    public void ReturnWinnerIsO_WhenNewGameStarted_Given0SymbolHasALineInSecondColumn()
    {
        var game = new TicTacToeGame();
        
        game.TakeTurn(Column.Right, Row.Bottom); 
        game.TakeTurn(Column.Centre, Row.Top); 
        game.TakeTurn(Column.Left, Row.Top); 
        game.TakeTurn(Column.Centre,Row.Middle); 
        game.TakeTurn(Column.Centre, Row.Middle); 
        game.TakeTurn(Column.Centre, Row.Bottom); 
        
        game.WinnerIs().Should().Be("O");
    }
    

}

