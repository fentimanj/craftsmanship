namespace tests;

using System.Runtime.InteropServices.JavaScript;
using FluentAssertions;

public class GameOfLife2Should
{
    [Fact]
    public void ReturnEmptyUniverse_WhenTick_GivenEmptyUniverse()
    {
        object[] seed = [];
        Universe universe = new Universe(seed);
        
        universe.LiveCells().Should().Be(0);
    }
}

public class Universe
{
    public Universe(object[] seed)
    {
       
    }

    public int LiveCells()
    {
        return 0;
    }
}