using FluentAssertions;

public class TicTacToe2Should
{
    [Fact]
    public void Return_When_Given()
    {
        string currentSymbolIs = TicTacToe.CurrentSymbol();
        currentSymbolIs.Should().Be("X");
    }
}

public class TicTacToe
{
    public static string CurrentSymbol()
    {
        return "X";
    }
}
