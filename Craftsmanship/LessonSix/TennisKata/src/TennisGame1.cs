namespace src;

using Strategies;

public class TennisGame1 : ITennisGame
{
    private string player1Name;
    private string player2Name;
    private int playerOnePoints;
    private int playerTwoPoints;

    public TennisGame1(string player1Name, string player2Name)
    {
        this.player1Name = player1Name;
        this.player2Name = player2Name;
    }

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
        var score = "";
        ITennisScoringStrategy scoreStrategy;


        if (this.IsATie()) // This is a tie
        {
            scoreStrategy = new TiedStrategy(this.playerOnePoints);
            score = scoreStrategy.GetScore();
        }
        else if (this.PlayerHasAdvantage())
        {
            scoreStrategy = new AdvantageStrategy(this.playerOnePoints, this.playerTwoPoints);
            score = scoreStrategy.GetScore();
        }
        else // InProgress
        {
            scoreStrategy = new InProgress(this.playerOnePoints, this.playerTwoPoints);
            score = scoreStrategy.GetScore();
        }

        return score;
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

public class InProgress(int playerOnePoints, int playerTwoPoints) : ITennisScoringStrategy
{
    public string GetScore()
    {
        var pointsToWin = new Dictionary<int, string>
        {
            { 0, "Love" },
            { 1, "Fifteen" },
            { 2, "Thirty" },
            { 3, "Forty" }
        };

        var player1Score = pointsToWin[playerOnePoints];
        var player2Score = pointsToWin[playerTwoPoints];
        return player1Score + "-" + player2Score;
    }
}