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

public class CellShould
{
    [Fact]
    public void ReturnsUnderPopulated_WhenGetStateInvoked_GivenNoNeighbouringCells()
    {
        Cell cell = new Cell();
        
        cell.GetState().Should().Be(CellState.UnderPopulated);
    }

    [Fact]
    public void ReturnsNextGeneration_WhenGetStateInvoked_GivenTwoNeighbouringCells()
    {
        Cell cellOne = new Cell();
        Cell cellTwo = new Cell();
        Cell cellThree = new Cell();
        
        cellOne.AddNeighbourCell(cellTwo);
        cellOne.AddNeighbourCell(cellThree);
        
        cellOne.GetState().Should().Be(CellState.NextGeneration);
    }

    [Fact]
    public void ReturnsUnderPopulated_WhenGetStateInvoked_GivenOneNeighbouringCell()
    {
        Cell cellOne = new Cell();
        Cell cellTwo = new Cell();
        
        cellOne.AddNeighbourCell(cellTwo);
        
        cellOne.GetState().Should().Be(CellState.UnderPopulated);
    }

    [Fact]
    public void ReturnsOverPopulated_WhenGetStateInvoked_GivenThreeNeighbouringCells()
    {
        var cellOne = new Cell();
        var cellTwo = new Cell();
        var cellThree = new Cell();
        var cellFour = new Cell();
        var cellFive = new Cell();
        
        cellOne.AddNeighbourCell(cellTwo);
        cellOne.AddNeighbourCell(cellThree);
        cellOne.AddNeighbourCell(cellFour);
        cellOne.AddNeighbourCell(cellFive);
        
        cellOne.GetState().Should().Be(CellState.OverPopulated);
    }

    [Fact]
    public void ReturnsUnderPopulated_WhenGetStateInvoked_GivenTwoNeighbouringCellsAddedAndOneIsItself()
    {
        var cellOne = new Cell();
        var cellTwo = new Cell();

        cellOne.AddNeighbourCell(cellOne);
        cellOne.AddNeighbourCell(cellTwo);

        cellOne.GetState().Should().Be(CellState.UnderPopulated);
    }
    
    [Theory]
    [InlineData(-1,0, true)]
    [InlineData(1, 0, true)]
    [InlineData(0, 1, true)]
    [InlineData(0, -1, true)]
    [InlineData(-1, 2, false)]
    [InlineData(-1, -2, false)]
    [InlineData(-2,0, false)]
    [InlineData(2, 0, false)]
    
    public void ReturnCorrectBool_WhenIsNeighbourInvoked_GivenOtherCellIsToLeft(int otherCellColumn, int otherCellRow, bool expected)
    {
        var cellUnderTest = new Cell();
        var otherCell = new Cell();
        
        cellUnderTest.Column = 0;
        cellUnderTest.Row = 0;
        
        otherCell.Column = otherCellColumn;
        otherCell.Row = otherCellRow;
        
        cellUnderTest.IsNeighbourOf(otherCell).Should().Be(expected);
    }
}

