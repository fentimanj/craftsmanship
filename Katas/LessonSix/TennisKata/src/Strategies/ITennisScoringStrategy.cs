namespace src.Strategies;

public interface ITennisScoringStrategy
{
    string GetScore(int playerOneScore, int playerTwoScore);
}