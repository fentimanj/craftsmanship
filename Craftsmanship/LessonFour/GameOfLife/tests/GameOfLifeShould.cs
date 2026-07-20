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
        List<Cell> seed = [new()];
        var seedingCells = new Cells(seed);
        var gameOfLife = new GameOfLife(seedingCells);

        var numberOfLivingCells = gameOfLife.GetNumberOfLivingCells();
        
        numberOfLivingCells.Should().Be(1);
    }

    [Fact]
    public void ReturnOne_WhenNumberOfCellsRequested_GivenOneCellInSeedAndNoLifecycles()
    {
        List<Cell> seed = [new()];
        var seedingCells = new Cells(seed);
        var gameOfLife = new GameOfLife(seedingCells);
        
        gameOfLife.GetNumberOfLivingCells().Should().Be(1);
    }

    [Fact]
    public void ReturnFalse_WhenCheckIfGameShouldContinue_GivenOneCellInSeedAndOneLifecycles()
    {
        
        List<Cell> seed = [new()];
        var seedingCells = new Cells(seed);
        var gameOfLife = new GameOfLife(seedingCells);

        gameOfLife.CompleteLifecycle();
        
        gameOfLife.GetNumberOfLivingCells().Should().Be(0);
    }
}