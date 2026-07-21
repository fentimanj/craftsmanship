namespace src.Strategies;

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