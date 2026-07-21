namespace src;

using Strategies;

public class TennisGame1(string player1Name, string player2Name) : ITennisGame
{
    private int playerOnePoints;
    private int playerTwoPoints;

    public void WonPoint(string playerName)
    {
        if (playerName == "player1")
        {
            this.playerOnePoints += 1;
        }
        else
        {
            this.playerTwoPoints += 1;
        }
    }

    public string GetScore()
    {
        ITennisScoringStrategy scoreStrategy;
        ScoringType scoreType;
        TennisScoreStrategyFactory factory = new TennisScoreStrategyFactory();

        if (this.IsATie())
        {
            scoreType = ScoringType.Tied;
            
        }
        else if (this.PlayerHasAdvantage())
        {
            scoreType = ScoringType.Advantage;
        }
        else
        {
            scoreType = ScoringType.InProgress;
        }
        
        scoreStrategy = factory.GetStrategy(scoreType);

        
        
        return scoreStrategy.GetScore(playerOnePoints, playerTwoPoints);
    }
    
    

    private bool PlayerHasAdvantage()
    {
        return this.playerOnePoints >= 4 || this.playerTwoPoints >= 4;
    }

    private bool IsATie()
    {
        return this.playerOnePoints == this.playerTwoPoints;
    }
}

public class TennisScoreStrategyFactory
{
    public ITennisScoringStrategy GetStrategy(ScoringType scoreType)
    {
        if (scoreType == ScoringType.Advantage)
        {
            return new AdvantageStrategy();
        }

        if (scoreType == ScoringType.Tied)
        {
            return new InProgress();
        }

        if (scoreType == ScoringType.InProgress)
        {
            return new TiedStrategy();
        }
        
        throw new ArgumentOutOfRangeException(nameof(scoreType));
    }
}

public enum ScoringType
{
    Tied,
    Advantage, 
    InProgress
}