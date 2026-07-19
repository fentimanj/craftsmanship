using FluentAssertions;

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

public class GameOfLife
{
    public GameOfLife(List<Cell> seed)
    {
       
    }

    public bool ContinueGenerating()
    {
        return false;
    }
}

public class Cell
{
}
