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

        if (this.IsATie())
        {
            scoreStrategy = new TiedStrategy(this.playerOnePoints);
        }
        else if (this.PlayerHasAdvantage())
        {
            scoreStrategy = new AdvantageStrategy(this.playerOnePoints, this.playerTwoPoints);
        }
        else
        {
            scoreStrategy = new InProgress(this.playerOnePoints, this.playerTwoPoints);
        }

        return scoreStrategy.GetScore();
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