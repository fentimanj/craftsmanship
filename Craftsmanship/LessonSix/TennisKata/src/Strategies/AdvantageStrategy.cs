namespace src.Strategies;

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