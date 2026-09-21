namespace tests;

using src.Enums;
using src.Models;

public class GameShould
{
    private readonly Game game;

    public GameShould()
    {
        this.game = new Game();
    }

    [Fact]
    public void NotAllowPlayerOToPlayFirst()
    {
        var wrongPlay = () => this.game.Play('O', 0, 0);

        var exception = Assert.Throws<Exception>(wrongPlay);
        Assert.Equal("Invalid first player", exception.Message);
    }

    [Fact]
    public void NotAllowPlayerXToPlayTwiceInARow()
    {
        this.game.Play('X', 0, 0);

        var wrongPlay = () => this.game.Play('X', 1, 0);

        var exception = Assert.Throws<Exception>(wrongPlay);
        Assert.Equal("Invalid next player", exception.Message);
    }

    [Fact]
    public void NotAllowPlayerToPlayInLastPlayedPosition()
    {
        this.game.Play('X', 0, 0);

        var wrongPlay = () => this.game.Play('O', 0, 0);

        var exception = Assert.Throws<Exception>(wrongPlay);
        Assert.Equal("Invalid position", exception.Message);
    }

    [Fact]
    public void NotAllowPlayerToPlayInAnyPlayedPosition()
    {
        this.game.Play('X', 0, 0);
        this.game.Play('O', 1, 0);

        var wrongPlay = () => this.game.Play('X', 0, 0);

        var exception = Assert.Throws<Exception>(wrongPlay);
        Assert.Equal("Invalid position", exception.Message);
    }

    [Fact]
    public void DeclarePlayerXAsAWinnerIfThreeInLeftColumn()
    {
        this.game.Play(Symbol.X, Positions.TopLeft);
        this.game.Play(Symbol.O, Positions.TopCenter);
        this.game.Play(Symbol.X, Positions.MiddleLeft);
        this.game.Play(Symbol.O, Positions.MiddleCenter);
        this.game.Play(Symbol.X, Positions.BottomLeft);

        var winner = this.game.Winner();

        Assert.Equal('X', winner);
    }

    [Fact]
    public void DeclarePlayerOAsAWinnerIfThreeInLeftColumn()
    {
        this.game.Play(Symbol.X, Positions.BottomRight);
        this.game.Play(Symbol.O, Positions.TopLeft);
        this.game.Play(Symbol.X, Positions.TopCenter);
        this.game.Play(Symbol.O, Positions.MiddleLeft);
        this.game.Play(Symbol.X, Positions.MiddleCenter);
        this.game.Play(Symbol.O, Positions.BottomLeft);

        var winner = this.game.Winner();

        Assert.Equal('O', winner);
    }

    [Fact]
    public void DeclarePlayerXAsAWinnerIfThreeInCenterColumn()
    {
        this.game.Play(Symbol.X, Positions.TopCenter);
        this.game.Play(Symbol.O, Positions.TopLeft);
        this.game.Play(Symbol.X, Positions.MiddleCenter);
        this.game.Play(Symbol.O, Positions.MiddleLeft);
        this.game.Play(Symbol.X, Positions.BottomCenter);

        var winner = this.game.Winner();

        Assert.Equal('X', winner);
    }

    [Fact]
    public void DeclarePlayerOAsAWinnerIfThreeInMiddleColumn()
    {
        this.game.Play(Symbol.X, Positions.TopLeft);
        this.game.Play(Symbol.O, Positions.TopCenter);
        this.game.Play(Symbol.X, Positions.TopRight);
        this.game.Play(Symbol.O, Positions.MiddleCenter);
        this.game.Play(Symbol.X, Positions.MiddleRight);
        this.game.Play(Symbol.O, Positions.BottomCenter);

        var winner = this.game.Winner();

        Assert.Equal('O', winner);
    }

    [Fact]
    public void DeclarePlayerXAsAWinnerIfThreeInRightColumn()
    {
        this.game.Play(Symbol.X, Positions.TopRight);
        this.game.Play(Symbol.O, Positions.TopLeft);
        this.game.Play(Symbol.X, Positions.MiddleRight);
        this.game.Play(Symbol.O, Positions.MiddleLeft);
        this.game.Play(Symbol.X, Positions.BottomRight);

        var winner = this.game.Winner();

        Assert.Equal('X', winner);
    }

    [Fact]
    public void DeclarePlayerOAsAWinnerIfThreeInRightColumn()
    {
        this.game.Play(Symbol.X, Positions.TopLeft);
        this.game.Play(Symbol.O, Positions.TopRight);
        this.game.Play(Symbol.X, Positions.TopCenter);
        this.game.Play(Symbol.O, Positions.MiddleRight);
        this.game.Play(Symbol.X, Positions.MiddleCenter);
        this.game.Play(Symbol.O, Positions.BottomRight);

        var winner = this.game.Winner();

        Assert.Equal('O', winner);
    }

    [Fact]
    public void DeclarePlayerXAsAWinnerIfThreeInTopRow()
    {
        this.game.Play(Symbol.X, Positions.TopLeft);
        this.game.Play(Symbol.O, Positions.MiddleLeft);
        this.game.Play(Symbol.X, Positions.TopCenter);
        this.game.Play(Symbol.O, Positions.MiddleCenter);
        this.game.Play(Symbol.X, Positions.TopRight);

        var winner = this.game.Winner();

        Assert.Equal('X', winner);
    } 
    
    [Fact]
    public void DeclarePlayerXAsAWinnerIfThreeInMiddleRow()
    {
        this.game.Play(Symbol.X, Positions.MiddleLeft);
        this.game.Play(Symbol.O, Positions.TopLeft);
        this.game.Play(Symbol.X, Positions.MiddleCenter);
        this.game.Play(Symbol.O, Positions.TopCenter);
        this.game.Play(Symbol.X, Positions.MiddleRight);

        var winner = this.game.Winner();

        Assert.Equal('X', winner);
    } 
    
    [Fact]
    public void DeclarePlayerXAsAWinnerIfThreeInBottomRow()
    {
        this.game.Play(Symbol.X, Positions.BottomLeft);
        this.game.Play(Symbol.O, Positions.MiddleLeft);
        this.game.Play(Symbol.X, Positions.BottomCenter);
        this.game.Play(Symbol.O, Positions.MiddleCenter);
        this.game.Play(Symbol.X, Positions.BottomRight);

        var winner = this.game.Winner();

        Assert.Equal('X', winner);
    }
}