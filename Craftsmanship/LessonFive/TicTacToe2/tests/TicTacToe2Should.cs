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

        ticTacToe.TakeTurn(Position.TopRowLeftColumn);
        
        Symbol currentSymbolIs = ticTacToe.CurrentSymbol();
        currentSymbolIs.Should().Be(Symbol.O);
    }
    
    [Fact]
    public void ReturnSymbolX_WhenGameStarted_GivenTwoTurnsHasBeenTaken()
    {
        var ticTacToe = new TicTacToe();

        ticTacToe.TakeTurn(Position.TopRowLeftColumn);
        ticTacToe.TakeTurn(Position.BottomRowLeftColumn);
        
        Symbol currentSymbolIs = ticTacToe.CurrentSymbol();
        currentSymbolIs.Should().Be(Symbol.X);
    }

    [Fact]
    public void ReturnWinnerNotKnown_WhenWinnerQueried_GivenCurrentlyNoWinner()
    {
        var ticTacToe = new TicTacToe();
        
        ticTacToe.TakeTurn(Position.TopRowLeftColumn);

        var currentWinner = ticTacToe.GetWinningSymbol();

        currentWinner.Should().Be(Symbol.Unknown);
    }

    [Fact]
    public void ReturnSymbolX_WhenWinnerQueired_GivenXHasThreeInARow()
    {
        var ticTacToe = new TicTacToe();
        
        ticTacToe.TakeTurn(Position.TopRowLeftColumn); 
        ticTacToe.TakeTurn(Position.TopRowCentreColumn); 
        ticTacToe.TakeTurn(Position.MiddleRowLeftColumn);
        ticTacToe.TakeTurn(Position.MiddleRowRightColumn);
        ticTacToe.TakeTurn(Position.BottomRowLeftColumn);
        
        var currentWinner = ticTacToe.GetWinningSymbol();

        currentWinner.Should().Be(Symbol.X);
    } 
    
    [Fact]
    public void ReturnSymbolO_WhenWinnerQueired_GivenOHasThreeInARowInLeftColumn()
    {
        var ticTacToe = new TicTacToe();
        
        ticTacToe.TakeTurn(Position.TopRowRightColumn);
        ticTacToe.TakeTurn(Position.TopRowLeftColumn); 
        ticTacToe.TakeTurn(Position.TopRowCentreColumn);
        ticTacToe.TakeTurn(Position.MiddleRowLeftColumn);
        ticTacToe.TakeTurn(Position.MiddleRowCentreColumn);
        ticTacToe.TakeTurn(Position.BottomRowLeftColumn);

        var currentWinner = ticTacToe.GetWinningSymbol();
    
        currentWinner.Should().Be(Symbol.O);
    }
    
    [Fact]
    public void ReturnSymbolUnknown_WhenWinnerQueired_GivenNoOneHasThreeInARow()
    {
        var ticTacToe = new TicTacToe();
        
        ticTacToe.TakeTurn(Position.TopRowRightColumn);
        ticTacToe.TakeTurn(Position.TopRowLeftColumn); 
        ticTacToe.TakeTurn(Position.TopRowCentreColumn); 
        ticTacToe.TakeTurn(Position.MiddleRowLeftColumn);
        ticTacToe.TakeTurn(Position.MiddleRowRightColumn);
        ticTacToe.TakeTurn(Position.BottomRowCentreColumn);
        
        var currentWinner = ticTacToe.GetWinningSymbol();
    
        currentWinner.Should().Be(Symbol.Unknown);
    }
    
    [Fact]
    public void ReturnSymbolX_WhenWinnerQueired_GivenXHasThreeInACentreRow()
    {
        var ticTacToe = new TicTacToe();
        
        ticTacToe.TakeTurn(Position.TopRowCentreColumn);
        ticTacToe.TakeTurn(Position.TopRowLeftColumn); 
        ticTacToe.TakeTurn(Position.MiddleRowCentreColumn); 
        ticTacToe.TakeTurn(Position.MiddleRowLeftColumn);
        ticTacToe.TakeTurn(Position.BottomRowCentreColumn);
        
        var currentWinner = ticTacToe.GetWinningSymbol();
    
        currentWinner.Should().Be(Symbol.X);
    }
}