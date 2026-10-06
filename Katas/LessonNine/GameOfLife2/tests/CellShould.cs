namespace tests;

using FluentAssertions;
using src.Models;

public class CellShould
{
    [Fact]
    public void ReturnsUnderPopulated_WhenGetStateInvoked_GivenNoNeighbouringCells()
    {
        var cell = new Cell();

        cell.GetState().Should().Be(CellState.UnderPopulated);
    }

    [Fact]
    public void ReturnsNextGeneration_WhenGetStateInvoked_GivenTwoNeighbouringCells()
    {
        var cellOne = new Cell();
        var cellTwo = new Cell();
        var cellThree = new Cell();

        cellOne.AddNeighbourCell(cellTwo);
        cellOne.AddNeighbourCell(cellThree);

        cellOne.GetState().Should().Be(CellState.NextGeneration);
    }

    [Fact]
    public void ReturnsUnderPopulated_WhenGetStateInvoked_GivenOneNeighbouringCell()
    {
        var cellOne = new Cell();
        var cellTwo = new Cell();

        cellOne.AddNeighbourCell(cellTwo);

        cellOne.GetState().Should().Be(CellState.UnderPopulated);
    }

    [Fact]
    public void ReturnsOverPopulated_WhenGetStateInvoked_GivenThreeNeighbouringCells()
    {
        var cellOne = new Cell();
        var cellTwo = new Cell();
        var cellThree = new Cell();
        var cellFour = new Cell();
        var cellFive = new Cell();

        cellOne.AddNeighbourCell(cellTwo);
        cellOne.AddNeighbourCell(cellThree);
        cellOne.AddNeighbourCell(cellFour);
        cellOne.AddNeighbourCell(cellFive);

        cellOne.GetState().Should().Be(CellState.OverPopulated);
    }

    [Fact]
    public void ReturnsUnderPopulated_WhenGetStateInvoked_GivenTwoNeighbouringCellsAddedAndOneIsItself()
    {
        var cellOne = new Cell();
        var cellTwo = new Cell();

        cellOne.AddNeighbourCell(cellOne);
        cellOne.AddNeighbourCell(cellTwo);

        cellOne.GetState().Should().Be(CellState.UnderPopulated);
    }

    [Theory]
    [InlineData(-1, 0, true)]
    [InlineData(1, 0, true)]
    [InlineData(0, 1, true)]
    [InlineData(0, -1, true)]
    [InlineData(-1, 2, false)]
    [InlineData(-1, -2, false)]
    [InlineData(-2, 0, false)]
    [InlineData(2, 0, false)]
    public void ReturnCorrectBool_WhenIsNeighbourInvoked_GivenOtherCellIsToLeft(int otherCellColumn, int otherCellRow,
        bool expected)
    {
        var cellUnderTest = new Cell();
        var otherCell = new Cell();

        cellUnderTest.Column = 0;
        cellUnderTest.Row = 0;

        otherCell.Column = otherCellColumn;
        otherCell.Row = otherCellRow;

        cellUnderTest.IsNeighbourOf(otherCell).Should().Be(expected);
    }
}