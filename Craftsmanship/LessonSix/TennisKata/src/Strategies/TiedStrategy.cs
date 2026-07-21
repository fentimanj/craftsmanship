namespace src.Strategies;

public class TiedStrategy() : ITennisScoringStrategy
{
    public string GetScore(int playerOnePoints, int playerTwoPoints)
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