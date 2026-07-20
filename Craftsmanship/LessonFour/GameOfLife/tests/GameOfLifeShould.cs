using FluentAssertions;
using src.Models;
using src.Services;


namespace tests;

public class GameOfLifeShould
{
    [Fact]
    public void ReturnZero_WhenGettingNumberOfLivingCells_GivenAnEmptyListOfCellsAtStart()
    {
        List<Cell> seed = [];
        var seedingCells = new Cells(seed);
        var gameOfLife = new GameOfLife(seedingCells);
        
        var numberOfLivingCells = gameOfLife.GetNumberOfLivingCells();
        
        numberOfLivingCells.Should().Be(0);
    }

    [Fact]
    public void ReturnOne_WhenGettingNumberOfLivingCells_GivenOneCellInSeed()
    {
        var cellOnePosition = new GridPosition(1);
        List<Cell> seed = [new(cellOnePosition)];
        
        var seedingCells = new Cells(seed);
        var gameOfLife = new GameOfLife(seedingCells);

        var numberOfLivingCells = gameOfLife.GetNumberOfLivingCells();
        
        numberOfLivingCells.Should().Be(1);
    }

    [Fact]
    public void ReturnOne_WhenNumberOfCellsRequested_GivenOneCellInSeedAndNoLifecycles()
    {
        var cellOnePosition = new GridPosition(1);
        List<Cell> seed = [new(cellOnePosition)];
        
        var seedingCells = new Cells(seed);
        var gameOfLife = new GameOfLife(seedingCells);
        
        gameOfLife.GetNumberOfLivingCells().Should().Be(1);
    }

    [Fact]
    public void ReturnZero_WhenNumberOfCellsRequested_GivenOneCellInSeedAndOneLifecycles()
    {
        var cellOnePosition = new GridPosition(1);
        List<Cell> seed = [new(cellOnePosition)];
        
        var seedingCells = new Cells(seed);
        var gameOfLife = new GameOfLife(seedingCells);

        gameOfLife.CompleteLifecycle();
        
        gameOfLife.GetNumberOfLivingCells().Should().Be(0);
    }

    [Fact]
    public void ReturnZero_WhenNumberOfCellsRequested_GivenTwoCellsInSeedAndOneLifecycles()
    {
        var cellOnePosition = new GridPosition(1);
        var cellTwoPosition = new GridPosition(2);
        
        var cellOne = new Cell(cellOnePosition);
        var cellTwo = new Cell(cellTwoPosition);
            
        List<Cell> seed = [cellOne, cellTwo];
        var seedingCells = new Cells(seed);
        var gameOfLife = new GameOfLife(seedingCells);

        gameOfLife.CompleteLifecycle();
        
        gameOfLife.GetNumberOfLivingCells().Should().Be(0);
    }

    [Fact]
    public void ReturnOne_WhenNumberOfCellsRequested_GivenThreeCellsInARowInSeedAndOneLifecycles()
    {
        var cellOnePosition = new GridPosition(1);
        var cellTwoPosition = new GridPosition(2);
        var cellThreePosition = new GridPosition(3);
        
        var cellOne = new Cell(cellOnePosition);
        var cellTwo = new Cell(cellTwoPosition);
        var cellThree = new Cell(cellThreePosition);  
            
        List<Cell> seed = [cellOne, cellTwo, cellThree];
        var seedingCells = new Cells(seed);
        var gameOfLife = new GameOfLife(seedingCells);
        
        gameOfLife.CompleteLifecycle();
        
        gameOfLife.GetNumberOfLivingCells().Should().Be(1);
    }
        
}