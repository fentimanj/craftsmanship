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
}