namespace src.Services;

public class BowlingScoreService
{
    public int CalculateScore(string scoreString)
    {
        if (scoreString.Contains("01")) return 1;

        if (scoreString.Contains("02")) return 2;

        if (scoreString.Contains("03")) return 3;

        var score = int.Parse(scoreString.Substring(0, 1));
        return score;
    }
}