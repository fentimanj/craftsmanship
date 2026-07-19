using FluentAssertions;
using src.Models;
using src.Services;

public class GameOfLifeShould
{
    [Fact]
    public void Return_When_Given()
    {
        List<Cell> seed = new List<Cell>();
        GameOfLife gameOfLife = new GameOfLife(seed);
        
        bool continueGenerating = gameOfLife.ContinueGenerating();
        
        continueGenerating.Should().BeFalse();
    }
}