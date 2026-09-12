namespace src.Strategies;

public class AdvantageStrategy() : ITennisScoringStrategy
{
    public string GetScore(int playerOnePoints, int playerTwoPoints)
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