using FluentAssertions;
using src.Models;
using src.Services;


namespace tests;

public class GameOfLifeShould
{
    [Fact]
    public void ReturnFalse_WhenCheckIfGameShouldContinue_GivenAnEmptyListOfCellsAtStart()
    {
        List<Cell> seed = [];
        var seedingCells = new SeedingCells(seed);
        var gameOfLife = new GameOfLife(seedingCells);
        
        var continueGenerating = gameOfLife.ContinueGenerating();
        
        continueGenerating.Should().BeFalse();
    }

    [Fact]
    public void ReturnTrue_WhenCheckIfGameShouldContinue_GivenOneCellInSeed()
    {
        List<Cell> seed = [new Cell()];
        var seedingCells = new SeedingCells(seed);
        var gameOfLife = new GameOfLife(seedingCells);

        var continueGenerating = gameOfLife.ContinueGenerating();

        continueGenerating.Should().BeTrue();
    }
}