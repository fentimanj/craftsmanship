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

        ticTacToe.TakeTurn(Column.Left,Row.Top);
        
        Symbol currentSymbolIs = ticTacToe.CurrentSymbol();
        currentSymbolIs.Should().Be(Symbol.O);
    }
    
    [Fact]
    public void ReturnSymbolX_WhenGameStarted_GivenTwoTurnsHasBeenTaken()
    {
        var ticTacToe = new TicTacToe();

        ticTacToe.TakeTurn(Column.Left,Row.Top);
        ticTacToe.TakeTurn(Column.Left,Row.Bottom);
        
        Symbol currentSymbolIs = ticTacToe.CurrentSymbol();
        currentSymbolIs.Should().Be(Symbol.X);
    }

    [Fact]
    public void ReturnWinnerNotKnown_WhenWinnerQueried_GivenCurrentlyNoWinner()
    {
        var ticTacToe = new TicTacToe();
        
        ticTacToe.TakeTurn(Column.Left,Row.Top);

        var currentWinner = ticTacToe.GetWinningSymbnol();

        currentWinner.Should().Be(Symbol.Unknown);
    }

    [Fact]
    public void ReturnSymbolX_WhenWinnerQueired_GivenXHasThreeInARow()
    {
        var ticTacToe = new TicTacToe();
        
        ticTacToe.TakeTurn(Column.Left,Row.Top); 
        ticTacToe.TakeTurn(Column.Centre,Row.Top); 
        ticTacToe.TakeTurn(Column.Left, Row.Middle);
        ticTacToe.TakeTurn(Column.Right, Row.Middle);
        ticTacToe.TakeTurn(Column.Left,Row.Bottom);
        
        var currentWinner = ticTacToe.GetWinningSymbnol();

        currentWinner.Should().Be(Symbol.X);
    }
}