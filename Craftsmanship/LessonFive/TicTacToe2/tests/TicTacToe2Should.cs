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

        ticTacToe.TakeTurn();
        
        Symbol currentSymbolIs = ticTacToe.CurrentSymbol();
        currentSymbolIs.Should().Be(Symbol.O);
    }
    
    [Fact]
    public void ReturnSymbolX_WhenGameStarted_GivenTwoTurnsHasBeenTaken()
    {
        var ticTacToe = new TicTacToe();

        ticTacToe.TakeTurn();
        ticTacToe.TakeTurn();
        
        Symbol currentSymbolIs = ticTacToe.CurrentSymbol();
        currentSymbolIs.Should().Be(Symbol.X);
    }
}