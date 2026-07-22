using FluentAssertions;
using src.Services;

public class GreedIsGoodShould
{
    [Theory]
    [InlineData(2,2,2,2,2,0)]
    [InlineData(1,2,2,2,2,100)]
    [InlineData(1,1,2,2,2,200)]
    [InlineData(5,2,2,2,2,50)]
    [InlineData(5,5,2,2,2,100)]
    
    public void ReturnCorrectScore_WhenScoreIsCalculated_GivenFiveValidDice(int diceOne, int diceTwo, int diceThree, int diceFour, int diceFive, int expectedScore)
    {
       var dice = new [] {diceOne, diceTwo, diceThree, diceFour, diceFive};
       
       var actualScore = Kata.Score(dice);
       
       actualScore.Should().Be(expectedScore);
    }
}