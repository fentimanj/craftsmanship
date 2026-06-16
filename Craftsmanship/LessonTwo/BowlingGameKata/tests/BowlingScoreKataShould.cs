namespace tests;

using FluentAssertions;
using src.Services;

public class BowlingScoreKataShould
{
    [Theory]
    [InlineData("0|0|0|0|0|0|0|0|0|0||", 0)]
    [InlineData("1-|0|0|0|0|0|0|0|0|0||", 1)]
    [InlineData("2-|0|0|0|0|0|0|0|0|0||", 2)]
    [InlineData("3-|0|0|0|0|0|0|0|0|0||", 3)]
    [InlineData("01|0|0|0|0|0|0|0|0|0||", 1)] 
    [InlineData("03|0|0|0|0|0|0|0|0|0||", 3)]
    [InlineData("03|02|0|0|0|0|0|0|0|0||", 5)]
    [InlineData("03|03|0|0|0|0|0|0|0|0||", 6)]
    [InlineData("04|03|0|0|0|0|0|0|0|0||", 7)]
    public void ReturnCorrectScore_WhenCalculateScoreInvoked_GivenValidScoreCard(string scoreCard, int expectedScore)
    {
        var bowlingScoreService = new BowlingScoreService();

        var calculatedScore = bowlingScoreService.CalculateScore(scoreCard);

        calculatedScore.Should().Be(expectedScore);
    } 
    
}