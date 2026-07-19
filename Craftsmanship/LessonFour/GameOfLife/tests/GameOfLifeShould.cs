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
        var gameOfLife = new GameOfLife(seed);
        
        var continueGenerating = gameOfLife.ContinueGenerating();
        
        continueGenerating.Should().BeFalse();
    }
}