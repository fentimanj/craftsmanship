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
        
        cellOne.NeighbouringCells.Add(cellTwo);
        cellTwo.NeighbouringCells.Add(cellOne);
        
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
        
        cellOne.NeighbouringCells.Add(cellTwo);
        cellOne.NeighbouringCells.Add(cellThree);
        
        cellOne.GetState().Should().Be(CellState.NextGeneration);
    }

    [Fact]
    public void ReturnsUnderPopulated_WhenGetStateInvoked_GivenOneNeighbouringCell()
    {
        Cell cellOne = new Cell();
        Cell cellTwo = new Cell();
        
        cellOne.NeighbouringCells.Add(cellTwo);
        
        cellOne.GetState().Should().Be(CellState.UnderPopulated);
    }

    [Fact]
    public void ReturnsOverPopulated_WhenGetStateInvoked_GivenThreeNeighbouringCells()
    {
        Cell cellOne = new Cell();
        Cell cellTwo = new Cell();
        Cell cellThree = new Cell();
        Cell cellFour = new Cell();
        Cell cellFive = new Cell();
        
        cellOne.NeighbouringCells.Add(cellTwo);
        cellOne.NeighbouringCells.Add(cellThree);
        cellOne.NeighbouringCells.Add(cellFour);
        cellOne.NeighbouringCells.Add(cellFive);
        
        cellOne.GetState().Should().Be(CellState.OverPopulated);
    }
}