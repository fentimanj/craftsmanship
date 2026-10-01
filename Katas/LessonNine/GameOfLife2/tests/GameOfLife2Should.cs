namespace tests;

using System.Runtime.InteropServices.JavaScript;
using FluentAssertions;

public class GameOfLife2Should
{
    [Fact]
    public void ReturnZero_WhenLiveCellsInokved_GivenEmptyUniverseAndNoTick()
    {
        Cell[] seed = [];
        Universe universe = new Universe(seed);
        
        universe.LiveCells().Should().Be(0);
    }

    [Fact]
    public void ReturnOne_WhenLiveCellsInokved_GivenOneLiveSellInUniverseAnNoTick()
    {
        Cell[] seed = [new()];
        Universe universe = new Universe(seed);

        universe.LiveCells().Should().Be(1);
    }
}

public class Cell
{
}

public class Universe(Cell[] seed)
{
    public int LiveCells()
    {
        return seed.Length;
    }
}