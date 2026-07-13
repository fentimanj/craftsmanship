using FluentAssertions;
using src.Services;

public class TicTacToe2Should
{
    [Fact]
    public void Return_When_Given()
    {
        string currentSymbolIs = TicTacToe.CurrentSymbol();
        currentSymbolIs.Should().Be("X");
    }
}