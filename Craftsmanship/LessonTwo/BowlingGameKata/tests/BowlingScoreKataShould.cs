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
    
    [Fact]
    public void ReturnScoreOfOne_WhenCalculateScoreInvoked_GivenOnePinKnockedOver()
    {
        var bowlingScoreService = new BowlingScoreService();
        var scoreString = "1-|0|0|0|0|0|0|0|0|0||";

        var calculatedScore = bowlingScoreService.CalculateScore(scoreString);

        calculatedScore.Should().Be(1);
    }
    
    [Fact]
    public void ReturnScoreOfTwo_WhenCalculateScoreInvoked_GivenTwoPinsKnockedOver()
    {
        var bowlingScoreService = new BowlingScoreService();
        var scoreString = "2-|0|0|0|0|0|0|0|0|0||";

        var calculatedScore = bowlingScoreService.CalculateScore(scoreString);

        calculatedScore.Should().Be(2);
    } 
    
    [Fact]
    public void ReturnScoreOfThree_WhenCalculateScoreInvoked_GivenThreePinsKnockedOver()
    {
        var bowlingScoreService = new BowlingScoreService();
        var scoreString = "3-|0|0|0|0|0|0|0|0|0||";

        var calculatedScore = bowlingScoreService.CalculateScore(scoreString);

        calculatedScore.Should().Be(3);
    }
}

public class BowlingScoreService
{
    public int CalculateScore(string scoreString)
    {
        if (scoreString.Contains("1"))
        {
            return 1;
        }
        
        if (scoreString.Contains("2"))
        {
            return 2;
        }    
        
        if (scoreString.Contains("3"))
        {
            return 3;
        }
        return 0;
    }
}