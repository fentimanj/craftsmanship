namespace TicTacToeRefactor.tests;

using FluentAssertions;
using TicTacToeRefactor.src;
using TicTacToeRefactor.src.Constant;
using TicTacToeRefactor.src.Enums;
using TicTacToeRefactor.src.Models;

public class BoardShould
{
    [Fact]
    public void ReturnX_WhenHasWinnerInvokved_GivenLeftColumnIsTakenByX()
    {
        var board = new Board();
        board.AddTileAt(Symbol.X, new Position(Column.Left, Row.Top));
        board.AddTileAt(Symbol.X, new Position(Column.Left, Row.Middle));
        board.AddTileAt(Symbol.X, new Position(Column.Left, Row.Bottom));

        var winner = board.HasWinner();

        winner.Should().Be(Symbol.X);
    }

    [Fact]
    public void ReturnO_WhenHasWinnerInvoked_GivenRightColumnIsTakenByO()
    {
        var board = new Board();
        board.AddTileAt(Symbol.O, new Position(Column.Right, Row.Top));
        board.AddTileAt(Symbol.O, new Position(Column.Right, Row.Middle));
        board.AddTileAt(Symbol.O, new Position(Column.Right, Row.Bottom));

        var winner = board.HasWinner();

        winner.Should().Be(Symbol.O);
    }

    [Fact]
    public void ReturnO_WhenHasWinnerInvoked_GivenCenterColumnIsTakenByO()
    {
        var board = new Board();
        board.AddTileAt(Symbol.O, new Position(Column.Center, Row.Top));
        board.AddTileAt(Symbol.O, new Position(Column.Center, Row.Middle));
        board.AddTileAt(Symbol.O, new Position(Column.Center, Row.Bottom));

        var winner = board.HasWinner();

        winner.Should().Be(Symbol.O);
    }
}