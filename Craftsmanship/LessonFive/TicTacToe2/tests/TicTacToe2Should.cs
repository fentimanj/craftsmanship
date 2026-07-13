using FluentAssertions;
using src.Enums;
using src.Services;

public class TicTacToe2Should
{
    [Fact]
    public void ReturnSymbolX_WhenGameStarted_GivenNoTurnsHaveBeenTaken()
    {
        var ticTacToe = new TicTacToe();
        
        Symbol currentSymbolIs = ticTacToe.CurrentSymbol();
        
        currentSymbolIs.Should().Be(Symbol.X);
    }

    [Fact]
    public void ReturnSymbolO_WhenGameStarted_GivenOneTurnHasBeenTaken()
    {
        var ticTacToe = new TicTacToe();

        ticTacToe.TakeTurn(Position.LeftTop);
        
        Symbol currentSymbolIs = ticTacToe.CurrentSymbol();
        currentSymbolIs.Should().Be(Symbol.O);
    }
    
    [Fact]
    public void ReturnSymbolX_WhenGameStarted_GivenTwoTurnsHasBeenTaken()
    {
        var ticTacToe = new TicTacToe();

        ticTacToe.TakeTurn(Position.LeftTop);
        ticTacToe.TakeTurn(Position.LeftBottom);
        
        Symbol currentSymbolIs = ticTacToe.CurrentSymbol();
        currentSymbolIs.Should().Be(Symbol.X);
    }

    [Fact]
    public void ReturnWinnerNotKnown_WhenWinnerQueried_GivenCurrentlyNoWinner()
    {
        var ticTacToe = new TicTacToe();
        
        ticTacToe.TakeTurn(Position.LeftTop);

        var currentWinner = ticTacToe.GetWinningSymbol();

        currentWinner.Should().Be(Symbol.Unknown);
    }

    [Fact]
    public void ReturnSymbolX_WhenWinnerQueired_GivenXHasThreeInARow()
    {
        var ticTacToe = new TicTacToe();
        
        ticTacToe.TakeTurn(Position.LeftTop); 
        ticTacToe.TakeTurn(Position.CentreTop); 
        ticTacToe.TakeTurn(Position.LeftCentre);
        ticTacToe.TakeTurn(Position.RightCentre);
        ticTacToe.TakeTurn(Position.LeftBottom);
        
        var currentWinner = ticTacToe.GetWinningSymbol();

        currentWinner.Should().Be(Symbol.X);
    } 
    
    [Fact]
    public void ReturnSymbolO_WhenWinnerQueired_GivenOHasThreeInARow()
    {
        var ticTacToe = new TicTacToe();
        
        ticTacToe.TakeTurn(Position.RightTop);
        ticTacToe.TakeTurn(Position.LeftTop); 
        ticTacToe.TakeTurn(Position.CentreTop);
        ticTacToe.TakeTurn(Position.RightCentre);
        ticTacToe.TakeTurn(Position.LeftBottom);
        ticTacToe.TakeTurn(Position.LeftCentre);

        var currentWinner = ticTacToe.GetWinningSymbol();
    
        currentWinner.Should().Be(Symbol.O);
    }
    
    // [Fact]
    // public void ReturnSymbolUnknown_WhenWinnerQueired_GivenNoOneHasThreeInARow()
    // {
    //     var ticTacToe = new TicTacToe();
    //     
    //     ticTacToe.TakeTurn(Position.RightTop);
    //     ticTacToe.TakeTurn(Position.LeftTop); 
    //     ticTacToe.TakeTurn(Position.CentreTop); 
    //     ticTacToe.TakeTurn(Position.LeftCentre);
    //     ticTacToe.TakeTurn(Position.RightCentre);
    //     ticTacToe.TakeTurn(Position.CentreBottom);
    //     
    //     var currentWinner = ticTacToe.GetWinningSymbnol();
    //
    //     currentWinner.Should().Be(Symbol.Unknown);
    // }
}