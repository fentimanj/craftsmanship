namespace tests;

using FluentAssertions;

public class KnightRookShould
{
    [Fact]
    public void ReturnNone_WhenKnightVsRookInvoked_GivenKnightAndRookNextToEachOther()
    {
        object[] rookPosition = { 4, "C" };
        object[] knightPosition = { 5, "D" };

        KnightRook.KnightVsRook(knightPosition, rookPosition).Should().Be("None");
    }

    [Theory]
    [InlineData(5, "D", 5, "C")]
    [InlineData(6, "D", 6, "E")]
    [InlineData(7, "D", 9, "D")]
    public void ReturnRook_WhenKnightVsRookInvoked_GivenKnightIsInlineWithRook
        (int rookNumberPosition, string rookLetterPosition, int knightNumberPosition, string knightLetterPosition)
    {
        object[] rookPosition = { rookNumberPosition, rookLetterPosition };
        object[] knightPosition = { knightNumberPosition, knightLetterPosition };

        KnightRook.KnightVsRook(knightPosition, rookPosition).Should().Be("Rook");
    }

    [Theory]
    [InlineData(6, "D", 8, "C")]
    [InlineData(6, "B", 8, "C")]
    [InlineData(10, "B", 8, "C")]
    public void ReturnKnight_WhenKnightVsRookInvoked_GivenRookIsWithinKnightReach
        (int rookNumberPosition, string rookLetterPosition, int knightNumberPosition, string knightLetterPosition)
    {
        object[] rookPosition = { rookNumberPosition, rookLetterPosition };
        object[] knightPosition = { knightNumberPosition, knightLetterPosition };

        KnightRook.KnightVsRook(knightPosition, rookPosition).Should().Be("Knight");
    }

    [Fact]
    public void CodeWarsTestOne()
    {
        object[] rookPosition = { 4, "C" };
        object[] knightPosition = { 6, "D" };
        KnightRook.KnightVsRook(knightPosition, rookPosition).Should().Be("Knight");
    }

    [Fact]
    public void CodeWarsTestTwo()
    {
        object[] rookPosition = { 2, "G" };
        object[] knightPosition = { 2, "B" };
        KnightRook.KnightVsRook(knightPosition, rookPosition).Should().Be("Rook");
    }

    [Fact]
    public void CodeWarsTestThree()
    {
        object[] rookPosition = { 2, "F" };
        object[] knightPosition = { 7, "B" };
        KnightRook.KnightVsRook(knightPosition, rookPosition).Should().Be("None");
    } 
    
    [Fact]
    public void CodeWarsTestFour()
    {
        object[] rookPosition = { 6, "G" };
        object[] knightPosition = { 7, "E" };
        KnightRook.KnightVsRook(knightPosition, rookPosition).Should().Be("Knight");
    }
}

/*
Test Failed
     Knight Position: 6,G and Rook Position: 7,E --> Knight
   Assert.That(KnightRook.KnightVsRook(positions[0], positions[1]), Is.EqualTo(expected).IgnoreCase)
     Expected string length 6 but was 4. Strings differ at index 0.
     Expected: "Knight", ignoring case
     But was:  "None"
*/
