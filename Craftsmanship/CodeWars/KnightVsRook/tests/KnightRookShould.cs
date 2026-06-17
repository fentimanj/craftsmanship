namespace tests;

using FluentAssertions;

public class KnightRookShould
{
    [Fact]
    public void ReturnNone_WhenKnightVsRookInvoked_GivenKnightAndRookNextToEachOther()
    {
        object[] rookPosition = { 4, "C" };
        object[] knightPosition = { 4, "D" };
        
        KnightRook.KnightVsRook(knightPosition, rookPosition).Should().Be("None");
    }
    
}

/*
 [Test, Order(1)]
      public void KnightTest()
      {
          object[] rookPosition = { 4, "C" };
          object[] knightPosition = {6, "D"};
          Assert.That(KnightRook.KnightVsRook(knightPosition, rookPosition), Is.EqualTo("Knight").IgnoreCase);
      }
      
      [Test, Order(2)]
      public void RookTest()
      {
          object[] rookPosition = { 2, "G" };
          object[] knightPosition = { 2, "B" };
          Assert.That(KnightRook.KnightVsRook(knightPosition, rookPosition), Is.EqualTo("Rook").IgnoreCase);
      }
      
      [Test, Order(3)]
      public void NoneTest()
      {
          object[] rookPosition = { 2, "F" };
          object[] knightPosition = { 7, "B" };
          Assert.That(KnightRook.KnightVsRook(knightPosition, rookPosition), Is.EqualTo("None").IgnoreCase);
      }
      */