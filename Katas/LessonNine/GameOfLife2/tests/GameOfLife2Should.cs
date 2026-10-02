namespace tests;

using FluentAssertions;
using src.Models;

public class GameOfLife2Should
{
    [Fact]
    public void ReturnZero_WhenLiveCellsInvoked_GivenEmptyUniverseAndNoTick()
    {
        Cell[] seed = [];
        var universe = new Universe(seed);
        
        universe.LiveCells().Should().Be(0);
    }

    [Fact]
    public void ReturnOne_WhenLiveCellsInvoked_GivenOneLiveCellInUniverseAndNoTick()
    {
        Cell[] seed = [new Cell()];
        var universe = new Universe(seed);

        universe.LiveCells().Should().Be(1);
    }
    
    [Fact]
    public void ReturnZero_WhenLiveCellsInvoked_GivenTwoDeadCellInUniverseAndOneTick()
    {
        var cellOne = new Cell();
        var cellTwo = new Cell();
        
        Cell[] seed = [cellOne, cellTwo];
        var universe = new Universe(seed);

        universe.Tick();
        universe.LiveCells().Should().Be(0);
    }

    [Fact]
    public void ReturnNextGeneration_WhenGetCellStateInvokedOnMiddleCell_GivenThreeCellsInARowAndNoTick()
    {
        var leftCell = new Cell();
        var middleCell = new Cell();
        var rightCell = new Cell();

        leftCell.Column = 0;
        leftCell.Row = 1;
        middleCell.Column = 1;
        middleCell.Row = 1;
        rightCell.Column = 1;
        rightCell.Row = 1;
        
        var universe = new Universe(new Cell[] { leftCell, middleCell, rightCell });
        
        middleCell.GetState().Should().Be(CellState.NextGeneration);
        
    }
}