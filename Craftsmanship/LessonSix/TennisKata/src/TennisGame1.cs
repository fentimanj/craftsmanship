namespace src;

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
            for (var playerIndex = 1; playerIndex <= 2; playerIndex++) //This goes around twice
            {
                var tempPoints = 0; //This looks wrong
                if (playerIndex == 1)
                {
                    tempPoints = this.playerOnePoints;
                }
                else
                {
                    score += "-";
                    tempPoints = this.playerTwoPoints;
                }

                switch (tempPoints)
                {
                    case 0:
                        score += "Love";
                        break;
                    case 1:
                        score += "Fifteen";
                        break;
                    case 2:
                        score += "Thirty";
                        break;
                    case 3:
                        score += "Forty";
                        break;
                }
            }
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

public interface ITennisScoringStrategy
{
    string GetScore();
}

public class TiedStrategy(int playerOnePoints) : ITennisScoringStrategy
{
    public string GetScore()
    {
        switch (playerOnePoints)
        {
            case 0:
                return "Love-All";
            case 1:
                return "Fifteen-All";
            case 2:
                return "Thirty-All";
            default:
                return "Deuce";
        }
    }
}

public class AdvantageStrategy(int playerOnePoints, int playerTwoPoints) : ITennisScoringStrategy
{
    public string GetScore()
    {
        var differenceInPoints = playerOnePoints - playerTwoPoints;
        if (differenceInPoints == 1)
        {
            return "Advantage player1";
        }

        if (differenceInPoints == -1)
        {
            return "Advantage player2";
        }

        if (differenceInPoints >= 2)
        {
            return "Win for player1";
        }

        return "Win for player2";
    }
}