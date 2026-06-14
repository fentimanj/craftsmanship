namespace tests;

using FluentAssertions;

public class BowlingScoreKataShould
{
    [Fact]
    public void ReturnScoreOfZero_WhenCalculateScoreInvoked_GivenAllZeros()
    {
        var bowlingScoreService = new BowlingScoreService();
        var scoreString = "0|0|0|0|0|0|0|0|0|0||";

        var calculatedScore = bowlingScoreService.CalculateScore(scoreString);

        calculatedScore.Should().Be(0);
    }
}

public class BowlingScoreService
{
    public int CalculateScore(string scoreString)
    {
        return 0;
    }
}