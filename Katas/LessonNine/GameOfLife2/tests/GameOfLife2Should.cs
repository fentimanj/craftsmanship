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
        
        cellOne.AddNeighbourCell(cellTwo);
        cellTwo.AddNeighbourCell(cellOne);
        
        Cell[] seed = [cellOne, cellTwo];
        var universe = new Universe(seed);

        universe.Tick();
        universe.LiveCells().Should().Be(0);
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


}