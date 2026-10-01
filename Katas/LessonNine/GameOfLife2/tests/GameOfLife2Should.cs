namespace tests;

using FluentAssertions;
using src.Models;

public class GameOfLife2Should
{
    [Fact]
    public void ReturnZero_WhenLiveCellsInokved_GivenEmptyUniverseAndNoTick()
    {
        Cell[] seed = [];
        var universe = new Universe(seed);
        
        universe.LiveCells().Should().Be(0);
    }

    [Fact]
    public void ReturnOne_WhenLiveCellsInokved_GivenOneLiveSellInUniverseAnNoTick()
    {
        Cell[] seed = [new()];
        var universe = new Universe(seed);

        universe.LiveCells().Should().Be(1);
    }
}